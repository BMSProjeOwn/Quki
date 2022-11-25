using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class CustomerIdentity:EntityBase
    {
        [Key]
        public int CustomerIdentitySeqID { get; set; }
        public Guid customer_def_no { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DateOfDeath { get; set; }
        [MaxLength(150)]
        public string BirthPlace { get; set; }
        public int? GenderType { get; set; }
        [MaxLength(15)]
        public string CustomerIdentityNumber { get; set; }
        public int? CustomerIdentityType { get; set; }
        [MaxLength(150)]
        public string CustomerIdentityFatherName { get; set; }
        [MaxLength(150)]
        public string CustomerIdentityMotherName { get; set; }

        public int NationalityID { get; set; }
        public string NationalityRemark { get; set; }
        public int? DistrictSeqID { get; set; }
        [MaxLength(150)]
        public string CustomerIdentityDistrictName { get; set; }
        public string ImagePath { get; set; }
        public string Remark { get; set; }
        public int? MarrigeStatusType { get; set; }
        public int customer_def_seq { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
