namespace Shipping.DTO
{
    public class UpdateTraderViewModel
    {
        public string Id { get; set; }  
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double? Per_Rejected_order { get; set; }

        public string Id_City { get; set; }

        public string Id_Branch { get; set; }

        public string Id_Governate { get; set; }
    }
}
