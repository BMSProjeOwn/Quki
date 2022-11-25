using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Bll.Base;
using Quki.Common;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Entity.Parameters;
using Quki.Interface;

namespace Quki.Bll
{
    public class PlayListManager : BllBase<PlayList, PlayListModel>, IPlayListService
    {
        public readonly IPlayListRepository repo;
        public readonly ICustomerTrackingTypeRepository customerTrackingTypeRepository;
        public readonly ICustomerRatingsRepository customerRatingsRepository;
        public readonly IAttributeStaticValueRepository attributeStaticValueRepository;
        public readonly IPlayListDetailRepository playListDetailRepository;
        public readonly IProductImagesRepository productImagesRepository;
        public readonly IProductsRepository productRepository;
        public readonly ICustomerFovoriListRepository customerFovoriListRepository;
        public readonly IProductWithCategoryRepository productWithCategoryRepository;
        public readonly ICategoryRepository categoryRepository;
        public PlayListManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IPlayListRepository>();
            customerTrackingTypeRepository = service.GetService<ICustomerTrackingTypeRepository>();
            customerRatingsRepository = service.GetService<ICustomerRatingsRepository>();
            attributeStaticValueRepository = service.GetService<IAttributeStaticValueRepository>();
            playListDetailRepository = service.GetService<IPlayListDetailRepository>();
            productImagesRepository = service.GetService<IProductImagesRepository>();
            customerFovoriListRepository = service.GetService<ICustomerFovoriListRepository>();
            productWithCategoryRepository = service.GetService<IProductWithCategoryRepository>();
            categoryRepository = service.GetService<ICategoryRepository>();
            productRepository = service.GetService<IProductsRepository>();
            }
        public List<PlayListModelApi> GetCustomerPlayListApi(string customer_def_no, int count, int languageID)
        {
            Random rastgele = new Random();
           
            var playList = TGetList(w => w.IsDelet == false && w.IsActive == true && w.customer_def_seq == customer_def_no && w.LanguageID == languageID)
                .Select(s => new PlayListModelApi
                {
                    PlayListSeqID = s.PlayListSeqID,
                    Name = s.PlayListName,
                    ImagePath = ApiParameters.URL + "/AdminImage/ProductImg/PlayListIcon" + rastgele.Next(1, 4) + ".jpg",
                    productList = playListDetailRepository.TGetList()
                .Join(productImagesRepository.TGetList(), PlayListDetail => PlayListDetail.RelatedItemSeqID, PC => PC.ProductImageSeqID, (C, P) => new
                {
                    C = C,
                    PI = P
                })
                .Join(productRepository.TGetList(), CI => CI.PI.ProductSeqID, P => P.ProductSeqID, (CI, PP) => new
                {
                    CF = CI,
                    P = PP
                })
                .Where(W => W.CF.C.IsActive == true && W.CF.C.PlayListSeqID == s.PlayListSeqID).Select(S => new Product
                {
                   productName = S.P.ProductName,
                    secondName = S.P.SecondName,
                    description = Functions.StripHTML(S.P.Description),
                    imageUrl = ApiParameters.URL + S.P.ImageThumbPath,
                    previewUrl = ApiParameters.URL + S.CF.PI.ImagePath,
                    theaterId = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? 0 : S.CF.PI.ProductImageSeqID,
                    theaterUrl = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? "" : ApiParameters.URL + S.CF.PI.ImagePath,
                    musicId = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? S.CF.PI.ProductImageSeqID : 0,
                    musicUrl = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? ApiParameters.URL + S.CF.PI.ImagePath : "",
                    theaterDuration = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? 0 : customerTrackingTypeRepository.GetCustomerTrackingTypeLastApi(customer_def_no, S.CF.PI.ProductImageSeqID),
                    musicDuration = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? customerTrackingTypeRepository.GetCustomerTrackingTypeLastApi(customer_def_no, S.CF.PI.ProductImageSeqID) : 0,
                    isMusicInPlayList = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? true : false,
                    isTheaterInPlayList = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? false : true, productId = S.P.ProductSeqID,
                    
                    isMusicInKeepListening = false,
                    isTheaterInKeepListening = false,
                    lastDuration = 0,
                    productPoints = Convert.ToDouble(customerRatingsRepository.ProductPoint(S.P.ProductSeqID)),
                    displayOrderNumber = Convert.ToInt64(S.CF.C.DisplayOrderNumber.ToString()),
                    //favoriteMediaId = new List<int>() { S.CF.PI.ProductImageSeqID },
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
                }).OrderBy(op => op.displayOrderNumber).ToList()
                }).OrderByDescending(o => o.PlayListSeqID).Take(count).ToList();
            return playList;
        }

        public void CreatePlayListApi(CreatePlayListRequest createPlayListRequest)
        {
            PlayList playList = new PlayList();
            playList.customer_def_seq = createPlayListRequest.customerDefNo;
            playList.PlayListName = createPlayListRequest.playListName;
            playList.PlayListThumpImagePath = createPlayListRequest.imagePath;
            playList.CreatedOn = DateTime.Now;
            playList.LanguageID = createPlayListRequest.languageId;
            playList.IsActive = true;
            playList.IsDelet = false;
            TAdd(playList);
        }

        public void DeletePlayListApi(int? PlayListSeqID)
        {
            int id = Convert.ToInt32(PlayListSeqID.ToString());
            var value = TgetItemByID(id);
            value.IsDelet = true;
            value.IsActive = false;
            TUpdate(value);
        }


        public List<PlayListModelApi> GetCustomerPlayListSP(string customer_def_no, int count, int languageID)
        {
            List<PlayListModelApi> playListModelApis = new List<PlayListModelApi>();
            Random rastgele = new Random();
            
            var playList = TGetList(w => w.IsDelet == false && w.IsActive == true && w.customer_def_seq == customer_def_no && w.LanguageID == languageID).OrderByDescending(d => d.PlayListSeqID).Take(count).ToList();

            if (playList != null)
            {
                if (playList.Count > 0)
                {
                    foreach (var playListItem in playList)
                    {
                        PlayListModelApi playListModelApi = new PlayListModelApi();
                        playListModelApi.PlayListSeqID = playListItem.PlayListSeqID;
                        playListModelApi.Name = playListItem.PlayListName;
                        playListModelApi.ImagePath = ApiParameters.URL + "/AdminImage/ProductImg/PlayListIcon" + rastgele.Next(1, 4) + ".jpg";
                        playListModelApi.productList = new List<Product>();
                        try
                        {
                            string sql = "exec GetCustomerPlayListSP @customer_def_no='" + customer_def_no + "' , @languageId=" + languageID + " , @PlayListSeqID=" + playListItem.PlayListSeqID;
                            var products = repo.ExecuteSql(sql);
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
                                    }).Where(I => I.Products.Status == true && I.Products.ProductSeqID == item.productId)
                                    .Select(sc => sc.ProductWithCategory.CategorySeqID).ToList();

                                        product.releaseDate = item.releaseDate;
                                        product.productAttributeList = attributeStaticValueRepository.GetHomeProductAttribute(item.productId);
                                        product.categoryName = item.categoryName;
                                        playListModelApi.productList.Add(product);


                                    }
                                }
                            }
                            playListModelApis.Add(playListModelApi);

                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }

            return playListModelApis;
        }

    }
}
