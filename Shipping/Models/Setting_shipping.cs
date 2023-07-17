using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Models
{
    public class Setting_shipping
    {
        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public Setting_shipping()
        {
            Id = GenerateUniqueId();
        }
        [Key]
        public string Id { get; set; }
        public string Name_Of_Shipping { get; set; }
        public int Value_Of_shipping { get; set; }
        public int Number_Of_Days { get; set; } = 0;

        public ICollection<Order> orders { get; set; }
    }
}
