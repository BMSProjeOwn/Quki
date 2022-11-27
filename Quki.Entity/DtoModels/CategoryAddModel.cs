using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using Quki.Entity.Base;
using Quki.Entity.Models;

namespace Quki.Entity.DtoModels
{
    public class CategoryAddModel : DtoBase
    {
        public int LanguageID { get; set; }
        [Required(ErrorMessage = "Ad alanı gereklidir.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Sıralama alanı gereklidir.")]
        [Range(1, int.MaxValue, ErrorMessage = "Sıralama 1 den büyük olmalıdır.")]
        public Int16? DisplayOrderNumber { get; set; }
        public IFormFile ImagePath { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public int DepartmanSeqID { get; set; }
        public int CategorySeqID { get; set; }
        public virtual TDepartModel Depart { get; set; }


    }
}
