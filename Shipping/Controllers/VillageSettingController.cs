using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.DTO.Shipping_Setting;
using Shipping.DTO.VillageSetting;
using Shipping.Models;
using Shipping.Repository;

namespace Shipping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillageSettingController : ControllerBase
    {
        private IVallageSetting _setting;

        public VillageSettingController(IVallageSetting shipping_Setting)
        {
            _setting = shipping_Setting;
        }
        [HttpPost]

        public ActionResult AddSetting(AddVillageSettingDTO addvillagesetting)
        {

            if (addvillagesetting != null)
            {
                var data = new VillageShipping()
                {
                    
                    Value = addvillagesetting.value,
                    

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
        public ActionResult UpdateSetting(string id, AddVillageSettingDTO addvillagesetting)
        {

            if (addvillagesetting != null)
            {
                var data = new VillageShipping()
                {
                    Id=addvillagesetting.Id,
                    Value=addvillagesetting.value

                };
                _setting.Update(id, data);
                return Created("", data);

            }
            return BadRequest();
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_setting.GetAllVillages());
        }

    }
}
