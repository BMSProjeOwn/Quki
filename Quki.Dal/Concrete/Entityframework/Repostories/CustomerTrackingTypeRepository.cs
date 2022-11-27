using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Entity.Parameters;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class CustomerTrackingTypeRepository : GenericRepository<CustomerTrackingType>, ICustomerTrackingTypeRepository
    {
        public CustomerTrackingTypeRepository(DbContext context):base(context)
        {
        }
        //public List<Product> GetCustomerTrackingTypeApi(int Count, string customer_def_no, int LanguageID)
        //{
        //    List<Product> result = new List<Product>();
        //    try
        //    {
        //        CustomerTrackingTypeRepository customerTrackingTypeRepostories = new CustomerTrackingTypeRepository(context);
        //        CustomerRatingsRepository ratingsRepository = new CustomerRatingsRepository(context);
        //        Random rastgele = new Random();
        //        ProductImagesRepository productImagesRepository = new ProductImagesRepository(context);
        //        AttributeStaticValueRepository attributeStaticValueRepository = new AttributeStaticValueRepository(context);
        //        var list = dbset
        //             .Join(context.Set<ProductImage>(), CustomerTrackingType => CustomerTrackingType.RelatedTrackingSeqID, PC => PC.ProductImageSeqID, (C, P) => new
        //             {
        //                 C = C,
        //                 PI = P
        //             })
        //            .Join(context.Set<Products>(), CI => CI.PI.ProductSeqID, P => P.ProductSeqID, (CI, PP) => new
        //            {
        //                CF = CI,
        //                P = PP
        //            })
        //            .Where(W => W.CF.C.Customer_def_no == customer_def_no && W.CF.C.TrackingTypeSeqID == 100 && W.P.LanguageID == LanguageID).Select(S => new Product
        //            {
        //                productId = S.P.ProductSeqID,
        //                productName = S.P.ProductName,
        //                secondName = S.P.SecondName,
        //                description = Functions.StripHTML(S.P.Description),
        //                imageUrl = ApiParameters.URL + S.P.ImageThumbPath,
        //                previewUrl = ApiParameters.URL + S.CF.PI.ImagePath,
        //                theaterId = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? 0 : S.CF.PI.ProductImageSeqID,
        //                theaterUrl = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? "" : ApiParameters.URL + S.CF.PI.ImagePath,
        //                musicId = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? S.CF.PI.ProductImageSeqID : 0,
        //                musicUrl = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? ApiParameters.URL + S.CF.PI.ImagePath : "",
        //                productUrl = ApiParameters.URL + "/Product/GetProductDetail/" + S.P.ProductSeqID.ToString(),
        //                theaterDuration = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? 0 : customerTrackingTypeRepostories.GetCustomerTrackingTypeLastApi(customer_def_no, S.CF.PI.ProductImageSeqID),
        //                musicDuration = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? customerTrackingTypeRepostories.GetCustomerTrackingTypeLastApi(customer_def_no, S.CF.PI.ProductImageSeqID) : 0,
        //                lastDuration = customerTrackingTypeRepostories.GetCustomerTrackingTypeLastApi(customer_def_no, S.CF.PI.ProductImageSeqID),
        //                productPoints = Convert.ToDouble(ratingsRepository.ProductPoint(S.P.ProductSeqID)),
        //                displayOrderNumber = S.CF.C.CustomerTrackingTypeSeqID,
        //                isMusicFavorite =
        //             context.Set<CustomerFavoritesList>().Join(context.Set<ProductImage>(), CF => CF.RelatedFavoritesListSeqID, Img => Img.ProductImageSeqID, (C, I) => new
        //             {
        //                 C = C,
        //                 I = I
        //             })
        //             .Where(
        //                 w => w.I.GroupId == ApiProductMediaGroupType.Tamami && w.I.MediaTypeId == ApiProductMediaType.Muzik && w.C.customer_def_no == customer_def_no && w.C.RelatedFavoritesListSeqID == w.I.ProductImageSeqID && w.I.ProductSeqID == S.P.ProductSeqID && w.C.GroupID == ApiFavoriListType.Favorite && w.C.IsActive == true
        //             ).Select(sci => sci.I.ProductImageSeqID).ToList().Count > 0 ? true : false,
        public int? GetCustomerToDayListenTimeApi(string customer_def_no)
        {
            int? returnResult = 0;
            Random rastgele = new Random();

            var result = TGetList()
                     .Join(context.Set<ProductImage>().ToList(), CustomerTrackingType => CustomerTrackingType.RelatedTrackingSeqID, PC => PC.ProductImageSeqID, (C, P) => new
                     {
                         C = C,
                         PI = P
                     })
                    .Join(context.Set<Products>().ToList(), CI => CI.PI.ProductSeqID, P => P.ProductSeqID, (CI, PP) => new
                    {
                        CF = CI,
                        P = PP
                    })
                    .Where(W => W.CF.C.Customer_def_no == customer_def_no && W.CF.C.TrackingTypeSeqID == 101 && W.CF.C.FunctionEnterDateTime > DateTime.Now.Date).Select(s => s.CF.C)
                    .OrderByDescending(o => o.CustomerTrackingTypeSeqID).ToList();

            if (result != null)
            {
                foreach (var item in result)
                {
                    returnResult = returnResult + item.Minute;
                }
            }
            return returnResult;
        }

        public int GetCustomerTrackingTypeLastApi(string customer_def_no, int ProductImageSeqID)
        {
            Random rastgele = new Random();

            int result = 0;
            try
            {
                result = TGetList()
                     .Join(context.Set<ProductImage>().ToList(), CustomerTrackingType => CustomerTrackingType.RelatedTrackingSeqID, PC => PC.ProductImageSeqID, (C, P) => new
                     {
                         C = C,
                         PI = P
                     })
                    .Join(context.Set<Products>().ToList(), CI => CI.PI.ProductSeqID, P => P.ProductSeqID, (CI, PP) => new
                    {
                        CF = CI,
                        P = PP
                    })
                    .Where(W => W.CF.C.Customer_def_no == customer_def_no && W.CF.C.TrackingTypeSeqID == 100 && W.CF.PI.ProductImageSeqID == ProductImageSeqID).Select(s => s.CF.C)
                    .OrderByDescending(o => o.CustomerTrackingTypeSeqID).FirstOrDefault().Minute;
            }
            catch { }
            if (result == null)
                result = 0;
            return result;
        }
        //                isTheaterFavorite =
        //              context.Set<CustomerFavoritesList>().Join(context.Set<ProductImage>(), CF => CF.RelatedFavoritesListSeqID, Img => Img.ProductImageSeqID, (C, I) => new
        //              {
        //                  C = C,
        //                  I = I
        //              })
        //             .Where(
        //                 w => w.I.GroupId == ApiProductMediaGroupType.Tamami && w.I.MediaTypeId == ApiProductMediaType.Tiyatro && w.C.customer_def_no == customer_def_no && w.C.RelatedFavoritesListSeqID == w.I.ProductImageSeqID && w.I.ProductSeqID == S.P.ProductSeqID && w.C.GroupID == ApiFavoriListType.Favorite && w.C.IsActive == true
        //             ).Select(sci => sci.I.ProductImageSeqID).ToList().Count > 0 ? true : false,

        //                isMusicInPlayList = false,
        //                isTheaterInPlayList = false,
        //                isMusicInKeepListening = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? true : false,
        //                isTheaterInKeepListening = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? false : true,
        //                //favoriteMediaId = new List<int>() { S.CF.PI.ProductImageSeqID },
        //                isFavorite = false,
        //                categoryIdList = context.Set<Products>()
        //             .Join(context.Set<ProductWithCategory>(), Products => Products.ProductSeqID, ProductWithCategory => ProductWithCategory.ProductSeqID, (P, PC) => new
        //             {
        //                 Products = P,
        //                 ProductWithCategory = PC
        //             }).Where(I => I.Products.Status == true && I.Products.ProductSeqID == S.P.ProductSeqID).Select(sc => sc.ProductWithCategory.Category.CategorySeqID).ToList(),
        //                releaseDate = S.P.ReleaseDate,
        //                productAttributeList = attributeStaticValueRepository.GetHomeProductAttribute(S.P.ProductSeqID),
        //                categoryName =
        //                 context.Set<Category>().Join(context.Set<ProductWithCategory>(), C => C.CategorySeqID, pc => pc.CategorySeqID, (C, PC) => new
        //                 {
        //                     C = C,
        //                     PC = PC
        //                 }).Where(w => w.PC.ProductSeqID == S.P.ProductSeqID && w.C.Status == true).FirstOrDefault().C.Name
        //            })
        //            .OrderByDescending(o => o.displayOrderNumber)
        //            .Take(Count)
        //            .ToList();
        //        result = list;
        //    }
        //    catch (Exception ex) { }
        //    return result;
        //}

        //public void AddCustomerTrackingTypeApi(AddCustomerTrackingTypeRequest addCustomerTrackingTypeApi)
        //{
        //    CustomerTrackingType customerTrackingType = new CustomerTrackingType();
        //    customerTrackingType.TrackingTypeSeqID = addCustomerTrackingTypeApi.TrackingTypeSeqID;
        //    customerTrackingType.Customer_def_no = addCustomerTrackingTypeApi.customerDefNo;
        //    customerTrackingType.RelatedTrackingSeqID = addCustomerTrackingTypeApi.ProductSeqID;
        //    customerTrackingType.Minute = addCustomerTrackingTypeApi.Second;
        //    customerTrackingType.IsShowUserScreen = true;
        //    customerTrackingType.FunctionEnterDateTime = DateTime.Now;
        //    customerTrackingType.FunctionExitDateTime = customerTrackingType.FunctionEnterDateTime;
        //    TAdd(customerTrackingType);
        //}


        //public int GetCustomerTrackingTypeLastApi(string customer_def_no, int ProductImageSeqID)
        //{
        //    CustomerRatingsRepository ratingsRepository = new CustomerRatingsRepository(context);
        //    Random rastgele = new Random();
        //    ProductImagesRepository productImagesRepository = new ProductImagesRepository(context);
        //    IAttributeStaticValueRepository attributeStaticValueRepository = new AttributeStaticValueRepository(context);

        //    int result = 0;
        //    try
        //    {
        //        result = context.Set<CustomerTrackingType>()
        //             .Join(context.Set<ProductImage>(), CustomerTrackingType => CustomerTrackingType.RelatedTrackingSeqID, PC => PC.ProductImageSeqID, (C, P) => new
        //             {
        //                 C = C,
        //                 PI = P
        //             })
        //            .Join(context.Set<Products>(), CI => CI.PI.ProductSeqID, P => P.ProductSeqID, (CI, PP) => new
        //            {
        //                CF = CI,
        //                P = PP
        //            })
        //            .Where(W => W.CF.C.Customer_def_no == customer_def_no && W.CF.C.TrackingTypeSeqID == 100 && W.CF.PI.ProductImageSeqID == ProductImageSeqID).Select(s => s.CF.C)
        //            .OrderByDescending(o => o.CustomerTrackingTypeSeqID).FirstOrDefault().Minute;
        //    }
        //    catch { }
        //    if (result == null)
        //        result = 0;
        //    return result;
        //}


        //public int? GetCustomerToDayListenTimeApi(string customer_def_no)
        //{
        //    int? returnResult = 0;
        //    CustomerRatingsRepository ratingsRepository = new CustomerRatingsRepository(context);
        //    Random rastgele = new Random();
        //    ProductImagesRepository productImagesRepository = new ProductImagesRepository(context);
        //    IAttributeStaticValueRepository attributeStaticValueRepository = new AttributeStaticValueRepository(context);

        //    var result = context.Set<CustomerTrackingType>()
        //             .Join(context.Set<ProductImage>(), CustomerTrackingType => CustomerTrackingType.RelatedTrackingSeqID, PC => PC.ProductImageSeqID, (C, P) => new
        //             {
        //                 C = C,
        //                 PI = P
        //             })
        //            .Join(context.Set<Products>(), CI => CI.PI.ProductSeqID, P => P.ProductSeqID, (CI, PP) => new
        //            {
        //                CF = CI,
        //                P = PP
        //            })
        //            .Where(W => W.CF.C.Customer_def_no == customer_def_no && W.CF.C.TrackingTypeSeqID == 101 && W.CF.C.FunctionEnterDateTime > DateTime.Now.Date).Select(s => s.CF.C)
        //            .OrderByDescending(o => o.CustomerTrackingTypeSeqID).ToList();

        //    if (result != null)
        //    {
        //        foreach (var item in result)
        //        {
        //            returnResult = returnResult + item.Minute;
        //        }
        //    }
        //    return returnResult;
        //}

        //public void UpdateListenTimeApi(AddCustomerTrackingTypeRequest addCustomerTrackingTypeApi)
        //{
        //    var customerTrackingTypes = context.Set<CustomerTrackingType>()
        //        .Where(w => w.TrackingTypeSeqID == 101 && w.Minute == 0 && w.Customer_def_no == addCustomerTrackingTypeApi.customerDefNo).ToList();
        //    if (customerTrackingTypes != null)
        //    {
        //        foreach (var customerTrackingType in customerTrackingTypes)
        //        {
        //            customerTrackingType.FunctionExitDateTime = DateTime.Now;
        //            customerTrackingType.Minute = (int)(DateTime.Now - Convert.ToDateTime(customerTrackingType.FunctionEnterDateTime)).TotalSeconds;
        //            TUpdate(customerTrackingType);
        //        }
        //    }
        //}

        public List<SelectHomeProduct> ExecuteSql(string sql)
        {

            return context.Set<SelectHomeProduct>().FromSqlRaw(sql).ToList();


        }

        //public bool ControlStopPorcess(string customer_def_no)
        //{
        //    bool result = false;
        //    var lastItem = context.Set<CustomerTrackingType>().Where(w => w.Customer_def_no == customer_def_no).LastOrDefault();
        //    if (lastItem != null)
        //    {
        //        if (lastItem.RelatedTrackingTypeID != 100)
        //        {
        //            result = true;
        //        }
        //    }
        //    return result;
        //}
    }
}
