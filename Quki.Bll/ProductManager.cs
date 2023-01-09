using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Quki.Bll.Base;
using Quki.Common;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Entity.Parameters;
using Quki.Entity.ViewModel;
using Quki.Interface;

namespace Quki.Bll
{
    public class ProductManager : BllBase<Products, Product>, IProductService
    {
        public readonly IProductsRepository productRepository;
        public readonly IProductWithCategoryRepository productWithCategoryRepository;
        public readonly IProductWithAttributeStaticValueRepository productWithAttributeStaticValueRepository;
        public readonly IAttributeStaticValueRepository attributeStaticValueRepository;
        public readonly ICategoryRepository categoryRepository;
        public readonly IProductImagesRepository productImagesRepository;
        public readonly IAttributeStaticRepository attributeStaticRepository;
        public readonly IProductWithProducersRepository productWithProducersRepository;
        public readonly ICustomerFovoriListRepository customerFovoriListRepository;
        public readonly ICustomerTrackingTypeRepository customerTrackingTypeRepository;
        public readonly ICustomerRatingsRepository customerRatingsRepository;
        public readonly IProducersRepository producersRepository;
        public readonly IDocumentsRepository documentsRepository;
        public readonly IMenuRepository menuRepository;
        public ProductManager(IServiceProvider service) :base(service)
        {
            productRepository = service.GetService<IProductsRepository>();
            productWithCategoryRepository = service.GetService<IProductWithCategoryRepository>();
            productWithAttributeStaticValueRepository = service.GetService<IProductWithAttributeStaticValueRepository>();
            attributeStaticValueRepository = service.GetService<IAttributeStaticValueRepository>();
            categoryRepository = service.GetService<ICategoryRepository>();
            productImagesRepository = service.GetService<IProductImagesRepository>();
            attributeStaticRepository = service.GetService<IAttributeStaticRepository>();
            productWithProducersRepository = service.GetService<IProductWithProducersRepository>();
            customerFovoriListRepository = service.GetService<ICustomerFovoriListRepository>();
            customerTrackingTypeRepository = service.GetService<ICustomerTrackingTypeRepository>();
            customerRatingsRepository = service.GetService<ICustomerRatingsRepository>();
            producersRepository = service.GetService<IProducersRepository>();
            documentsRepository = service.GetService<IDocumentsRepository>();
            menuRepository = service.GetService<IMenuRepository>();
        }
        public List<Products> GetProductList()
        {
            var items = TGetList(x=>x.Status==true).OrderByDescending(u => u.ProductSeqID);
            return items.ToList();
        }
        public List<AttributeStaticValue> GetAttributeStaticValueByProductID(int productID)// ürüne ait kategorileri getiriyor.
        {

            return TGetList().Join(productWithAttributeStaticValueRepository.TGetList(), Products => Products.ProductSeqID, ProductWithAttributeStaticValue => ProductWithAttributeStaticValue.ProductSeqID, (P, PC) => new
            {
                Products = P,
                ProductWithAttributeStaticValue = PC
            }).Join(attributeStaticValueRepository.TGetList(), iki => iki.ProductWithAttributeStaticValue.AttributeStaticValueSeqID, AttributeStaticValue => AttributeStaticValue.AttributeStaticValueSeqID, (PC, C) => new
            {
                Products = PC.Products,
                AttributeStaticValue = C,
                ProductWithAttributeStaticValue = PC.ProductWithAttributeStaticValue
            }).Where(I => I.Products.ProductSeqID == productID).Select(I => new AttributeStaticValue
            {
                //value = I.ProductWithAttributeStaticValue.Value,
                ValueName = I.AttributeStaticValue.ValueName,
                AttributeStaticValueSeqID = I.AttributeStaticValue.AttributeStaticValueSeqID

            }).ToList();

        }
        public List<AttributeStaticValue> GetAttributeStaticValueByProductID(int productID, int attiributeStaticSeq)// ürüne ait kategorileri getiriyor.
        {

            return TGetList().Join(productWithAttributeStaticValueRepository.TGetList(), Products => Products.ProductSeqID, ProductWithAttributeStaticValue => ProductWithAttributeStaticValue.ProductSeqID, (P, PC) => new
            {
                Products = P,
                ProductWithAttributeStaticValue = PC
            }).Join(attributeStaticValueRepository.TGetList(), iki => iki.ProductWithAttributeStaticValue.AttributeStaticValueSeqID, AttributeStaticValue => AttributeStaticValue.AttributeStaticValueSeqID, (PC, C) => new
            {
                Products = PC.Products,
                AttributeStaticValue = C,
                ProductWithAttributeStaticValue = PC.ProductWithAttributeStaticValue
            }).Where(I => I.Products.ProductSeqID == productID && I.AttributeStaticValue.AttributeStaticSeqID == attiributeStaticSeq).Select(I => new AttributeStaticValue
            {
                ValueName = I.AttributeStaticValue.ValueName,
                AttributeStaticValueSeqID = I.AttributeStaticValue.AttributeStaticValueSeqID

            }).ToList();
        }
        public void DeleteAttiributeStaticValue(ProductWithAttributeStaticValue Item)
        {
            var ControlItem = productWithAttributeStaticValueRepository.GetProductAttiributeStaticValue(Item.ProductSeqID, Item.AttributeStaticValueSeqID);
            if (ControlItem != null)
            {
                productWithAttributeStaticValueRepository.TDelete(ControlItem);
            }
        }
        public ProductDetailModel GetProductDetailByName(string ProductName)// ürüne ait kategorileri getiriyor.
        {
            ProductDetailModel pd = new ProductDetailModel();
            var poroduct = TGetList(i => i.ProductName == ProductName && i.Status == true).FirstOrDefault();
            pd.SecondName = poroduct.SecondName;
            pd.ProductName = poroduct.ProductName;
            pd.ProductSeqID = poroduct.ProductSeqID;
            pd.ReleaseDate = poroduct.ReleaseDate;
            pd.ImagePath = poroduct.ImagePath;
            pd.ThumpImagePath = poroduct.ImagePath;
            pd.AllowCustomerRating = poroduct.AllowCustomerRating;
            pd.AllowCustomerReviews = poroduct.AllowCustomerReviews;
            pd.Description = poroduct.Description;
            pd.ProductSEOData = poroduct.ProductSEOData;
            pd.ProductSEOMetaDescription = poroduct.ProductSEOMetaDescription;
            //var AttiributeStatic = Context.ProductWithAttributeStaticValues.Join(Context.AttributeStaticValue, A => A.AttributeStaticValueSeqID, PA => PA.AttributeStaticValueSeqID, (productWithAttributeStaticValues, attributeStaticValue) => new
            //{
            //    AttributeStaticValue = attributeStaticValue,
            //    ProductWithAttributeStaticValues = productWithAttributeStaticValues
            //}).Where(I => I.ProductWithAttributeStaticValues.ProductSeqID == productID).Select(I => new ProductAttributeModel
            //{
            //    AttributeStaticValueSeqID = I.ProductWithAttributeStaticValues.AttributeStaticValueSeqID,
            //    Value = I.ProductWithAttributeStaticValues.Value,
            //    ProductSeqID = I.ProductWithAttributeStaticValues.ProductSeqID,
            //    ValueName = I.AttributeStaticValue.ValueName,
            //    isdinamic = I.AttributeStaticValue.IsDynamic,
            //    Remark = I.AttributeStaticValue.Remark

            //}).ToList();


            List<ProductAttiributeValueList> list = new List<ProductAttiributeValueList>();
            //foreach (var item in AttiributeStatic)
            //{
            //    ProductAttiributeValueList model = new ProductAttiributeValueList();
            //    //model.AttributeStaticValueSeqID = item.AttributeStaticValueSeqID;
            //    //model.Value = item.Value;
            //    //model.IsDynamic = item.AttributeStaticValue.IsDynamic;
            //    //model.ValueName = item.AttributeStaticValue.ValueName;
            //    //model.ProductWithAttributeStaticValueSeqID = item.ProductWithAttributeStaticValueSeqID;
            //    //model.ProductSeqID = item.ProductSeqID;
            //    list.Add(model);
            //}
            pd.ProductAttiributeValueList = list;

            var Item = productImagesRepository.TGetList(I => I.ProductSeqID == poroduct.ProductSeqID && I.Status == true && I.GroupId == MediaTypes.PreLissen).ToList();
            pd.ProductImage = Item;
            pd.VisitorComments.ComantSeqID = poroduct.ProductSeqID;
            return pd;
        }
        public void AddAttiributeStaticValue(ProductWithAttributeStaticValue Item)
        {
            
            var ControlItem = productWithAttributeStaticValueRepository.GetProductAttiributeStaticValue(Item.ProductSeqID, Item.AttributeStaticValueSeqID);
            if (ControlItem == null)
            {
                productWithAttributeStaticValueRepository.TAdd(Item);
            }
            else
            {
                productWithAttributeStaticValueRepository.TUpdate(Item);
            }
        }
        public List<Category> GetCategoriesByProductID(int productID)// ürüne ait kategorileri getiriyor.
        {
            var list = TGetList().Join(productWithCategoryRepository.TGetList(), Products => Products.ProductSeqID, ProductWithCategory => ProductWithCategory.ProductSeqID, (P, PC) => new
            {
                Products = P,
                ProductWithCategory = PC
            }).Join(categoryRepository.TGetList(), iki => iki.ProductWithCategory.CategorySeqID, Category => Category.CategorySeqID, (PC, C) => new
            {
                Products = PC.Products,
                Category = C,
                ProductWithCategory = PC.ProductWithCategory
            }).ToList() ;
            var list2 = productWithCategoryRepository.TGetList();
            var list3 = categoryRepository.TGetList();
            return TGetList().Join(productWithCategoryRepository.TGetList(), Products => Products.ProductSeqID, ProductWithCategory => ProductWithCategory.ProductSeqID, (P, PC) => new
            {
                Products = P,
                ProductWithCategory = PC
            }).Join(categoryRepository.TGetList(), iki => iki.ProductWithCategory.CategorySeqID, Category => Category.CategorySeqID, (PC, C) => new
            {
                Products = PC.Products,
                Category = C,
                ProductWithCategory = PC.ProductWithCategory,
            }).ToList().Where(I => I.Products.ProductSeqID == productID && I.Category.Status == true).Select(I => new Category
            {
                Name = I.Category.Name,
                CategorySeqID = I.Category.CategorySeqID
            }).ToList();

        }
        public void ProductUpdate(ProductMergeModel model, int productID)
        {

         
            var Product = TgetItemByID(productID);
            if (Product.Description == null)
            {
                Product.Description = " ";
            }

            else
            {
                var test = new HtmlString(model.ProductUpdateModel.Description);
                Product.Description = test.ToString();
            }
            Product.ProductName = model.ProductUpdateModel.ProductName;
            Product.ProductSEOData = model.ProductUpdateModel.ProductSEOData;
            Product.ProductSEOMetaDescription = model.ProductUpdateModel.ProductSEOMetaDescription;
            Product.SecondName = model.ProductUpdateModel.SecondName;
            Product.ShowOnHomePage = model.ProductUpdateModel.ShowOnHomePage;
            Product.Status = model.ProductUpdateModel.Status;
            Product.ProductTypeSeqID = model.ProductUpdateModel.MediaType;
            Product.AllowCustomerRating = model.ProductUpdateModel.AllowCustomerRating;
            Product.AllowCustomerReviews = model.ProductUpdateModel.AllowCustomerReviews;
            Product.LanguageID = model.ProductUpdateModel.LanguageID;


            if (model.ProductUpdateModel.ProductSEOMetaDescription == null)
            {
                model.ProductUpdateModel.ProductSEOMetaDescription = Product.ProductName;
                Product.ProductSEOMetaDescription = model.ProductUpdateModel.ProductSEOMetaDescription;
            }

            if (model.ProductUpdateModel.ImagePath != null)
            {
    
                if (model.ProductUpdateModel.MediaType.Equals(0))
                {
                    var path = Path.GetExtension(model.ProductUpdateModel.ImagePath.FileName);
                    var newPath = Guid.NewGuid() + path;
                    var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProductImg/" + newPath;
                    var ThumbImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProductImg/Thump" + newPath;
                    var steem = new FileStream(ImagePath, FileMode.Create);
                    model.ProductUpdateModel.ImagePath.CopyTo(steem);
                    Utility.ResizeImage(model.ProductUpdateModel.ImagePath, ProductImageSize.Height, ProductImageSize.Width, ThumbImagePath);
                    Product.ImagePath = "/AdminImage/ProductImg/" + newPath;
                    Product.ImageThumbPath = "/AdminImage/ProductImg/Thump" + newPath;
                }
                else
                {
                    var path = Path.GetExtension(model.ProductUpdateModel.ImagePath.FileName);
                    var newPath = Guid.NewGuid() + path;
                    var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminMedia/AdminVideo/" + newPath;
                    // var ThumbImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminMedia/AdminVideo/Thump" + newPath;
                    var steem = new FileStream(ImagePath, FileMode.Create);
                    model.ProductUpdateModel.ImagePath.CopyTo(steem);
                    //Utility.ResizeImage(Item.ImagePath, ProductImageSize.Height, ProductImageSize.Width, ThumbImagePath);
                    Product.ImagePath = "/AdminMedia/AdminVideo/" + newPath;
                    //p.ImageThumbPath = "/AdminMedia/AdminVideo/Thump" + newPath;
                }
            }
            TUpdate(Product);


        }
        public void DeleteCategory(ProductWithCategory Item)
        {
            var category = productWithCategoryRepository.TGetList(x=>x.CategorySeqID==Item.CategorySeqID && x.ProductSeqID==Item.ProductSeqID).FirstOrDefault();
            if (category != null)
            {

                productWithCategoryRepository.TDelete(category);
            }
        }
        public void AddCategory(ProductWithCategory Item)
        {
            
            var ControlItem = productWithCategoryRepository.GetProductCategori(Item.ProductSeqID, Item.CategorySeqID);
            if (ControlItem == null)
            {
                productWithCategoryRepository.TAdd(Item);
            }
        }
        public List<Products> GetProductsByCategoryID(int? categoryID, int languageId)// kategoriye ait ürün Listesini verir
        {
            if (categoryID == 6)
                categoryID = null;
            if (categoryID != null)
            {
                return TGetList().Join(productWithCategoryRepository.TGetList(), P => P.ProductSeqID, PC => PC.ProductSeqID, (product, productWithCategory) => new
                {
                    Products = product,
                    productWithCategory = productWithCategory
                }).Where(I => I.productWithCategory.CategorySeqID == categoryID && I.Products.Status == true && I.Products.LanguageID == languageId).Select(I => new Products
                {
                    ProductSeqID = I.Products.ProductSeqID,
                    ProductName = I.Products.ProductName,
                    ImageThumbPath = I.Products.ImageThumbPath,
                    Description = I.Products.Description,
                    ImagePath = I.Products.ImagePath
                }).OrderByDescending(u => u.ProductSeqID).ToList();
            }
            else
            {
                return TGetList(I => I.Status == true && I.LanguageID == languageId).OrderByDescending(u => u.ProductSeqID).ToList();
            }
        }
        public List<Products> GetProductsByMedyaTypeID(int? MedyaTypeID, int GroupID)// kategoriye ait ürün Listesini verir
        {
            if (MedyaTypeID == null)
                MedyaTypeID = null;
            if (MedyaTypeID != null)
            {
                return productImagesRepository.TGetList().Join(TGetList(), PI => PI.ProductSeqID, P => P.ProductSeqID, (productImage, product) => new
                {
                    ProductImages = productImage,
                    Products = product

                }).Where(I => I.ProductImages.MediaTypeId == MedyaTypeID && I.ProductImages.GroupId == 5 && I.Products.Status == true && I.ProductImages.Status == true).Select(I => new Products
                {
                    ProductSeqID = I.Products.ProductSeqID,
                    ProductName = I.Products.ProductName,
                    ImageThumbPath = I.Products.ImageThumbPath,
                    Description = I.Products.Description,
                    ImagePath = I.Products.ImagePath
                }).OrderByDescending(u => u.ProductSeqID).ToList();
            }
            else
            {
                return TGetList(I => I.Status == true).OrderByDescending(u => u.ProductSeqID).ToList();
            }
        }
        public List<Products> GetLastProducts(int productCount, int languageID)
        {
            var items = TGetList(x => x.Status == true && x.LanguageID == languageID).OrderByDescending(u => u.ProductSeqID).Take(productCount);
            return items.ToList();
        }
        public ProductDetailModel GetProductDetail(int productID)// ürüne ait kategorileri getiriyor.
        {
            ProductDetailModel pd = new ProductDetailModel();
            var poroduct = TGetList(i => i.ProductSeqID == productID ).FirstOrDefault();
            pd.SecondName = poroduct.SecondName;
            pd.ProductName = poroduct.ProductName;
            pd.ProductSeqID = productID;
            pd.ReleaseDate = poroduct.ReleaseDate;
            pd.ImagePath = poroduct.ImagePath;
            pd.ThumpImagePath = poroduct.ImagePath;
            pd.AllowCustomerRating = poroduct.AllowCustomerRating;
            pd.AllowCustomerReviews = poroduct.AllowCustomerReviews;
            pd.Description = poroduct.Description;
            pd.ProductSEOData = poroduct.ProductSEOData;
            pd.ProductSEOMetaDescription = poroduct.ProductSEOMetaDescription;
            //var AttiributeStatic = Context.ProductWithAttributeStaticValues.Join(Context.AttributeStaticValue, A => A.AttributeStaticValueSeqID, PA => PA.AttributeStaticValueSeqID, (productWithAttributeStaticValues, attributeStaticValue) => new
            //{
            //    AttributeStaticValue = attributeStaticValue,
            //    ProductWithAttributeStaticValues = productWithAttributeStaticValues
            //}).Where(I => I.ProductWithAttributeStaticValues.ProductSeqID == productID).Select(I => new ProductAttributeModel
            //{
            //    AttributeStaticValueSeqID = I.ProductWithAttributeStaticValues.AttributeStaticValueSeqID,
            //    Value = I.ProductWithAttributeStaticValues.Value,
            //    ProductSeqID = I.ProductWithAttributeStaticValues.ProductSeqID,
            //    ValueName = I.AttributeStaticValue.ValueName,
            //    isdinamic = I.AttributeStaticValue.IsDynamic,
            //    Remark = I.AttributeStaticValue.Remark

            //}).ToList();


            List<ProductAttiributeValueList> list = new List<ProductAttiributeValueList>();
            //foreach (var item in AttiributeStatic)
            //{
            //    ProductAttiributeValueList model = new ProductAttiributeValueList();
            //    //model.AttributeStaticValueSeqID = item.AttributeStaticValueSeqID;
            //    //model.Value = item.Value;
            //    //model.IsDynamic = item.AttributeStaticValue.IsDynamic;
            //    //model.ValueName = item.AttributeStaticValue.ValueName;
            //    //model.ProductWithAttributeStaticValueSeqID = item.ProductWithAttributeStaticValueSeqID;
            //    //model.ProductSeqID = item.ProductSeqID;
            //    list.Add(model);
            //}
            pd.ProductAttiributeValueList = list;

            var Item = productImagesRepository.TGetList(I => I.ProductSeqID == productID && I.Status == true && I.GroupId == MediaTypes.PreLissen);
            pd.ProductImage = Item;
            pd.VisitorComments.ComantSeqID = productID;
            return pd;
        }
        
