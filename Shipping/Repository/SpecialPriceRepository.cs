using Microsoft.EntityFrameworkCore;
using Shipping.DTO;
using Shipping.Models;
using Shipping.Data;

namespace Shipping.Repository
{

    public class SpecialPriceRepository : ISpecialPriceRepository
    {

        ShippingContext db;
        public SpecialPriceRepository(ShippingContext db)
        {
            this.db = db;
        }
        public void Add(Special_Price_Trader sp)
        {
            db.Special_Price_Traders.Add(sp);
            Save();
        }

        public void Delete(string Id)
        {
            GetById(Id).IsDeleted = true;
            Save();
        }

        public List<Special_Price_Trader> GetAll()
        {
            return db.Special_Price_Traders.Include(x => x.Governates).Include(x => x.city)
                .Include(t=>t.trader).Where(x=>x.IsDeleted==false)
               .Select(t => new Special_Price_Trader
               {
                   ID = t.ID,
                   Price = t.Price,
                   // include the name of the city and governate
                   Id_city = t.city.Name,
                   Id_Governate = t.Governates.Name,
                   Id_Trader= t.trader.UserName,
                   IsDeleted= t.IsDeleted
               }).ToList();
        }

        public Special_Price_Trader GetById(string Id)
        {
            return db.Special_Price_Traders.FirstOrDefault(n => n.ID == Id);

        }

        public void Save()
        {
            db.SaveChanges();
        }








        public void Update(string id, UpdateSpecialViewModel sp)
        {
            var entity = db.Special_Price_Traders.FirstOrDefault(x => x.ID == id);

            if (entity != null)
            {
                entity.Price = sp.Price;
                entity.Id_city = sp.Id_city;
                entity.Id_Governate = sp.Id_Governate;
                entity.IsDeleted = sp.IsDeleted;

                Save();
            }
        }
    }
}
