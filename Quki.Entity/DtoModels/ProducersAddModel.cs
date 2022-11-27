using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class ProducersAddModel : DtoBase
    {
        public int ProducerSeqID { get; set; }
        public int ProducerTypeSeqID { get; set; }
        [Required(ErrorMessage = "Ad alanı zorunludur")]
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string SecondName { get; set; }
        [MaxLength(150)]
        public string Phone { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        public string Remark { get; set; }
        public string History { get; set; }
        public IFormFile ImagePath { get; set; }

        public int? LanguageID { get; set; }

        public bool IsActive { get; set; }
        public Int16 DisplayOrderNumber { get; set; }

        public string ImagePathStr { get; set; }

        public int? GroupID { get; set; }

        public List<ProducerTypeModel> producerTypeList { get; set; }
    }

    public class ProducerTypeModel : DtoBase
    {
        public int ProducerTypeSeqID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }

}
