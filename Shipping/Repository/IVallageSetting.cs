using Shipping.Models;

namespace Shipping.Repository
{
    public interface IVallageSetting
    {
        List<VillageShipping> GetAllVillages ();
        VillageShipping GetById(string Id);
        void Add(VillageShipping village_shipping);
        void Update(string id, VillageShipping village_shipping);
        void Save();
    }
}
