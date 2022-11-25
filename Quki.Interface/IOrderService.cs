using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface IOrderService : IGenericService<Order, OrderModel>
    {

        public int CreateOrder(string shoppingCartId,
 int taxSeqId, int shippingSeqId, int PaymentMethod, string UserID);     
    }
}
