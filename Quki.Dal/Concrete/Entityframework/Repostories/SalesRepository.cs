using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class SalesRepository : GenericRepository<Sales>, ISalesRepository
    {
        public SalesRepository(DbContext context) : base(context)
        {
            
        }
        //public Sales AddSale(Sales sale)
        //{
        //    TAdd(sale);
        //    sale.DocumentNumber = sale.SalesSeqID.ToString();
        //    TUpdate(sale);
        //    return sale;
        //}

        //public void UpdateSendStatus(long SalesSeqID, string SalesID, bool status, short TransferStatus, short statusType)
        //{
        //    var sale = dbset.Where(w => w.SalesSeqID == SalesSeqID).FirstOrDefault();
        //    sale.SalesID = SalesID;
        //    sale.IsTransfer = status;
        //    sale.TransferStatus = TransferStatus;
        //    sale.Status = statusType;
        //    TUpdate(sale);
        //}

        //public void UpdateSendStatus(string SalesID, bool status, short TransferStatus, short statusType)
        //{
        //    var sale = dbset.Where(w => w.SalesID == SalesID).FirstOrDefault();
        //    sale.IsTransfer = status;
        //    sale.TransferStatus = TransferStatus;
        //    sale.Status = statusType;
        //    TUpdate(sale);
        //}

        //public List<SalesModel> InvoiceReportSP(DateTime StartDateTime, DateTime EndDateTime)
        //{
        //    var sales = dbset.Where(w => w.CreatedDateTime >= StartDateTime && w.CreatedDateTime < EndDateTime).Select(s =>
        //        new SalesModel
        //        {
        //            SalesSeqID = s.SalesSeqID,
        //            DocumentNumber = s.DocumentNumber,
        //            SalesTotal = s.SalesTotal,
        //            CustomerName = s.CustomerName,
        //            CustomerSurname = s.CustomerSurname,
        //            Status =
        //            s.Status == 1 ? "Hazırlanmamış" :
        //            s.Status == 2 ? "Gönderilmemiş" :
        //            s.Status == 3 ? "Taslak" :
        //            s.Status == 4 ? "İptal edildi" :
        //            s.Status == 5 ? "Sıraya alınmış" :
        //            s.Status == 6 ? "İşleniyor" :
        //            s.Status == 7 ? "Gib'e Gönderildi" :
        //            s.Status == 8 ? "Onaylandı" :
        //            s.Status == 9 ? "Onay Bekleniyor" :
        //            s.Status == 10 ? "Reddedildi" :
        //            s.Status == 11 ? "Dönüş" :
        //            s.Status == 12 ? "EArşivleme İptal Edildi" :
        //            s.Status == 13 ? "Hata" : "",
        //            Description = s.Description
        //        }).ToList();
        //    return sales;
        //}

        //public Sales GelSalesBySalesSeqID(long SalesSeqID)
        //{
        //    var item = dbset.Where(w => w.SalesSeqID == SalesSeqID).FirstOrDefault();
        //    return item;
        //}

        //public List<Sales> GelSalesNotSendGIB()
        //{
        //    var sales = dbset.Where(w => w.Status != (int)InvoiceStatus.SentToGib).ToList();
        //    return sales;
        //}

    }
}
