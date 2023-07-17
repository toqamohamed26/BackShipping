using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shipping.DTO;
using Shipping.Models;
using Shipping.Repository;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Shipping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraderController : ControllerBase
    {
        public readonly ITraderRepository _traderRepository;
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        public TraderController(ITraderRepository traderRepository, IConfiguration configuration,
            UserManager<ApplicationUser> userManager
            )
        {
            _traderRepository = traderRepository;
            _userManager = userManager;
            _config = configuration;
        }

        [HttpGet]
        public  ActionResult GetAll()
        {
           return Ok( _traderRepository.GetAll());
        }

        [HttpGet("id")]
        public ActionResult GetById(string id)
        {
            var res = _traderRepository.GetById(id);
       
            return Ok(res);
        }
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> Add(TraderViewModel trader)
        {
            if (trader != null)
            {
                ApplicationUser trade = new Trader()
                {
                    Address = trader.Address,
                    Email = trader.Email,
                    Id_Branch = trader.Id_Branch,
                    Id_City = trader.Id_City,
                    UserName = trader.Name,
                    Per_Rejected_order = trader.Per_Rejected_order,
                    PhoneNumber = trader.Phone,
                    Id_Governate = trader.Id_Governate,
                    IsDeleted = false,
                };
                var result = await _userManager.CreateAsync(trade, trader.Password);
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, trade.Id),
            new Claim(ClaimTypes.Name, trade.UserName),
            new Claim(ClaimTypes.Role, "Trader"),
        };
                await _userManager.AddClaimsAsync(trade, claims);
            }
            return Ok();
        }



        [HttpPut("{id}")]
        public ActionResult Update(string id, UpdateTraderViewModel model)
        {
            if (id != null)
            {
                var trader = _traderRepository.GetById(id);
                if (trader != null)
                {
                    trader.Per_Rejected_order = model.Per_Rejected_order ?? trader.Per_Rejected_order;
                    trader.Address = model.Address ?? trader.Address;
                    trader.Email = model.Email ?? trader.Email;
                    trader.Id_City = model.Id_City ?? trader.Id_City;
                    trader.UserName = model.Name ?? trader.UserName;
                    trader.PhoneNumber = model.Phone ?? trader.PhoneNumber;
                    trader.Id_Branch = model.Id_Branch ?? trader.Id_Branch;
                    trader.Id_Governate = model.Id_Governate ?? trader.Id_Governate;
                    trader.IsDeleted = false;
                    _traderRepository.Update(id, trader); // use the id parameter here
                    return Created("Updated", trader);
                }
            }
            return NotFound();
        
    }
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var traderbyid = _traderRepository.GetById(id);
            if (traderbyid != null)
            {
                traderbyid.IsDeleted = true;
                _traderRepository.Update(id,traderbyid); 
               _traderRepository.Save();// set IsDeleted property to true
                return Ok(traderbyid); // return the updated entity
            }

            return NotFound();
        }



    }
}
