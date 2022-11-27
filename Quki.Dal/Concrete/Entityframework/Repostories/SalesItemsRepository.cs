using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Abstract;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class SalesItemsRepository : GenericRepository<SalesItems>, ISalesItemsRepository
    {
        public SalesItemsRepository(DbContext context) : base(context)
        {
            
        }
        public bool AddSalesItems(SalesItems item)
        {
            bool result = false;
            TAdd(item);
            if (item.SalesItemsSeqID != null)
                if (item.SalesItemsSeqID > 0)
                    result = true;
            return result;
        }
        public void UpdateSendStatus(long SalesSeqID, short statusType)
        {
            try
            {
                var result = dbset.Where(w => w.SalesSeqID == SalesSeqID).ToList();
                foreach (var saleItem in result)
                {
                    saleItem.TransferStatus = statusType;
                    TUpdate(saleItem);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public List<SalesItems> GelSalesItemsBySalesSeqID(long SalesSeqID)
        {
            var items = dbset.Where(w => w.SalesSeqID == SalesSeqID).ToList();
            return items;
        }
    }
}
