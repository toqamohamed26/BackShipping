namespace Shipping.DTO
{
    public class ProductDto
    {
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
    }
}
