using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using Quki.Entity.Models;

namespace Quki.Entity.DtoModels
{
    public class CategoryUpdateModel
    {
        public int CategorySeqID { get; set; }
        public int DepartmanSeqID { get; set; }
        public int? LanguageID { get; set; }
        [Required(ErrorMessage = "Ad alanı gereklidir.")]
        public string Name { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Sıralama 1 den büyük olmalıdır.")]
        public Int16? DisplayOrderNumber { get; set; }

        public string Description { get; set; }
        public bool Status { get; set; }
        public virtual TDepart Depart { get; set; }
    }
}
