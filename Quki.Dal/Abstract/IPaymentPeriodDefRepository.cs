using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;
using Quki.Entity.Parameters;

namespace Quki.Dal.Abstract
{
    public interface IPaymentsRepository : IGenericRepository<Payments>
    {

        //public List<Payments> GetCustomerPaymentTransaction(int MemberShipTypePricePlaneSeqID, int MemberShipTypeWithCustomerSeqID);
        //public void LoadAllPaymnets();
      
    }
}
