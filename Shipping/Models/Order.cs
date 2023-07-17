using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Models
{

    public enum OrderStatus
    {
        New,
        Pending,
        RepresentitiveDelivered,
        ClientDelivered,
        UnReachable,
        Postponed,
        PartiallyDelivered,
        ClientCanceled,
        RejectWithPaying,
        RejectWithPartialPaying,
        RejectFromEmployee,
    }
    public enum PaymentType
    {
        payOnDelivery,
        prepaid,
        packageForAPackage
    }


    public class Order
    {
        public PaymentType PaymentType { get; set; } = 0;
        public OrderStatus orderStatus { get; set; }


        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public Order()
        {
            Id_Order = GenerateUniqueId();
        }
        [Key]
        public string Id_Order { get; set; }
        public string Client_Name { get; set; }
        public string Address { get; set; }
        public string FirstPhoneNumber { get; set; } = string.Empty;
        public string? SecondPhoneNumber { get; set; }
        public string Email { get; set; }

        [ForeignKey(nameof(Governates))]
        public string? Id_Governate { get; set; }
        public virtual Governates? Governates { get; set; }


        [ForeignKey(nameof(city))]
        public string? Id_City { get; set; }
        public virtual Cities? city { get; set; }

        [ForeignKey(nameof(branches))]
        public string? Id_Branch { get; set; }
        public virtual Branches? branches { get; set; }
        public string Village_Name { get; set; }
        public bool flag_of_villagee { get; set; } 
        public virtual ICollection<Product> product { get; set; }

        [ForeignKey(nameof(Representive))]
        public string? Id_representive { get; set; }
        public virtual Representive? Representives { get; set; }

        [ForeignKey(nameof(Trader))]
        public string? Id_Trader { get; set; }
        public virtual Trader? Trader { get; set; }
        public string Notes { get; set; }
        public double Total_weight { get; set; }
        public double OrderShippingTotalCost { get; set; }
        public double ProductTotalCost { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("Type_Of_Shipping")]
        public string ShippingTypeId { get; set; }
        public virtual Setting_shipping? ShippingType { get; set; }

    }
}
