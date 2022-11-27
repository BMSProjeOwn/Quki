
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
    public class ProducersManager : BllBase<Producer, ProducersAddModel>, IProducersService
    {
        public readonly IProducersRepository repo;
        public readonly IProducerWithProduserTypeRepository producerWithProduserTypeRepository;
        public readonly IProducerTypeRepository producerTypeRepository;
        public readonly IProductsRepository productRepository;
        public readonly IProductWithProducersRepository productWithProducersRepository;
        public readonly IDocumentsRepository documentsRepository;
        public readonly IMenuRepository menuRepository;
        public readonly ICategoryRepository categoryRepository;
        public readonly IProductImagesRepository productImagesRepository;
        public ProducersManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IProducersRepository>();
            producerWithProduserTypeRepository = service.GetService<IProducerWithProduserTypeRepository>();
            producerTypeRepository = service.GetService<IProducerTypeRepository>();
            productRepository = service.GetService<IProductsRepository>();
            productWithProducersRepository = service.GetService<IProductWithProducersRepository>();
            documentsRepository = service.GetService<IDocumentsRepository>();
            menuRepository = service.GetService<IMenuRepository>();
            categoryRepository = service.GetService<ICategoryRepository>();
            productImagesRepository = service.GetService<IProductImagesRepository>();
        }
        public List<Producer> GetLastProducer(int count) // ilk 8 seslendireni getir
        {
            var items = TGetList(I => I.IsActive == true && I.DisplayOrderNumber != null).OrderBy(x => x.Name).Take(count).OrderBy(x => x.DisplayOrderNumber);
            return items.ToList();
        }

        public List<Producer> getProducersLitForHomePage()

        {
            var query = from p in TGetList()
                        join py in producerWithProduserTypeRepository.TGetList() on p.ProducerSeqID equals py.ProducerSeqID
                        where py.ProducerTypeSeqID == 2 && p.IsActive == true && py.IsActive == true
                        select new Producer
                        {
                            ProducerID = p.ProducerID,
                            ProducerSeqID = p.ProducerSeqID,
                            Phone = p.Phone,
                            PrivateDate = p.PrivateDate,
                            Name = p.Name,
                            SecondName = p.SecondName,
                            SEOKey = p.SEOKey,
                            SocialMedia = p.SocialMedia,
                            SpokenLanguage = p.SpokenLanguage,
                            CitySeqID = p.CitySeqID,
                            CountrySeqID = p.CountrySeqID,
                            Adress = p.Adress,
                            BirthDate = p.BirthDate,
                            IsActive = p.IsActive,
                            WebAdress = p.WebAdress,
                            CreatedBy = p.CreatedBy,
                            DisplayOrderNumber = p.DisplayOrderNumber,
                            CreatedOn = p.CreatedOn,
                            Email = p.Email,
                            GroupID = p.GroupID,
                            History = p.History,
                            ImagePath = p.ImagePath,
                            ImageThumpPath = p.ImageThumpPath,
                            IsCompany = p.IsCompany,
                            LanguageID = p.LanguageID,
                            Remark = p.Remark,
                            UpdatedBy = p.UpdatedBy,
                            UpdatedOn = p.UpdatedOn
                        };


            return query.OrderBy(x => x.Name).ToList();

        }

        public List<SelectListItem> GetProducerTypeListForDropdown()
        {
            List<SelectListItem> list = (from x in producerTypeRepository.TGetList(i => i.ISActive == true).OrderByDescending(i => i.DisplayOrderNumber).ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.Name,
                                             Value = x.ProducerTypeID.ToString()
                                         }).ToList();
            return list;

        }

        public List<SelectListItem> GetProducerListForDropdown()
        {
            List<SelectListItem> list = (from x in TGetList(i => i.IsActive == true).OrderByDescending(i => i.DisplayOrderNumber).ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.Name,
                                             Value = x.ProducerSeqID.ToString()
                                         }).ToList();
            return list;
        }

        public bool ProducersAdd(ProducersAddModel Item)
        {
            Producer p = new Producer();
            if (Item.ImagePath != null)
            {
                var path = Path.GetExtension(Item.ImagePath.FileName);
                var newPath = Guid.NewGuid() + path;
                var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProducerImg/" + newPath;
                var ThumbImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProducerImg/Thump" + newPath;
                var steem = new FileStream(ImagePath, FileMode.Create);
                Item.ImagePath.CopyTo(steem);
                Utility.ResizeImage(Item.ImagePath, ProducerImageSize.Height, ProducerImageSize.Width, ThumbImagePath);
                p.ImagePath = "/AdminImage/ProducerImg/" + newPath; ;
                p.ImageThumpPath = "/AdminImage/ProducerImg/Thump" + newPath; ;
            }
            p.Name = Item.Name;
            //   p.ProducerTypeSeqID = Item.ProducerTypeSeqID;
            p.SecondName = Item.SecondName;
            p.Phone = Item.Phone;
            p.Email = Item.Email;
            p.CreatedOn = DateTime.Now;
            p.IsActive = Item.IsActive;
            p.Remark = Item.Remark;
            p.History = Item.History;
            p.LanguageID = Item.LanguageID;
            TAdd(p);

            //var producer = contex.Producers.Where(I => I.Name == p.Name && I.Email == p.Email && I.Phone == p.Phone).FirstOrDefault();
            if (p.ProducerSeqID != null)
            {
                ProducerWithProduserType producerWithProduserType = new ProducerWithProduserType();
                producerWithProduserType.CreatedOn = DateTime.Now;
                producerWithProduserType.IsActive = true;
                producerWithProduserType.ProducerSeqID = p.ProducerSeqID;
                producerWithProduserType.ProducerTypeSeqID = Item.ProducerTypeSeqID;
                producerWithProduserType.CreatedOn = DateTime.Now;
                producerWithProduserTypeRepository.TAdd(producerWithProduserType);
            }
            return true;
        }

        public ProducersAddModel getProducersByID(int id)
        {
            ProducersAddModel mymodel = new ProducersAddModel();
            var Item = TgetItemByID(id);
            mymodel.Name = Item.Name;
            mymodel.Email = Item.Email;
            mymodel.Phone = Item.Phone;
            mymodel.ProducerSeqID = Item.ProducerSeqID;
            mymodel.SecondName = Item.SecondName;
            mymodel.IsActive = Item.IsActive;
            mymodel.Remark = Item.Remark;
            mymodel.History = Item.History;
            mymodel.ImagePathStr = Item.ImagePath;
            return mymodel;
        }


        public bool UpdateProducers(ProducersAddModel model)
        {
            var Item = TgetItemByID(model.ProducerSeqID);

            Item.Name = model.Name;
            Item.Email = model.Email;
            Item.Phone = model.Phone;
            Item.ProducerSeqID = model.ProducerSeqID;
            Item.SecondName = model.SecondName;
            Item.IsActive = model.IsActive;
            Item.Remark = model.Remark;
            Item.History = model.History;
            Item.LanguageID = model.LanguageID;

            Producer p = new Producer();

            if (model.ImagePath != null)
            {
                var path = Path.GetExtension(model.ImagePath.FileName);
                var newPath = Guid.NewGuid() + path;
                var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProducerImg/" + newPath;
                var ThumbImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProducerImg/Thump" + newPath;
                var steem = new FileStream(ImagePath, FileMode.Create);
                model.ImagePath.CopyTo(steem);
                Utility.ResizeImage(model.ImagePath, ProductImageSize.Height, ProductImageSize.Width, ThumbImagePath);
                p.ImagePath = "/AdminImage/ProducerImg/" + newPath;
                p.ImageThumpPath = "/AdminImage/ProducerImg/Thump" + newPath;

                Item.ImagePath = p.ImagePath;
                Item.ImageThumpPath = p.ImageThumpPath;
            }

            TUpdate(Item);

            return true;
        }

        #region Onder

        public ProducerDetailModel GetProducerDetailByProducerID(int prodcureID, int languageId)
        {
            ProducerDetailModel producerDetailModel = new ProducerDetailModel();

            var Item = TgetItemByID(prodcureID);

            producerDetailModel.Name = Item.Name;
            producerDetailModel.Phone = Item.Phone;
            producerDetailModel.ProducerSeqID = prodcureID;
            producerDetailModel.SecondName = Item.SecondName;
            producerDetailModel.Remark = Item.Remark;
            producerDetailModel.History = Item.History;
            producerDetailModel.ImageThumpPath = Item.ImageThumpPath;
            producerDetailModel.SocialMedia = Item.SocialMedia;
            producerDetailModel.CreatedOn = Item.CreatedOn;
            producerDetailModel.UpdatedOn = Item.UpdatedOn;
            var ProducerProduct = productWithProducersRepository.TGetList(I => I.ProducerSeqID == prodcureID);
            if (ProducerProduct != null)
            {
                List<Products> productList = new List<Products>();
                foreach (var item in ProducerProduct)
                {
                    Products p = new Products();
                    p = productRepository.TGetList(J => J.ProductSeqID == item.ProductSeqID && J.Status != false && J.LanguageID==languageId).FirstOrDefault();
                    if (p != null)
                    {
                        productList.Add(p);
                    }
                }

                producerDetailModel.Products = productList;
            }
            return producerDetailModel;
        }

        public List<ProducersModel> getProducersLit()
        {

            List<ProducersModel> list2 = TGetList().Join(producerWithProduserTypeRepository.TGetList(), Producers => Producers.ProducerSeqID, ProducerWithProduserType => ProducerWithProduserType.ProducerSeqID, (P, PC) => new
            {
                Producers = P,
                ProducerWithProduserType = PC
            }).Join(producerTypeRepository.TGetList(), iki => iki.ProducerWithProduserType.ProducerTypeSeqID, ProducerType => ProducerType.ProducerTypeID, (PC, C) => new
            {
                Producers = PC.Producers,
                ProducerType = C,
                ProducerWithProduserType = PC.ProducerWithProduserType
            }).Select(I => new ProducersModel
            {
                ProducerSeqID = I.Producers.ProducerSeqID,
                Name = I.Producers.Name,
                TypeName = I.ProducerType.Name,
                Phone = I.Producers.Phone,
                Email = I.Producers.Email,
                Adress = I.Producers.Adress,
                IsActive = I.Producers.IsActive,
                ImagePath = I.Producers.ImagePath,
                ImageThumpPath = I.Producers.ImageThumpPath

            }).Where(x => x.IsActive == true).OrderBy(x => x.Name).ToList();

            return list2;
        }

        public List<ProducersModel> getProducersLitApi()
        {
            List<ProducersModel> list2 = TGetList().Join(producerWithProduserTypeRepository.TGetList(), Producers => Producers.ProducerSeqID, ProducerWithProduserType => ProducerWithProduserType.ProducerSeqID, (P, PC) => new
            {
                Producers = P,
                ProducerWithProduserType = PC
            }).Join(producerTypeRepository.TGetList(), iki => iki.ProducerWithProduserType.ProducerTypeSeqID, ProducerType => ProducerType.ProducerTypeID, (PC, C) => new
            {
                Producers = PC.Producers,
                ProducerType = C,
                ProducerWithProduserType = PC.ProducerWithProduserType
            }).Select(I => new ProducersModel
            {
                ProducerSeqID = I.Producers.ProducerSeqID,
                Name = I.Producers.Name,
                TypeName = I.ProducerType.Name,
                Phone = I.Producers.Phone,
                Email = I.Producers.Email,
                Adress = I.Producers.Adress,
                IsActive = I.Producers.IsActive,
                ImagePath = ApiParameters.URL + I.Producers.ImagePath,
                ImageThumpPath = ApiParameters.URL + I.Producers.ImageThumpPath

            }).Take(5).ToList();

            return list2;
        }

        public List<ViewValueItems> getProducersLitMainMenu(int Count, string customer_def_no)
        {
            
            return TGetList().Join(producerWithProduserTypeRepository.TGetList(), Producers => Producers.ProducerSeqID, ProducerWithProduserType => ProducerWithProduserType.ProducerSeqID, (P, PC) => new
            {
                Producers = P,
                ProducerWithProduserType = PC
            }).Join(producerTypeRepository.TGetList(), iki => iki.ProducerWithProduserType.ProducerTypeSeqID, ProducerType => ProducerType.ProducerTypeID, (PC, C) => new
            {
                Producers = PC.Producers,
                ProducerType = C,
                ProducerWithProduserType = PC.ProducerWithProduserType
            }).Select(I => new ViewValueItems
            {
                ID = I.Producers.ProducerSeqID,
                Name = I.Producers.Name,
                ImagePath = ApiParameters.URL + I.Producers.ImageThumpPath,
                ProductDetailList = GetProductDetailByProducerID(I.Producers.ProducerSeqID, customer_def_no, Count)
            }).Take(Count).ToList();
        }

        public List<ProductDetailForMobile> GetProductDetailByProducerID(int ProducerSeqID, string customer_def_no, int count)
        {
            List<ProductDetailForMobile> list = new List<ProductDetailForMobile>();
            var ProducerProduct = productWithProducersRepository.TGetList(I => I.ProducerSeqID == ProducerSeqID);
            if (ProducerProduct != null)
            {
                foreach (var item in ProducerProduct)
                {
                    if (list.Count < count)
                    {
                        ProductDetailForMobile detail = new ProductDetailForMobile();
                        detail = productRepository.GetProductDetailForMobile(item.ProductSeqID, customer_def_no)[0];
                        list.Add(detail);
                    }
                }
            }
            return list;
        }

        public ProducersApiDetailModel GetProducerByIDApi(int ProducerSeqID, string customer_def_no, int count)
        {
            ProducersApiDetailModel producersApiDetailModel = new ProducersApiDetailModel();
            var Item = TgetItemByID(ProducerSeqID);
            producersApiDetailModel.ID = Item.ProducerSeqID;
            producersApiDetailModel.Name = Item.Name;
            producersApiDetailModel.ImagePath = ApiParameters.URL + Item.ImageThumpPath;
            producersApiDetailModel.ProductDetailList = GetProductDetailByProducerID(ProducerSeqID, customer_def_no, count);
            return producersApiDetailModel;
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

        public PerformerGroup GetHomeProducerGroupApi(int GroupID, string customer_def_no, int count, int languageId)
        {
            PerformerGroup value1 = new PerformerGroup();
            if (GroupID == ApiMainPageGroupID.Producers)
            {
                value1.PerformerGroupId = ApiMainPageGroupID.Producers;//6;

                if (languageId == 1)
                { value1.title = "Seslendirenler"; }
                else if (languageId == 2)
                { value1.title = "Dubbed by"; }
                else if (languageId == 3)
                { value1.title = "Synchronisiert von"; }
                else
                { value1.title = "Seslendirenler"; }

                //value1.title = "Seslendirenlere Göre";
                value1.coverImageUrl = ApiParameters.URL + "/AdminImage/CategoryImage/turunculogoQuki.png";
                value1.performerList = getHomeProducersList(count, customer_def_no);
            }

            return value1;
        }

        public List<Performer> getHomeProducersList(int Count, string customer_def_no)
        {
            return TGetList().Join(producerWithProduserTypeRepository.TGetList(), Producers => Producers.ProducerSeqID, ProducerWithProduserType => ProducerWithProduserType.ProducerSeqID, (P, PC) => new
            {
                Producers = P,
                ProducerWithProduserType = PC
            }).Join(producerTypeRepository.TGetList(), iki => iki.ProducerWithProduserType.ProducerTypeSeqID, ProducerType => ProducerType.ProducerTypeID, (PC, C) => new
            {
                Producers = PC.Producers,
                ProducerType = C,
                ProducerWithProduserType = PC.ProducerWithProduserType
            }).Where(I => I.Producers.IsActive == true).Select(I => new Performer
            {
                performerId = I.Producers.ProducerSeqID,
                performerName = I.Producers.Name,
                performerLastName = I.Producers.SecondName,
                imageUrl = ApiParameters.URL + I.Producers.ImageThumpPath,
                coverImageUrl = ApiParameters.URL + I.Producers.ImageThumpPath
            }).OrderBy(o => o.performerName).Take(Count).ToList();
        }


        public List<Product> GetProductByPerformerID(int ProducerSeqID, string customer_def_no, int count, int languageId)
        {
            List<Product> list = new List<Product>();

            var ProducerProduct = productRepository.GetProducersProductDetailByIDSP(ProducerSeqID, customer_def_no, languageId);
            if (ProducerProduct != null)
            {
                foreach (var item in ProducerProduct)
                {
                    if (list.Count < count)
                    {
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        #endregion Onder
        public ProductDetailModel GetProductDetailByName(string ProductName)// ürüne ait kategorileri getiriyor.
        {
            ProductDetailModel pd = new ProductDetailModel();
            var poroduct = productRepository.TGetList(i => i.ProductName == ProductName && i.Status == true).FirstOrDefault();
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


        public bool ProducerDeleteById(int id)
        {
            bool result = false;

            var x = TGetList(x => x.ProducerSeqID == id).FirstOrDefault();

            x.IsActive = false;

            //var y = context.ProducerWithProduserType.

            TUpdate(x);
            result = true;
            return result;
        }


        public bool GetProducerByName(string producerName, int producerTypeId)
        {
            bool result = false;

            //var x = context.Producers.Where(x => x.Name == producerName && x.IsActive ==true).ToList();

            var x = TGetList().Join(producerWithProduserTypeRepository.TGetList(), Producers => Producers.ProducerSeqID, ProducerWithProduserType => ProducerWithProduserType.ProducerSeqID, (P, PC) => new
            {
                Producers = P,
                ProducerWithProduserType = PC
            }).Join(producerTypeRepository.TGetList(), iki => iki.ProducerWithProduserType.ProducerTypeSeqID, ProducerType => ProducerType.ProducerTypeID, (PC, C) => new
            {
                Producers = PC.Producers,
                ProducerType = C,
                ProducerWithProduserType = PC.ProducerWithProduserType
            }).Where(x => x.ProducerWithProduserType.IsActive == true && x.Producers.IsActive == true && x.Producers.Name == producerName && x.ProducerWithProduserType.ProducerTypeSeqID == producerTypeId).Select(I => new Producer
            {
                ProducerSeqID = I.Producers.ProducerSeqID,
                Name = producerName,
                SecondName = I.Producers.SecondName
            }).ToList();

            if (x != null)
            {
                if (x.Count > 0)
                    result = true;
            }

            return result;
        }

        public List<ProducerTypeModel> GetProducerTypeListForCheckBox()
        {

            List<ProducerTypeModel> list = (from x in producerTypeRepository.TGetList(i => i.ISActive == true).OrderByDescending(i => i.DisplayOrderNumber).ToList()
                                            select new ProducerTypeModel
                                            {
                                                ProducerTypeSeqID = x.ProducerTypeSeqID,
                                                Name = x.Name,
                                                Status = false
                                            }).ToList();
            return list;

        }

    }
}
