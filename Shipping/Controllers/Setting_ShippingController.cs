using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.DTO.Shipping_Setting;
using Shipping.Models;
using Shipping.Repository;

namespace Shipping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Setting_ShippingController : ControllerBase
    {
        private IShipping_Setting _setting;
        
        public Setting_ShippingController(IShipping_Setting shipping_Setting) { 
            _setting = shipping_Setting;
        }
        [HttpGet]
        public ActionResult GetSetting() { 

            return Ok(_setting.GetAll());
        }
        [HttpPost]

        public ActionResult AddSetting(Add_Shipping_Setting_DTO add_Shipping_Setting_DTO)
        {

            if (add_Shipping_Setting_DTO != null)
            {
                var data = new Setting_shipping()
                {
                    Name_Of_Shipping = add_Shipping_Setting_DTO.Name,
                    Value_Of_shipping = add_Shipping_Setting_DTO.Value,
                    Number_Of_Days = add_Shipping_Setting_DTO.Number_Of_Day

                };
                _setting.Add(data);
                return Created("", data);
            }
            return BadRequest();
        }
        [HttpGet("{id}")]
        public ActionResult GetSetting(string id)
        {

            if (id != null)
            {
                return Ok(_setting.GetById(id));

            }
            return NotFound();

        }
        [HttpPut("{id}")]
        public ActionResult UpdateSetting(string id , Add_Shipping_Setting_DTO add_Shipping_Setting_DTO) 
        {

            if (add_Shipping_Setting_DTO != null)
            {
                var data = new Setting_shipping()
                {
                    Name_Of_Shipping = add_Shipping_Setting_DTO.Name,
                    Value_Of_shipping = add_Shipping_Setting_DTO.Value,
                    Number_Of_Days = add_Shipping_Setting_DTO.Number_Of_Day

                };
                _setting.Update(id,data);
                return Created("", data);

            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteSetting(string id)
        {
            if (id != null)
            {
                _setting.Delete(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
