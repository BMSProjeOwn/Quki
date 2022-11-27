using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class SalesItemsManager : BllBase<SalesItems, SalesModel>, ISalesItemsService
    {
        public readonly ISalesItemsRepository repo;
        public SalesItemsManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<ISalesItemsRepository>();
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
                var result = TGetList(w => w.SalesSeqID == SalesSeqID).ToList();
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
            var items = TGetList(w => w.SalesSeqID == SalesSeqID).ToList();
            return items;
        }
    }
}
