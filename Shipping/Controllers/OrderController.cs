using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Repository;
using Shipping.DTO;
using Shipping.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Authorization;

namespace Shipping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        [HttpPost]
        public ActionResult<AddOrderResultDto> Add(AddOrderDto order)
        {
            var result = orderRepository.Add(order);
            if (result.IsSuccesfull && ModelState.IsValid)
            {
                return Ok(new
                {
                    message = "Order was added successfully.",
                    result
                });
            }
            return BadRequest();
        }
        [HttpPut("{id}")]


        public ActionResult<UpdateOrderResultDto> Update(UpdateOrderDto order)
        {
            var result = orderRepository.Update(order);
            if (result.IsSuccesfull && ModelState.IsValid)
            {
                return Ok(new { message = "Order was updated successfully.", result });
            }
            return BadRequest();
        }
        [HttpGet("/Show_Order")]
        public ActionResult Get_Order()
        {
            var ressult = orderRepository.GetAll();
            if (ressult != null)
            {
                var data = new List<Show_Order>();
                foreach (var item in ressult)
                {
                    Show_Order s1 = new Show_Order()
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
                    data.Add(s1);
                }
                

                
                return Ok(new { message = "Order was loaded successfully.", data });

            }
            return NotFound();
        }

        [HttpGet("/Show_OrderforTrader")]
        public ActionResult Get_OrderTrader(string id)
        {
            var ressult = orderRepository.GetAllFilter(id);
            if (ressult != null)
            {
                var data = new List<Show_Order>();
                foreach (var item in ressult)
                {
                    Show_Order s1 = new Show_Order()
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
                    data.Add(s1);
                }

                return Ok(new { message = "Order was loaded successfully.", data });

            }
            return NotFound();
        }


        [HttpGet]

        public ActionResult Get_Orders()
        {
            var result = orderRepository.GetAll();
            if (result != null)
            {
                List<Report_Order> data = new List<Report_Order>();
                foreach (var item in result)
                {

                    Report_Order r1 = new Report_Order();
                    r1.Id = item.Id_Order;
                    r1.Status_Order = item.orderStatus.ToString();
                    r1.Name_Trader = item.Trader.UserName;
                    r1.Name_Client = item.Client_Name;
                    r1.Phone = item.FirstPhoneNumber;
                    r1.City = item.city.Name;
                    r1.Governate = item.Governates.Name;
                    r1.Cost_Order = item.product.Select(n => n.Price).FirstOrDefault();//cost of order that i have added to it in product 
                                                                                       //r1.Recieved_Money=item.;// he will display the money that i added when i update the status 
                    r1.Cost_Shipping = item.OrderShippingTotalCost; //that is the value of part of only shipping
                                                                    //r1.Cost_Shipping_Paid;//that is all data that the customer updated in status 
                                                                    //r1.Value_Company;//that is the value of company that i make to it
                    r1.Date = item.Date;

                    data.Add(r1);
                }

                return Ok(new { message = "Order was loaded successfully.", data });
            }
            return NotFound();
        }
        [HttpGet("/AllStatus")]

        public ActionResult Get_All_Status()
        {
            var data = orderRepository.GetAllStatusOrders();

            return Ok(data);
        }
        [HttpGet("/FilterStatus")]
        public ActionResult Filter_Status(string Name_status)
        {
            OrderStatus orderstatus;
            orderstatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), Name_status);
            
            var data = orderRepository.GetOrdersByStatus(orderstatus);
            if (data != null)
            {
                return Ok(new { message = "Order was loaded successfully.", data });
            }

            return NotFound();

        }

        [HttpGet("/FilterStatusForTrader")]
        [Authorize(Policy = "Trader")]

        public ActionResult FilterStatusForTrader(string Name_status,string traderId)
        {
            OrderStatus orderstatus;
            orderstatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), Name_status);

            var data = orderRepository.GetOrdersByStatusForTrader(orderstatus,traderId);
            if (data != null)
            {
                return Ok(new { message = "Order was loaded successfully .", data });
            }

            return NotFound();

        }
        [HttpGet("/FilterDate")]
        public ActionResult Filter_Date(DateTime FromDate,DateTime ToDate  )
        {
            var data = orderRepository.GetOrdersByDateRange(FromDate, ToDate);
            if (data != null)
            {
                return Ok(data);
            }

            return NotFound();


        }

        [HttpPut("/filter/{id}")]
        [Authorize(Policy = "Employe")]

        public ActionResult update_status(string id,string newstatus)
        {
            OrderStatus orderstatus;
            orderstatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), newstatus);
            var data=orderRepository.GetById(id);
            if (data != null)
            {
                orderRepository.update_status(id, orderstatus); 
                return Ok(data);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("EmpCount")]
        [Authorize(Policy = "Employee")]

        public ActionResult EmpCount()
        {
            return Ok(orderRepository.EmpCount());
        }

        [HttpGet]
        [Route("TraderCount")]
        [Authorize(Policy = "Trader")]

        public ActionResult CountOrdersForTraderByStatus(string id)
        {
            return Ok(orderRepository.TraderCount(id));
        }

        [HttpGet("{id}")]
        public ActionResult Get_Order_By_Id(string id)
        {
            var data=orderRepository.GetById(id);
            return Ok(data);
        }
        [HttpDelete("{id}")]
        public ActionResult deleteOrder(string id)
        {
            if (id != null)
            {
                orderRepository.DeleteOrder(id);
                return Ok(new { message = "Order was loaded successfully." });
            }
            return NotFound();
        }
    }
}
