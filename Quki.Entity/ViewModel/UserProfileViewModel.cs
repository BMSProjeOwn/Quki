using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.ViewModel
{
    public class UserProfileViewModel:DtoBase
    {

        [MaxLength(450)]
        public string Id { get; set; }
        [MaxLength(1000)]
        public string Address1 { get; set; }
        [MaxLength(1000)]
        public string Address2 { get; set; }
        [MaxLength(450)]
        public string Region { get; set; }

        [MaxLength(450)]
        public string Country { get; set; }
   
        [MaxLength(250)]

        public string City { get; set; }
        [MaxLength(1000)]
        public string ShippingRegion { get; set; }
        [MaxLength(250)]
        public string PostalCode { get; set; }
        [Phone]
        public string MobPhone { get; set; }
        [Phone]
        public string EvePhone { get; set; }
        [Phone]
        public string DayPhone { get; set; }

        public int LanguageID { get; set; }

        [Required(ErrorMessage = "Boş geçilemez")]
        public string Name { get; set; }

        public string SurName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public bool issubscriber { get; set; }
        public string subscriberRef { get; set; }
        public Int16 Gender { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
