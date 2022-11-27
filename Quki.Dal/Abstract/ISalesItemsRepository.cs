using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;

namespace Quki.Dal.Abstract
{
    public interface ISalesItemsRepository
    {
        public bool AddSalesItems(SalesItems item);
        public void UpdateSendStatus(long SalesSeqID, short statusType);
        public List<SalesItems> GelSalesItemsBySalesSeqID(long SalesSeqID);      
    }
}
