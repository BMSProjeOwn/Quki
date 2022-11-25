using Microsoft.Extensions.DependencyInjection;
using System;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class OrderManager : BllBase<Order, OrderModel>, IOrderService
    {
        public readonly IOrderRepository repo;
        public OrderManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IOrderRepository>();
        }
        public int CreateOrder(string shoppingCartId,
 int taxSeqId, int shippingSeqId, int PaymentMethod, string UserID)
        {

            int ordersSeqID = 0;
            string paramout = "";
            int orderid = 0;

            //Guid customerid = (Guid)Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey;
            string customerName = "";
            string shippingAdress = "";
            string emailAddress = "";
            Order order = new Order();
            order.OrdersGUID = shoppingCartId;
            order.UserID = UserID;
            order.ShippingSeqID = shippingSeqId;
            order.TaxSeqID = taxSeqId;
            order.CustomerName = customerName;
            order.CustomerEmail = emailAddress;



            //param[4] = new EBirikimParameters("@OrdersSeqID", ordersSeqID, ParameterDirection.Output);
            //    param[5] = new EBirikimParameters("@CustomerName", customerName);
            //    param[6] = new EBirikimParameters("@CustomerEmail", emailAddress);
            //    param[7] = new EBirikimParameters("@PaymentMethod", PaymentMethod);

            //    _orders.Parameters = param;
            //    //_orders.StoredProcedureName = "CreateOrderAndOrderDetailSP";
            //    _orders.StoredProcedureName = "CreateOrderForNext";

            //    DataAccess.InsertData(_orders, true, true, out paramout);

            if (paramout != null)
                orderid = Int32.Parse(paramout);
            return orderid;
        }
    }
}
