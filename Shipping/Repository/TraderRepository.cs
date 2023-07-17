using Microsoft.EntityFrameworkCore;
using Shipping.DTO;
using Shipping.Models;
using Shipping.Data;

namespace Shipping.Repository
{
    public class TraderRepository : ITraderRepository
    {

        ShippingContext db;
        public TraderRepository(ShippingContext db)
        {
            this.db = db;
        }

        public void Add(Trader trader)
        {
            db.Traders.Add(trader);
            Save();
        }

      

        public List<GetAllTraderViewModel> GetAll()
        {
            return db.Traders.Include(x => x.city).Include(x => x.Governates).Include(x => x.branches)
                .Select(t => new GetAllTraderViewModel() { 
                  ID= t.Id,
                Name = t.UserName,
                Address = t.Address,
                Branch_Name = t.branches.Name,
                City_Name = t.city.Name,
                Governate_Name = t.Governates.Name,
                Email = t.Email,
                Per_Rejected_order = t.Per_Rejected_order,
                Phone = t.PhoneNumber,
                IsDeleted= t.IsDeleted,
                Id_Branch= t.Id_Branch,
                Id_Governate= t.Id_Governate,
                Id_City = t.Id_City,
                }).ToList();
        }

        public Trader GetById(string Id)
        {
            var res = db.Traders.Include(x => x.city).Include(x => x.Governates).Include(x => x.branches)
                .Where(t => t.Id == Id)
                .Select(t => new Trader
                {
                    UserName = t.UserName,
                    Address = t.Address,
                    Id = t.Id,
                    Email = t.Email,
                    Per_Rejected_order = t.Per_Rejected_order,
                    PhoneNumber = t.PhoneNumber,
                    IsDeleted = t.IsDeleted,
                    Id_Branch = t.Id_Branch,
                    Id_Governate = t.Id_Governate,
                    Id_City = t.Id_City,

                }).FirstOrDefault();
            return res;
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public void Update(string id, Trader trader)
        {

            var existingTrader = db.Traders.Find(trader.Id);

            if (existingTrader != null)

            {

                existingTrader.UserName = trader.UserName;

                existingTrader.Email = trader.Email;

                existingTrader.PhoneNumber = trader.PhoneNumber;
                existingTrader.Address = trader.Address;
                existingTrader.Id_Branch = trader.Id_Branch;
                existingTrader.Id_City = trader.Id_City;
                existingTrader.Id_Governate = trader.Id_Governate;
                existingTrader.Per_Rejected_order=trader.Per_Rejected_order;




                db.SaveChanges();

            }
        }


    }
}
