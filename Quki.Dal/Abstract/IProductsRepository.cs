
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Entity.ViewModel;

namespace Quki.Dal.Abstract
{
    public interface IProductsRepository : IGenericRepository<Products>
    {
        public List<ProductDetailForMobile> GetProductDetailForMobile(int productID, string customer_def_no);
        //public List<Products> GetProductList();
        //public List<AttributeStaticValue> GetAttributeStaticValueByProductID(int productID);// ürüne ait kategorileri getiriyor.       
        //public List<AttributeStaticValue> GetAttributeStaticValueByProductID(int productID, int attiributeStaticSeq);// ürüne ait kategorileri getiriyor.       
        //public void DeleteAttiributeStaticValue(ProductWithAttributeStaticValue Item);
        //public void AddAttiributeStaticValue(ProductWithAttributeStaticValue Item);
        //public List<Category> GetCategoriesByProductID(int productID);// ürüne ait kategorileri getiriyor.      
        //public void ProductUpdate(ProductMergeModel model, int productID);
        //public void DeleteCategory(ProductWithCategory Item);
        //public void AddCategory(ProductWithCategory Item);
        //public List<Products> GetProductsByCategoryID(int? categoryID, int languageId);// kategoriye ait ürün Listesini verir       
        //public List<Products> GetProductsByMedyaTypeID(int? MedyaTypeID, int GroupID);//kategoriye ait ürün Listesini verir   
        //public List<Products> GetLastProducts(int productCount, int languageID);
        //public ProductDetailModel GetProductDetail(int productID);// ürüne ait kategorileri getiriyor.      
        //public List<Products> GetAllActiveProduct();
        //public List<Products> GetProductShowOnHomePage();
        //public bool ProductAdd(ProductAddModel Item);
        //public ProductMergeModel GetProductDetailForAdd(int id, int LanguageID);// Ürünün Tüm Tanım bilgilerini getirir      
        //public List<ProductAttributeModel> GetAttributeModel(int productID);// Ürünün Tüm Tanım bilgilerini getirir    
        //public List<ProductDetailForMobile> GetProductDetailForMobile(int productID, string customer_def_no);// ürüne ait kategorileri getiriyor.      
        //public List<ProductDetailForMobile> GetAllProductDetailForMobile(int count, string customer_def_no);
        //public List<Products> SeachProductWeb(string name, int languageId);
        //#region Onder
        //public ProductsModel getProducts();
        //public List<ProductWithCategoryModel> getProductWithCategory();
        //public List<ViewValueItems> ByAageRrangeProducts(int Count, string customer_def_no);
        //public List<ViewValueItems> getTheNewests(int Count, string customer_def_no);
        //public List<ViewValueItems> getTopRateProduct(int Count, string customer_def_no);
        //public List<ViewValueItems> getPopularAudioTheaters(int Count, string customer_def_no);
        //public Document GetItemsAsync(int MenuID, int LanguageID);
        //public ProductsSearchApi SeachProduct(string name, string customer_def_no);
        //public ProductGroup GetHomeProductsApi(int GroupID, string customer_def_no, int count, int languageId);
        //public List<Product> GetHomeProductDetailForMobile(int count, string customer_def_no, int languageId, int GroupID);
        //public int ProductAddForAnotherLanguage(ProductMergeModel Item, int ProductSeqID);
        //public Product GetProductByID(int ProductSeqID, string customer_def_no, int? languageId);
        //#endregion Onder
        //public ProductImage GetMediaList(int id);
        //public List<Quki.Entity.DtoModels.ApiModels.Filter> SelectAllOrders();
        //public bool ProductDeleteById(int id);
        //public List<Product> GetHomeProductDetailByIDForMobile(int ProductSeqID, string customer_def_no, int languageId);
        //public List<SelectListItem> GetAllProduct();
        public List<Product> GetProducersProductDetailByIDSP(int ProductSeqID, string customer_def_no, int languageId);
        //public Product GetProductByIDSP(int ProductSeqID, string customer_def_no, int? languageId);
        //public ProductsSearchApi SeachProductSP(string name, string customer_def_no, int languageId);
        public List<Products> HomePageMostListened(int languageID);
        public List<Products> HomePageMostListenedByMedayType(int languageID, int medyaType);
        public List<Products> GetLastCreadedProductByMedayType(int languageID, int medyaType);

        public List<SelectHomeProduct> ExecuteSql(string sql);
    }
}
