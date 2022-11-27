using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class SalesItems:EntityBase
    {
        [Key]
        public long SalesItemsSeqID { get; set; }

        public long SalesSeqID { get; set; }

        public long? SalesItemLineNumber { get; set; }

        public string SalesItemName { get; set; }

        public decimal? SalesItemPrice { get; set; }

        public decimal? SalesItemVateRate { get; set; }

        public decimal SalesItemCount { get; set; }

        public string SalesItemUnitType { get; set; }

        public short? SalesItemCancelTypeID { get; set; }

        public int? SalesItemTypeID { get; set; }

        public int? SalesItemStatus { get; set; }

        public Guid? SalesItemSalePersonel { get; set; }

        public string SalesItemRelatedSalesItemNumber { get; set; }

        public short? TransferStatus { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public Guid? CreatedBy { get; set; }

        public decimal? DiscountRate { get; set; }

        public string StockCode { get; set; }

    }
}
