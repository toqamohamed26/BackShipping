
using System.ComponentModel.DataAnnotations;

namespace Shipping.DTO
{


    public class UpdateSpecialViewModel
    {
        [Required]
        public double Price { get; set; }

        [Required]
        public string Id_city { get; set; }

        [Required]
        public string Id_Governate { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}
