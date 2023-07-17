using System.ComponentModel.DataAnnotations;

namespace Shipping.DTO
{
    public class AddSpecialViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Id_city { get; set; }

        [Required]
        public string Id_Governate { get; set; }

       
    }
}
