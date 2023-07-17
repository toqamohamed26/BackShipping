using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shipping.DTO;
using Shipping.Models;
using Shipping.Repository;
using System.Security.Claims;

namespace Shipping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeRepository employeeRepository;
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        public EmployeeController(IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
             IEmployeeRepository employeeRepository)
        {
            _userManager = userManager;
            _config = configuration;
            this.employeeRepository = employeeRepository;

        }
        #region Register

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(RegisterDtoEmployee registerDto)
        {
            ApplicationUser employee = new Employee
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.Phone,
                Address = registerDto.Address,
                Id_Branch = registerDto.Branch,

            };

            var result = await _userManager.CreateAsync(employee, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, employee.Id),
            new Claim(ClaimTypes.Name, employee.UserName),
            new Claim(ClaimTypes.Role, "Employee"),
        };
            await _userManager.AddClaimsAsync(employee, claims);

            return Ok();
        }

        #endregion


        #region GetAll

        [HttpGet]
        public ActionResult getAllEmployee()
        {
            List<GetAllEmployee> sd = new List<GetAllEmployee>();
            foreach (var item in employeeRepository.getall())
            {
                GetAllEmployee d = new GetAllEmployee();

                d.Id = item.Id;
                d.userName = item.UserName;
                d.Phone = item.PhoneNumber;
                d.Email = item.Email;
                d.Address = item.Address;
                d.Branch = item.branches.Name;


                sd.Add(d);
            }
            return Ok(sd);

        }
        #endregion

        #region Update

        [HttpPut]
        [Route("Update/{id}")]
        public ActionResult UpdateEmployee(string id, UpdateEmployeeDTO DTO)
        {
            if (DTO.Id == id)
            {
                var res = new Employee()
                {
                    Id = DTO.Id,
                    UserName = DTO.UserName,
                    Email= DTO.Email,
                    Address = DTO.Address,
                    PhoneNumber = DTO.Phone,
                    Id_Branch = DTO.Branch,
                };
                if (res != null)
                {
                   


                    employeeRepository.update(res);

                    return Ok();
                }
            }

            return BadRequest();

        }

        #endregion


        #region Get BY ID

        [HttpGet]
        [Route("getById/{id}")]
        public ActionResult getById(string id)
        {
            var rep = employeeRepository.getbyid(id);
            if (rep == null)
            { return BadRequest(); }

                GetAllEmployee d = new GetAllEmployee();

                d.Id = rep.Id;
                d.userName = rep.UserName;
                d.Phone = rep.PhoneNumber;
                d.Email = rep.Email;
                d.Address = rep.Address;
                d.Branch = rep.branches.Id;



            return Ok(d);

        }
        #endregion


        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            employeeRepository.delete(id);
            return Ok();

        }

    }
}
