using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Dal.Abstract;

using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Entity.Parameters;
using Quki.Entity.ViewModel;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class CustomerFovoriListRepository : GenericRepository<CustomerFavoritesList>, ICustomerFovoriListRepository
    {
        public CustomerFovoriListRepository(DbContext context):base(context)
        {
           
        }
        //public void AddCustomerFavoriList(CustomerFovoriListApiModel model)
        //{
        //    CustomerFavoritesList customerFavoritesList = new CustomerFavoritesList();
        //    customerFavoritesList.customer_def_no = model.customerDefNo;
        //    customerFavoritesList.FavoritesListDefSeqID = model.FavoritesListDefSeqID;
        //    customerFavoritesList.RelatedFavoritesListSeqID = model.productId;
        //    customerFavoritesList.CreatedOn = DateTime.Now;
        //    customerFavoritesList.IsActive = true;
        //    customerFavoritesList.GroupID = model.GroupID;
        //    var value = dbset.Where(W => W.customer_def_no == model.customerDefNo && W.IsActive == true && W.RelatedFavoritesListSeqID == model.productId && W.GroupID == model.GroupID).ToList();
        //    if (value.Count <= 0)
        //        TAdd(customerFavoritesList);
        //}

        //public void DeleteCustomerFavoriList(CustomerFovoriListApiModel model)
        //{
        //    var value =dbset.Where(W => W.customer_def_no == model.customerDefNo
        //        && W.IsActive == true
        //        && W.RelatedFavoritesListSeqID == model.productId
        //        && W.GroupID == model.GroupID
        //        && W.FavoritesListDefSeqID == model.FavoritesListDefSeqID).ToList();
        //    foreach (var item in value)
        //    {
        //        item.IsActive = false;
        //        TUpdate(item);
        //    }
        //}

        //public void DeleteListOfCustomerFavoriList(string customer_def_no)
        //{
        //    var value = dbset.Where(W => W.customer_def_no == customer_def_no).ToList();
        //    foreach (var item in value)
        //    {
        //        item.IsActive = false;
        //        TUpdate(item);
        //    }
        //}

        //public List<CustomerFavoritesList> getCustomerFovoriList(string customer_def_no)
        //{
        //    return dbset.Where(W => W.customer_def_no == customer_def_no && W.IsActive == true).ToList();
        //}

        public List<CustomerFavoritesList> getCustomerFovoriListWithType(string customer_def_no, int? TypeID)
        {
            return dbset.Where(W => W.customer_def_no == customer_def_no && W.IsActive == true && W.GroupID == TypeID).ToList();
        }

        //// Api Önder

        //public List<Product> getCustomerFovoriListApi(string customer_def_no)
        //{
        //    CustomerTrackingTypeRepository customerTrackingTypeRepostories=new CustomerTrackingTypeRepository(context);
        //    CustomerRatingsRepository ratingsRepository=new CustomerRatingsRepository(context);
        //    Random rastgele = new Random();
        //    ProductsRepository productsRepository = new ProductsRepository(context);
        //    AttributeStaticValueRepository attributeStaticValueRepository=new AttributeStaticValueRepository(context);
        //    var products = dbset
        //        .Join(context.Set<ProductImage>(), CustomerFavoritesList => CustomerFavoritesList.RelatedFavoritesListSeqID, PC => PC.ProductImageSeqID, (C, P) => new
        //        {
        //            C = C,
        //            PI = P
        //        })
        //        .Join(context.Set<Products>(), CI => CI.PI.ProductSeqID, P => P.ProductSeqID, (CI, PP) => new
        //        {
        //            CF = CI,
        //            P = PP
        //        })
        //        .Where(W => W.CF.C.customer_def_no == customer_def_no && W.CF.C.IsActive == true).Select(S => new Product
        //        {
        //            productId = S.P.ProductSeqID,
        //            productName = S.P.ProductName,
        //            secondName = S.P.SecondName,
        //            description = Functions.StripHTML(S.P.Description),
        //            imageUrl = ApiParameters.URL + S.P.ImageThumbPath,
        //            previewUrl = ApiParameters.URL + S.CF.PI.ImagePath,
        //            theaterId = context.Set<ProductImage>().Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Tiyatro && w.ProductSeqID == S.P.ProductSeqID && w.IsDeleted == false && w.Status == true).Select(s => s.ProductImageSeqID).FirstOrDefault(),
        //            theaterUrl = ApiParameters.URL + context.Set<ProductImage>().Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Tiyatro && w.ProductSeqID == S.P.ProductSeqID && w.IsDeleted == false && w.Status == true).Select(s => s.ImagePath).FirstOrDefault(),
        //            musicId = context.Set<ProductImage>().Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Muzik && w.ProductSeqID == S.P.ProductSeqID && w.IsDeleted == false && w.Status == true).Select(s => s.ProductImageSeqID).FirstOrDefault(),
        //            musicUrl = ApiParameters.URL + context.Set<ProductImage>().Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Muzik && w.ProductSeqID == S.P.ProductSeqID && w.IsDeleted == false && w.Status == true).Select(s => s.ImagePath).FirstOrDefault(),
        //            productUrl = ApiParameters.URL + "/Product/GetProductDetail/" + S.P.ProductSeqID.ToString(),
        //            theaterDuration = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? 0 : customerTrackingTypeRepostories.GetCustomerTrackingTypeLastApi(customer_def_no, S.CF.PI.ProductImageSeqID),
        //            musicDuration = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? customerTrackingTypeRepostories.GetCustomerTrackingTypeLastApi(customer_def_no, S.CF.PI.ProductImageSeqID) : 0,
        //            lastDuration = 0,
        //            isMusicInPlayList = false,
        //            isTheaterInPlayList = false,
        //            isMusicInKeepListening = false,
        //            isTheaterInKeepListening = false,
        //            productPoints = Convert.ToDouble(ratingsRepository.ProductPoint(S.P.ProductSeqID)),
        //            displayOrderNumber = S.P.DisplayOrderNumber,
        //            //favoriteMediaId = new List<int>() { S.CF.PI.ProductImageSeqID },
        //            isMusicFavorite = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? true : false,
        //            isTheaterFavorite = S.CF.PI.MediaTypeId == MediaTypes.Muzik ? false : true,
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
        //        }).ToList();
        //    return products;
        //}


        public List<SelectHomeProduct> GetCustomerFavoriListFromSP(string customer_def_no, int languageId)
        {
            try
            {
             
                string sql = "exec GetCustomerFavoriListFromSP @customer_def_no='" + customer_def_no + "' , @languageId=" + languageId;
                var products = context.Set<SelectHomeProduct>().FromSqlRaw(sql).ToList();

                return products;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
    }
}
