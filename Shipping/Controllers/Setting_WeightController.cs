using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.DTO.Weight_Setting;
using Shipping.Models;
using Shipping.Repository;

namespace Shipping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Setting_WeightController : ControllerBase
    {
        private IWeight_Setting _setting;

        public Setting_WeightController(IWeight_Setting weight_Setting)
        {
            _setting = weight_Setting;
        }

        [HttpPost]

        public ActionResult AddSetting(Add_weight_Setting_DTO add_weight_Setting_DTO)
        {

            if (add_weight_Setting_DTO != null)
            {
                var data = new Setting_Weight()
                {
                    weight_shipping = add_weight_Setting_DTO.weight_shipping ,
                    Extra_weight = add_weight_Setting_DTO.Extra_weight
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
        public ActionResult UpdateSetting(string id, Add_weight_Setting_DTO add_weight_Setting_DTO)
        {

            if (add_weight_Setting_DTO != null)
            {
                var data = new Setting_Weight()
                {
                    weight_shipping = add_weight_Setting_DTO.weight_shipping,
                    Extra_weight = add_weight_Setting_DTO.Extra_weight

                };
                _setting.Update(id, data);
                return Created("", data);

            }
            return BadRequest();
        }
        [HttpGet]
        public ActionResult getall()
        {
            return Ok(_setting.GetAllWeights());
        }


    }
}
