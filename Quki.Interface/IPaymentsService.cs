using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface IPaymentsService : IGenericService<Payments, PaymentsModel>
    {

        public List<Payments> GetCustomerPaymentTransaction(int MemberShipTypePricePlaneSeqID, int MemberShipTypeWithCustomerSeqID);
        public void LoadAllPaymnets();
      
    }
}
