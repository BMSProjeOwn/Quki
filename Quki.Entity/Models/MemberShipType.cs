using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class MemberShipType:EntityBase
    {
        [Key]
        public int MemberShipTypeSeqID { get; set; }
        public int? MemberShipTypeID { get; set; }
        public int LanguageID { get; set; }
        public Int16 ParentID { get; set; }
        public Int16 Type { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Code { get; set; }
        public string Remark { get; set; }
        public string ImageThumpPath { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [MaxLength(450)]
        public string UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        [MaxLength(450)]
        public string CreatedBy { get; set; }
        public Int16 DisplayOrderNumber { get; set; }
        public bool Status { get; set; }
        public bool ShowOnHomePage { get; set; }

        public List<MemberShipTypeWithProperties> MemberShipTypeWithPropertiess { get; set; }
        public List<MembershipTypePricePlane> MembershipTypePricePlane { get; set; }
        public List<MemberShipTypeWithCustomer> MemberShipTypeWithCustomers { get; set; }
        public List<MemberShipTypesWithPaymentChanel> MemberShipTypesWithPaymentChanels { get; set; }
    

    }
}
