
using Microsoft.EntityFrameworkCore;
using Shipping.Data;
using Shipping.DTO;
using Shipping.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Shipping.Repository

{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShippingContext context;
        private readonly IProductRepository productRepo;
        private readonly IVallageSetting vallageRepo;
        private readonly IWeight_Setting weightRepo;
        private readonly IShipping_Setting shipping_Setting;
        private readonly ISpecialPriceRepository specialPriceRepository;
        private readonly ICities cityRepo;



        public OrderRepository(ShippingContext context ,IProductRepository productRepo ,IVallageSetting vallageRepo ,IWeight_Setting weightRepo,
            ISpecialPriceRepository specialPriceRepository,
            IShipping_Setting shipping_Setting,
            ICities cityRepo)
        {
            this.context = context;
            this.productRepo = productRepo;
            this.vallageRepo = vallageRepo;
            this.weightRepo = weightRepo;
            this.shipping_Setting = shipping_Setting;
            this.specialPriceRepository= specialPriceRepository;
            this.cityRepo=cityRepo;
        }


        public AddOrderResultDto Add(AddOrderDto orderDto )
        {

            double costDeliverToVillage =  Cost_DeliverToVillage(orderDto.DeliverToVillage);

            double countWeight = CountWeight(orderDto.Products);

            double costAllProducts = Cost_AllProducts(orderDto.Products);

            double costAddititonalWeight = Cost_AdditionalWeight(countWeight);

            double costShippingType = Cost_ShippingType(orderDto.ShippingTypeId);

            double cityShippingPrice = (double) GetSpecialPricesWithTraderandCityId(orderDto.TraderId, orderDto.CityId);
            if (cityShippingPrice == 0)
            {
                cityShippingPrice =  CityShippingPrice(orderDto.CityId);
            }

            Order order = new Order()
            {
                Id_Trader = orderDto.TraderId,
                Client_Name = orderDto.ClientName,
                FirstPhoneNumber = orderDto.FirstPhoneNumber,
                SecondPhoneNumber = orderDto.SecondPhoneNumber,
                Email = orderDto.Email,
                Address = orderDto.Address,
                Village_Name = orderDto.Street,
                Id_Governate = orderDto.GovernorateId,
                Id_City = orderDto.CityId,
                flag_of_villagee = orderDto.DeliverToVillage,
                ShippingTypeId = orderDto.ShippingTypeId,
                PaymentType = orderDto.PaymentType,
                Id_Branch = orderDto.BranchId,
                orderStatus = OrderStatus.New,
                Date = DateTime.Now,
                Notes = orderDto.Notes,
                IsDeleted = false,
                ProductTotalCost = costAllProducts,
                OrderShippingTotalCost = costDeliverToVillage + costAddititonalWeight + cityShippingPrice + costShippingType,
                Total_weight = countWeight,
                product = orderDto.Products.Select(prod => new Product
                {
                    Name = prod.Name,
                    Quantity = prod.Quantity,
                    Price = prod.Price,
                    weight = prod.Weight,
                }).ToList(),
            };

            bool isSuccesfullOrder;
                try
                {
                context.Orders.Add(order);
                isSuccesfullOrder = true;
                }
                catch (Exception ex)
                {
                isSuccesfullOrder = false;
            }

            bool isSuccesfullProduct;

            try
            {
                productRepo.AddRange(order.product.ToList());
                isSuccesfullProduct = true;

            }
            catch (Exception ex) {
                isSuccesfullProduct = false;
            }

            if (isSuccesfullOrder && isSuccesfullProduct)
            {
                bool isSaved;

                try
                {
                    context.SaveChanges();
                    isSaved = true;

                }
                catch (Exception ex)
                {
                    isSaved = false;
                }
                
                if (isSaved)
                {
                    double shippingTotalCost = costDeliverToVillage + costAddititonalWeight + cityShippingPrice + costShippingType;

                    return new AddOrderResultDto(true, costAllProducts, shippingTotalCost, countWeight);
                }
            }
            return new AddOrderResultDto(false, null, null, null);

        }


        public UpdateOrderDto GetById(string orderId)
        {
            var order = context.Orders.Where(e=>e.Id_Order==orderId).Include(n => n.product).FirstOrDefault();
            if (order != null)
            {
                UpdateOrderDto result = new UpdateOrderDto()
                {
                    Id = order.Id_Order,
                    TraderId = order.Id_Trader,
                    PaymentType = order.PaymentType,
                    Email = order.Email,
                    BranchId = order.Id_Branch,
                    CityId = order.Id_City,
                    Address = order.Address,
                    DeliverToVillage = order.flag_of_villagee ,
                    FirstPhoneNumber = order.FirstPhoneNumber,
                    SecondPhoneNumber = order.SecondPhoneNumber,
                    GovernorateId = order.Id_Governate,
                    Notes = order.Notes,
                    ShippingTypeId = order.ShippingTypeId,
                    Street = order.Village_Name,
                    orderStatus=order.orderStatus,
                    ClientName = order.Client_Name,
                    Stauts_of_Shipping = order.orderStatus.ToString(),
                    Products = order.product.Select(prod => new ProductDto
                    {
                        Name = prod.Name,
                        Quantity = prod.Quantity,
                        Price = prod.Price,
                        Weight = prod.weight,
                    }).ToList()
                };
                return result;
            }

            return null;
        }


        public UpdateOrderResultDto Update(UpdateOrderDto newOrder)
        {
            double costDeliverToVillage = Cost_DeliverToVillage(newOrder.DeliverToVillage);

            double countWeight = CountWeight(newOrder.Products);

            double costAllProducts = Cost_AllProducts(newOrder.Products);

            double costAddititonalWeight =  Cost_AdditionalWeight(countWeight);

            double costShippingType =  Cost_ShippingType(newOrder.ShippingTypeId);

            double cityShippingPrice = (double) GetSpecialPricesWithTraderandCityId(newOrder.TraderId, newOrder.CityId);
            if (cityShippingPrice == 0)
            {
                cityShippingPrice =  CityShippingPrice(newOrder.CityId);
            }


            var oldOrder = context.Orders.FirstOrDefault(e => e.Id_Order == newOrder.Id);


            if (oldOrder != null)
            {
                oldOrder.Client_Name = newOrder.ClientName;
                oldOrder.FirstPhoneNumber = newOrder.FirstPhoneNumber;
                oldOrder.SecondPhoneNumber = newOrder.SecondPhoneNumber;
                oldOrder.Email = newOrder.Email;
                oldOrder.Id_Governate = newOrder.GovernorateId;
                oldOrder.Id_City = newOrder.CityId;
                oldOrder.Village_Name = newOrder.Street;
                oldOrder.flag_of_villagee = newOrder.DeliverToVillage;
                oldOrder.ShippingTypeId = newOrder.ShippingTypeId;
                oldOrder.PaymentType = newOrder.PaymentType;
                oldOrder.Id_Branch = newOrder.BranchId;
                oldOrder.orderStatus = newOrder.orderStatus;
                oldOrder.Date = DateTime.Now;
                oldOrder.Notes = newOrder.Notes;
                oldOrder.ProductTotalCost = costAllProducts;
                oldOrder.OrderShippingTotalCost = costDeliverToVillage + costAddititonalWeight + cityShippingPrice + costShippingType;
                oldOrder.Total_weight = countWeight;
                var newProducts = newOrder.Products.Select(prod => new Product
                {
                    Id_Order = oldOrder.Id_Order,
                    Name = prod.Name,
                    Quantity = prod.Quantity,
                    Price = prod.Price,
                    weight = prod.Weight,
                }).ToList();

                var products = productRepo.GetProductsByOrderId(oldOrder.Id_Order).ToList();
                var deleteFlag = productRepo.DeleteRange(products);
                var addFlag = productRepo.AddRange(newProducts);

                if (deleteFlag && addFlag)
                {
                    bool isSaved;

                    try
                    {
                        context.SaveChanges();
                        isSaved = true;

                    }
                    catch (Exception ex)
                    {
                        isSaved = false;
                    }
                    if (isSaved)
                    {
                        double shippingTotalCost = costDeliverToVillage + costAddititonalWeight + cityShippingPrice + costShippingType;

                        return new UpdateOrderResultDto(true, costAllProducts, shippingTotalCost, countWeight);
                    }
                }
            }
            return new UpdateOrderResultDto(false, null, null, null);
        }
        public void DeleteOrder(string id)
        {

            var order=context.Orders.Where(n => n.Id_Order == id).Include(n=>n.product).FirstOrDefault();
            var porducts=context.Products.Where(n => n.Id_Order == id).ToList();
            if (Cost_AllProducts != null)
            {
                foreach (var item in porducts)
                {
                    context.Products.Remove(item);
                }
                if (order != null)
                {
                    context.Orders.Remove(order);
                    context.SaveChanges();
                }
            }


        }
        public Order GetData(string id)
        {
            return context.Orders.Where(n => n.Id_Order == id).Include(n => n.Governates).Include(n => n.city).FirstOrDefault();
        }
        public List<Order> GetAll()
        {
            return context.Orders.Include(n => n.Governates).Include(n => n.city).Include(n => n.product).Include(n => n.Trader).ToList();
        }

        public List<Order> GetAllFilter(string id)
        {
            return context.Orders.Include(n => n.Governates).Include(n => n.city).Include(n => n.product).Include(n => n.Trader).Where(e=>e.Id_Trader==id).ToList();
        }
        public IEnumerable<string> GetAllStatusOrders()
        {
            return Enum.GetNames(typeof(OrderStatus));
        }
        public List<Show_Order> GetOrdersByStatus(OrderStatus status)
        {
            List<Show_Order> data = new List<Show_Order>();
            var result = context.Orders.Where(o => o.orderStatus == status).Include(n => n.Governates).Include(n => n.city).Include(n => n.product).Include(n => n.Trader).ToList();
            if (result != null)
            {
                
                foreach (var item in result)
                {

                    Show_Order r1 = new Show_Order()
                    {
                        Id = item.Id_Order,
                        Date_Adding = item.Date,
                        City = item.city.Name,
                        Governate = item.Governates.Name,
                        Name_customer = item.Client_Name,
                        Phone_Customer = item.FirstPhoneNumber,
                        Total_shipping = item.OrderShippingTotalCost,
                        Stauts_of_Shipping = item.orderStatus.ToString(),
                    };
                    data.Add(r1);
                }
                
            }
            return data;
        }

        public List<Show_Order> GetOrdersByStatusForTrader(OrderStatus status , string traderId)
        {
            List<Show_Order> data = new List<Show_Order>();
            var result = context.Orders.Where(o => o.orderStatus == status && o.Id_Trader==traderId).Include(n => n.Governates).Include(n => n.city).Include(n => n.product).Include(n => n.Trader).ToList();
            if (result != null)
            {

                foreach (var item in result)
                {

                    Show_Order r1 = new Show_Order()
                    {
                        Id = item.Id_Order,
                        Date_Adding = item.Date,
                        City = item.city.Name,
                        Governate = item.Governates.Name,
                        Name_customer = item.Client_Name,
                        Phone_Customer = item.FirstPhoneNumber,
                        Total_shipping = item.OrderShippingTotalCost,
                        Stauts_of_Shipping = item.orderStatus.ToString(),
                    };
                    data.Add(r1);
                }

            }
            return data;
        }

        public List<Order> GetOrdersByDateRange(DateTime fromDate, DateTime toDate)
        {
            return context.Orders.Where(o => o.Date >= fromDate && o.Date <= toDate).ToList();
        }

        public void update_status(string id,OrderStatus orderStatus)
        {
            var data = context.Orders.FirstOrDefault(n => n.Id_Order == id);
            if (data != null) {

                data.orderStatus = orderStatus;
                context.SaveChanges();
            }
        }
        private double Cost_DeliverToVillage(bool isDeliverToVillage)
        {
            var result = vallageRepo.GetAllVillages();

            if (isDeliverToVillage && result != null)
            {
                return result.Select(s => s.Value).FirstOrDefault();
            }
            return 0;
        }

        private double CountWeight(List<ProductDto> products)
        {
            double weight = 0;
            foreach (var item in products)
            {
                weight += item.Weight * item.Quantity;
            }
            return weight;
        }
        private double Cost_AllProducts(List<ProductDto> products)
        {
            double price = 0;
            foreach (var item in products)
            {
                price += item.Price * item.Quantity;
            }
            return price;
        }
        private double Cost_AdditionalWeight(double totalWeight)
        {
            double cost = 0;
            double defaultWeight = 0;
            double additionalPrice = 0;
            var result = weightRepo.GetAllWeights();
            if (result != null)
            {
                defaultWeight = result.Select(w => w.weight_shipping).FirstOrDefault();

                if (totalWeight > defaultWeight)
                {

                    additionalPrice = result.Select(w => w.Extra_weight).FirstOrDefault();

                    totalWeight = totalWeight - defaultWeight;

                    cost = totalWeight * additionalPrice;
                }
            }

            return cost;
        }

        private double Cost_ShippingType(string shippingTypeId)
        {
            var result = shipping_Setting.GetById(shippingTypeId);
            if (result != null)
            {
                return result.Value_Of_shipping;
            }
            return 0;
        }

        private double GetSpecialPricesWithTraderandCityId(string TraderId, string cityId)
        {
            double totalPrice = 0;
            var result = specialPriceRepository.GetAll();
            if (result != null)
            {
                var specialPrices = result.Where(sp => sp.Id_city == cityId & sp.Id_Trader == TraderId).FirstOrDefault();
                if (specialPrices != null)
                {
                    totalPrice = specialPrices.Price;
                }
            }
            return totalPrice;

        }
        public List<int> EmpCount()
        {
            var listOrderStatus = context.Orders.Where(s => s.IsDeleted == false).Select(s => (int)s.orderStatus).ToList();
            int[] countOrdres = new int[11];//size of enum

            var g = listOrderStatus.GroupBy(i => i);

            foreach (var grp in g)
            {
                countOrdres[grp.Key] = grp.Count();
            }
            return countOrdres.ToList();
        }

        public List<int> TraderCount(string traderId)
        {
            var listOrderStatus = context.Orders.Where(s => s.IsDeleted == false && s.Id_Trader == traderId).Select(s => (int)s.orderStatus).ToList();
            ;
            int[] countOrdres = new int[11];//size of enum

            var g = listOrderStatus.GroupBy(i => i);

            foreach (var grp in g)
            {
                countOrdres[grp.Key] = grp.Count();
            }
            return countOrdres.ToList();
        }
        private double CityShippingPrice(string cityId)
        {
            var result = cityRepo.GetCities(cityId);
            if (result != null)
            {
                return result.Regular_Shipping;
            }
            return 0;
        }

    }
}
