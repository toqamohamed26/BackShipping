namespace Shipping.DTO
{
    public class Report_Order
    {

        public string Id { get; set; }
        public string Status_Order { get; set; }
        public string Name_Trader { get; set; }
        public string Name_Client { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Governate { get; set; }
        public double Cost_Order { get; set; }
       // public double? Recieved_Money { get; set; }
        public double Cost_Shipping { get; set; }

        //public double? Cost_Shipping_Paid { get; set; }
        //public double? Value_Company { get; set; }
        public DateTime Date { get; set; }

    }
}
