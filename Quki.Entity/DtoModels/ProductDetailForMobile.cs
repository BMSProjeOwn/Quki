using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.ViewModel;

namespace Quki.Entity.DtoModels
{
    public class ProductDetailForMobile : Response
    {
        public int ProductSeqID { get; set; }
        public string ProductName { get; set; }
        public string SecondName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        //public bool AllowCustomerReviews { get; set; }
        //public bool AllowCustomerRating { get; set; }
        public double ProductPoints { get; set; }
        public bool isFavorite { get; set; }
        //public bool inMyLibrary { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public List<ProductAttributeModelApi> ProductAttributeModel { get; set; }
        public List<int> CategorySeqIDList { get; set; }
        public string PreviewLink { get; set; }
        public string TheaterLink { get; set; }
        public string MusicLink { get; set; }
        public int? LeftOfSecond { get; set; }
    }

    public class ApiProductImages
    {
        public int ProductImageSeqID { get; set; }
        public int ProductSeqID { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public int? MediaTypeId { get; set; }
        public int? GroupId { get; set; }
    }

    public class ProductAttributeModelApi
    {
        public string ValueName { get; set; }
        public string Value { get; set; }
    }

}
