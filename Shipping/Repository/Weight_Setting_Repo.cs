using Microsoft.EntityFrameworkCore;
using Shipping.Data;
using Shipping.Models;

namespace Shipping.Repository
{
    public class Weight_Setting_Repo : IWeight_Setting
    {
        private ShippingContext _db;
        public Weight_Setting_Repo(ShippingContext db )
        {
            _db = db;
        }
        

        public List<Setting_Weight> GetAllWeights()
        {
            return _db.Setting_Weights.ToList();

        }
        public void Add(Setting_Weight setting_weight)
        {
            _db.Setting_Weights.Add( setting_weight );
            Save();
        }

        public Setting_Weight GetById(string Id)
        {
           return _db.Setting_Weights.FirstOrDefault(n => n.Id == Id);

        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(string id, Setting_Weight setting_seight)
        {
            var existingSetting = _db.Setting_Weights.Find(id);

            if (existingSetting != null)

            {

                existingSetting.weight_shipping = setting_seight.weight_shipping;


                existingSetting.Extra_weight = setting_seight.Extra_weight;


                
                Save();
            }
        }
    }
}
