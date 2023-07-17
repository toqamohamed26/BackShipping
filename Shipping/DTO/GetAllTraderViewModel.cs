using Shipping.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.DTO
{
    public class GetAllTraderViewModel
    {
        public string ID { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double? Per_Rejected_order { get; set; }
        public bool? IsDeleted { get; set; }
        public string City_Name { get; set; }
        public string Branch_Name { get; set; }
        public string Governate_Name { get; set; }

        public string Id_City { get; set; }
    
        public string Id_Branch { get; set; }
        
        public string Id_Governate { get; set; }
    }
}
