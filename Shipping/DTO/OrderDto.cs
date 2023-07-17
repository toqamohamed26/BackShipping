using Shipping.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.DTO
{
    public record AddOrderDto
    {
        [Required(ErrorMessage = "TraderId is required.")]
        public string TraderId { get; set; } = string.Empty;  

        [Required(ErrorMessage = "Payment Type is required.")]
        [Range(0, 2)]
        public PaymentType PaymentType { get; set; }


        [Required(ErrorMessage = "Client name is required.")]
        public string ClientName { get; set; } = string.Empty;

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone Number is required.")]
        public string FirstPhoneNumber { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string SecondPhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;


        [Required(ErrorMessage = "Governorate is required.")]
        public string GovernorateId { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string CityId { get; set; }

        [Required(ErrorMessage = "Street is required.")]
        public string Street { get; set; } = string.Empty;
        public bool DeliverToVillage { get; set; }

        [Required(ErrorMessage = "Shipping Type is required.")]
        public string ShippingTypeId { get; set; }

        [Required(ErrorMessage = "Branch is required.")]
        public string BranchId { get; set; }

        public string? Notes { get; set; }

        [Required(ErrorMessage = "Enter at least one Product.")]
        public List<ProductDto> Products { get; set; }
    }
    public record AddOrderResultDto(bool IsSuccesfull, double? ProductTotalCost, double? OrderShippingTotalCost, double? totalWeight);


    public record UpdateOrderDto
    {
        [Required(ErrorMessage = "Order Id is required.")]
        public string Id { get; set; }


        [Required(ErrorMessage = "TraderId is required.")]
        public string TraderId { get; set; } = string.Empty;

        [Required(ErrorMessage = "ClientName is required.")]

        public string ClientName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;


        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone Number is required.")]
        public string FirstPhoneNumber { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string SecondPhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = "Governorate is required.")]
        public string GovernorateId { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string CityId { get; set; }

        [Required(ErrorMessage = "Street is required.")]
        public string Street { get; set; } = string.Empty;
        public bool DeliverToVillage { get; set; } = false;

        [Required(ErrorMessage = "Shipping Type is required.")]
        public string ShippingTypeId { get; set; }

        [Required(ErrorMessage = "Payment Type is required.")]
        [Range(0, 2)]
        public PaymentType PaymentType { get; set; }

        [Required(ErrorMessage = "Branch is required.")]
        public string BranchId { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public OrderStatus orderStatus { get; set; }

        public string? Notes { get; set; }

        [Required(ErrorMessage = "Enter at least one Product.")]
        public List<ProductDto> Products { get; set; }
        [NotMapped]
        public string ? Stauts_of_Shipping { get; set; }
    }

    public record UpdateOrderResultDto(bool IsSuccesfull, double? ProductTotalCost, double? OrderShippingTotalCost, double? totalWeight);

    public record ReadOrderDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public string Governorate { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public double Cost { get; set; }
        public OrderStatus orderStatus { get; set; }
    }

}
