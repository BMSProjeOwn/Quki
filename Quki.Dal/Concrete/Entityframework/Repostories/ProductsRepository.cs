using Microsoft.EntityFrameworkCore;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class ProductsRepository : GenericRepository<Products>, IProductsRepository
    {
        
        public ProductsRepository(DbContext context) : base(context)
        {
        }
        
        public List<Products> GetProductList()
        {
            var items = dbset.Where(x => x.Status == true).OrderByDescending(u => u.ProductSeqID);
            return items.ToList();
        }
        
        

        public List<SelectHomeProduct> ExecuteSql(string sql)
        {
            

                var products = context.Set<SelectHomeProduct>().FromSqlRaw(sql).ToList();
                

            return products;

        }






        //public int ProductAddForAnotherLanguage(ProductMergeModel Item, int ProductSeqID)
        //{
        //    Products p = new Products();
        //    if (Item.ProductUpdateModel.ImagePath != null)
        //    {
        //        var path = Path.GetExtension(Item.ProductUpdateModel.ImagePath.FileName);
        //        var newPath = Guid.NewGuid() + path;
        //        var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProductImg/" + newPath;
        //        var ThumbImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProductImg/Thump" + newPath;
        //        var steem = new FileStream(ImagePath, FileMode.Create);
        //        Item.ProductUpdateModel.ImagePath.CopyTo(steem);
        //        Utility.ResizeImage(Item.ProductUpdateModel.ImagePath, ProductImageSize.Height, ProductImageSize.Width, ThumbImagePath);
        //        p.ImagePath = "/AdminImage/ProductImg/" + newPath; ;
        //        p.ImageThumbPath = "/AdminImage/ProductImg/Thump" + newPath;
        //    }

        //    p.ProductName = Item.ProductUpdateModel.ProductName;
        //    p.LanguageID = Item.ProductUpdateModel.LanguageID;
        //    p.SecondName = Item.ProductUpdateModel.SecondName;
        //    p.ProductSEOData = Item.ProductUpdateModel.ProductSEOData;
        //    p.AllowCustomerReviews = Item.ProductUpdateModel.AllowCustomerReviews;
        //    p.AllowCustomerRating = Item.ProductUpdateModel.AllowCustomerRating;
        //    p.ShowOnHomePage = Item.ProductUpdateModel.ShowOnHomePage;
        //    p.Status = Item.ProductUpdateModel.Status;
        //    p.DisplayOrderNumber = Item.ProductUpdateModel.DisplayOrderNumber;
        //    p.Description = Item.ProductUpdateModel.Description;
        //    p.ReleaseDate = Item.ProductUpdateModel.ReleaseDate;
        //    p.CreatedOn = DateTime.Now;
        //    TAdd(p);
        //    p.ProductID = ProductSeqID;
        //    TUpdate(p);
        //    return p.ProductSeqID;
        //}

        //public Product GetProductByID(int ProductSeqID, string customer_def_no, int? languageId)
        //{
        //    CustomerTrackingTypeRepository customerTrackingTypeRepostories = new CustomerTrackingTypeRepository(context);
        //    CustomerRatingsRepository ratingsRepository = new CustomerRatingsRepository(context);
        //    Random rastgele = new Random();
        //    ProductImagesRepository productImagesRepository = new ProductImagesRepository(context);
        //    IAttributeStaticValueRepository attributeStaticValueRepository = new AttributeStaticValueRepository(context);

        //    var poroduct = context.Set<Products>()
        //        .Where(w => w.Status == true && w.LanguageID == languageId && w.ProductSeqID == ProductSeqID)
        //        .Select(poroduct => new Product
        //        {
        //            productId = poroduct.ProductSeqID,
        //            productName = poroduct.ProductName,
        //            secondName = poroduct.SecondName,
        //            description = Functions.StripHTML(poroduct.Description),
        //            imageUrl = ApiParameters.URL + dbset.Where(w => w.ProductSeqID == poroduct.ProductID).FirstOrDefault().ImageThumbPath,
        //            previewUrl = ApiParameters.URL + context.Set<ProductImage>().Where(w => w.GroupId == ApiProductMediaGroupType.Kisa && w.MediaTypeId == ApiProductMediaType.Tiyatro && w.ProductSeqID == poroduct.ProductID && w.IsDeleted == false && w.Status == true).Select(s => s.ImagePath).FirstOrDefault(),
        //            theaterId = context.Set<ProductImage>().Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Tiyatro && w.ProductSeqID == poroduct.ProductID && w.IsDeleted == false && w.Status == true).Select(s => s.ProductImageSeqID).FirstOrDefault(),
        //            theaterUrl = ApiParameters.URL + context.Set<ProductImage>().Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Tiyatro && w.ProductSeqID == poroduct.ProductID && w.IsDeleted == false && w.Status == true).Select(s => s.ImagePath).FirstOrDefault(),
        //            musicId = context.Set<ProductImage>().Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Muzik && w.ProductSeqID == poroduct.ProductSeqID && w.IsDeleted == false && w.Status == true).Select(s => s.ProductImageSeqID).FirstOrDefault(),
        //            musicUrl = ApiParameters.URL + context.Set<ProductImage>().Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Muzik && w.ProductSeqID == poroduct.ProductID && w.IsDeleted == false && w.Status == true).Select(s => s.ImagePath).FirstOrDefault(),
        //            productUrl = ApiParameters.URL + "/Product/GetProductDetail/" + poroduct.ProductSeqID.ToString(),
        //            theaterDuration = customerTrackingTypeRepostories.GetCustomerTrackingTypeLastApi(customer_def_no, context.Set<ProductImage>().Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Tiyatro && w.ProductSeqID == poroduct.ProductSeqID && w.IsDeleted == false && w.Status == true).Select(s => s.ProductImageSeqID).FirstOrDefault()),
        //            musicDuration = customerTrackingTypeRepostories.GetCustomerTrackingTypeLastApi(customer_def_no, context.Set<ProductImage>().Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Muzik && w.ProductSeqID == poroduct.ProductSeqID && w.IsDeleted == false && w.Status == true).Select(s => s.ProductImageSeqID).FirstOrDefault()),
        //            lastDuration = 0,
        //            productPoints = Convert.ToDouble(ratingsRepository.ProductPoint(poroduct.ProductSeqID)),
        //            displayOrderNumber = poroduct.DisplayOrderNumber,

        //            isMusicFavorite =
        //        context.Set<CustomerFavoritesList>().Join(context.Set<ProductImage>(), CF => CF.RelatedFavoritesListSeqID, Img => Img.ProductImageSeqID, (C, I) => new
        //        {
        //            C = C,
        //            I = I
        //        })
        //        .Where(
        //            w => w.I.GroupId == ApiProductMediaGroupType.Tamami && w.I.MediaTypeId == ApiProductMediaType.Muzik && w.C.customer_def_no == customer_def_no && w.C.RelatedFavoritesListSeqID == w.I.ProductImageSeqID && w.I.ProductSeqID == poroduct.ProductSeqID && w.C.GroupID == ApiFavoriListType.Favorite && w.C.IsActive == true
        //        ).Select(sci => sci.I.ProductImageSeqID).ToList().Count > 0 ? true : false,


        //            isTheaterFavorite =
        //         context.Set<CustomerFavoritesList>().Join(context.Set<ProductImage>(), CF => CF.RelatedFavoritesListSeqID, Img => Img.ProductImageSeqID, (C, I) => new
        //         {
        //             C = C,
        //             I = I
        //         })
        //        .Where(
        //            w => w.I.GroupId == ApiProductMediaGroupType.Tamami && w.I.MediaTypeId == ApiProductMediaType.Tiyatro && w.C.customer_def_no == customer_def_no && w.C.RelatedFavoritesListSeqID == w.I.ProductImageSeqID && w.I.ProductSeqID == poroduct.ProductSeqID && w.C.GroupID == ApiFavoriListType.Favorite && w.C.IsActive == true
        //        ).Select(sci => sci.I.ProductImageSeqID).ToList().Count > 0 ? true : false,


        //            isMusicInPlayList = false,
        //            isTheaterInPlayList = false,
        //            isMusicInKeepListening = context.Set<CustomerTrackingType>().Join(context.Set<ProductImage>(), CF => CF.RelatedTrackingSeqID, Img => Img.ProductImageSeqID, (C, I) => new
        //            {
        //                C = C,
        //                I = I
        //            })
        //        .Where(
        //            w => w.I.GroupId == ApiProductMediaGroupType.Tamami && w.I.MediaTypeId == ApiProductMediaType.Muzik && w.C.Customer_def_no == customer_def_no && w.C.RelatedTrackingSeqID == w.I.ProductImageSeqID && w.I.ProductSeqID == poroduct.ProductSeqID && w.C.GroupID == ApiFavoriListType.Favorite
        //        ).Select(sci => sci.I.ProductImageSeqID).ToList().Count > 0 ? true : false,
        //            isTheaterInKeepListening = context.Set<CustomerTrackingType>().Join(context.Set<ProductImage>(), CF => CF.RelatedTrackingSeqID, Img => Img.ProductImageSeqID, (C, I) => new
        //            {
        //                C = C,
        //                I = I
        //            })
        //        .Where(
        //            w => w.I.GroupId == ApiProductMediaGroupType.Tamami && w.I.MediaTypeId == ApiProductMediaType.Tiyatro && w.C.Customer_def_no == customer_def_no && w.C.RelatedTrackingSeqID == w.I.ProductImageSeqID && w.I.ProductSeqID == poroduct.ProductSeqID && w.C.GroupID == ApiFavoriListType.Favorite
        //        ).Select(sci => sci.I.ProductImageSeqID).ToList().Count > 0 ? true : false,
        //            //     favoriteMediaId = context.CustomerFavoritesList
        //            //         .Join(context.ProductImages, CustomerFavoritesList => CustomerFavoritesList.RelatedFavoritesListSeqID, ProductImage => ProductImage.ProductImageSeqID,
        //            //     (C, P) => new
        //            //     {
        //            //         CustomerFavoritesList = C,
        //            //         ProductImage = P
        //            //     }).Where(
        //            //    w => w.CustomerFavoritesList.customer_def_no == customer_def_no && w.CustomerFavoritesList.RelatedFavoritesListSeqID == w.ProductImage.ProductImageSeqID && w.ProductImage.ProductSeqID == poroduct.ProductSeqID && w.CustomerFavoritesList.GroupID == ApiFavoriListType.Favorite && w.CustomerFavoritesList.IsActive == true
        //            //).Select(sf => sf.ProductImage.ProductImageSeqID).ToList(),
        //            isFavorite = false,

        //            categoryIdList = dbset
        //        .Join(context.Set<ProductWithCategory>(), Products => Products.ProductSeqID, ProductWithCategory => ProductWithCategory.ProductSeqID, (P, PC) => new
        //        {
        //            Products = P,
        //            ProductWithCategory = PC
        //        }).Where(I => I.Products.Status == true && I.Products.ProductSeqID == poroduct.ProductSeqID).Select(sc => sc.ProductWithCategory.Category.CategorySeqID).ToList(),
        //            releaseDate = poroduct.ReleaseDate,
        //            productAttributeList = attributeStaticValueRepository.GetHomeProductAttribute(poroduct.ProductSeqID),
        //            categoryName =
        //            context.Set<Category>().Join(context.Set<ProductWithCategory>(), C => C.CategorySeqID, pc => pc.CategorySeqID, (C, PC) => new
        //            {
        //                C = C,
        //                PC = PC
        //            }).Where(w => w.PC.ProductSeqID == poroduct.ProductSeqID && w.C.Status == true).FirstOrDefault().C.Name
        //        }).FirstOrDefault();
        //    return poroduct;
        //}


        //#endregion Onder


        //public ProductImage GetMediaList(int id)
        //{
        //    var items = context.Set<ProductImage>().Where(x => x.ProductImageSeqID == id && x.Status == true).FirstOrDefault();
        //    return items;
        //}

        //public List<Quki.Entity.DtoModels.ApiModels.Filter> SelectAllOrders()
        //{
        //    List<Quki.Entity.DtoModels.ApiModels.Filter> filterList = new List<Quki.Entity.DtoModels.ApiModels.Filter>();
        //    Quki.Entity.DtoModels.ApiModels.Filter allAudioTheaters = new Quki.Entity.DtoModels.ApiModels.Filter();
        //    allAudioTheaters.filterId = ApiProductOrderIDs.allAudioTheaters;
        //    allAudioTheaters.name = "Tüm Sesli Tiyatrolar";
        //    Quki.Entity.DtoModels.ApiModels.Filter productOrderAZ = new Quki.Entity.DtoModels.ApiModels.Filter();
        //    productOrderAZ.filterId = ApiProductOrderIDs.productOrderAZ;
        //    productOrderAZ.name = "Ürün Adı (A-Z)";
        //    Quki.Entity.DtoModels.ApiModels.Filter productOrderZA = new Quki.Entity.DtoModels.ApiModels.Filter();
        //    productOrderZA.filterId = ApiProductOrderIDs.productOrderZA;
        //    productOrderZA.name = "Ürün Adı (Z-A)";
        //    Quki.Entity.DtoModels.ApiModels.Filter productOrderPoint = new Quki.Entity.DtoModels.ApiModels.Filter();
        //    productOrderPoint.filterId = ApiProductOrderIDs.productOrderPoint;
        //    productOrderPoint.name = "En Yüksek Puan";
        //    Quki.Entity.DtoModels.ApiModels.Filter productOrderLastCreate = new Quki.Entity.DtoModels.ApiModels.Filter();
        //    productOrderLastCreate.filterId = ApiProductOrderIDs.productOrderLastCreate;
        //    productOrderLastCreate.name = "En Son Eklenen";

        //    filterList.Add(allAudioTheaters);
        //    filterList.Add(productOrderAZ);
        //    filterList.Add(productOrderZA);
        //    filterList.Add(productOrderPoint);
        //    filterList.Add(productOrderLastCreate);
        //    return filterList;
        //}


        //public bool ProductDeleteById(int id)
        //{
        //    bool result = false;

        //    var x = dbset.Where(x => x.ProductSeqID == id).FirstOrDefault();

        //    x.Status = false;
        //    x.IsDeleted = true;

        //    TUpdate(x);
        //    result = true;
        //    return result;
        //}


        //public List<Product> GetHomeProductDetailByIDForMobile(int ProductSeqID, string customer_def_no, int languageId)
        //{
        //    CustomerTrackingTypeRepository customerTrackingTypeRepostories = new CustomerTrackingTypeRepository(context);
        //    CustomerRatingsRepository ratingsRepository = new CustomerRatingsRepository(context);
        //    Random rastgele = new Random();
        //    ProductImagesRepository productImagesRepository = new ProductImagesRepository(context);
        //    IAttributeStaticValueRepository attributeStaticValueRepository = new AttributeStaticValueRepository(context);

        //    var poroduct = new List<Product>();
        //    try
        //    {
        //        var setProductImage = context.Set<ProductImage>();
        //        var setCustomerFavoritesList = context.Set<CustomerFavoritesList>();

        //        poroduct = dbset
        //        .Where(w => w.Status == true && w.LanguageID == languageId && w.ProductSeqID == ProductSeqID)
        //        .Select(poroduct => new Product
        //        {
        //            productId = poroduct.ProductSeqID,
        //            productName = poroduct.ProductName,
        //            secondName = poroduct.SecondName,
        //            description = Functions.StripHTML(poroduct.Description),


        //            imageUrl = ApiParameters.URL + dbset.Where(w => w.ProductSeqID == poroduct.ProductID).FirstOrDefault().ImageThumbPath,
        //            previewUrl = ApiParameters.URL + setProductImage.Where(w => w.GroupId == ApiProductMediaGroupType.Kisa && w.MediaTypeId == ApiProductMediaType.Tiyatro && w.ProductSeqID == poroduct.ProductID && w.IsDeleted == false && w.Status == true).FirstOrDefault(),
        //            theaterId = setProductImage.Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Tiyatro && w.ProductSeqID == poroduct.ProductID && w.IsDeleted == false && w.Status == true).Select(s => s.ProductImageSeqID).FirstOrDefault(),
        //            theaterUrl = ApiParameters.URL + setProductImage.Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Tiyatro && w.ProductSeqID == poroduct.ProductID && w.IsDeleted == false && w.Status == true).Select(s => s.ImagePath).FirstOrDefault(),
        //            musicId = setProductImage.Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Muzik && w.ProductSeqID == poroduct.ProductSeqID && w.IsDeleted == false && w.Status == true).Select(s => s.ProductImageSeqID).FirstOrDefault(),
        //            musicUrl = ApiParameters.URL + setProductImage.Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Muzik && w.ProductSeqID == poroduct.ProductID && w.IsDeleted == false && w.Status == true).Select(s => s.ImagePath).FirstOrDefault(),

        //            productUrl = ApiParameters.URL + "/Product/GetProductDetail/" + poroduct.ProductSeqID.ToString(),
        //            theaterDuration = customerTrackingTypeRepostories.GetCustomerTrackingTypeLastApi(customer_def_no, setProductImage.Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Tiyatro && w.ProductSeqID == poroduct.ProductSeqID && w.IsDeleted == false && w.Status == true).Select(s => s.ProductImageSeqID).FirstOrDefault()),
        //            musicDuration = customerTrackingTypeRepostories.GetCustomerTrackingTypeLastApi(customer_def_no, setProductImage.Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Muzik && w.ProductSeqID == poroduct.ProductSeqID && w.IsDeleted == false && w.Status == true).Select(s => s.ProductImageSeqID).FirstOrDefault()),
        //            lastDuration = 0,
        //            productPoints = Convert.ToDouble(ratingsRepository.ProductPoint(poroduct.ProductSeqID)),
        //            displayOrderNumber = poroduct.DisplayOrderNumber,

        //            isMusicFavorite =
        //        context.Set<CustomerFavoritesList>().Join(setProductImage, CF => CF.RelatedFavoritesListSeqID, Img => Img.ProductImageSeqID, (C, I) => new
        //        {
        //            C = C,
        //            I = I
        //        })
        //        .Where(
        //            w => w.I.GroupId == ApiProductMediaGroupType.Tamami && w.I.MediaTypeId == ApiProductMediaType.Muzik && w.C.customer_def_no == customer_def_no && w.C.RelatedFavoritesListSeqID == w.I.ProductImageSeqID && w.I.ProductSeqID == poroduct.ProductSeqID && w.C.GroupID == ApiFavoriListType.Favorite && w.C.IsActive == true
        //        ).Select(sci => sci.I.ProductImageSeqID).ToList().Count > 0 ? true : false,



        //            isTheaterFavorite =
        //         context.Set<CustomerFavoritesList>().Join(setProductImage, CF => CF.RelatedFavoritesListSeqID, Img => Img.ProductImageSeqID, (C, I) => new
        //         {
        //             C = C,
        //             I = I
        //         })
        //        .Where(
        //            w => w.I.GroupId == ApiProductMediaGroupType.Tamami && w.I.MediaTypeId == ApiProductMediaType.Tiyatro && w.C.customer_def_no == customer_def_no && w.C.RelatedFavoritesListSeqID == w.I.ProductImageSeqID && w.I.ProductSeqID == poroduct.ProductSeqID && w.C.GroupID == ApiFavoriListType.Favorite && w.C.IsActive == true
        //        ).Select(sci => sci.I.ProductImageSeqID).ToList().Count > 0 ? true : false,


        //            isMusicInPlayList = false,
        //            isTheaterInPlayList = false,
        //            isMusicInKeepListening = context.Set<CustomerTrackingType>().Join(setProductImage, CF => CF.RelatedTrackingSeqID, Img => Img.ProductImageSeqID, (C, I) => new
        //            {
        //                C = C,
        //                I = I
        //            })
        //        .Where(
        //            w => w.I.GroupId == ApiProductMediaGroupType.Tamami && w.I.MediaTypeId == ApiProductMediaType.Muzik && w.C.Customer_def_no == customer_def_no && w.C.RelatedTrackingSeqID == w.I.ProductImageSeqID && w.I.ProductSeqID == poroduct.ProductSeqID && w.C.GroupID == ApiFavoriListType.Favorite
        //        ).Select(sci => sci.I.ProductImageSeqID).ToList().Count > 0 ? true : false,
        //            isTheaterInKeepListening = context.Set<CustomerTrackingType>().Join(setProductImage, CF => CF.RelatedTrackingSeqID, Img => Img.ProductImageSeqID, (C, I) => new
        //            {
        //                C = C,
        //                I = I
        //            })
        //        .Where(
        //            w => w.I.GroupId == ApiProductMediaGroupType.Tamami && w.I.MediaTypeId == ApiProductMediaType.Tiyatro && w.C.Customer_def_no == customer_def_no && w.C.RelatedTrackingSeqID == w.I.ProductImageSeqID && w.I.ProductSeqID == poroduct.ProductSeqID && w.C.GroupID == ApiFavoriListType.Favorite
        //        ).Select(sci => sci.I.ProductImageSeqID).ToList().Count > 0 ? true : false,
        //            isFavorite = false,

        //            categoryIdList = dbset
        //        .Join(context.Set<ProductWithCategory>(), Products => Products.ProductSeqID, ProductWithCategory => ProductWithCategory.ProductSeqID, (P, PC) => new
        //        {
        //            Products = P,
        //            ProductWithCategory = PC
        //        }).Where(I => I.Products.Status == true && I.Products.ProductSeqID == poroduct.ProductSeqID).Select(sc => sc.ProductWithCategory.Category.CategorySeqID).ToList(),
        //            releaseDate = poroduct.ReleaseDate,
        //            productAttributeList = attributeStaticValueRepository.GetHomeProductAttribute(poroduct.ProductSeqID),
        //            categoryName =
        //            context.Set<Category>().Join(context.Set<ProductWithCategory>(), C => C.CategorySeqID, pc => pc.CategorySeqID, (C, PC) => new
        //            {
        //                C = C,
        //                PC = PC
        //            }).Where(w => w.PC.ProductSeqID == poroduct.ProductSeqID && w.C.Status == true).FirstOrDefault().C.Name
        //        })
        //        .OrderByDescending(o => o.productId)
        //        .Take(1).ToList();
        //    }
        //    catch (Exception ex) { }
        //    return poroduct;

        //}



        //public List<SelectListItem> GetAllProduct()
        //{
        //    return dbset.Where(w => w.Status == true).Select(s => new SelectListItem
        //    {
        //        Value = s.ProductSeqID.ToString(),
        //        Text = s.ProductName
        //    }).ToList();
        //}


        public List<Product> GetProducersProductDetailByIDSP(int ProductSeqID, string customer_def_no, int languageId)
        {
            List<Product> productList = new List<Product>();
            AttributeStaticValueRepository attributeStaticValueRepository = new AttributeStaticValueRepository(context);
            try
            {
                string sql = "exec GetProducersProductDetailByIDSP @customer_def_no='" + customer_def_no
                    + "' , @languageId=" + languageId + " , @ProducerSeqID=" + ProductSeqID;

                var products = context.Set<SelectHomeProduct>().FromSqlRaw(sql).ToList();
                if (products != null)
                {
                    if (products.Count > 0)
                    {
                        foreach (var item in products)
                        {
                            Product product = new Product();
                            product.productId = item.productId;
                            product.productName = item.productName;
                            product.secondName = item.secondName;
                            //product.description = Functions.StripHTML(item.description);
                            product.imageUrl = item.imageUrl;
                            product.previewUrl = item.previewUrl;
                            product.theaterId = item.theaterId;
                            product.theaterUrl = item.theaterUrl;
                            product.musicId = item.musicId;
                            product.musicUrl = item.musicUrl;
                            product.productUrl = item.productUrl;
                            product.theaterDuration = item.theaterDuration;
                            product.musicDuration = item.musicDuration;
                            product.lastDuration = item.lastDuration;
                            product.productPoints = Convert.ToDouble(item.productPoints);
                            product.displayOrderNumber = Convert.ToInt64(item.displayOrderNumber.ToString());
                            product.isMusicFavorite = item.isMusicFavorite;
                            product.isTheaterFavorite = item.isTheaterFavorite;
                            product.isMusicInPlayList = item.isMusicInPlayList;
                            product.isTheaterInPlayList = item.isTheaterInPlayList;
                            product.backgroundImage = item.backgroundImage;
                            product.isMusicInKeepListening = item.isMusicInKeepListening;
                            product.isTheaterInKeepListening = item.isTheaterInKeepListening;
                            product.isFavorite = item.isFavorite;

                            product.categoryIdList = dbset
                        .Join(context.Set<ProductWithCategory>(), Products => Products.ProductSeqID, ProductWithCategory => ProductWithCategory.ProductSeqID, (P, PC) => new
                        {
                            Products = P,
                            ProductWithCategory = PC
                        }).Where(I => I.Products.Status == true && I.Products.ProductSeqID == item.productId).Select(sc => sc.ProductWithCategory.Category.CategorySeqID).ToList();

                            product.releaseDate = item.releaseDate;
                            product.productAttributeList = attributeStaticValueRepository.GetHomeProductAttribute(item.productId);
                            product.categoryName = item.categoryName;
                            productList.Add(product);
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return productList;
        }

        //public Product GetProductByIDSP(int ProductSeqID, string customer_def_no, int? languageId)
        //{
        //    Product returnProduct = new Product();
        //    AttributeStaticValueRepository attributeStaticValueRepository = new AttributeStaticValueRepository(context);
        //    try
        //    {
        //        string sql = "exec GetProductByIDSP @customer_def_no='" + customer_def_no + "' , @languageId=" + languageId + " , @ProductSeqID=" + ProductSeqID;
        //        var products = context.Set<SelectHomeProduct>().FromSqlRaw(sql).ToList();
        //        if (products != null)
        //        {
        //            if (products.Count > 0)
        //            {
        //                foreach (var item in products)
        //                {
        //                    Product product = new Product();
        //                    product.productId = item.productId;
        //                    product.productName = item.productName;
        //                    product.secondName = item.secondName;
        //                    product.description = Functions.StripHTML(item.description);
        //                    product.imageUrl = item.imageUrl;
        //                    product.previewUrl = item.previewUrl;
        //                    product.theaterId = item.theaterId;
        //                    product.theaterUrl = item.theaterUrl;
        //                    product.musicId = item.musicId;
        //                    product.musicUrl = item.musicUrl;
        //                    product.productUrl = item.productUrl;
        //                    product.theaterDuration = item.theaterDuration;
        //                    product.musicDuration = item.musicDuration;
        //                    product.lastDuration = item.lastDuration;
        //                    product.productPoints = Convert.ToDouble(item.productPoints);
        //                    product.displayOrderNumber = Convert.ToInt64(item.displayOrderNumber.ToString());
        //                    product.isMusicFavorite = item.isMusicFavorite;
        //                    product.isTheaterFavorite = item.isTheaterFavorite;
        //                    product.isMusicInPlayList = item.isMusicInPlayList;
        //                    product.isTheaterInPlayList = item.isTheaterInPlayList;
        //                    product.backgroundImage = item.backgroundImage;
        //                    product.isMusicInKeepListening = item.isMusicInKeepListening;
        //                    product.isTheaterInKeepListening = item.isTheaterInKeepListening;
        //                    product.isFavorite = item.isFavorite;

        //                    product.categoryIdList = dbset
        //                .Join(context.Set<ProductWithCategory>(), Products => Products.ProductSeqID, ProductWithCategory => ProductWithCategory.ProductSeqID, (P, PC) => new
        //                {
        //                    Products = P,
        //                    ProductWithCategory = PC
        //                }).Where(I => I.Products.Status == true && I.Products.ProductSeqID == item.productId).Select(sc => sc.ProductWithCategory.Category.CategorySeqID).ToList();

        //                    product.releaseDate = item.releaseDate;
        //                    product.productAttributeList = attributeStaticValueRepository.GetHomeProductAttribute(item.productId);
        //                    product.categoryName = item.categoryName;
        //                    returnProduct = product;
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return returnProduct;
        //}


        //public ProductsSearchApi SeachProductSP(string name, string customer_def_no, int languageId)
        //{
        //    ProductsSearchApi productsSearchApi = new ProductsSearchApi();
        //    productsSearchApi.Result = true;
        //    productsSearchApi.ResultCode = 1;
        //    productsSearchApi.ResultMessage = "İşlem Başarılı";
        //    List<Product> productList = new List<Product>();
        //    IAttributeStaticValueRepository attributeStaticValueRepository = new AttributeStaticValueRepository(context);
        //    try
        //    {
        //        string sql = "exec SeachProductSP @customer_def_no='" + customer_def_no + "' , @languageId=" + languageId + " , @name='" + name + "'";
        //        var products = context.Set<SelectHomeProduct>().FromSqlRaw(sql).ToList();
        //        if (products != null)
        //        {
        //            if (products.Count > 0)
        //            {
        //                foreach (var item in products)
        //                {
        //                    Product product = new Product();
        //                    product.productId = item.productId;
        //                    product.productName = item.productName;
        //                    product.secondName = item.secondName;
        //                    product.description = Functions.StripHTML(item.description);
        //                    product.imageUrl = item.imageUrl;
        //                    product.previewUrl = item.previewUrl;
        //                    product.theaterId = item.theaterId;
        //                    product.theaterUrl = item.theaterUrl;
        //                    product.musicId = item.musicId;
        //                    product.musicUrl = item.musicUrl;
        //                    product.productUrl = item.productUrl;
        //                    product.theaterDuration = item.theaterDuration;
        //                    product.musicDuration = item.musicDuration;
        //                    product.lastDuration = item.lastDuration;
        //                    product.productPoints = Convert.ToDouble(item.productPoints);
        //                    product.displayOrderNumber = Convert.ToInt64(item.displayOrderNumber.ToString());
        //                    product.isMusicFavorite = item.isMusicFavorite;
        //                    product.isTheaterFavorite = item.isTheaterFavorite;
        //                    product.isMusicInPlayList = item.isMusicInPlayList;
        //                    product.isTheaterInPlayList = item.isTheaterInPlayList;
        //                    product.backgroundImage = item.backgroundImage;
        //                    product.isMusicInKeepListening = item.isMusicInKeepListening;
        //                    product.isTheaterInKeepListening = item.isTheaterInKeepListening;
        //                    product.isFavorite = item.isFavorite;

        //                    product.categoryIdList = dbset
        //                .Join(context.Set<ProductWithCategory>(), Products => Products.ProductSeqID, ProductWithCategory => ProductWithCategory.ProductSeqID, (P, PC) => new
        //                {
        //                    Products = P,
        //                    ProductWithCategory = PC
        //                }).Where(I => I.Products.Status == true && I.Products.ProductSeqID == item.productId).Select(sc => sc.ProductWithCategory.Category.CategorySeqID).ToList();

        //                    product.releaseDate = item.releaseDate;
        //                    product.productAttributeList = attributeStaticValueRepository.GetHomeProductAttribute(item.productId);
        //                    product.categoryName = item.categoryName;
        //                    productList.Add(product);
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    productsSearchApi.Products = productList;
        //    return productsSearchApi;
        //}
        public List<Products> HomePageMostListened(int languageID)
        {
            string sql = "exec GetMostListened @languageID= " + languageID;
            var products = dbset.FromSqlRaw(sql).ToList();
            return products;
        }

        public List<Products> HomePageMostListenedByMedayType(int languageID, int medyaType)
        {
            string sql = "exec GetMostListenedByMedayType @languageID= " + languageID + ", @medyaType= " + medyaType;
            var products = dbset.FromSqlRaw(sql).ToList();
            return products;
        }

        public List<Products> GetLastCreadedProductByMedayType(int languageID, int medyaType)
        {
            string sql = "exec GetLastCreadedProductByMedayType @languageID= " + languageID + ", @medyaType= " + medyaType;
            var products = dbset.FromSqlRaw(sql).ToList();
            return products;
        }

        public List<ProductDetailForMobile> GetProductDetailForMobile(int productID, string customer_def_no)
        {
            throw new NotImplementedException();
        }
    }
}
