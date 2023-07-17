namespace Shipping.DTO
{
    public class Show_Order
    {

        public string Id { get; set; }
        public DateTime Date_Adding { get; set; }
        public string Name_customer { get; set; }
        public string Phone_Customer { get; set; }
        public string  City{ get; set; }
        public string  Governate{ get; set; }
        public double Total_shipping { get; set; }
        public string ?Stauts_of_Shipping { get; set; }

    }
}
