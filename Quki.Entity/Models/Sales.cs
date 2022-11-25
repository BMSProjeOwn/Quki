using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class Sales:EntityBase
    {
        [Key]
        public long SalesSeqID { get; set; }

        public int? DocumentTypeSeqID { get; set; }

        public long? CustomerSeqID { get; set; }

        public int? IntegratorsSeqID { get; set; }

        public short? ApplicationSeqID { get; set; }

        public string DocumentNumber { get; set; }

        public string SalesID { get; set; }

        public short? SalesTypeID { get; set; }

        public DateTime SalesOpenDateTime { get; set; }

        public DateTime SalesCloseDateTime { get; set; }

        public Guid? SalesOpenPersonel { get; set; }

        public Guid? SalesClosePersonel { get; set; }

        public decimal SalesTotal { get; set; }
        public decimal VatRate { get; set; }

        public decimal SalesVatTotal { get; set; }

        public decimal SalesTotalWithoutVAT { get; set; }

        public string CustomerVKN { get; set; }
        public string CustomerTCKN { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }

        public decimal? DiscountTotal { get; set; }

        public string SalesTerminalID { get; set; }

        public string SalesRevenueCenterID { get; set; }

        public string SalesBranchID { get; set; }

        public string FiscalReceiptNumber { get; set; }

        public string FicalDeviceSerialNumber { get; set; }

        public short? FiscalEKUNumber { get; set; }

        public int? FiscalZNumber { get; set; }

        public bool? IsTransfer { get; set; }

        public short? TransferStatus { get; set; }

        public short? Status { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public Guid? CreatedBy { get; set; }

        public string CurrencyCode { get; set; }

        public string Description { get; set; }

        public string SpecialCode1 { get; set; }

        public string SpecialCode2 { get; set; }

    }
}
