using System;
using System.ComponentModel.DataAnnotations;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class Departments : EntityBase
    {
        public int? LanguageID { get; set; }
        [Required(ErrorMessage ="Ad alanı gereklidir.")]
        public string Name { get; set; }
        [Range(1,int.MaxValue,ErrorMessage ="Sıralama 1 den büyük olmalıdır.")]
        public int? DisplayOrderNumber { get; set; }
        public bool Status { get; set; }
    }
}
