using System;
using System.ComponentModel.DataAnnotations;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class AttributeStaticValueUpdateModel : DtoBase
    {

        public int AttributeStaticValueSeqID { get; set; }
        public int LanguageID { get; set; }
        [Required(ErrorMessage = "Ad alanı gereklidir.")]

        public string ValueName { get; set; }
        public string Adress { get; set; }

        public string Remark { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Sıralama 1 den büyük olmalıdır.")]

        public Int16 DisplayOrderNumber { get; set; }
        public bool IsDynamic { get; set; }

    }
}
