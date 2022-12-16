using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels
{
    public class ProductAddModel
    {
        public int ProductSeqID { get; set; }
        public int LanguageID { get; set; }

        [Required(ErrorMessage = "Ad alanı zorunludur")]
        public string ProductName { get; set; }
        [MaxLength(150)]
        public string SecondName { get; set; }
        public string Description { get; set; }
        public IFormFile ImagePath { get; set; }
        public string ImagePathName { get; set; }
        public string ProductSEOData { get; set; }
        public bool AllowCustomerReviews { get; set; }
        public bool AllowCustomerRating { get; set; }
        public bool ShowOnHomePage { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ProductSEOMetaDescription { get; set; }

        public int MediaType { get; set; }



        public bool Status { get; set; }
        public Int16 DisplayOrderNumber { get; set; }
    }
}
