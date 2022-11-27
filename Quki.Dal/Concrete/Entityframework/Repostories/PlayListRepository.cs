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
    public class PlayListRepository : GenericRepository<PlayList>, IPlayListRepository
    {
        public PlayListRepository(DbContext context) : base(context)
        {
            
        }
        //public List<PlayListModelApi> GetCustomerPlayListApi(string customer_def_no, int count, int languageID)
        //{
        //    CustomerTrackingTypeRepository customerTrackingTypeRepostories = new CustomerTrackingTypeRepository(context);
        //    CustomerRatingsRepository ratingsRepository = new CustomerRatingsRepository(context);
        //    Random rastgele = new Random();
        //    AttributeStaticValueRepository attributeStaticValueRepository = new AttributeStaticValueRepository(context);

        //    var playList = dbset.Where(w => w.IsDelet == false && w.IsActive == true && w.customer_def_seq == customer_def_no && w.LanguageID == languageID)
        //        .Select(s => new PlayListModelApi
        //        {
        //            PlayListSeqID = s.PlayListSeqID,
        //            Name = s.PlayListName,
        //            ImagePath = ApiParameters.URL + "/AdminImage/ProductImg/PlayListIcon" + rastgele.Next(1, 4) + ".jpg",
        //            productList = context.Set<PlayListDetail>()
        //        .Join(context.Set<ProductImage>(), PlayListDetail => PlayListDetail.RelatedItemSeqID, PC => PC.ProductImageSeqID, (C, P) => new
        //        {
        //            C = C,
        //            PI = P
        //        })
        //        .Join(context.Set<Products>(), CI => CI.PI.ProductSeqID, P => P.ProductSeqID, (CI, PP) => new
        //        {
        //            CF = CI,
        //            P = PP
        //        })
        //        .Where(W => W.CF.C.IsActive == true && W.CF.C.PlayListSeqID == s.PlayListSeqID).Select(S => new Product
        //        {
        //            productId = S.P.ProductSeqID,
        //            productName = S.P.ProductName,
        //            secondName = S.P.SecondName,
        //            description = Functions.StripHTML(S.P.Description),
        //            imageUrl = ApiParameters.URL + S.P.ImageThumbPath,
        //            previewUrl = ApiParameters.URL + S.CF.PI.ImagePath,
        //            theaterId = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? 0 : S.CF.PI.ProductImageSeqID,
        //            theaterUrl = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? "" : ApiParameters.URL + S.CF.PI.ImagePath,
        //            musicId = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? S.CF.PI.ProductImageSeqID : 0,
        //            musicUrl = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? ApiParameters.URL + S.CF.PI.ImagePath : "",
        //            theaterDuration = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? 0 : customerTrackingTypeRepostories.GetCustomerTrackingTypeLastApi(customer_def_no, S.CF.PI.ProductImageSeqID),
        //            musicDuration = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? customerTrackingTypeRepostories.GetCustomerTrackingTypeLastApi(customer_def_no, S.CF.PI.ProductImageSeqID) : 0,
        //            isMusicInPlayList = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? true : false,
        //            isTheaterInPlayList = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? false : true,
        //            isMusicInKeepListening = false,
        //            isTheaterInKeepListening = false,
        //            lastDuration = 0,
        //            productPoints = Convert.ToDouble(ratingsRepository.ProductPoint(S.P.ProductSeqID)),
        //            displayOrderNumber = Convert.ToInt64(S.CF.C.DisplayOrderNumber.ToString()),
        //            //favoriteMediaId = new List<int>() { S.CF.PI.ProductImageSeqID },
        //            isMusicFavorite =
        //        context.Set<CustomerFavoritesList>().Join(context.Set<ProductImage>(), CF => CF.RelatedFavoritesListSeqID, Img => Img.ProductImageSeqID, (C, I) => new
        //        {
        //            C = C,
        //            I = I
        //        })
        //        .Where(
        //            w => w.I.GroupId == ApiProductMediaGroupType.Tamami && w.I.MediaTypeId == ApiProductMediaType.Muzik && w.C.customer_def_no == customer_def_no && w.C.RelatedFavoritesListSeqID == w.I.ProductImageSeqID && w.I.ProductSeqID == S.P.ProductSeqID && w.C.GroupID == ApiFavoriListType.Favorite && w.C.IsActive == true
        //        ).Select(sci => sci.I.ProductImageSeqID).ToList().Count > 0 ? true : false,


        //            isTheaterFavorite =
        //         context.Set<CustomerFavoritesList>().Join(context.Set<ProductImage>(), CF => CF.RelatedFavoritesListSeqID, Img => Img.ProductImageSeqID, (C, I) => new
        //         {
        //             C = C,
        //             I = I
        //         })
        //        .Where(
        //            w => w.I.GroupId == ApiProductMediaGroupType.Tamami && w.I.MediaTypeId == ApiProductMediaType.Tiyatro && w.C.customer_def_no == customer_def_no && w.C.RelatedFavoritesListSeqID == w.I.ProductImageSeqID && w.I.ProductSeqID == S.P.ProductSeqID && w.C.GroupID == ApiFavoriListType.Favorite && w.C.IsActive == true
        //        ).Select(sci => sci.I.ProductImageSeqID).ToList().Count > 0 ? true : false,

        //            isFavorite = false,

        //            categoryIdList = context.Set<Products>()
        //        .Join(context.Set<ProductWithCategory>(), Products => Products.ProductSeqID, ProductWithCategory => ProductWithCategory.ProductSeqID, (P, PC) => new
        //        {
        //            Products = P,
        //            ProductWithCategory = PC
        //        }).Where(I => I.Products.Status == true && I.Products.ProductSeqID == S.P.ProductSeqID).Select(sc => sc.ProductWithCategory.Category.CategorySeqID).ToList(),
        //            releaseDate = S.P.ReleaseDate,
        //            productAttributeList = attributeStaticValueRepository.GetHomeProductAttribute(S.P.ProductSeqID),
        //            categoryName =
        //            context.Set<Category>().Join(context.Set<ProductWithCategory>(), C => C.CategorySeqID, pc => pc.CategorySeqID, (C, PC) => new
        //            {
        //                C = C,
        //                PC = PC
        //            }).Where(w => w.PC.ProductSeqID == S.P.ProductSeqID && w.C.Status == true).FirstOrDefault().C.Name
        //        }).OrderBy(op => op.displayOrderNumber).ToList()
        //        }).OrderByDescending(o => o.PlayListSeqID).Take(count).ToList();
        //    return playList;
        //}

        //public void CreatePlayListApi(CreatePlayListRequest createPlayListRequest)
        //{
        //    PlayList playList = new PlayList();
        //    playList.customer_def_seq = createPlayListRequest.customerDefNo;
        //    playList.PlayListName = createPlayListRequest.playListName;
        //    playList.PlayListThumpImagePath = createPlayListRequest.imagePath;
        //    playList.CreatedOn = DateTime.Now;
        //    playList.LanguageID = createPlayListRequest.languageId;
        //    playList.IsActive = true;
        //    playList.IsDelet = false;
        //    TAdd(playList);
        //}

        //public void DeletePlayListApi(int? PlayListSeqID)
        //{
        //    int id = Convert.ToInt32(PlayListSeqID.ToString());
        //    var value = TgetItemByID(id);
        //    value.IsDelet = true;
        //    value.IsActive = false;
        //    TUpdate(value);
        //}


        public List<SelectHomeProduct> ExecuteSql(string sql)
        {
            var products = context.Set<SelectHomeProduct>().FromSqlRaw(sql).ToList();
                            
            return products;
        }

    }
}
