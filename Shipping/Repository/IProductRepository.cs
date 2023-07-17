using Shipping.Models;

namespace Shipping.Repository

{
    public interface IProductRepository
    {
        bool AddRange(List<Product> products);
        bool DeleteRange(List<Product> products);
        List<Product> GetProductsByOrderId(string id);
    }
}
