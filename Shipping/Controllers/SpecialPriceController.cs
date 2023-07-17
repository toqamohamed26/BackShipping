using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.DTO;
using Shipping.Models;
using Shipping.Repository;

namespace Shipping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialPriceController : ControllerBase
    {
        public  ISpecialPriceRepository _specialPriceRepo { get; set; }
        public SpecialPriceController(ISpecialPriceRepository specialPriceRepository)
        {
            _specialPriceRepo = specialPriceRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var spList = _specialPriceRepo.GetAll();

            return Ok(spList);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var sp = _specialPriceRepo.GetById(id);

            if (sp == null)
            {
                return NotFound();
            }

            return Ok(sp);
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddSpecialViewModel sp)
        {
            if (ModelState.IsValid)
            {
                // Map the view model to a new Special_Price_Trader object
                var newSpecialPriceTrader = new Special_Price_Trader
                {
                    ID= sp.Id,
                    Price = sp.Price,
                    Id_city = sp.Id_city,
                    Id_Governate = sp.Id_Governate,
                };

                _specialPriceRepo.Add(newSpecialPriceTrader);

                return Created("", newSpecialPriceTrader);
            }

            return BadRequest();
        }





        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] UpdateSpecialViewModel sp)
        {
            _specialPriceRepo.Update(id, sp);

            return NoContent();
        }




        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var sp = _specialPriceRepo.GetById(id);

            if (sp == null)
            {
                return NotFound();
            }

            _specialPriceRepo.Delete(id);

            return NoContent();
        }


    }
}
