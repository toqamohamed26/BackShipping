using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Models
{
    public class Trader : ApplicationUser
    {

        public double Per_Rejected_order { get; set; }

        [ForeignKey(nameof(city))]
        public string Id_City { get; set; }

        public virtual Cities? city { get; set; }

        [ForeignKey(nameof(branches))]
        public string Id_Branch { get; set; }
        public virtual Branches? branches { get; set; }

        [ForeignKey(nameof(Governates))]
        public string Id_Governate { get; set; }
        public virtual Governates? Governates { get; set; }





    }
}
