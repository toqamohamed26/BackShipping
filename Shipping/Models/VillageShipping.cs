using System.ComponentModel.DataAnnotations;

namespace Shipping.Models
{
    public class VillageShipping
    {
        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public VillageShipping()
        {
            Id = GenerateUniqueId();
        }
        [Key]
        public string Id { get; set; }
        public double Value { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
