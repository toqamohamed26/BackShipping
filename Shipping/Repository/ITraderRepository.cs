using Shipping.DTO;
using Shipping.Data;
using Shipping.Models;
namespace Shipping.Repository
{
    public interface ITraderRepository
    {
        List<GetAllTraderViewModel> GetAll();
        Trader GetById(string Id);
        void Add(Trader trader);
        void Update(string id, Trader trader);
       // void Delete(string Id);
        void Save();
    }
}
