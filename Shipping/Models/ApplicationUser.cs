using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        public string Address { get; set; }
        public bool IsDeleted { get; set; } = false ;

    }
}




