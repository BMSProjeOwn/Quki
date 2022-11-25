using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class MemberShipTypeWithProperties : EntityBase
    {
        [Key]
        public int MemberShipTypeWithPropertiesSeqID { get; set; }
        public int MemberShipTypeSeqID { get; set; }
        public virtual MemberShipType MemberShipTypes { get; set; }
        public int MemberShipPropertiesSeqID { get; set; }
        public virtual MembershipProperties  MembershipPropertiess { get; set; }
        [MaxLength(250)]
        //public string ReName { get; set; }
        //[MaxLength(250)]
        public string InitialValue { get; set; }
        [MaxLength(250)]
        public string EndValue { get; set; }
        //public int ValueTypeSeqID { get; set; }
   
        public string Command { get; set; }
        [MaxLength(250)]
        public string FunctionContent { get; set; }
        //public bool IsAskUser { get; set; }
        //public string UserContent { get; set; }
        public decimal AddedPrice { get; set; }
        public string Remark { get; set; }
        //public string ShowUserMessage { get; set; }
        public string ShowInstractionToUser { get; set; }
        //public int? CurrencyTypeSeqID { get; set; }
        //public int? BaseCurrencySeqID { get; set; }
        //public int? Type { get; set; }
        public bool? IsActive { get; set; }
        public Int16 DisplayOrderNumber { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }

        public bool IsshowScreen { get; set; }

    }
}
