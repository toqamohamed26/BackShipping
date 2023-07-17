using Shipping.DTO;
using Shipping.Models;

namespace Shipping.Repository
{
    public interface IOrderRepository
    {
        AddOrderResultDto Add(AddOrderDto order);

        UpdateOrderResultDto Update(UpdateOrderDto order);

        UpdateOrderDto GetById(string orderId);

        Order GetData(string id);
        List<Order> GetAll();
        List<Order> GetAllFilter(string id);

        List<int> EmpCount();
        List<int> TraderCount(string traderId);
        IEnumerable<string> GetAllStatusOrders();
        List<Show_Order> GetOrdersByStatus(OrderStatus status);
        List<Show_Order> GetOrdersByStatusForTrader(OrderStatus status, string traderId);

        List<Order> GetOrdersByDateRange(DateTime fromDate, DateTime toDate);
        void update_status(string id, OrderStatus orderstatus);
        void DeleteOrder(string id);
    }
}
