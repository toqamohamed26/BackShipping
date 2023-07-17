using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Models
{

    [PrimaryKey(nameof(Id_employee), nameof(Id_Order))]
    public class Employee_Order
    {
        [ForeignKey(nameof(employee))]

        public string Id_employee { get; set; }

        [ForeignKey(nameof(Order))]
        public string Id_Order { get; set; }
        public virtual Order? order { get; set; }
        public virtual Employee? employee { get; set; }
    }

}