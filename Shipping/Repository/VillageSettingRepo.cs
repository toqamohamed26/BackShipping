using Microsoft.EntityFrameworkCore;
using Shipping.Data;
using Shipping.Models;

namespace Shipping.Repository
{
    public class VillageSettingRepo : IVallageSetting
    {
        private ShippingContext _db;

        public VillageSettingRepo(ShippingContext db)
        {
            _db = db;
        }

        public List<VillageShipping> GetAllVillages()
        {
            return _db.VillageShippings.ToList();

        }

        public void Add(VillageShipping village_shipping)
        {
            _db.VillageShippings.Add(village_shipping);
            Save();
        }

        public VillageShipping GetById(string Id)
        {
            return _db.VillageShippings.FirstOrDefault(n => n.Id == Id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(string id, VillageShipping village_shipping)
        {
            var existingSetting = _db.VillageShippings.Find(id);

            if (existingSetting != null)

            {

                existingSetting.Value = village_shipping.Value;

                Save();
            }
            Save();
        }
    }
}
