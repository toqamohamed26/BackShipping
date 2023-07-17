using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shipping.DTO;
using Shipping.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shipping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
            )
        {
            _config = configuration;
            _userManager = userManager;
            _signInManager = signInManager;

        }

        #region Login
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDto credentials)
        {
            var user = await _userManager.FindByEmailAsync(credentials.UserName);
            if (user == null)
            {
                return Unauthorized();
            }

            var isAuthenticated = await _userManager.CheckPasswordAsync(user, credentials.Password);
            if (!isAuthenticated)
            {
                return Unauthorized();
            }

            var claimsList = await _userManager.GetClaimsAsync(user);

            #region Secret Key
            var secretKeyString = _config.GetValue<string>("SecretKey");
            var secretyKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString ?? string.Empty);
            var secretKey = new SymmetricSecurityKey(secretyKeyInBytes);
            #endregion

            #region Create a combination of secretKey, Algorithm
            var signingCredentials = new SigningCredentials(secretKey,
                SecurityAlgorithms.HmacSha256Signature);
            #endregion

            #region Putting all together

            var expiryDate = DateTime.Now.AddDays(1);
            var token = new JwtSecurityToken(
                claims: claimsList,
                expires: expiryDate,
                signingCredentials: signingCredentials);

            #endregion

            #region Convert Token Object To String

            var tokenHndler = new JwtSecurityTokenHandler();
            var tokenString = tokenHndler.WriteToken(token);

            #endregion

            return new TokenDto(tokenString, expiryDate);
        }

        #endregion

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return Ok(new { message = "Logged out successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
    }
