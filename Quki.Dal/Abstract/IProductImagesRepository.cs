using Quki.Entity.Models;

namespace Quki.Dal.Abstract
{
    public interface IProductImagesRepository : IGenericRepository<ProductImage>
    {
        //public List<ProductImage> GetProductImageByProductID(int productID);// ürüne ait Product Image Getiriliyor       
        //public List<ProductImage> GetProductImageByProductIDAndMedyaType(int productID, int medyaTypeID, int GroupID);// ürüne ait verilen medya tipine göre  product Image Getiriliyor      
        //public List<ProductImage> GetProductImageByProductIDByGroupID(int productID, int GroupID);// ürüne ait verilen medya tipine göre  product Image Getiriliyor       
        //public void DeleteProductImage(ProductImage Item);
        //public void ProductImageAdd(ProductImageAddModel Item);
        //public List<ApiProductImages> GetProductImageByProductIDApi(int productID);
        //public bool ProductImageDeleteById(int id);
        //public void ProductImageUpdate(ProductImageAddModel Item);
       
    }
}
