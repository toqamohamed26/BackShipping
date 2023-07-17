using Microsoft.EntityFrameworkCore;
using Shipping.Data;
using Shipping.Models;

namespace Shipping.Repository
{
    public class Shipping_Setting_Repo : IShipping_Setting
    {
        private ShippingContext _db;
        public Shipping_Setting_Repo(ShippingContext db)
        {
            _db = db;
        }
        public void Add(Setting_shipping setting_shipping)
        {
            _db.Setting_shippings.Add(setting_shipping);
            Save();
        }

        public List<Setting_shipping> GetAll()
        {
            return _db.Setting_shippings.ToList();

        }

        public Setting_shipping GetById(string Id)
        {
            return _db.Setting_shippings.FirstOrDefault(n => n.Id == Id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(string id, Setting_shipping setting_shipping)
        {
            var existingSetting = _db.Setting_shippings.Where(n => n.Id == id).FirstOrDefault();
            if (existingSetting != null)
            {
                existingSetting.Name_Of_Shipping = setting_shipping.Name_Of_Shipping;
                existingSetting.Number_Of_Days = setting_shipping.Number_Of_Days;
                existingSetting.Value_Of_shipping = setting_shipping.Value_Of_shipping;
                Save();
            }
        }
        public void Delete( string id)
        {
            var element=GetById(id);
            if (element != null)
            {
                _db.Setting_shippings.Remove(element);
                Save();
            }
        }
    }
}
