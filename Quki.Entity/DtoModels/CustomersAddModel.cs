using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class CustomersAddModel : DtoBase
    {

        public int customer_def_seq { get; set; }
        public int parentCustomerID { get; set; }
        public Guid? customer_def_no { get; set; }
        public string customer_title { get; set; }
        [MaxLength(50)]
        public string customer_VknTckn { get; set; }
        [MaxLength(400)]
        public string customer_def_CompanyName { get; set; }
        [MaxLength(200)]
        public string customer_def_name { get; set; }
        [MaxLength(200)]
        public string customer_def_surname { get; set; }
        [MaxLength(20)]
        public string customer_def_account_number { get; set; }
        public string customer_def_Description { get; set; }
        public string customer_tax_location { get; set; }
       
        [MaxLength(200)]
        public string email { get; set; }
        [MaxLength(50)]
        public string customer_account_code { get; set; }
        public int GroupID { get; set; }
        public int CustomerTypeID { get; set; }
        public int FirmTypeID { get; set; }
        public int TerminalID { get; set; }
        public bool isAccount { get; set; }
        public bool IsFirm { get; set; }
        public bool Status { get; set; }
    }
}
