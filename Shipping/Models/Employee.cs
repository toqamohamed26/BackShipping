using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Models
{
    public class Employee:ApplicationUser
    {

        [ForeignKey(nameof(branches))]
        public string Id_Branch { get; set; }
        public virtual Branches? branches { get; set; }
        public virtual ICollection<Employee_Order> Employee_Order { get; set; }


    }
}
