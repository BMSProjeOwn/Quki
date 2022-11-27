using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels.ApiModels
{
    public class HomeResourceApiModel
    {
    }

    public class HomeResourceRequest
    {
        public int languageId { get; set; }
        public string customerDefNo { get; set; }
    }

    public class HomeResource
    {

        public ProductGroup newest { get; set; }
        public ProductGroup topRated { get; set; }
        public ProductGroup keepListening { get; set; }
        public ProductGroup popular { get; set; }
        public ProductGroup byAge { get; set; }

        public PerformerGroup performers { get; set; }

        public bool result { get; set; }
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
    }

    public class ProductGroup
    {

        public int productGroupId { get; set; }
        public string title { get; set; }
        public string coverImageUrl { get; set; }
        public List<Product> productList { get; set; }
        public List<Filter> filterList { get; set; }
        public List<Filter> orderList { get; set; }

    }

    public class PerformerGroup
    {
        public int PerformerGroupId { get; set; }
        public string title { get; set; }
        public string coverImageUrl { get; set; }
        public List<Performer> performerList { get; set; }
    }

    public class Performer
    {

        public int performerId { get; set; }
        public string performerName { get; set; }
        public string performerLastName { get; set; }
        public string imageUrl { get; set; }
        public string coverImageUrl { get; set; }

    }

    public class Product :  DtoBase
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string secondName { get; set; }
        public string description { get; set; }
        public string imageUrl { get; set; }
        public string previewUrl { get; set; }
        public string preListeningRight { get; set; }
        public string backgroundImage { get; set; }
        public int theaterId { get; set; }
        public string theaterUrl { get; set; }
        public int? theaterDuration { get; set; }
        public int musicId { get; set; }
        public string musicUrl { get; set; }
        public string productUrl { get; set; }
        public int? musicDuration { get; set; }
        public bool isMusicFavorite { get; set; }
        public bool isTheaterFavorite { get; set; }
        public bool isMusicInKeepListening { get; set; }
        public bool isTheaterInKeepListening { get; set; }
        public bool isMusicInPlayList { get; set; }
        public bool isTheaterInPlayList { get; set; }
        public int? lastDuration { get; set; }
        public double productPoints { get; set; }
        public bool isFavorite { get; set; }
        public List<int> categoryIdList { get; set; }
        public DateTime? releaseDate { get; set; }
        public List<ProductAttribute> productAttributeList { get; set; }
        public long displayOrderNumber { get; set; }
        public string categoryName { get; set; }
    }

    class ProductDetail
    {
        public int id { get; set; }
        public string url { get; set; }
        public bool isFavorite { get; set; }
        public bool isInPlayList { get; set; }
    }

    public class ProductAttribute
    {
        public string name { get; set; }
        public string value { get; set; }
    }
    public class Filter
    {
        public int filterId { get; set; }
        public string name { get; set; }
        public string ImagePath { get; set; }
    }

    public class GetProductByIDModel : Response
    {
        public Product product { get; set; }
    }


    public class PerformerListResource
    {
        public List<Performer> performers { get; set; }
        public bool result { get; set; }
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
    }

    public class SelectHomeProduct
    {
        [Key]
        public string ID { get; set; }
        public int productId { get; set; }
        public string? productName { get; set; }
        public string? secondName { get; set; }
        public string? description { get; set; }
        public string? imageUrl { get; set; }
        public string? previewUrl { get; set; }
        public string? preListeningRight { get; set; }
        public string? backgroundImage { get; set; }
        public int theaterId { get; set; }
        public string? theaterUrl { get; set; }
        public int? theaterDuration { get; set; }
        public int musicId { get; set; }
        public string? musicUrl { get; set; }
        public string? productUrl { get; set; }
        public int? musicDuration { get; set; }
        public bool isMusicFavorite { get; set; }
        public bool isTheaterFavorite { get; set; }
        public bool isMusicInPlayList { get; set; }
        public bool isTheaterInPlayList { get; set; }
        public bool isMusicInKeepListening { get; set; }
        public bool isTheaterInKeepListening { get; set; }
        public int? lastDuration { get; set; }
        public string? productPoints { get; set; }
        public bool isFavorite { get; set; }
        public DateTime? releaseDate { get; set; }
        public int? displayOrderNumber { get; set; }
        public string? categoryName { get; set; }
    }
}