        public List<Products> GetAllActiveProduct()
        {
            var items = TGetList(i => i.Status == true).OrderByDescending(u => u.DisplayOrderNumber).ToList();
            return items.ToList();
        }
        public List<Products> GetProductShowOnHomePage()
        {

            var items = TGetList(i => i.Status == true && i.ShowOnHomePage == true).OrderByDescending(u => u.DisplayOrderNumber).ToList();
            return items.ToList();
        }
        public bool ProductAdd(ProductAddModel Item)
        {
            Products p = new Products();
            if (Item.ImagePath != null)
            {
                if (Item.MediaType.Equals(0))
                {
                var path = Path.GetExtension(Item.ImagePath.FileName);
                var newPath = Guid.NewGuid() + path;
                var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProductImg/" + newPath;
                var ThumbImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProductImg/Thump" + newPath;
                var steem = new FileStream(ImagePath, FileMode.Create);
                Item.ImagePath.CopyTo(steem);
                Utility.ResizeImage(Item.ImagePath, ProductImageSize.Height, ProductImageSize.Width, ThumbImagePath);
                p.ImagePath = "/AdminImage/ProductImg/" + newPath;
                p.ImageThumbPath = "/AdminImage/ProductImg/Thump" + newPath;
                }
                else
                {
                    var path = ".mp4";
                    var newPath = Guid.NewGuid() + path;
                    var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminMedia/AdminVideo/" + newPath;
                   // var ThumbImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminMedia/AdminVideo/Thump" + newPath;
                    var steem = new FileStream(ImagePath, FileMode.Create);
                    Item.ImagePath.CopyTo(steem);
                    //Utility.ResizeImage(Item.ImagePath, ProductImageSize.Height, ProductImageSize.Width, ThumbImagePath);
                    p.ImagePath = "/AdminMedia/AdminVideo/" + newPath;
                    //p.ImageThumbPath = "/AdminMedia/AdminVideo/Thump" + newPath;
                }
                
            }



            p.ProductName = Item.ProductName;
            p.LanguageID = Item.LanguageID;
            p.SecondName = Item.SecondName;
            p.ProductSEOData = Item.ProductSEOData;
            p.ProductTypeSeqID = Item.MediaType;
            p.ProductSEOMetaDescription = Item.ProductSEOMetaDescription;
            p.AllowCustomerReviews = Item.AllowCustomerReviews;
            p.AllowCustomerRating = Item.AllowCustomerRating;
            p.ShowOnHomePage = Item.ShowOnHomePage;
            p.Status = Item.Status;
            p.DisplayOrderNumber = Item.DisplayOrderNumber;
            if (Item.Description == null)
            {
                p.Description = " ";
            }
            else
            {
                p.Description = Item.Description;
            }
            p.ReleaseDate = Item.ReleaseDate;
            p.CreatedOn = DateTime.Now;


            if (Item.ProductSEOMetaDescription == null)
            {
                Item.ProductSEOMetaDescription = Item.ProductName;
                p.ProductSEOMetaDescription = Item.ProductSEOMetaDescription;
            }

            TAdd(p);
            p.ProductID = p.ProductSeqID;
            TUpdate(p);
            return true;
        }
        public ProductMergeModel GetProductDetailForAdd(int id, int LanguageID)// Ürünün Tüm Tanım bilgilerini getirir
        {
            ProductMergeModel mymodel = new ProductMergeModel();
            
            var Item = TgetItemByID(id);
            int productid = Item.ProductID;
            if (LanguageID != 0)
            {
                Item = TGetList(i => i.LanguageID == LanguageID && i.ProductID == productid).FirstOrDefault();
                if (Item == null)
                {
                    Item = TgetItemByID(id);
                }
            }


            ProductAddModel newModel = new ProductAddModel
            {
                ProductSeqID = Item.ProductSeqID,
                LanguageID = Item.LanguageID,
                ProductName = Item.ProductName,
                SecondName = Item.SecondName,
                //ImagePath = Item.ImagePath,
                MediaType=(int)Item.ProductTypeSeqID,
                
                ProductSEOData = Item.ProductSEOData,
                AllowCustomerReviews = Item.AllowCustomerReviews,
                AllowCustomerRating = Item.AllowCustomerRating,
                ShowOnHomePage = Item.ShowOnHomePage,
                Status = Item.Status,
                Description = Item.Description,
                DisplayOrderNumber = Item.DisplayOrderNumber

            };
            mymodel.ProductUpdateModel = newModel;
            var ProductCategory = GetCategoriesByProductID(id).Select(I => I.CategorySeqID);
            var categoris = categoryRepository.GetAllCategori();
            List<CategoryAtaModel> list1 = new List<CategoryAtaModel>();


            foreach (var item in categoris)
            {
                CategoryAtaModel model = new CategoryAtaModel();
                model.CategorySeqID = item.CategorySeqID;
                model.CategoryName = item.Name;
                model.isHas = ProductCategory.Contains(item.CategorySeqID);
                list1.Add(model);
            }

            // var productAttiributeStatic = productsRepository.GetAttributeStaticValueByProductID(id).Select(I => I.AttributeStaticValueSeqID);
            var productAttiributeStatic2 = GetAttributeStaticValueByProductID(id);

            var attributeStaticValues = attributeStaticValueRepository.TGetList();
            List<ProductAttirubuteStaticValueAtaModel> list2 = new List<ProductAttirubuteStaticValueAtaModel>();


            foreach (var item in attributeStaticValues)
            {
                ProductAttirubuteStaticValueAtaModel model = new ProductAttirubuteStaticValueAtaModel();
                model.AttributeStaticSeqID = item.AttributeStaticSeqID;
                model.AttributeStaticValueSeqID = item.AttributeStaticValueSeqID;
                model.ValueName = item.ValueName;
                model.IsDynamic = item.IsDynamic;

                //var Value = productAttiributeStatic2.Where(I => I.AttributeStaticValueSeqID == item.AttributeStaticValueSeqID).FirstOrDefault();
                string value = "";
                var attributeStaticValue = productAttiributeStatic2.FirstOrDefault(I => I.AttributeStaticValueSeqID == item.AttributeStaticValueSeqID);
                
                if (attributeStaticValue != null)
                    value = productWithAttributeStaticValueRepository.GetProductAttiributeStaticValue(id, attributeStaticValue.AttributeStaticValueSeqID).Value;

                if (model.IsDynamic)
                {
                    //model.Value = Value.value;
                }
                model.Value = value;  // burası "" yani boştu içi tanımladığım value değikenini atadım
                model.isHas = productAttiributeStatic2.Select(I => I.AttributeStaticValueSeqID).Contains(item.AttributeStaticValueSeqID);
                list2.Add(model);
            }
            List<AttributeStaticModel> list3 = new List<AttributeStaticModel>();
            var attributeStatic = attributeStaticRepository.TGetList();
            foreach (var item in attributeStatic)
            {
                AttributeStaticModel model = new AttributeStaticModel();
                model.AttributeStaticSeqID = item.AttributeStaticSeqID;
                model.Name = item.Name;
                list3.Add(model);
            }


            var productImageItem = productImagesRepository.TGetList(I => I.ProductSeqID == id && I.Status == true);
            

            List<ProductImageAddModel> listProductImage = new List<ProductImageAddModel>();

            foreach (var item in productImageItem)
            {
                ProductImageAddModel model = new ProductImageAddModel();
                model.ProductSeqID = item.ProductSeqID;
                model.ProductImageSeqID = item.ProductImageSeqID;
                model.ImageName = item.ImageName;
                model.Remark = item.Remark;
                listProductImage.Add(model);
            }

            var productProducersItem = productWithProducersRepository.TGetList(I => I.ProductSeqID == id);

            List<ProductWithProducersModel> listProductProducers = new List<ProductWithProducersModel>();

            foreach (var item in productProducersItem)
            {
                ProductWithProducersModel model = new ProductWithProducersModel();
                model.ProductSeqID = item.ProductSeqID;
                model.ProducerTypeSeqID = item.ProducerTypeSeqID;
                model.Name = item.Name;
                model.Description = item.Description;
                model.ProductWithProducerSeqID = item.ProductWithProducerSeqID;
                listProductProducers.Add(model);
            }

            mymodel.AttributeStaticListModel = list3;
            mymodel.catagoriAtaListModel = list1;
            mymodel.productAttirubuteStaticValueAtaListModel = list2;
            mymodel.ProductImageAddListModel = listProductImage;
            mymodel.ProductWithProducersListModel = listProductProducers;

            return mymodel;
        }
        public List<ProductAttributeModel> GetAttributeModel(int productID)// Ürünün Tüm Tanım bilgilerini getirir
        {
            var AttiributeStatic = productWithAttributeStaticValueRepository.TGetList().Join(attributeStaticValueRepository.TGetList(), A => A.AttributeStaticValueSeqID, PA => PA.AttributeStaticValueSeqID, (productWithAttributeStaticValues, attributeStaticValue) => new
            {
                AttributeStaticValue = attributeStaticValue,
                ProductWithAttributeStaticValues = productWithAttributeStaticValues
            }).Where(I => I.ProductWithAttributeStaticValues.ProductSeqID == productID).Select(I => new ProductAttributeModel
            {
                AttributeStaticValueSeqID = I.ProductWithAttributeStaticValues.AttributeStaticValueSeqID,
                Value = I.ProductWithAttributeStaticValues.Value,
                ProductSeqID = I.ProductWithAttributeStaticValues.ProductSeqID,
                ValueName = I.AttributeStaticValue.ValueName,
                isdinamic = I.AttributeStaticValue.IsDynamic,
                Remark = I.AttributeStaticValue.Remark,
                DisplayOrderNumber = I.AttributeStaticValue.DisplayOrderNumber

            }).OrderBy(O => O.DisplayOrderNumber).ToList();

            return AttiributeStatic;
        }
        public List<ProductDetailForMobile> GetProductDetailForMobile(int productID, string customer_def_no)// ürüne ait kategorileri getiriyor.
        {
            ProductDetailForMobile pd = new ProductDetailForMobile();
            pd.Result = true;
            pd.ResultCode = 1;
            pd.ResultMessage = "İşlem Başarılı";
            var poroduct = TGetList(i => i.ProductSeqID == productID).FirstOrDefault();
            if (poroduct != null)
            {
                pd.ProductSeqID = productID;
                pd.ProductName = poroduct.ProductName;
                pd.SecondName = poroduct.SecondName;
                pd.ReleaseDate = poroduct.ReleaseDate;
                pd.ImagePath = ApiParameters.URL + poroduct.ImageThumbPath;
                //pd.AllowCustomerRating = poroduct.AllowCustomerRating;
                //pd.AllowCustomerReviews = poroduct.AllowCustomerReviews;
                pd.Description = poroduct.Description;
                pd.ProductAttributeModel = attributeStaticValueRepository.GetProductAttribute(poroduct.ProductSeqID);

                
                pd.isFavorite =
                   customerFovoriListRepository.TGetList(w => w.customer_def_no == customer_def_no && w.RelatedFavoritesListSeqID == productID && w.GroupID == ApiFavoriListType.Favorite && w.IsActive == true
                   ).ToList().Count
                   > 0 ? true : false;
                //pd.inMyLibrary =
                //    context.CustomerFavoritesList.Where(w => w.customer_def_no == customer_def_no && w.RelatedFavoritesListSeqID == productID && w.GroupID == ApiFavoriListType.Library && w.IsActive == true
                //    ).ToList().Count
                //> 0 ? true : false;
                Random rastgele = new Random();
                int sayi = rastgele.Next(0, 5);
                pd.ProductPoints = sayi;
                var files = productImagesRepository.TGetList().Where(w => w.ProductSeqID == productID && w.IsDeleted == false && w.Status == true);
                foreach (var item in files)
                {
                    if (item.GroupId == ApiProductMediaGroupType.Kisa && item.MediaTypeId == ApiProductMediaType.Tiyatro)
                    {
                        pd.PreviewLink = ApiParameters.URL + item.ImagePath;
                    }
                    if (item.GroupId == ApiProductMediaGroupType.Tamami && item.MediaTypeId == ApiProductMediaType.Muzik)
                    {
                        pd.MusicLink = ApiParameters.URL + item.ImagePath;
                    }
                    if (item.GroupId == ApiProductMediaGroupType.Tamami && item.MediaTypeId == ApiProductMediaType.Tiyatro)
                    {
                        pd.TheaterLink = ApiParameters.URL + item.ImagePath;
                    }
                }

                // pd.PreviewLink = ApiParameters.URL +
                //     context.ProductImages.Where(w => w.ProductSeqID == productID && w.IsDeleted == false && w.GroupId == ApiProductMediaGroupType.Kisa && w.MediaTypeId == ApiProductMediaType.Tiyatro && w.Status == true)
                //         .Select(sdl => sdl.ImagePath).FirstOrDefault();
                // pd.MusicLink = ApiParameters.URL +
                //context.ProductImages.Where(w => w.ProductSeqID == productID && w.IsDeleted == false && w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Muzik && w.Status == true)
                //        .Select(sdl => sdl.ImagePath).FirstOrDefault();
                // pd.TheaterLink = ApiParameters.URL +
                //context.ProductImages.Where(w => w.ProductSeqID == productID && w.IsDeleted == false && w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Tiyatro && w.Status == true)
                //        .Select(sdl => sdl.ImagePath).FirstOrDefault();

                pd.CategorySeqIDList = TGetList()
                   .Join(productWithCategoryRepository.TGetList(), Products => Products.ProductSeqID, ProductWithCategory => ProductWithCategory.ProductSeqID, (P, PC) => new
                   {
                       Products = P,
                       ProductWithCategory = PC
                   })
                   .Where(I => I.Products.Status == true && I.Products.ProductSeqID == productID)
                   .Select(sc => sc.ProductWithCategory.CategorySeqID).ToList();
            }
            else
            {
                pd.Result = false;
                pd.ResultCode = -1;
                pd.ResultMessage = "Ürün Bulunamadı!";
            }
            List<ProductDetailForMobile> list = new List<ProductDetailForMobile>();
            list.Add(pd);
            return list;
        }
        public List<ProductDetailForMobile> GetAllProductDetailForMobile(int count, string customer_def_no)
        {
            Random rastgele = new Random();
            var poroduct = TGetList()
                .Where(w => w.Status == true)
                .Select(poroduct => new ProductDetailForMobile
                {
                    ProductSeqID = poroduct.ProductSeqID,
                    ProductName = poroduct.ProductName,
                    SecondName = poroduct.SecondName,
                    ReleaseDate = poroduct.ReleaseDate,
                    ImagePath = ApiParameters.URL + poroduct.ImageThumbPath,
                    //AllowCustomerRating = poroduct.AllowCustomerRating,
                    //AllowCustomerReviews = poroduct.AllowCustomerReviews,
                    Description = poroduct.Description,
                    ProductAttributeModel = attributeStaticValueRepository.GetProductAttribute(poroduct.ProductSeqID),
                    isFavorite =
               customerFovoriListRepository.TGetList()
               .Where(
                   w => w.customer_def_no == customer_def_no && w.RelatedFavoritesListSeqID == poroduct.ProductSeqID && w.GroupID == ApiFavoriListType.Favorite && w.IsActive == true
               ).ToList().Count
               > 0 ? true : false,
                    //        inMyLibrary =
                    //    context.CustomerFavoritesList
                    //    .Where(
                    //        w => w.customer_def_no == customer_def_no && w.RelatedFavoritesListSeqID == poroduct.ProductSeqID && w.GroupID == ApiFavoriListType.Library && w.IsActive == true
                    //    ).ToList().Count
                    //> 0 ? true : false,
                    ProductPoints = rastgele.Next(0, 5),
                    CategorySeqIDList = TGetList()
                .Join(productWithCategoryRepository.TGetList(), Products => Products.ProductSeqID, ProductWithCategory => ProductWithCategory.ProductSeqID, (P, PC) => new
                {
                    Products = P,
                    ProductWithCategory = PC
                }).Where(I => I.Products.Status == true && I.Products.ProductSeqID == poroduct.ProductSeqID).Select(sc => sc.ProductWithCategory.CategorySeqID).ToList(),
                    Result = true,
                    ResultCode = 1,
                    ResultMessage = "İşlem Başarılı"
                }).Take(count).ToList();
            return poroduct;
        }
        public List<Products> SeachProductWeb(string name, int languageId)
        {
            var Products = TGetList(q => q.Status == true && q.LanguageID == languageId && q.ProductName.Contains(name)).ToList();
            return Products;
        }
        #region Onder
        public ProductsModel getProducts()
        {
            ProductsModel ProductList = new ProductsModel();
            ProductList.Result = true;
            ProductList.ResultCode = 1;
            ProductList.ResultMessage = "İşlem Başarılı";
            ProductList.Products = TGetList();
            return ProductList;
        }
        public List<ProductWithCategoryModel> getProductWithCategory()
        {

            var result = categoryRepository.TGetList().Where(W => W.Status == true).Select(S => new ProductWithCategoryModel
            {
                CategorySeqID = S.CategorySeqID,
                CategoryName = S.Name,
                ImagePath = S.ImagePath,
                DisplayOrderNumber = S.DisplayOrderNumber,
                Products = TGetList().Join(productWithCategoryRepository.TGetList(), Products => Products.ProductSeqID, ProductWithCategory => ProductWithCategory.ProductSeqID, (P, PC) => new
                {
                    Products = P,
                    ProductWithCategory = PC
                }).Where(I => I.Products.Status == true && I.ProductWithCategory.CategorySeqID == S.CategorySeqID).Select(S1 => new ViewValueItems
                {
                    ID = S1.Products.ProductSeqID,
                    Name = S1.Products.ProductName,
                    ImagePath = ApiParameters.URL + S1.Products.ImageThumbPath
                }).ToList()
            }).OrderBy(O => O.DisplayOrderNumber).ToList();
            return result;
        }
        public List<ViewValueItems> ByAageRrangeProducts(int Count, string customer_def_no)
        {
            return TGetList().OrderByDescending(u => u.ProductSeqID).Select(S => new ViewValueItems
            {
                ID = S.ProductSeqID,
                Name = S.ProductName,
                ImagePath = ApiParameters.URL + S.ImageThumbPath,
                //CategorySeqIDList = context.Products.Join(context.ProductWithCategories, Products => Products.ProductSeqID, ProductWithCategory => ProductWithCategory.ProductSeqID, (P, PC) => new
                //{
                //    Products = P,
                //    ProductWithCategory = PC
                //}).Where(I => I.Products.Status == true && I.Products.ProductSeqID == S.ProductSeqID).Select(sc => sc.ProductWithCategory.CategorySeqID).ToList(),
                ProductDetailList = GetProductDetailForMobile(S.ProductSeqID, customer_def_no)
            }).Take(Count).ToList();
        }
        public List<ViewValueItems> getTheNewests(int Count, string customer_def_no)
        {
            var result = TGetList().OrderByDescending(u => u.ProductSeqID).Select(S => new ViewValueItems
            {
                ID = S.ProductSeqID,
                Name = S.ProductName,
                ImagePath = ApiParameters.URL + S.ImageThumbPath,

                //CategorySeqIDList = context.Products.Join(context.ProductWithCategories, Products => Products.ProductSeqID, ProductWithCategory => ProductWithCategory.ProductSeqID, (P, PC) => new
                //{
                //    Products = P,
                //    ProductWithCategory = PC
                //}).Where(I => I.Products.Status == true && I.Products.ProductSeqID == S.ProductSeqID).Select(sc => sc.ProductWithCategory.CategorySeqID).ToList(),
                ProductDetailList = GetProductDetailForMobile(S.ProductSeqID, customer_def_no)
            }).OrderByDescending(O => O.ID).Take(Count).ToList();
            return result;
        }
        public List<ViewValueItems> getTopRateProduct(int Count, string customer_def_no)
        {
            return TGetList().OrderByDescending(u => u.ProductSeqID).Select(S => new ViewValueItems
            {
                ID = S.ProductSeqID,
                Name = S.ProductName,
                ImagePath = ApiParameters.URL + S.ImageThumbPath,
                //CategorySeqIDList = context.Products.Join(context.ProductWithCategories, Products => Products.ProductSeqID, ProductWithCategory => ProductWithCategory.ProductSeqID, (P, PC) => new
                //{
                //    Products = P,
                //    ProductWithCategory = PC
                //}).Where(I => I.Products.Status == true && I.Products.ProductSeqID == S.ProductSeqID).Select(sc => sc.ProductWithCategory.CategorySeqID).ToList(),
                ProductDetailList = GetProductDetailForMobile(S.ProductSeqID, customer_def_no)
            }).Take(Count).ToList();
        }
        public List<ViewValueItems> getPopularAudioTheaters(int Count, string customer_def_no)
        {
            return TGetList().OrderByDescending(u => u.ProductSeqID).Select(S => new ViewValueItems
            {
                ID = S.ProductSeqID,
                Name = S.ProductName,
                ImagePath = ApiParameters.URL + S.ImageThumbPath,
                //CategorySeqIDList = context.Products.Join(context.ProductWithCategories, Products => Products.ProductSeqID, ProductWithCategory => ProductWithCategory.ProductSeqID, (P, PC) => new
                //{
                //    Products = P,
                //    ProductWithCategory = PC
                //}).Where(I => I.Products.Status == true && I.Products.ProductSeqID == S.ProductSeqID).Select(sc => sc.ProductWithCategory.CategorySeqID).ToList(),
                ProductDetailList = GetProductDetailForMobile(S.ProductSeqID, customer_def_no)
            }).Take(Count).ToList();
        }
        public Document GetItemsAsync(int MenuID, int LanguageID)
        {
            Document documnet = documentsRepository.TgetItemByID(MenuID);
            return documnet;
        }
        public List<Menu> GetUserMenusForDocument(int LanguageID)
        {
            return menuRepository.TGetList(I => I.ContentTypeID == MenuContentType.MobilAndroid && I.Status == true && I.controller == "Document" && I.PositionID == 3 && I.LanguageID == LanguageID)
                .OrderBy(I => I.DisplayOrderNumber).ToList();
        }
        public ProductsSearchApi SeachProduct(string name, string customer_def_no)
        {
            Random rastgele = new Random();
            ProductsSearchApi ProductList = new ProductsSearchApi();
            ProductList.Result = true;
            ProductList.ResultCode = 1;
            ProductList.ResultMessage = "İşlem Başarılı";
            ProductList.Products = TGetList(q => q.Status == true && q.ProductName.Contains(name)).Select(S => new Product
            {
                productId = S.ProductSeqID,
                productName = S.ProductName,
                secondName = S.SecondName,
                description = Functions.StripHTML(S.Description),
                imageUrl = ApiParameters.URL + TGetList(w => w.ProductSeqID == S.ProductID).FirstOrDefault().ImageThumbPath,
                musicId = productImagesRepository.TGetList().Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Muzik && w.ProductSeqID == S.ProductID && w.IsDeleted == false && w.Status == true).Select(s => s.ProductImageSeqID).FirstOrDefault(),
                theaterId = productImagesRepository.TGetList().Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Tiyatro && w.ProductSeqID == S.ProductID && w.IsDeleted == false && w.Status == true).Select(s => s.ProductImageSeqID).FirstOrDefault(),
                previewUrl = ApiParameters.URL + productImagesRepository.TGetList().Where(w => w.GroupId == ApiProductMediaGroupType.Kisa && w.MediaTypeId == ApiProductMediaType.Tiyatro && w.ProductSeqID == S.ProductID && w.IsDeleted == false && w.Status == true).Select(s => s.ImagePath).FirstOrDefault(),
                theaterUrl = ApiParameters.URL + productImagesRepository.TGetList().Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Tiyatro && w.ProductSeqID == S.ProductID && w.IsDeleted == false && w.Status == true).Select(s => s.ImagePath).FirstOrDefault(),
                musicUrl = ApiParameters.URL + productImagesRepository.TGetList().Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Muzik && w.ProductSeqID == S.ProductID && w.IsDeleted == false && w.Status == true).Select(s => s.ImagePath).FirstOrDefault(),
                productUrl = ApiParameters.URL + "/Product/GetProductDetail/" + S.ProductSeqID.ToString(),
                theaterDuration = customerTrackingTypeRepository.GetCustomerTrackingTypeLastApi(customer_def_no, productImagesRepository.TGetList().Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Tiyatro && w.ProductSeqID == S.ProductSeqID && w.IsDeleted == false && w.Status == true).Select(s => s.ProductImageSeqID).FirstOrDefault()),
                musicDuration = customerTrackingTypeRepository.GetCustomerTrackingTypeLastApi(customer_def_no, productImagesRepository.TGetList().Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Muzik && w.ProductSeqID == S.ProductSeqID && w.IsDeleted == false && w.Status == true).Select(s => s.ProductImageSeqID).FirstOrDefault()),
                isFavorite = false,
                lastDuration = 0,
                productPoints = Convert.ToDouble(customerRatingsRepository.ProductPoint(S.ProductSeqID)),
                displayOrderNumber = S.DisplayOrderNumber,
                isMusicFavorite =
                customerFovoriListRepository.TGetList().Join(productImagesRepository.TGetList(), CF => CF.RelatedFavoritesListSeqID, Img => Img.ProductImageSeqID, (C, I) => new
                {
                    C = C,
                    I = I
                })
                .Where(
                    w => w.I.GroupId == ApiProductMediaGroupType.Tamami && w.I.MediaTypeId == ApiProductMediaType.Muzik && w.C.customer_def_no == customer_def_no && w.C.RelatedFavoritesListSeqID == w.I.ProductImageSeqID && w.I.ProductSeqID == S.ProductSeqID && w.C.GroupID == ApiFavoriListType.Favorite && w.C.IsActive == true
                ).Select(sci => sci.I.ProductImageSeqID).ToList().Count > 0 ? true : false,

                isTheaterFavorite =
                 customerFovoriListRepository.TGetList().Join(productImagesRepository.TGetList(), CF => CF.RelatedFavoritesListSeqID, Img => Img.ProductImageSeqID, (C, I) => new
                 {
                     C = C,
                     I = I
                 })
                .Where(
                    w => w.I.GroupId == ApiProductMediaGroupType.Tamami && w.I.MediaTypeId == ApiProductMediaType.Tiyatro && w.C.customer_def_no == customer_def_no && w.C.RelatedFavoritesListSeqID == w.I.ProductImageSeqID && w.I.ProductSeqID == S.ProductSeqID && w.C.GroupID == ApiFavoriListType.Favorite && w.C.IsActive == true
                ).Select(sci => sci.I.ProductImageSeqID).ToList().Count > 0 ? true : false,


                isMusicInPlayList = false,
                isTheaterInPlayList = false,
                isMusicInKeepListening = false,
                isTheaterInKeepListening = false,


                categoryIdList = TGetList()
                .Join(productWithCategoryRepository.TGetList(), Products => Products.ProductSeqID, ProductWithCategory => ProductWithCategory.ProductSeqID, (P, PC) => new
                {
                    Products = P,
                    ProductWithCategory = PC
                }).Where(I => I.Products.Status == true && I.Products.ProductSeqID == S.ProductSeqID).Select(sc => sc.ProductWithCategory.CategorySeqID).ToList(),
                releaseDate = S.ReleaseDate,
                productAttributeList = attributeStaticValueRepository.GetHomeProductAttribute(S.ProductSeqID),
                categoryName =
                    categoryRepository.TGetList().Join(productWithCategoryRepository.TGetList(), C => C.CategorySeqID, pc => pc.CategorySeqID, (C, PC) => new
                    {
                        C = C,
                        PC = PC
                    }).Where(w => w.PC.ProductSeqID == S.ProductSeqID && w.C.Status == true).FirstOrDefault().C.Name
            }).Take(5).ToList();
            return ProductList;
        }
        public ViewValue GetGroupAllProductsApi(int GroupID, string customer_def_no, int count)
        {
            ViewValue value1 = new ViewValue();
            if (GroupID == ApiMainPageGroupID.TheNewests)
            {
                value1.GroupID = ApiMainPageGroupID.TheNewests;//1;
                value1.Title = "En Yeniler";
                value1.TitleImagePhat = ApiParameters.URL + "/AdminImage/ProductImg/Thump48112ff0-d6e7-45cd-8e03-c19423351cc6.jpg";
                value1.Data = getTheNewests(count, customer_def_no);
            }
            if (GroupID == ApiMainPageGroupID.TopRateProducts)
            {
                value1.GroupID = ApiMainPageGroupID.TopRateProducts;//2;
                value1.Title = "En Beğenilenler";
                value1.TitleImagePhat = ApiParameters.URL + "/AdminImage/ProductImg/Thump48112ff0-d6e7-45cd-8e03-c19423351cc6.jpg";
                value1.Data = getTopRateProduct(count, customer_def_no);
            }
            if (GroupID == ApiMainPageGroupID.KeepListening)
            {
                value1.GroupID = ApiMainPageGroupID.KeepListening;//3;
                value1.Title = "Dinlemeye Devam Edin (Üye Olanlar İçin)";
                value1.TitleImagePhat = ApiParameters.URL + "/AdminImage/ProductImg/Thump48112ff0-d6e7-45cd-8e03-c19423351cc6.jpg";
                value1.Data = getTheNewests(count, customer_def_no);
            }
            if (GroupID == ApiMainPageGroupID.PopularAudioTheaterProducts)
            {
                value1.GroupID = ApiMainPageGroupID.PopularAudioTheaterProducts;//4;
                value1.Title = "Bilindik Sesli Tiyatrolar";
                value1.TitleImagePhat = ApiParameters.URL + "/AdminImage/ProductImg/Thump48112ff0-d6e7-45cd-8e03-c19423351cc6.jpg";
                value1.Data = getPopularAudioTheaters(count, customer_def_no);
            }
            if (GroupID == ApiMainPageGroupID.ByAgeRrangeProducts)
            {
                value1.GroupID = ApiMainPageGroupID.ByAgeRrangeProducts;//5;
                value1.Title = "Yaş Aralığına Göre";
                value1.TitleImagePhat = ApiParameters.URL + "/AdminImage/ProductImg/Thump48112ff0-d6e7-45cd-8e03-c19423351cc6.jpg";
                value1.FliterList = categoryRepository.GetAllCategoriForApi();
                value1.Data = ByAageRrangeProducts(count, customer_def_no);
            }
            if (GroupID == ApiMainPageGroupID.Producers)
            {
                value1.GroupID = ApiMainPageGroupID.Producers;//6;
                value1.Title = "Seslendirenler";
                value1.TitleImagePhat = ApiParameters.URL + "/AdminImage/ProductImg/Thump48112ff0-d6e7-45cd-8e03-c19423351cc6.jpg";
                value1.Data = producersRepository.getProducersLitMainMenu(count, customer_def_no);
             }

            return value1;
        }
        public ProductGroup GetHomeProductsApi(int GroupID, string customer_def_no, int count, int languageId)
        {
            ProductGroup value1 = new ProductGroup();
            //if (languageId == 1)
            //{
            //    MultiLanguageOmni.ReadResourceKey.cultureName = "tr-TR";
            //}

            //else if (languageId == 2)
            //{ MultiLanguageOmni.ReadResourceKey.cultureName = "en-US"; }
            //else if (languageId == 3)
            //{ MultiLanguageOmni.ReadResourceKey.cultureName = "de-DE"; }
            //else
            //{ MultiLanguageOmni.ReadResourceKey.cultureName = "tr-TR"; }

            if (GroupID == ApiMainPageGroupID.TheNewests)
            {
                value1.productGroupId = ApiMainPageGroupID.TheNewests;//1;
                if (languageId == 1)
                { value1.title = "En Yeniler"; }
                else if (languageId == 2)
                { value1.title = "Newest"; }
                else if (languageId == 3)
                { value1.title = "Neueste"; }
                else
                { value1.title = "En Yeniler"; }

                //value1.title = "En Yeniler";
                value1.coverImageUrl = ApiParameters.URL + "/AdminImage/CategoryImage/mavilogoQuki.png";
                //value1.productList = productsRepository.GetHomeProductTheNewestsDetailForMobile(count, customer_def_no, languageId);
                value1.productList = GetHomeProductDetailForMobile(count, customer_def_no, languageId, GroupID);

                value1.orderList = SelectAllOrders();
            }
            if (GroupID == ApiMainPageGroupID.TopRateProducts)
            {
                value1.productGroupId = ApiMainPageGroupID.TopRateProducts;//2;

                if (languageId == 1)
                { value1.title = "En Beğenilenler"; }
                else if (languageId == 2)
                { value1.title = "Most Liked"; }
                else if (languageId == 3)
                { value1.title = "Beliebsteste"; }
                else
                { value1.title = "En Beğenilenler"; }
                value1.coverImageUrl = ApiParameters.URL + "/AdminImage/CategoryImage/mavilogoQuki.png";
                value1.productList = GetHomeProductDetailForMobile(count, customer_def_no, languageId, GroupID);
                value1.orderList = SelectAllOrders();
            }
            if (GroupID == ApiMainPageGroupID.KeepListening)
            {
                value1.productGroupId = ApiMainPageGroupID.KeepListening;//3;
                //value1.title=MultiLanguageOmni.ReadResourceKey.GetString("ContinueListening", "MultiLanguageOmni.Index");
                if (languageId == 1)
                { value1.title = "Dinlemeye Devam Edin"; }
                else if (languageId == 2)
                { value1.title = "Keep hearing"; }
                else if (languageId == 3)
                { value1.title = "Weiter zuhören"; }
                else
                { value1.title = "Dinlemeye Devam Edin"; }

                value1.coverImageUrl = ApiParameters.URL + "/AdminImage/CategoryImage/pembelogoQuki.png";
                value1.productList = GetHomeProductDetailForMobile(count, customer_def_no, languageId, GroupID);
                value1.orderList = SelectAllOrders();
            }
            if (GroupID == ApiMainPageGroupID.PopularAudioTheaterProducts)
            {
                value1.productGroupId = ApiMainPageGroupID.PopularAudioTheaterProducts;//4;

                if (languageId == 1)
                { value1.title = "Popüler Sesli Tiyatrolar"; }
                else if (languageId == 2)
                { value1.title = "Popular audio theaters"; }
                else if (languageId == 3)
                { value1.title = "Beliebte Hörspiele"; }
                else
                { value1.title = "Popüler Sesli Tiyatrolar"; }

                value1.coverImageUrl = ApiParameters.URL + "/AdminImage/CategoryImage/pembelogoQuki.png";
                value1.productList = GetHomeProductDetailForMobile(count, customer_def_no, languageId, GroupID);
                value1.orderList = SelectAllOrders();
            }
            if (GroupID == ApiMainPageGroupID.ByAgeRrangeProducts)
            {
                value1.productGroupId = ApiMainPageGroupID.ByAgeRrangeProducts;//5;

                if (languageId == 1)
                { value1.title = "Yaş Aralığına Göre"; }
                else if (languageId == 2)
                { value1.title = "By Age Range"; }
                else if (languageId == 3)
                { value1.title = "nach Altersgruppen"; }
                else
                { value1.title = "Yaş Aralığına Göre"; }


                value1.coverImageUrl = ApiParameters.URL + "/AdminImage/CategoryImage/turunculogoQuki.png";
                value1.filterList = categoryRepository.GetHomeCategoriForApi(languageId);
                value1.orderList = SelectAllOrders();
                value1.productList = GetHomeProductDetailForMobile(count, customer_def_no, languageId, GroupID);
            }
            //if (GroupID == ApiMainPageGroupID.Producers)
            //{
            //    value1.productGroupId = ApiMainPageGroupID.Producers;//6;
            //    value1.title = "Seslendirenler";
            //    value1.coverImageUrl = ApiParameters.URL + "/AdminImage/ProductImg/Thump48112ff0-d6e7-45cd-8e03-c19423351cc6.jpg";
            //    value1. = producers.getHomeProducersList(count, customer_def_no);
            //}

            return value1;
        }
        public List<Product> GetHomeProductDetailForMobile(int count, string customer_def_no, int languageId, int GroupID)
        {
            Random rastgele = new Random();
           List<Product> productList = new List<Product>();
            try
            {
                string sql = "exec SelectHomeProduct @customer_def_no='" + customer_def_no + "' , @languageId=" + languageId + ", @groupID=" + GroupID;
                var products = productRepository.ExecuteSql(sql);
                int index = 0;
                if (products != null)
                {
                    if (products.Count > 0)
                    {
                        foreach (var item in products)
                        {
                            if (index > count)
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
                            product.preListeningRight = item.preListeningRight;
                            product.isMusicInKeepListening = item.isMusicInKeepListening;
                            product.isTheaterInKeepListening = item.isTheaterInKeepListening;
                            product.isFavorite = item.isFavorite;

                            product.categoryIdList = TGetList()
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
        public int ProductAddForAnotherLanguage(ProductMergeModel Item, int ProductSeqID)
        {
            Products p = new Products();
            if (Item.ProductUpdateModel.ImagePath != null)
            {
                var path = Path.GetExtension(Item.ProductUpdateModel.ImagePath.FileName);
                var newPath = Guid.NewGuid() + path;
                var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProductImg/" + newPath;
                var ThumbImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProductImg/Thump" + newPath;
                var steem = new FileStream(ImagePath, FileMode.Create);
                Item.ProductUpdateModel.ImagePath.CopyTo(steem);
                Utility.ResizeImage(Item.ProductUpdateModel.ImagePath, ProductImageSize.Height, ProductImageSize.Width, ThumbImagePath);
                p.ImagePath = "/AdminImage/ProductImg/" + newPath; ;
                p.ImageThumbPath = "/AdminImage/ProductImg/Thump" + newPath;
            }

            p.ProductName = Item.ProductUpdateModel.ProductName;
            p.LanguageID = Item.ProductUpdateModel.LanguageID;
            p.SecondName = Item.ProductUpdateModel.SecondName;
            p.ProductSEOData = Item.ProductUpdateModel.ProductSEOData;
            p.AllowCustomerReviews = Item.ProductUpdateModel.AllowCustomerReviews;
            p.AllowCustomerRating = Item.ProductUpdateModel.AllowCustomerRating;
            p.ShowOnHomePage = Item.ProductUpdateModel.ShowOnHomePage;
            p.Status = Item.ProductUpdateModel.Status;
            p.DisplayOrderNumber = Item.ProductUpdateModel.DisplayOrderNumber;
            p.Description = Item.ProductUpdateModel.Description;
            p.ReleaseDate = Item.ProductUpdateModel.ReleaseDate;
            p.CreatedOn = DateTime.Now;
            TAdd(p);
            p.ProductID = ProductSeqID;
            TUpdate(p);
            return p.ProductSeqID;
        }
        public Product GetProductByID(int ProductSeqID, string customer_def_no, int? languageId)
        {
            Random rastgele = new Random();
            
            var poroduct = TGetList()
                .Where(w => w.Status == true && w.LanguageID == languageId && w.ProductSeqID == ProductSeqID)
                .Select(poroduct => new Product
                {
                    productId = poroduct.ProductSeqID,
                    productName = poroduct.ProductName,
                    secondName = poroduct.SecondName,
                    description = Functions.StripHTML(poroduct.Description),
                    imageUrl = ApiParameters.URL + TGetList(w => w.ProductSeqID == poroduct.ProductID).FirstOrDefault().ImageThumbPath,
                    previewUrl = ApiParameters.URL + productImagesRepository.TGetList().Where(w => w.GroupId == ApiProductMediaGroupType.Kisa && w.MediaTypeId == ApiProductMediaType.Tiyatro && w.ProductSeqID == poroduct.ProductID && w.IsDeleted == false && w.Status == true).Select(s => s.ImagePath).FirstOrDefault(),
                    theaterId = productImagesRepository.TGetList().Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Tiyatro && w.ProductSeqID == poroduct.ProductID && w.IsDeleted == false && w.Status == true).Select(s => s.ProductImageSeqID).FirstOrDefault(),
                    theaterUrl = ApiParameters.URL + productImagesRepository.TGetList().Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Tiyatro && w.ProductSeqID == poroduct.ProductID && w.IsDeleted == false && w.Status == true).Select(s => s.ImagePath).FirstOrDefault(),
                    musicId = productImagesRepository.TGetList().Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Muzik && w.ProductSeqID == poroduct.ProductSeqID && w.IsDeleted == false && w.Status == true).Select(s => s.ProductImageSeqID).FirstOrDefault(),
                    musicUrl = ApiParameters.URL + productImagesRepository.TGetList().Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Muzik && w.ProductSeqID == poroduct.ProductID && w.IsDeleted == false && w.Status == true).Select(s => s.ImagePath).FirstOrDefault(),
                    productUrl = ApiParameters.URL + "/Product/GetProductDetail/" + poroduct.ProductSeqID.ToString(),
                    theaterDuration = customerTrackingTypeRepository.GetCustomerTrackingTypeLastApi(customer_def_no, productImagesRepository.TGetList().Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Tiyatro && w.ProductSeqID == poroduct.ProductSeqID && w.IsDeleted == false && w.Status == true).Select(s => s.ProductImageSeqID).FirstOrDefault()),
                    musicDuration = customerTrackingTypeRepository.GetCustomerTrackingTypeLastApi(customer_def_no, productImagesRepository.TGetList().Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Muzik && w.ProductSeqID == poroduct.ProductSeqID && w.IsDeleted == false && w.Status == true).Select(s => s.ProductImageSeqID).FirstOrDefault()),
                    lastDuration = 0,
                    productPoints = Convert.ToDouble(customerRatingsRepository.ProductPoint(poroduct.ProductSeqID)),
                    displayOrderNumber = poroduct.DisplayOrderNumber,isMusicFavorite =
                customerFovoriListRepository.TGetList().Join(productImagesRepository.TGetList(), CF => CF.RelatedFavoritesListSeqID, Img => Img.ProductImageSeqID, (C, I) => new
                {
                    C = C,
                    I = I
                })
                .Where(
                    w => w.I.GroupId == ApiProductMediaGroupType.Tamami && w.I.MediaTypeId == ApiProductMediaType.Muzik && w.C.customer_def_no == customer_def_no && w.C.RelatedFavoritesListSeqID == w.I.ProductImageSeqID && w.I.ProductSeqID == poroduct.ProductSeqID && w.C.GroupID == ApiFavoriListType.Favorite && w.C.IsActive == true
                ).Select(sci => sci.I.ProductImageSeqID).ToList().Count > 0 ? true : false,


                    isTheaterFavorite =
                 customerFovoriListRepository.TGetList().Join(productImagesRepository.TGetList(), CF => CF.RelatedFavoritesListSeqID, Img => Img.ProductImageSeqID, (C, I) => new
                 {
                     C = C,
                     I = I
                 })
                .Where(
                    w => w.I.GroupId == ApiProductMediaGroupType.Tamami && w.I.MediaTypeId == ApiProductMediaType.Tiyatro && w.C.customer_def_no == customer_def_no && w.C.RelatedFavoritesListSeqID == w.I.ProductImageSeqID && w.I.ProductSeqID == poroduct.ProductSeqID && w.C.GroupID == ApiFavoriListType.Favorite && w.C.IsActive == true
                ).Select(sci => sci.I.ProductImageSeqID).ToList().Count > 0 ? true : false,


                    isMusicInPlayList = false,
                    isTheaterInPlayList = false,
                    isMusicInKeepListening = customerTrackingTypeRepository.TGetList().Join(productImagesRepository.TGetList(), CF => CF.RelatedTrackingSeqID, Img => Img.ProductImageSeqID, (C, I) => new
                    {
                        C = C,
                        I = I
                    })
                .Where(
                    w => w.I.GroupId == ApiProductMediaGroupType.Tamami && w.I.MediaTypeId == ApiProductMediaType.Muzik && w.C.Customer_def_no == customer_def_no && w.C.RelatedTrackingSeqID == w.I.ProductImageSeqID && w.I.ProductSeqID == poroduct.ProductSeqID && w.C.GroupID == ApiFavoriListType.Favorite
                ).Select(sci => sci.I.ProductImageSeqID).ToList().Count > 0 ? true : false,
                    isTheaterInKeepListening = customerTrackingTypeRepository.TGetList().Join(productImagesRepository.TGetList(), CF => CF.RelatedTrackingSeqID, Img => Img.ProductImageSeqID, (C, I) => new
                    {
                        C = C,
                        I = I
                    })
                .Where(
                    w => w.I.GroupId == ApiProductMediaGroupType.Tamami && w.I.MediaTypeId == ApiProductMediaType.Tiyatro && w.C.Customer_def_no == customer_def_no && w.C.RelatedTrackingSeqID == w.I.ProductImageSeqID && w.I.ProductSeqID == poroduct.ProductSeqID && w.C.GroupID == ApiFavoriListType.Favorite
                ).Select(sci => sci.I.ProductImageSeqID).ToList().Count > 0 ? true : false,
                    //     favoriteMediaId = context.CustomerFavoritesList
                    //         .Join(context.ProductImages, CustomerFavoritesList => CustomerFavoritesList.RelatedFavoritesListSeqID, ProductImage => ProductImage.ProductImageSeqID,
                    //     (C, P) => new
                    //     {
                    //         CustomerFavoritesList = C,
                    //         ProductImage = P
                    //     }).Where(
                    //    w => w.CustomerFavoritesList.customer_def_no == customer_def_no && w.CustomerFavoritesList.RelatedFavoritesListSeqID == w.ProductImage.ProductImageSeqID && w.ProductImage.ProductSeqID == poroduct.ProductSeqID && w.CustomerFavoritesList.GroupID == ApiFavoriListType.Favorite && w.CustomerFavoritesList.IsActive == true
                    //).Select(sf => sf.ProductImage.ProductImageSeqID).ToList(),
                    isFavorite = false,

                    categoryIdList = TGetList()
                .Join(productWithCategoryRepository.TGetList(), Products => Products.ProductSeqID, ProductWithCategory => ProductWithCategory.ProductSeqID, (P, PC) => new
                {
                    Products = P,
                    ProductWithCategory = PC
                }).Where(I => I.Products.Status == true && I.Products.ProductSeqID == poroduct.ProductSeqID).Select(sc => sc.ProductWithCategory.CategorySeqID).ToList(),
                    releaseDate = poroduct.ReleaseDate,
                    productAttributeList = attributeStaticValueRepository.GetHomeProductAttribute(poroduct.ProductSeqID),
                    categoryName =
                    categoryRepository.TGetList().Join(productWithCategoryRepository.TGetList(), C => C.CategorySeqID, pc => pc.CategorySeqID, (C, PC) => new
                    {
                        C = C,
                        PC = PC
                    }).Where(w => w.PC.ProductSeqID == poroduct.ProductSeqID && w.C.Status == true).FirstOrDefault().C.Name
                }).FirstOrDefault();
            return poroduct;
        }
        #endregion Onder
        public ProductImage GetMediaList(int id)
        {
            var items = productImagesRepository.TGetList().Where(x => x.ProductImageSeqID == id && x.Status == true).FirstOrDefault();
            return items;
        }
        public List<Filter> SelectAllOrders()
        {
            List<Filter> filterList = new List<Filter>();
            Filter allAudioTheaters = new Filter();
            allAudioTheaters.filterId = ApiProductOrderIDs.allAudioTheaters;
            allAudioTheaters.name = "Tüm Sesli Tiyatrolar";
            Filter productOrderAZ = new Filter();
            productOrderAZ.filterId = ApiProductOrderIDs.productOrderAZ;
            productOrderAZ.name = "Ürün Adı (A-Z)";
            Filter productOrderZA = new Filter();
            productOrderZA.filterId = ApiProductOrderIDs.productOrderZA;
            productOrderZA.name = "Ürün Adı (Z-A)";
            Filter productOrderPoint = new Filter();
            productOrderPoint.filterId = ApiProductOrderIDs.productOrderPoint;
            productOrderPoint.name = "En Yüksek Puan";
            Filter productOrderLastCreate = new Filter();
            productOrderLastCreate.filterId = ApiProductOrderIDs.productOrderLastCreate;
            productOrderLastCreate.name = "En Son Eklenen";

            filterList.Add(allAudioTheaters);
            filterList.Add(productOrderAZ);
            filterList.Add(productOrderZA);
            filterList.Add(productOrderPoint);
            filterList.Add(productOrderLastCreate);
            return filterList;
        }
        public bool ProductDeleteById(int id)
        {
            bool result = false;

            var x = TGetList(x => x.ProductSeqID == id).FirstOrDefault();

            x.Status = false;
            x.IsDeleted = true;

            TUpdate(x);
            result = true;
            return result;
        }
        public List<Product> GetHomeProductDetailByIDForMobile(int ProductSeqID, string customer_def_no, int languageId)
        {
            Random rastgele = new Random();
            
            var poroduct = new List<Product>();
            try
            {
                var setProductImage = productImagesRepository.TGetList();
                var setCustomerFavoritesList = customerFovoriListRepository.TGetList();

                poroduct = TGetList()
                .Where(w => w.Status == true && w.LanguageID == languageId && w.ProductSeqID == ProductSeqID)
                .Select(poroduct => new Product
                {
                    productId = poroduct.ProductSeqID,
                    productName = poroduct.ProductName,
                    secondName = poroduct.SecondName,
                    description = Functions.StripHTML(poroduct.Description),


                    imageUrl = ApiParameters.URL + TGetList(w => w.ProductSeqID == poroduct.ProductID).FirstOrDefault().ImageThumbPath,
                    previewUrl = ApiParameters.URL + setProductImage.Where(w => w.GroupId == ApiProductMediaGroupType.Kisa && w.MediaTypeId == ApiProductMediaType.Tiyatro && w.ProductSeqID == poroduct.ProductID && w.IsDeleted == false && w.Status == true).FirstOrDefault(),
                    theaterId = setProductImage.Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Tiyatro && w.ProductSeqID == poroduct.ProductID && w.IsDeleted == false && w.Status == true).Select(s => s.ProductImageSeqID).FirstOrDefault(),
                    theaterUrl = ApiParameters.URL + setProductImage.Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Tiyatro && w.ProductSeqID == poroduct.ProductID && w.IsDeleted == false && w.Status == true).Select(s => s.ImagePath).FirstOrDefault(),
                    musicId = setProductImage.Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Muzik && w.ProductSeqID == poroduct.ProductSeqID && w.IsDeleted == false && w.Status == true).Select(s => s.ProductImageSeqID).FirstOrDefault(),
                    musicUrl = ApiParameters.URL + setProductImage.Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Muzik && w.ProductSeqID == poroduct.ProductID && w.IsDeleted == false && w.Status == true).Select(s => s.ImagePath).FirstOrDefault(),

                    productUrl = ApiParameters.URL + "/Product/GetProductDetail/" + poroduct.ProductSeqID.ToString(),
                    theaterDuration = customerTrackingTypeRepository.GetCustomerTrackingTypeLastApi(customer_def_no, setProductImage.Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Tiyatro && w.ProductSeqID == poroduct.ProductSeqID && w.IsDeleted == false && w.Status == true).Select(s => s.ProductImageSeqID).FirstOrDefault()),
                    musicDuration = customerTrackingTypeRepository.GetCustomerTrackingTypeLastApi(customer_def_no, setProductImage.Where(w => w.GroupId == ApiProductMediaGroupType.Tamami && w.MediaTypeId == ApiProductMediaType.Muzik && w.ProductSeqID == poroduct.ProductSeqID && w.IsDeleted == false && w.Status == true).Select(s => s.ProductImageSeqID).FirstOrDefault()),
                    lastDuration = 0,
                    productPoints = Convert.ToDouble(customerRatingsRepository.ProductPoint(poroduct.ProductSeqID)),
                    displayOrderNumber = poroduct.DisplayOrderNumber,

                    isMusicFavorite =
                customerFovoriListRepository.TGetList().Join(setProductImage, CF => CF.RelatedFavoritesListSeqID, Img => Img.ProductImageSeqID, (C, I) => new
                {
                    C = C,
                    I = I
                })
                .Where(
                    w => w.I.GroupId == ApiProductMediaGroupType.Tamami && w.I.MediaTypeId == ApiProductMediaType.Muzik && w.C.customer_def_no == customer_def_no && w.C.RelatedFavoritesListSeqID == w.I.ProductImageSeqID && w.I.ProductSeqID == poroduct.ProductSeqID && w.C.GroupID == ApiFavoriListType.Favorite && w.C.IsActive == true
                ).Select(sci => sci.I.ProductImageSeqID).ToList().Count > 0 ? true : false,



                    isTheaterFavorite =
                 customerFovoriListRepository.TGetList().Join(setProductImage, CF => CF.RelatedFavoritesListSeqID, Img => Img.ProductImageSeqID, (C, I) => new
                 {
                     C = C,
                     I = I
                 })
                .Where(
                    w => w.I.GroupId == ApiProductMediaGroupType.Tamami && w.I.MediaTypeId == ApiProductMediaType.Tiyatro && w.C.customer_def_no == customer_def_no && w.C.RelatedFavoritesListSeqID == w.I.ProductImageSeqID && w.I.ProductSeqID == poroduct.ProductSeqID && w.C.GroupID == ApiFavoriListType.Favorite && w.C.IsActive == true
                ).Select(sci => sci.I.ProductImageSeqID).ToList().Count > 0 ? true : false,


                    isMusicInPlayList = false,
                    isTheaterInPlayList = false,
                    isMusicInKeepListening = customerTrackingTypeRepository.TGetList().Join(setProductImage, CF => CF.RelatedTrackingSeqID, Img => Img.ProductImageSeqID, (C, I) => new
                    {
                        C = C,
                        I = I
                    })
                .Where(
                    w => w.I.GroupId == ApiProductMediaGroupType.Tamami && w.I.MediaTypeId == ApiProductMediaType.Muzik && w.C.Customer_def_no == customer_def_no && w.C.RelatedTrackingSeqID == w.I.ProductImageSeqID && w.I.ProductSeqID == poroduct.ProductSeqID && w.C.GroupID == ApiFavoriListType.Favorite
                ).Select(sci => sci.I.ProductImageSeqID).ToList().Count > 0 ? true : false,
                    isTheaterInKeepListening = customerTrackingTypeRepository.TGetList().Join(setProductImage, CF => CF.RelatedTrackingSeqID, Img => Img.ProductImageSeqID, (C, I) => new
                    {
                        C = C,
                        I = I
                    })
                .Where(
                    w => w.I.GroupId == ApiProductMediaGroupType.Tamami && w.I.MediaTypeId == ApiProductMediaType.Tiyatro && w.C.Customer_def_no == customer_def_no && w.C.RelatedTrackingSeqID == w.I.ProductImageSeqID && w.I.ProductSeqID == poroduct.ProductSeqID && w.C.GroupID == ApiFavoriListType.Favorite
                ).Select(sci => sci.I.ProductImageSeqID).ToList().Count > 0 ? true : false,
                    isFavorite = false,

                    categoryIdList = TGetList()
                .Join(productWithCategoryRepository.TGetList(), Products => Products.ProductSeqID, ProductWithCategory => ProductWithCategory.ProductSeqID, (P, PC) => new
                {
                    Products = P,
                    ProductWithCategory = PC
                }).Where(I => I.Products.Status == true && I.Products.ProductSeqID == poroduct.ProductSeqID).Select(sc => sc.ProductWithCategory.CategorySeqID).ToList(),
                    releaseDate = poroduct.ReleaseDate,
                    productAttributeList = attributeStaticValueRepository.GetHomeProductAttribute(poroduct.ProductSeqID),
                    categoryName =
                    categoryRepository.TGetList().Join(productWithCategoryRepository.TGetList(), C => C.CategorySeqID, pc => pc.CategorySeqID, (C, PC) => new
                    {
                        C = C,
                        PC = PC
                    }).Where(w => w.PC.ProductSeqID == poroduct.ProductSeqID && w.C.Status == true).FirstOrDefault().C.Name
                })
                .OrderByDescending(o => o.productId)
                .Take(1).ToList();
            }
            catch (Exception ex) { }
            return poroduct;

        }
        public List<SelectListItem> GetAllProduct()
        {
            return TGetList(w => w.Status == true).Select(s => new SelectListItem
            {
                Value = s.ProductSeqID.ToString(),
                Text = s.ProductName
            }).ToList();
        }
        public List<Product> GetProducersProductDetailByIDSP(int ProductSeqID, string customer_def_no, int languageId)
        {
            List<Product> productList = new List<Product>();
            try
            {
                string sql = "exec GetProducersProductDetailByIDSP @customer_def_no='" + customer_def_no
                    + "' , @languageId=" + languageId + " , @ProducerSeqID=" + ProductSeqID;

                var products = productRepository.ExecuteSql(sql);
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

                            product.categoryIdList = TGetList()
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
        public Product GetProductByIDSP(int ProductSeqID, string customer_def_no, int? languageId)
        {
            Product returnProduct = new Product();
            try
            {
                string sql = "exec GetProductByIDSP @customer_def_no='" + customer_def_no + "' , @languageId=" + languageId + " , @ProductSeqID=" + ProductSeqID;
                var products = productRepository.ExecuteSql(sql);
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
                            product.preListeningRight = item.preListeningRight;
                            product.categoryIdList = TGetList()
                        .Join(productWithCategoryRepository.TGetList(), Products => Products.ProductSeqID, ProductWithCategory => ProductWithCategory.ProductSeqID, (P, PC) => new
                        {
                            Products = P,
                            ProductWithCategory = PC
                        }).Where(I => I.Products.Status == true && I.Products.ProductSeqID == item.productId).Select(sc => sc.ProductWithCategory.CategorySeqID).ToList();

                            product.releaseDate = item.releaseDate;
                            product.productAttributeList = attributeStaticValueRepository.GetHomeProductAttribute(item.productId);
                            product.categoryName = item.categoryName;
                            returnProduct = product;
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return returnProduct;
        }
        public ProductsSearchApi SeachProductSP(string name, string customer_def_no, int languageId)
        {
            ProductsSearchApi productsSearchApi = new ProductsSearchApi();
            productsSearchApi.Result = true;
            productsSearchApi.ResultCode = 1;
            productsSearchApi.ResultMessage = "İşlem Başarılı";
            List<Product> productList = new List<Product>();
            try
            {
                string sql = "exec SeachProductSP @customer_def_no='" + customer_def_no + "' , @languageId=" + languageId + " , @name='" + name + "'";
                var products = productRepository.ExecuteSql(sql);
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
                            product.preListeningRight = item.preListeningRight;
                            product.categoryIdList = TGetList()
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
            productsSearchApi.Products = productList;
            return productsSearchApi;
        }
        public List<Products> HomePageMostListened(int languageID)
        {
            return productRepository.HomePageMostListened(languageID);
        }
        public List<Products> HomePageMostListenedByMedayType(int languageID, int medyaType)
        {
            return productRepository.HomePageMostListenedByMedayType(languageID, medyaType);
        }
        public List<Products> GetLastCreadedProductByMedayType(int languageID, int medyaType)
        {
            return productRepository.GetLastCreadedProductByMedayType(languageID, medyaType);
        }

        public List<Products> GetAllActiveProduct(int language)
        {
            var items = TGetList(i => i.Status == true && i.LanguageID==language).OrderByDescending(u => u.DisplayOrderNumber).ToList();
            return items.ToList();
        }
    }
}
