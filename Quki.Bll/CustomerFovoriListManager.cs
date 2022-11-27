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
using Quki.Entity.ViewModel;
using Quki.Interface;

namespace Quki.Bll
{
    public class CustomerFovoriListManager : BllBase<CustomerFavoritesList, CustomerFovoriListApiModel>, ICustomerFovoriListService
    {
        private readonly ICustomerFovoriListRepository repo;
        private readonly ICustomerTrackingTypeRepository customerTrackingTypeRepostories;
        private readonly ICustomerRatingsRepository customerRatingsRepository;
        private readonly IProductsRepository productsRepository;
        private readonly IAttributeStaticValueRepository attributeStaticValueRepository;
        private readonly IProductImagesRepository productImagesRepository;
        private readonly IProductWithCategoryRepository productWithCategoryRepository;
        private readonly ICategoryRepository categoryRepository;
        public CustomerFovoriListManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<ICustomerFovoriListRepository>();
            customerTrackingTypeRepostories = service.GetService<ICustomerTrackingTypeRepository>();
            customerRatingsRepository = service.GetService<ICustomerRatingsRepository>();
            productsRepository = service.GetService<IProductsRepository>();
            attributeStaticValueRepository = service.GetService<IAttributeStaticValueRepository>();
            productImagesRepository = service.GetService<IProductImagesRepository>();
            productWithCategoryRepository = service.GetService<IProductWithCategoryRepository>();
            categoryRepository = service.GetService<ICategoryRepository>();
        }
        public void AddCustomerFavoriList(CustomerFovoriListApiModel model)
        {
            CustomerFavoritesList customerFavoritesList = new CustomerFavoritesList();
            customerFavoritesList.customer_def_no = model.customerDefNo;
            customerFavoritesList.FavoritesListDefSeqID = model.FavoritesListDefSeqID;
            customerFavoritesList.RelatedFavoritesListSeqID = model.productId;
            customerFavoritesList.CreatedOn = DateTime.Now;
            customerFavoritesList.IsActive = true;
            customerFavoritesList.GroupID = model.GroupID;
            var value = TGetList(W => W.customer_def_no == model.customerDefNo && W.IsActive == true && W.RelatedFavoritesListSeqID == model.productId && W.GroupID == model.GroupID).ToList();
            if (value.Count <= 0)
                TAdd(customerFavoritesList);
        }
        public void DeleteCustomerFavoriList(CustomerFovoriListApiModel model)
        {
            var value = TGetList(W => W.customer_def_no == model.customerDefNo
                && W.IsActive == true
                && W.RelatedFavoritesListSeqID == model.productId
                && W.GroupID == model.GroupID
                && W.FavoritesListDefSeqID == model.FavoritesListDefSeqID).ToList();
            foreach (var item in value)
            {
                item.IsActive = false;
                TUpdate(item);
            }
        }
        public void DeleteListOfCustomerFavoriList(string customer_def_no) 
        {
            var value = TGetList(W => W.customer_def_no == customer_def_no).ToList();
            foreach (var item in value)
            {
                item.IsActive = false;
                TUpdate(item);
            }
        }
        public List<CustomerFavoritesList> getCustomerFovoriList(string customer_def_no) 
        {
            return TGetList(W => W.customer_def_no == customer_def_no && W.IsActive == true).ToList();
        }
        public List<CustomerFavoritesList> getCustomerFovoriListWithType(string customer_def_no, int? TypeID)
        { 
            return repo.getCustomerFovoriListWithType(customer_def_no, TypeID); 
        }
        public List<Product> getCustomerFovoriListApi(string customer_def_no) 
        {
            
            Random rastgele = new Random();

            var products = TGetList()
                .Join(productImagesRepository.TGetList(), CustomerFavoritesList => CustomerFavoritesList.RelatedFavoritesListSeqID, PC => PC.ProductImageSeqID, (C, P) => new
                {
                    C = C,
                    PI = P
                })
                .Join(productsRepository.TGetList(), CI => CI.PI.ProductSeqID, P => P.ProductSeqID, (CI, PP) => new
                {
                    CF = CI,
                    P = PP
                })
                .Where(W => W.CF.C.customer_def_no == customer_def_no && W.CF.C.IsActive == true).Select(S => new Product
                {
                    productId = S.P.ProductSeqID,
                    productName = S.P.ProductName,
                    secondName = S.P.SecondName,
                    description = Functions.StripHTML(S.P.Description),
                    imageUrl = ApiParameters.URL + S.P.ImageThumbPath,
                    previewUrl = ApiParameters.URL + S.CF.PI.ImagePath,
                    theaterId = productImagesRepository.TGetList(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Tiyatro && w.ProductSeqID == S.P.ProductSeqID && w.IsDeleted == false && w.Status == true).Select(s => s.ProductImageSeqID).FirstOrDefault(),
                    theaterUrl = ApiParameters.URL + productImagesRepository.TGetList(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Tiyatro && w.ProductSeqID == S.P.ProductSeqID && w.IsDeleted == false && w.Status == true).Select(s => s.ImagePath).FirstOrDefault(),
                    musicId = productImagesRepository.TGetList(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Muzik && w.ProductSeqID == S.P.ProductSeqID && w.IsDeleted == false && w.Status == true).Select(s => s.ProductImageSeqID).FirstOrDefault(),
                    musicUrl = ApiParameters.URL + productImagesRepository.TGetList(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Muzik && w.ProductSeqID == S.P.ProductSeqID && w.IsDeleted == false && w.Status == true).Select(s => s.ImagePath).FirstOrDefault(),
                    productUrl = ApiParameters.URL + "/Product/GetProductDetail/" + S.P.ProductSeqID.ToString(),
                    theaterDuration = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? 0 : customerTrackingTypeRepostories.GetCustomerTrackingTypeLastApi(customer_def_no, S.CF.PI.ProductImageSeqID),
                    musicDuration = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? customerTrackingTypeRepostories.GetCustomerTrackingTypeLastApi(customer_def_no, S.CF.PI.ProductImageSeqID) : 0,
                    lastDuration = 0,
                    isMusicInPlayList = false,
                    isTheaterInPlayList = false,
                    isMusicInKeepListening = false,
                    isTheaterInKeepListening = false,
                    productPoints = Convert.ToDouble(customerRatingsRepository.ProductPoint(S.P.ProductSeqID)),
                    displayOrderNumber = S.P.DisplayOrderNumber,
                    //favoriteMediaId = new List<int>() { S.CF.PI.ProductImageSeqID },
                    isMusicFavorite = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? true : false,
                    isTheaterFavorite = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? false : true,
                    isFavorite = false,

                    categoryIdList = productsRepository.TGetList()
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
                }).ToList();
            return products;
        }
        public List<Product> GetCustomerFavoriListFromSP(string customer_def_no, int languageId) 
        { 
            List<Product> productList = new List<Product>();
            var products= repo.GetCustomerFavoriListFromSP(customer_def_no, languageId);
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
                        product.description = Functions.StripHTML(item.description);
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
                        product.categoryIdList = productWithCategoryRepository.TGetList(x => x.ProductSeqID == item.productId).ToList().Select(sc => sc.CategorySeqID).ToList(); ; ;
                        
                        product.releaseDate = item.releaseDate;
                        product.productAttributeList = attributeStaticValueRepository.GetHomeProductAttribute(item.productId);
                        product.categoryName = item.categoryName;
                        productList.Add(product);
                    }
                }
            }
            return productList;
        }

    }
}
