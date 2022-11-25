using System;
using System.ComponentModel.DataAnnotations;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class Producer:EntityBase
    {
        [Key]
        public int ProducerSeqID { get; set; }
        public int? ProducerID { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Adress { get; set; }
        [MaxLength(150)]
        public string SecondName { get; set; }
        public int? GroupID { get; set; }
        public int? DisplayOrderNumber { get; set; }
        public int? CountrySeqID { get; set; }
        public int? CitySeqID { get; set; }

        public int? LanguageID { get; set; }

        [MaxLength(150)]
        public string Phone { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        [MaxLength(150)]
        public string WebAdress { get; set; }
        [MaxLength(1000)]
        public string ImageThumpPath { get; set; }
        [MaxLength(1000)]
        public string ImagePath { get; set; }
        [MaxLength(150)]
        public string BirthDate { get; set; }
        [MaxLength(150)]
        public string PrivateDate { get; set; }
        [MaxLength(150)]
        public string SpokenLanguage { get; set; }
        public string History { get; set; }
        public string Remark { get; set; }
        [MaxLength(250)]
        public string SocialMedia { get; set; }
        [MaxLength(250)]
        public string SEOKey { get; set; }
        public bool IsActive { get; set; }
        public bool IsCompany { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [MaxLength(450)]
        public string UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        [MaxLength(450)]
        public string CreatedBy { get; set; }
    }
}
