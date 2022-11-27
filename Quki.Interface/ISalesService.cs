using System;
using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface ISalesService : IGenericService<Sales, SalesModel>
    {
        public Sales AddSale(Sales sale);
        public void UpdateSendStatus(long SalesSeqID, string SalesID, bool status, short TransferStatus, short statusType);
        public void UpdateSendStatus(string SalesID, bool status, short TransferStatus, short statusType);
        public List<SalesModel> InvoiceReportSP(DateTime StartDateTime, DateTime EndDateTime);
        public Sales GelSalesBySalesSeqID(long SalesSeqID);
        public List<Sales> GelSalesNotSendGIB();
      

    }
}
