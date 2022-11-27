using System.ComponentModel.DataAnnotations;
using Quki.Entity.Base;

namespace Quki.Entity.ViewModel
{
    public class CustomerAddModel:DtoBase
    {
        public int customer_def_seq { get; set; }
        public int parentCustomerID { get; set; }
        [MaxLength(450)]
        public string UserID { get; set; }

        public string customer_title { get; set; }
        [MaxLength(50)]
        public string customer_VknTckn { get; set; }
        [MaxLength(400)]
        public string customer_def_CompanyName { get; set; }
        [MaxLength(200)]
        public string customer_def_name { get; set; }
        [MaxLength(200)]
        public string customer_def_surname { get; set; }
        [MaxLength(200)]
        public string email { get; set; }
        [MaxLength(20)]

        public int? CustomerTypeID { get; set; }
        public int? LanguageID { get; set; }
        public bool? isUser { get; set; }
    }
}
