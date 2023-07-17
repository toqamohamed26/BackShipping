using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Models
{
    public class Special_Price_Trader
    {
        [Key]

        public string ID { get; set; }
        public double Price { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey(nameof(trader))]
        public string?Id_Trader { get; set; }
        public virtual Trader? trader { get; set; }
        [ForeignKey(nameof(city))]
        public string Id_city { get; set; }
        public virtual Cities? city { get; set; }
        [ForeignKey(nameof(Governates))]
        public string Id_Governate { get; set; }
        public virtual Governates? Governates { get; set; }

    }
}
