using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Bll.Base;
using Quki.Common;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Entity.Parameters;
using Quki.Interface;

namespace Quki.Bll
{
    public class CustomerTrackingTypeManager : BllBase<CustomerTrackingType, AddCustomerTrackingTypeRequest>, ICustomerTrackingTypeService

    {
        public readonly ICustomerTrackingTypeRepository repo;
        public readonly ICustomerTrackingTypeRepository customerTrackingTypeRepository;
        public readonly ICustomerRatingsRepository customerRatingsRepository;
        public readonly IProductImagesRepository productImagesRepository;
        public readonly IProductsRepository productRepository;
        public readonly ICustomerFovoriListRepository customerFovoriListRepository;
        public readonly IProductWithCategoryRepository productWithCategoryRepository;
        public readonly IAttributeStaticValueRepository attributeStaticValueRepository;
        public readonly ICategoryRepository categoryRepository;

        public CustomerTrackingTypeManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<ICustomerTrackingTypeRepository>();
            customerTrackingTypeRepository = service.GetService<ICustomerTrackingTypeRepository>();
            customerRatingsRepository = service.GetService<ICustomerRatingsRepository>();
            productImagesRepository = service.GetService<IProductImagesRepository>();
            productRepository = service.GetService<IProductsRepository>();
            customerFovoriListRepository = service.GetService<ICustomerFovoriListRepository>();
            productWithCategoryRepository = service.GetService<IProductWithCategoryRepository>();
            attributeStaticValueRepository = service.GetService<IAttributeStaticValueRepository>();
            categoryRepository = service.GetService<ICategoryRepository>();
        }
        public List<Product> GetCustomerTrackingTypeApi(int Count, string customer_def_no, int LanguageID)
        {
            List<Product> result = new List<Product>();
            try
            {

                Random rastgele = new Random();
                var list = TGetList()
                     .Join(productImagesRepository.TGetList(), CustomerTrackingType => CustomerTrackingType.RelatedTrackingSeqID, PC => PC.ProductImageSeqID, (C, P) => new
                     {
                         C = C,
                         PI = P
                     })
                    .Join(productRepository.TGetList(), CI => CI.PI.ProductSeqID, P => P.ProductSeqID, (CI, PP) => new
                    {
                        CF = CI,
                        P = PP
                    })
                    .Where(W => W.CF.C.Customer_def_no == customer_def_no && W.CF.C.TrackingTypeSeqID == 100 && W.P.LanguageID == LanguageID).Select(S => new Product
                    {
                        productId = S.P.ProductSeqID,
                        productName = S.P.ProductName,
                        secondName = S.P.SecondName,
                        description = Functions.StripHTML(S.P.Description),
                        imageUrl = ApiParameters.URL + S.P.ImageThumbPath,
                        previewUrl = ApiParameters.URL + S.CF.PI.ImagePath,
                        theaterId = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? 0 : S.CF.PI.ProductImageSeqID,
                        theaterUrl = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? "" : ApiParameters.URL + S.CF.PI.ImagePath,
                        musicId = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? S.CF.PI.ProductImageSeqID : 0,
                        musicUrl = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? ApiParameters.URL + S.CF.PI.ImagePath : "",
                        productUrl = ApiParameters.URL + "/Product/GetProductDetail/" + S.P.ProductSeqID.ToString(),
                        theaterDuration = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? 0 : customerTrackingTypeRepository.GetCustomerTrackingTypeLastApi(customer_def_no, S.CF.PI.ProductImageSeqID),
                        musicDuration = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? customerTrackingTypeRepository.GetCustomerTrackingTypeLastApi(customer_def_no, S.CF.PI.ProductImageSeqID) : 0,
                        lastDuration = customerTrackingTypeRepository.GetCustomerTrackingTypeLastApi(customer_def_no, S.CF.PI.ProductImageSeqID),
                        productPoints = Convert.ToDouble(customerRatingsRepository.ProductPoint(S.P.ProductSeqID)),
                        displayOrderNumber = S.CF.C.CustomerTrackingTypeSeqID,
                        isMusicFavorite =
                     customerFovoriListRepository.TGetList().Join(productImagesRepository.TGetList(), CF => CF.RelatedFavoritesListSeqID, Img => Img.ProductImageSeqID, (C, I) => new
                     {
                         C = C,
                         I = I
                     })
                     .Where(
                         w => w.I.GroupId == ApiProductMediaGroupType.Tamami && w.I.MediaTypeId == ApiProductMediaType.Muzik && w.C.customer_def_no == customer_def_no && w.C.RelatedFavoritesListSeqID == w.I.ProductImageSeqID && w.I.ProductSeqID == S.P.ProductSeqID && w.C.GroupID == ApiFavoriListType.Favorite && w.C.IsActive == true
                     ).Select(sci => sci.I.ProductImageSeqID).ToList().Count > 0 ? true : false,



                        isTheaterFavorite =
                     customerFovoriListRepository.TGetList().Join(productImagesRepository.TGetList(), CF => CF.RelatedFavoritesListSeqID, Img => Img.ProductImageSeqID, (C, I) => new
                      {
                          C = C,
                          I = I
                      })
                     .Where(
                         w => w.I.GroupId == ApiProductMediaGroupType.Tamami && w.I.MediaTypeId == ApiProductMediaType.Tiyatro && w.C.customer_def_no == customer_def_no && w.C.RelatedFavoritesListSeqID == w.I.ProductImageSeqID && w.I.ProductSeqID == S.P.ProductSeqID && w.C.GroupID == ApiFavoriListType.Favorite && w.C.IsActive == true
                     ).Select(sci => sci.I.ProductImageSeqID).ToList().Count > 0 ? true : false,

                        isMusicInPlayList = false,
                        isTheaterInPlayList = false,
                        isMusicInKeepListening = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? true : false,
                        isTheaterInKeepListening = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? false : true,
                        //favoriteMediaId = new List<int>() { S.CF.PI.ProductImageSeqID },
                        isFavorite = false,
                        categoryIdList = productRepository.TGetList()
                     .Join(productWithCategoryRepository.TGetList(), Products => Products.ProductSeqID, ProductWithCategory => ProductWithCategory.ProductSeqID, (P, PC) => new
                     {
                         Products = P,
                         ProductWithCategory = PC
                     }).Where(I => I.Products.Status == true && I.Products.ProductSeqID == S.P.ProductSeqID).Select(sc => sc.ProductWithCategory.Category.CategorySeqID).ToList(),
                        releaseDate = S.P.ReleaseDate,
                        productAttributeList = attributeStaticValueRepository.GetHomeProductAttribute(S.P.ProductSeqID),
                        categoryName =
                         categoryRepository.TGetList().Join(productWithCategoryRepository.TGetList(), C => C.CategorySeqID, pc => pc.CategorySeqID, (C, PC) => new
                         {
                             C = C,
                             PC = PC
                         }).Where(w => w.PC.ProductSeqID == S.P.ProductSeqID && w.C.Status == true).FirstOrDefault().C.Name
                    })
                    .OrderByDescending(o => o.displayOrderNumber)
                    .Take(Count)
                    .ToList();
                result = list;
            }
            catch (Exception ex) { }
            return result;
        }
        public void AddCustomerTrackingTypeApi(AddCustomerTrackingTypeRequest addCustomerTrackingTypeApi)
        {
            CustomerTrackingType customerTrackingType = new CustomerTrackingType();
            customerTrackingType.TrackingTypeSeqID = addCustomerTrackingTypeApi.TrackingTypeSeqID;
            customerTrackingType.Customer_def_no = addCustomerTrackingTypeApi.customerDefNo;
            customerTrackingType.RelatedTrackingSeqID = addCustomerTrackingTypeApi.ProductSeqID;
            customerTrackingType.Minute = addCustomerTrackingTypeApi.Second;
            customerTrackingType.IsShowUserScreen = true;
            customerTrackingType.FunctionEnterDateTime = DateTime.Now;
            customerTrackingType.FunctionExitDateTime = customerTrackingType.FunctionEnterDateTime;
            TAdd(customerTrackingType);
        }
        public int GetCustomerTrackingTypeLastApi(string customer_def_no, int ProductImageSeqID)
        {
            Random rastgele = new Random();
            
            int result = 0;
            try
            {
                result = TGetList()
                     .Join(productImagesRepository.TGetList(), CustomerTrackingType => CustomerTrackingType.RelatedTrackingSeqID, PC => PC.ProductImageSeqID, (C, P) => new
                     {
                         C = C,
                         PI = P
                     })
                    .Join(productRepository.TGetList(), CI => CI.PI.ProductSeqID, P => P.ProductSeqID, (CI, PP) => new
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
        public int? GetCustomerToDayListenTimeApi(string customer_def_no)
        {
            int? returnResult = 0;
            Random rastgele = new Random();
           
            var result = TGetList()
                     .Join(productImagesRepository.TGetList(), CustomerTrackingType => CustomerTrackingType.RelatedTrackingSeqID, PC => PC.ProductImageSeqID, (C, P) => new
                     {
                         C = C,
                         PI = P
                     })
                    .Join(productRepository.TGetList(), CI => CI.PI.ProductSeqID, P => P.ProductSeqID, (CI, PP) => new
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
        public void UpdateListenTimeApi(AddCustomerTrackingTypeRequest addCustomerTrackingTypeApi)
        {
            var customerTrackingTypes = TGetList()
                .Where(w => w.TrackingTypeSeqID == 101 && w.Minute == 0 && w.Customer_def_no == addCustomerTrackingTypeApi.customerDefNo).ToList();
            if (customerTrackingTypes != null)
            {
                foreach (var customerTrackingType in customerTrackingTypes)
                {
                    customerTrackingType.FunctionExitDateTime = DateTime.Now;
                    customerTrackingType.Minute = (int)(DateTime.Now - Convert.ToDateTime(customerTrackingType.FunctionEnterDateTime)).TotalSeconds;
                    TUpdate(customerTrackingType);
                }
            }
        }
        public List<Product> GetCustomerTrackingTypeSP(int Count, string customer_def_no, int LanguageID)
        {
            List<Product> productList = new List<Product>();
           try
            {
                string sql = "exec GetCustomerTrackingTypeSP @customer_def_no='" + customer_def_no + "' , @languageId=" + LanguageID;
                var products = repo.ExecuteSql(sql);
                int index = 0;
                if (products != null)
                {
                    if (products.Count > 0)
                    {
                        foreach (var item in products)
                        {
                            if (index > Count)
                                break;
                            index = index + 1;
                            Product product = new Product();
                            product.productId = item.productId;
                            product.productName = item.productName;
                            product.secondName = item.secondName;
                            product.description = Functions.StripHTML(item.description);
                            product.imageUrl = item.imageUrl;
                            product.previewUrl = item.previewUrl;
                            product.backgroundImage = item.backgroundImage;
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

                            product.isMusicInKeepListening = item.isMusicInKeepListening;
                            product.isTheaterInKeepListening = item.isTheaterInKeepListening;
                            product.isFavorite = item.isFavorite;

                            product.categoryIdList = productRepository.TGetList()
                        .Join(productWithCategoryRepository.TGetList(), Products => Products.ProductSeqID, ProductWithCategory => ProductWithCategory.ProductSeqID, (P, PC) => new
                        {
                            Products = P,
                            ProductWithCategory = PC
                        }).Where(I => I.Products.Status == true && I.Products.ProductSeqID == item.productId).Select(sc => sc.ProductWithCategory.CategorySeqID).ToList();

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
        public bool ControlStopPorcess(string customer_def_no)
        {
            bool result = false;
            var lastItem = customerTrackingTypeRepository.TGetList(w => w.Customer_def_no == customer_def_no).LastOrDefault();
            if (lastItem != null)
            {
                if (lastItem.RelatedTrackingTypeID != 100)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
