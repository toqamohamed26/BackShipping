using Shipping.DTO;
using Shipping.Models;

namespace Shipping.Repository
{
    public interface IWeight_Setting
    {
        List<Setting_Weight> GetAllWeights();

        Setting_Weight GetById(string Id);
        void Add(Setting_Weight setting_weight);
        void Update(string id, Setting_Weight setting_seight);
        void Save();
    }
}
