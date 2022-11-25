using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class Branch
    {
        [Key]
        public int BranchSeqID { get; set; }

        public long? BranchNo { get; set; }

        public string Name { get; set; }

        public string DetailName { get; set; }

        public string Code { get; set; }

        public string Remark { get; set; }

        public string company_tax_number { get; set; }

        public string company_tax_office { get; set; }

        public string official_code { get; set; }

        public string company_addres { get; set; }

        public string ImagePath { get; set; }

        public string dateFormat { get; set; }

        public string Logo { get; set; }

        public int? CountrySeqID { get; set; }

        public string? CityName { get; set; }

        public bool? IsCenter { get; set; }

        public bool? status { get; set; }

        public DateTime? updatedate { get; set; }

        public long? createdby { get; set; }
    }
}
