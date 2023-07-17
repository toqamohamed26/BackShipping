using Shipping.Models;

namespace Shipping.Repository
{
    public interface IShipping_Setting
    {
        List<Setting_shipping> GetAll();
        Setting_shipping GetById(string Id);
        void Add(Setting_shipping setting_shipping);
        void Update(string id, Setting_shipping setting_shipping);
        void Delete(string id);
        void Save();
    }
}
