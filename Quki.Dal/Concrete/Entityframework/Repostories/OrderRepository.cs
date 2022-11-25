using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext context) : base(context)
        {
            
        }
 //       public  int CreateOrder(string shoppingCartId,
 //int taxSeqId, int shippingSeqId, int PaymentMethod,string UserID)
 //       {
           
 //               int ordersSeqID = 0;
 //               string paramout = "";
 //               int orderid = 0;

 //           //Guid customerid = (Guid)Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey;
 //           string customerName = "";
 //          string shippingAdress = "";
 //          string emailAddress ="";
 //           Order order = new Order();
 //           order.OrdersGUID = shoppingCartId;
 //           order.UserID = UserID;
 //           order.ShippingSeqID = shippingSeqId;
 //           order.TaxSeqID = taxSeqId;
 //           order.CustomerName = customerName;
 //           order.CustomerEmail = emailAddress;
     


 //           //param[4] = new EBirikimParameters("@OrdersSeqID", ordersSeqID, ParameterDirection.Output);
 //           //    param[5] = new EBirikimParameters("@CustomerName", customerName);
 //           //    param[6] = new EBirikimParameters("@CustomerEmail", emailAddress);
 //           //    param[7] = new EBirikimParameters("@PaymentMethod", PaymentMethod);

 //           //    _orders.Parameters = param;
 //           //    //_orders.StoredProcedureName = "CreateOrderAndOrderDetailSP";
 //           //    _orders.StoredProcedureName = "CreateOrderForNext";

 //           //    DataAccess.InsertData(_orders, true, true, out paramout);

 //               if (paramout != null)
 //                   orderid = Int32.Parse(paramout);
 //               return orderid;
 //       }
    }
}
