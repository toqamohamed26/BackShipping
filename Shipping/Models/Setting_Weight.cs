using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Models
{
    public class Setting_Weight
    {
        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public Setting_Weight()
        {
            Id = GenerateUniqueId();
        }
        [Key]

        public string Id { get; set; }
        public double weight_shipping { get; set; }
        public double Extra_weight { get; set; }
        public ICollection<Order>? order { get; set; }

    }
}
