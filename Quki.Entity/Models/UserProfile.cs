using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class UserProfile:EntityBase
    {
        [Key]
        public int UserContactID { get; set; }
        [MaxLength(450)]
        public string Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Surname { get; set; }


        [MaxLength(250)]
        public string City { get; set; }
        [MaxLength(20)]
        public string MobPhone { get; set; }
        [MaxLength(20)]
        public string EvePhone { get; set; }
        [MaxLength(20)]
        public string DayPhone { get; set; }
        [MaxLength(1000)]
        public string Address1 { get; set; }
        [MaxLength(1000)]
        public string Address2 { get; set; }
        [MaxLength(450)]
        public string Country { get; set; }
        [MaxLength(450)]
        public string Ip { get; set; }
        [MaxLength(450)]
        public string Region { get; set; }
        [MaxLength(1000)]
        public string ShippingRegion { get; set; }
        [MaxLength(250)]
        public string PostalCode { get; set; }
        [MaxLength(1000)]
        public string CreditCard { get; set; }

        public Int16 Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public int AddressType { get; set; }
        public int? LanguageID { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [MaxLength(450)]
        public string UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        [MaxLength(450)]
        public string CreatedBy { get; set; }
        public int languageID;
    }
}
