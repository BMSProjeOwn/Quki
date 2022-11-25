using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels
{
    public class AttributeStaticUpdateModel
    {

        public int AttributeStaticSeqID { get; set; }
        public int LanguageID { get; set; }
        [Required(ErrorMessage = "Ad alanı gereklidir.")]
        public string Name { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Sıralama 1 den büyük olmalıdır.")]
        public Int16 DisplayOrderNumber { get; set; }
        public bool Status { get; set; }
    }
}
