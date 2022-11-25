using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Quki.Bll.Base;
using Quki.Common;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Entity.Parameters;
using Quki.Interface;

namespace Quki.Bll
{
    public class ProductImagesManager : BllBase<ProductImage,ProductImageAddModel >, IProductImagesService
    {
        public readonly IProductImagesRepository repo;
        public readonly IProductsRepository productRepository;
        public ProductImagesManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IProductImagesRepository>();
            productRepository = service.GetService<IProductsRepository>();
        }
        public List<ProductImage> GetProductImageByProductID(int productID)// ürüne ait Product Image Getiriliyor
        {

            return TGetList(I => I.ProductSeqID == productID && I.Status == true).ToList();
        }
        public List<ProductImage> GetProductImageByProductIDAndMedyaType(int productID, int medyaTypeID, int GroupID)// ürüne ait verilen medya tipine göre  product Image Getiriliyor
        {

            return TGetList(I => I.ProductSeqID == productID && I.Status == true && I.MediaTypeId == medyaTypeID && I.GroupId == GroupID).ToList();
        }
        public List<ProductImage> GetProductImageByProductIDByGroupID(int productID, int GroupID)// ürüne ait verilen medya tipine göre  product Image Getiriliyor
        {

            return TGetList(I => I.ProductSeqID == productID && I.Status == true && I.GroupId == GroupID).ToList();
        }
        public void DeleteProductImage(ProductImage Item)
        {
            var ControlItem = TgetItemByID(Item.ProductImageSeqID);
            if (ControlItem != null)
            {
                TDelete(ControlItem);
            }
        }
        public void ProductImageAdd(ProductImageAddModel Item)
        {
            ProductImage p = new ProductImage();
            if (Item.ImagePath != null)
            {
                var path = Path.GetExtension(Item.ImagePath.FileName);
                var newPath = Guid.NewGuid() + path;
                if (Item.MediaTypeId == MediaTypes.Resim)
                {
                    var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProductImg/" + newPath;
                    var ThumbImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProductImg/Thump" + newPath;
                    var steem = new FileStream(ImagePath, FileMode.Create);
                    Item.ImagePath.CopyTo(steem);
                    Utility.ResizeImage(Item.ImagePath, ProductImageSize.Height, ProductImageSize.Width, ThumbImagePath);
                    p.ImagePath = "/AdminImage/ProductImg/" + newPath; ;
                    p.ImageThumbPath = "/AdminImage/ProductImg/Thump" + newPath; ;
                }
                else
                {
                    var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminMedia/AdminAudio/" + newPath;
                    var steem = new FileStream(ImagePath, FileMode.Create);
                    Item.ImagePath.CopyTo(steem);

                    p.ImagePath = "/AdminMedia/AdminAudio/" + newPath; ;

                }
                p.ImageName = Item.ImageName;
                p.Remark = Item.Remark;
                p.Status = Item.Status;
                p.ProductSeqID = Item.ProductSeqID;
                p.MediaTypeId = Item.MediaTypeId;
                p.GroupId = Item.GroupId;
                p.GroupValue = Item.GroupValue;
                p.CreatedOn = DateTime.Now;
                p.UpdatedOn = DateTime.Now;
                TAdd(p);
            }
        }
        public List<ApiProductImages> GetProductImageByProductIDApi(int productID)
        {
            return TGetList(I => I.ProductSeqID == productID && I.Status == true).Select(s => new ApiProductImages
            {
                ProductImageSeqID = s.ProductImageSeqID,
                ProductSeqID = s.ProductSeqID,
                ImagePath = s.ImagePath,
                ImageName = s.ImageName,
                MediaTypeId = s.MediaTypeId,
                GroupId = s.GroupId
            }).ToList();
        }
        public bool ProductImageDeleteById(int id)
        {
            bool result = false;

            var x = TGetList(x => x.ProductImageSeqID == id).FirstOrDefault();

            var a = TGetList(x => x.ProductSeqID == x.Products.ProductSeqID);

            x.Status = false;
            x.IsDeleted = true;

            TUpdate(x);
            result = true;
            return result;
        }
        public void ProductImageUpdate(ProductImageAddModel Item)
        {
            ProductImage p = new ProductImage();
            if (Item.ImagePath != null)
            {
                var path = Path.GetExtension(Item.ImagePath.FileName);
                var newPath = Guid.NewGuid() + path;
                if (Item.MediaTypeId == MediaTypes.Resim)
                {
                    var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProductImg/" + newPath;
                    var ThumbImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProductImg/Thump" + newPath;
                    var steem = new FileStream(ImagePath, FileMode.Create);
                    Item.ImagePath.CopyTo(steem);
                    Utility.ResizeImage(Item.ImagePath, ProductImageSize.Height, ProductImageSize.Width, ThumbImagePath);
                    p.ImagePath = "/AdminImage/ProductImg/" + newPath; ;
                    p.ImageThumbPath = "/AdminImage/ProductImg/Thump" + newPath; ;
                }
                else
                {
                    var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminMedia/AdminAudio/" + newPath;
                    var steem = new FileStream(ImagePath, FileMode.Create);
                    Item.ImagePath.CopyTo(steem);
                    p.ImagePath = "/AdminMedia/AdminAudio/" + newPath;
                }
            }
            else
            {

                
                var getMedia = repo.TGetList().Where(x => x.ProductImageSeqID == Item.ProductImageSeqID && x.Status == true).FirstOrDefault();
                p.ImagePath = getMedia.ImagePath;
            }
            p.ProductImageSeqID = Item.ProductImageSeqID;
            p.ImageName = Item.ImageName;
            p.Remark = Item.Remark;
            p.Status = Item.Status;
            p.ProductSeqID = Item.ProductSeqID;
            p.MediaTypeId = Item.MediaTypeId;
            p.GroupId = Item.GroupId;
            p.GroupValue = Item.GroupValue;
            p.UpdatedOn = DateTime.Now;
            TUpdate(p);
        }

    }
}
