using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Entity.Parameters;
using Quki.Entity.ViewModel;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class ProducersRepository : GenericRepository<Producer>,IProducersRepository
    {
        IProductsRepository productsRepository;
        public ProducersRepository(DbContext context,IProductsRepository productsRepository) : base(context)
        {
            this.productsRepository = productsRepository;
        }
        public List<ViewValueItems> getProducersLitMainMenu(int Count, string customer_def_no)
        {

            return TGetList().Join(context.Set<ProducerWithProduserType>().ToList(), Producers => Producers.ProducerSeqID, ProducerWithProduserType => ProducerWithProduserType.ProducerSeqID, (P, PC) => new
            {
                Producers = P,
                ProducerWithProduserType = PC
            }).Join(context.Set<ProducerType>().ToList(), iki => iki.ProducerWithProduserType.ProducerTypeSeqID, ProducerType => ProducerType.ProducerTypeID, (PC, C) => new
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
            var ProducerProduct = context.Set<ProductWithProducers>().Where(I => I.ProducerSeqID == ProducerSeqID);
            if (ProducerProduct != null)
            {
                foreach (var item in ProducerProduct)
                {
                    if (list.Count < count)
                    {
                        ProductDetailForMobile detail = new ProductDetailForMobile();
                        detail = productsRepository.GetProductDetailForMobile(item.ProductSeqID, customer_def_no)[0];
                        list.Add(detail);
                    }
                }
            }
            return list;
        }

        //    producerDetailModel.Name = Item.Name;
        //    producerDetailModel.Phone = Item.Phone;
        //    producerDetailModel.ProducerSeqID = prodcureID;
        //    producerDetailModel.SecondName = Item.SecondName;
        //    producerDetailModel.Remark = Item.Remark;
        //    producerDetailModel.History = Item.History;
        //    producerDetailModel.ImageThumpPath = Item.ImageThumpPath;
        //    producerDetailModel.SocialMedia = Item.SocialMedia;
        //    var ProducerProduct = context.Set<ProductWithProducers>().Where(I => I.ProducerSeqID == prodcureID);
        //    if (ProducerProduct != null)
        //    {
        //        List<Products> productList = new List<Products>();
        //        foreach (var item in ProducerProduct)
        //        {
        //            Products p = new Products();
        //            p = context.Set<Products>().Where(J => J.ProductSeqID == item.ProductSeqID).FirstOrDefault();
        //            if (p.Status!=false)
        //            {
        //                productList.Add(p);
        //            }
        //        }

        //        producerDetailModel.Products = productList;
        //    }

        //    return producerDetailModel;
        //}

        //public List<ProducersModel> getProducersLit()
        //{

        //    List<ProducersModel> list2 = dbset.Join(context.Set<ProducerWithProduserType>(), Producers => Producers.ProducerSeqID, ProducerWithProduserType => ProducerWithProduserType.ProducerSeqID, (P, PC) => new
        //    {
        //        Producers = P,
        //        ProducerWithProduserType = PC
        //    }).Join(context.Set<ProducerType>(), iki => iki.ProducerWithProduserType.ProducerTypeSeqID, ProducerType => ProducerType.ProducerTypeID, (PC, C) => new
        //    {
        //        Producers = PC.Producers,
        //        ProducerType = C,
        //        ProducerWithProduserType = PC.ProducerWithProduserType
        //    }).Select(I => new ProducersModel
        //    {
        //        ProducerSeqID = I.Producers.ProducerSeqID,
        //        Name = I.Producers.Name,
        //        TypeName = I.ProducerType.Name,
        //        Phone = I.Producers.Phone,
        //        Email = I.Producers.Email,
        //        Adress = I.Producers.Adress,
        //        IsActive = I.Producers.IsActive,
        //        ImagePath = I.Producers.ImagePath,
        //        ImageThumpPath = I.Producers.ImageThumpPath

        //    }).Where(x => x.IsActive == true).OrderBy(x => x.Name).ToList();

        //    return list2;
        //}

        //public List<ProducersModel> getProducersLitApi()
        //{
        //    List<ProducersModel> list2 = dbset.Join(context.Set<ProducerWithProduserType>(), Producers => Producers.ProducerSeqID, ProducerWithProduserType => ProducerWithProduserType.ProducerSeqID, (P, PC) => new
        //    {
        //        Producers = P,
        //        ProducerWithProduserType = PC
        //    }).Join(context.Set<ProducerType>(), iki => iki.ProducerWithProduserType.ProducerTypeSeqID, ProducerType => ProducerType.ProducerTypeID, (PC, C) => new
        //    {
        //        Producers = PC.Producers,
        //        ProducerType = C,
        //        ProducerWithProduserType = PC.ProducerWithProduserType
        //    }).Select(I => new ProducersModel
        //    {
        //        ProducerSeqID = I.Producers.ProducerSeqID,
        //        Name = I.Producers.Name,
        //        TypeName = I.ProducerType.Name,
        //        Phone = I.Producers.Phone,
        //        Email = I.Producers.Email,
        //        Adress = I.Producers.Adress,
        //        IsActive = I.Producers.IsActive,
        //        ImagePath = ApiParameters.URL + I.Producers.ImagePath,
        //        ImageThumpPath = ApiParameters.URL + I.Producers.ImageThumpPath

        //    }).Take(5).ToList();

        //    return list2;
        //}


        //public ProducersApiDetailModel GetProducerByIDApi(int ProducerSeqID, string customer_def_no, int count)
        //{
        //    ProducersApiDetailModel producersApiDetailModel = new ProducersApiDetailModel();
        //    var Item = TgetItemByID(ProducerSeqID);
        //    producersApiDetailModel.ID = Item.ProducerSeqID;
        //    producersApiDetailModel.Name = Item.Name;
        //    producersApiDetailModel.ImagePath = ApiParameters.URL + Item.ImageThumpPath;
        //    producersApiDetailModel.ProductDetailList = GetProductDetailByProducerID(ProducerSeqID, customer_def_no, count);
        //    return producersApiDetailModel;
        //}

        //public Document GetItemsAsync(int MenuID, int LanguageID)
        //{
        //    DocumentsRepository documentsRepository = new DocumentsRepository(context);
        //    Document documnet = documentsRepository.GetDocumentByMenuId(MenuID);
        //    return documnet;
        //}

        //public List<Menu> GetUserMenusForDocument(int LanguageID)
        //{
        //    return context.Set<Menu>().Where(I => I.ContentTypeID == MenuContentType.MobilAndroid && I.Status == true && I.controller == "Document" && I.PositionID == 3 && I.LanguageID == LanguageID)
        //        .OrderBy(I => I.DisplayOrderNumber).ToList();
        //}

        //public PerformerGroup GetHomeProducerGroupApi(int GroupID, string customer_def_no, int count, int languageId)
        //{
        //    ProductsRepository productsRepository = new ProductsRepository(context);
        //    ProducersRepository producers = new ProducersRepository(context);
        //    CategoryRepository category = new CategoryRepository(context);
        //    PerformerGroup value1 = new PerformerGroup();
        //    if (GroupID == ApiMainPageGroupID.Producers)
        //    {
        //        value1.PerformerGroupId = ApiMainPageGroupID.Producers;//6;

        //        if (languageId == 1)
        //        { value1.title = "Seslendirenler"; }
        //        else if (languageId == 2)
        //        { value1.title = "Dubbed by"; }
        //        else if (languageId == 3)
        //        { value1.title = "Synchronisiert von"; }
        //        else
        //        { value1.title = "Seslendirenler"; }

        //        //value1.title = "Seslendirenlere Göre";
        //        value1.coverImageUrl = ApiParameters.URL + "/AdminImage/CategoryImage/turunculogoQuki.png";
        //        value1.performerList = producers.getHomeProducersList(count, customer_def_no);
        //    }

        //    return value1;
        //}

        //public List<Performer> getHomeProducersList(int Count, string customer_def_no)
        //{
        //    ProducersRepository producers = new ProducersRepository(context);
        //    return dbset.Join(context.Set<ProducerWithProduserType>(), Producers => Producers.ProducerSeqID, ProducerWithProduserType => ProducerWithProduserType.ProducerSeqID, (P, PC) => new
        //    {
        //        Producers = P,
        //        ProducerWithProduserType = PC
        //    }).Join(context.Set<ProducerType>(), iki => iki.ProducerWithProduserType.ProducerTypeSeqID, ProducerType => ProducerType.ProducerTypeID, (PC, C) => new
        //    {
        //        Producers = PC.Producers,
        //        ProducerType = C,
        //        ProducerWithProduserType = PC.ProducerWithProduserType
        //    }).Where(I => I.Producers.IsActive == true).Select(I => new Performer
        //    {
        //        performerId = I.Producers.ProducerSeqID,
        //        performerName = I.Producers.Name,
        //        performerLastName = I.Producers.SecondName,
        //        imageUrl = ApiParameters.URL + I.Producers.ImageThumpPath,
        //        coverImageUrl = ApiParameters.URL + I.Producers.ImageThumpPath
        //    }).OrderBy(o => o.performerName).Take(Count).ToList();
        //}


        //public List<Product> GetProductByPerformerID(int ProducerSeqID, string customer_def_no, int count, int languageId)
        //{
        //    ProductsRepository productsRepository = new ProductsRepository(context);
        //    List<Product> list = new List<Product>();

        //    var ProducerProduct = productsRepository.GetProducersProductDetailByIDSP(ProducerSeqID, customer_def_no, languageId);
        //    if (ProducerProduct != null)
        //    {
        //        foreach (var item in ProducerProduct)
        //        {
        //            if (list.Count < count)
        //            {
        //                list.Add(item);
        //            }
        //        }
        //    }
        //    return list;
        //}

        //#endregion Onder


        //public bool ProducerDeleteById(int id)
        //{
        //    bool result = false;

        //    var x = dbset.Where(x => x.ProducerSeqID == id).FirstOrDefault();

        //    x.IsActive = false;

        //    //var y = context.ProducerWithProduserType.

        //    TUpdate(x);
        //    result = true;
        //    return result;
        //}


        //public bool GetProducerByName(string producerName, int producerTypeId)
        //{
        //    bool result = false;

        //    //var x = context.Producers.Where(x => x.Name == producerName && x.IsActive ==true).ToList();

        //    var x = dbset.Join(context.Set<ProducerWithProduserType>(), Producers => Producers.ProducerSeqID, ProducerWithProduserType => ProducerWithProduserType.ProducerSeqID, (P, PC) => new
        //    {
        //        Producers = P,
        //        ProducerWithProduserType = PC
        //    }).Join(context.Set<ProducerType>(), iki => iki.ProducerWithProduserType.ProducerTypeSeqID, ProducerType => ProducerType.ProducerTypeID, (PC, C) => new
        //    {
        //        Producers = PC.Producers,
        //        ProducerType = C,
        //        ProducerWithProduserType = PC.ProducerWithProduserType
        //    }).Where(x => x.ProducerWithProduserType.IsActive == true && x.Producers.IsActive == true && x.Producers.Name == producerName && x.ProducerWithProduserType.ProducerTypeSeqID == producerTypeId).Select(I => new Producer
        //    {
        //        ProducerSeqID = I.Producers.ProducerSeqID,
        //        Name = producerName,
        //        SecondName = I.Producers.SecondName
        //    }).ToList();

        //    if (x != null)
        //    {
        //        if (x.Count > 0)
        //            result = true;
        //    }

        //    return result;
        //}

        //public List<ProducerTypeModel> GetProducerTypeListForCheckBox()
        //{

        //    List<ProducerTypeModel> list = (from x in context.Set<ProducerType>().Where(i => i.ISActive == true).OrderByDescending(i => i.DisplayOrderNumber).ToList()
        //                                    select new ProducerTypeModel
        //                                    {
        //                                        ProducerTypeSeqID = x.ProducerTypeSeqID,
        //                                        Name = x.Name,
        //                                        Status = false
        //                                    }).ToList();
        //    return list;

        //}
    }
}
