using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Models
{
    public class Product
    {
        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public Product()
        {
            Id = GenerateUniqueId();
        }

        [Key]

        public string Id { get; set; }
        public string Name { get; set; }
        public double weight { get; set; }
        public double Price { get; set; }

        public int Quantity { get; set; }
        [ForeignKey(nameof(order))]
        public string? Id_Order { get; set; }
        public virtual Order? order { get; set; }
    }
}
