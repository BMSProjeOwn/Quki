using Microsoft.EntityFrameworkCore;
using Quki.Dal.Abstract;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class ProductImagesRepository : GenericRepository<ProductImage>, IProductImagesRepository
    {
        public ProductImagesRepository(DbContext context) : base(context)
        {
            
        }
        //public List<ProductImage> GetProductImageByProductID(int productID)// ürüne ait Product Image Getiriliyor
        //{

        //    return dbset.Where(I => I.ProductSeqID == productID && I.Status == true).ToList();
        //}
        //public List<ProductImage> GetProductImageByProductIDAndMedyaType(int productID, int medyaTypeID, int GroupID)// ürüne ait verilen medya tipine göre  product Image Getiriliyor
        //{

        //    return dbset.Where(I => I.ProductSeqID == productID && I.Status == true && I.MediaTypeId == medyaTypeID && I.GroupId == GroupID).ToList();
        //}
        //public List<ProductImage> GetProductImageByProductIDByGroupID(int productID, int GroupID)// ürüne ait verilen medya tipine göre  product Image Getiriliyor
        //{

        //    return dbset.Where(I => I.ProductSeqID == productID && I.Status == true && I.GroupId == GroupID).ToList();
        //}
        //public void DeleteProductImage(ProductImage Item)
        //{
        //    var ControlItem = TgetItemByID(Item.ProductImageSeqID);
        //    if (ControlItem != null)
        //    {
        //        TDelete(ControlItem);
        //    }
        //}
        //public void ProductImageAdd(ProductImageAddModel Item)
        //{
        //    ProductImage p = new ProductImage();
        //    if (Item.ImagePath != null)
        //    {
        //        var path = Path.GetExtension(Item.ImagePath.FileName);
        //        var newPath = Guid.NewGuid() + path;
        //        if (Item.MediaTypeId == MediaTypes.Resim)
        //        {
        //            var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProductImg/" + newPath;
        //            var ThumbImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProductImg/Thump" + newPath;
        //            var steem = new FileStream(ImagePath, FileMode.Create);
        //            Item.ImagePath.CopyTo(steem);
        //            Utility.ResizeImage(Item.ImagePath, ProductImageSize.Height, ProductImageSize.Width, ThumbImagePath);
        //            p.ImagePath = "/AdminImage/ProductImg/" + newPath; ;
        //            p.ImageThumbPath = "/AdminImage/ProductImg/Thump" + newPath; ;
        //        }
        //        else
        //        {
        //            var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminMedia/AdminAudio/" + newPath;
        //            var steem = new FileStream(ImagePath, FileMode.Create);
        //            Item.ImagePath.CopyTo(steem);

        //            p.ImagePath = "/AdminMedia/AdminAudio/" + newPath; ;

        //        }
        //        p.ImageName = Item.ImageName;
        //        p.Remark = Item.Remark;
        //        p.Status = Item.Status;
        //        p.ProductSeqID = Item.ProductSeqID;
        //        p.MediaTypeId = Item.MediaTypeId;
        //        p.GroupId = Item.GroupId;
        //        p.GroupValue = Item.GroupValue;
        //        p.CreatedOn = DateTime.Now;
        //        p.UpdatedOn = DateTime.Now;
        //        TAdd(p);
        //    }
        //}
        //public List<ApiProductImages> GetProductImageByProductIDApi(int productID)
        //{
        //    return dbset.Where(I => I.ProductSeqID == productID && I.Status == true).Select(s => new ApiProductImages
        //    {
        //        ProductImageSeqID = s.ProductImageSeqID,
        //        ProductSeqID = s.ProductSeqID,
        //        ImagePath = s.ImagePath,
        //        ImageName = s.ImageName,
        //        MediaTypeId = s.MediaTypeId,
        //        GroupId = s.GroupId
        //    }).ToList();
        //}
        //public bool ProductImageDeleteById(int id)
        //{
        //    bool result = false;

        //    var x = dbset.Where(x => x.ProductImageSeqID == id).FirstOrDefault();

        //    var a = dbset.Where(x => x.ProductSeqID == x.Products.ProductSeqID);

        //    x.Status = false;
        //    x.IsDeleted = true;

        //    TUpdate(x);
        //    result = true;
        //    return result;
        //}
        //public void ProductImageUpdate(ProductImageAddModel Item)
        //{
        //    ProductImage p = new ProductImage();
        //    if (Item.ImagePath != null)
        //    {
        //        var path = Path.GetExtension(Item.ImagePath.FileName);
        //        var newPath = Guid.NewGuid() + path;
        //        if (Item.MediaTypeId == MediaTypes.Resim)
        //        {
        //            var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProductImg/" + newPath;
        //            var ThumbImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProductImg/Thump" + newPath;
        //            var steem = new FileStream(ImagePath, FileMode.Create);
        //            Item.ImagePath.CopyTo(steem);
        //            Utility.ResizeImage(Item.ImagePath, ProductImageSize.Height, ProductImageSize.Width, ThumbImagePath);
        //            p.ImagePath = "/AdminImage/ProductImg/" + newPath; ;
        //            p.ImageThumbPath = "/AdminImage/ProductImg/Thump" + newPath; ;
        //        }
        //        else
        //        {
        //            var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminMedia/AdminAudio/" + newPath;
        //            var steem = new FileStream(ImagePath, FileMode.Create);
        //            Item.ImagePath.CopyTo(steem);
        //            p.ImagePath = "/AdminMedia/AdminAudio/" + newPath;
        //        }
        //    }
        //    else
        //    {
        //        ProductsRepository productsRepository = new ProductsRepository(context);

        //        var getMedia = productsRepository.GetMediaList(Item.ProductImageSeqID);
        //        p.ImagePath = getMedia.ImagePath;
        //    }
        //    p.ProductImageSeqID = Item.ProductImageSeqID;
        //    p.ImageName = Item.ImageName;
        //    p.Remark = Item.Remark;
        //    p.Status = Item.Status;
        //    p.ProductSeqID = Item.ProductSeqID;
        //    p.MediaTypeId = Item.MediaTypeId;
        //    p.GroupId = Item.GroupId;
        //    p.GroupValue = Item.GroupValue;
        //    p.UpdatedOn = DateTime.Now;
        //    TUpdate(p);
        //}
    }
}
