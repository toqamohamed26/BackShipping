using Microsoft.EntityFrameworkCore;
using Shipping.Data;
using Shipping.Models;

namespace Shipping.Repository
{
    public class RepresentiveRepository : IRepresentiveRepository
    {
        ShippingContext context;

        public RepresentiveRepository(ShippingContext context)
        {
            this.context = context;
        }


        public void delete(string id)
        {
            var representive = context.Representives.FirstOrDefault(e => e.Id == id);
            representive.IsDeleted = true;
            update(representive);


        }

        public List<Representive> getall()
        {
            var res= context.Representives.Where(e => e.IsDeleted == false).Include(e=>e.branches).Include(e=>e.Governates).ToList();
            return res;
            //
        }


        public Representive getbyid(string id)
        {
            return context.Representives.Where(s=>s.Id == id).Include(n=>n.Governates).Include(n => n.branches).FirstOrDefault();
        }

   
        public void update(Representive s)
        {
            
            context.Entry(s).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
