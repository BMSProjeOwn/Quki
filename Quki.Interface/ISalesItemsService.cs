using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface ISalesItemsService : IGenericService<SalesItems, SalesModel>
    {
        public bool AddSalesItems(SalesItems item);
        public void UpdateSendStatus(long SalesSeqID, short statusType);
        public List<SalesItems> GelSalesItemsBySalesSeqID(long SalesSeqID);      
    }
}
