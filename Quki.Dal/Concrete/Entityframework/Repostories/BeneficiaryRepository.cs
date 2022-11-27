
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Quki.Dal.Abstract;

using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Entity.Parameters;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class BeneficiaryRepository : GenericRepository<Producer>, IBeneficiaryRepository
    {
        public BeneficiaryRepository(DbContext context) : base(context)
        {

        }
        ////public List<ProducersAgreementModel> getProducersList()
        ////{

        ////    List<ProducersAgreementModel> list2 = dbset
        ////    .Select(I => new ProducersAgreementModel
        ////    {
        ////        ProducerSeqID = I.ProducerSeqID,
        ////        Name = I.Name,
        ////        TypeName = context.Set<ProducerWithProduserType>().Join(context.Set<ProducerType>(), iki => iki.ProducerTypeSeqID, ProducerType => ProducerType.ProducerTypeSeqID,
        ////        (PC, C) => new
        ////        {
        ////            ProducersW = PC,
        ////            ProducerType = C,
        ////        }).Where(w => w.ProducersW.ProducerSeqID == I.ProducerSeqID && w.ProducersW.IsActive==true).Select(s => s.ProducerType.Name+", " ).ToList(),
        ////        Phone = I.Phone,
        ////        Email = I.Email,
        ////        Adress = I.Adress,
        ////        IsActive = I.IsActive,
        ////        ImagePath = I.ImagePath,
        ////        ImageThumpPath = I.ImageThumpPath,
        ////        GroupID = I.GroupID

        ////    }).Where(x => x.IsActive == true)
        ////    .OrderBy(x => x.Name).ToList();

        ////    return list2;
        ////}
        ////public bool GetProducerByName(string producerName, int producerTypeId)
        ////{
        ////    bool result = false;

        ////    var x = dbset.Join(context.Set<ProducerWithProduserType>(), Producers => Producers.ProducerSeqID, ProducerWithProduserType => ProducerWithProduserType.ProducerSeqID, (P, PC) => new
        ////    {
        ////        Producers = P,
        ////        ProducerWithProduserType = PC
        ////    }).Join(context.Set<ProducerType>(), iki => iki.ProducerWithProduserType.ProducerTypeSeqID, ProducerType => ProducerType.ProducerTypeID, (PC, C) => new
        ////    {
        ////        Producers = PC.Producers,
        ////        ProducerType = C,
        ////        ProducerWithProduserType = PC.ProducerWithProduserType
        ////    }).Where(x => x.ProducerWithProduserType.IsActive == true && x.Producers.IsActive == true && x.Producers.Name == producerName && x.ProducerWithProduserType.ProducerTypeSeqID == producerTypeId).Select(I => new Producer
        ////    {
        ////        ProducerSeqID = I.Producers.ProducerSeqID,
        ////        Name = producerName,
        ////        SecondName = I.Producers.SecondName
        ////    }).ToList();

        ////    if (x != null)
        ////    {
        ////        if (x.Count > 0)
        ////            result = true;
        ////    }
        ////    return result;
        ////}
        ////public bool ProducersAdd(ProducersAddModel Item)
        ////{
        ////    Producer p = new Producer();
        ////    if (Item.ImagePath != null)
        ////    {
        ////        var path = Path.GetExtension(Item.ImagePath.FileName);
        ////        var newPath = Guid.NewGuid() + path;
        ////        var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProducerImg/" + newPath;
        ////        var ThumbImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProducerImg/Thump" + newPath;
        ////        var steem = new FileStream(ImagePath, FileMode.Create);
        ////        Item.ImagePath.CopyTo(steem);
        ////        Utility.ResizeImage(Item.ImagePath, ProducerImageSize.Height, ProducerImageSize.Width, ThumbImagePath);
        ////        p.ImagePath = "/AdminImage/ProducerImg/" + newPath; ;
        ////        p.ImageThumpPath = "/AdminImage/ProducerImg/Thump" + newPath; ;
        ////    }
        ////    p.Name = Item.Name;
        ////    //   p.ProducerTypeSeqID = Item.ProducerTypeSeqID;
        ////    p.SecondName = Item.SecondName;
        ////    p.Phone = Item.Phone;
        ////    p.Email = Item.Email;
        ////    p.CreatedOn = DateTime.Now;
        ////    p.IsActive = Item.IsActive;
        ////    p.Remark = Item.Remark;
        ////    p.History = Item.History;
        ////    p.GroupID = Item.GroupID;
        ////    TAdd(p);

        ////    if (p.ProducerSeqID != null)
        ////    {



        ////        foreach (var item in Item.producerTypeList)
        ////        {
        ////            if (item.Status == true)
        ////            {

        ////                ProducerWithProduserType producerWithProduserType = new ProducerWithProduserType();
        ////                producerWithProduserType.CreatedOn = DateTime.Now;
        ////                producerWithProduserType.IsActive = true;
        ////                producerWithProduserType.ProducerSeqID = p.ProducerSeqID;

        ////                producerWithProduserType.ProducerTypeSeqID = item.ProducerTypeSeqID;

        ////                //producerWithProduserType.ProducerTypeSeqID = Item.ProducerTypeSeqID;
        ////                producerWithProduserType.CreatedOn = DateTime.Now;
        ////                ProducerWithProduserTypeRepository producerWithProduserTypeRepository = new ProducerWithProduserTypeRepository(context);
        ////                producerWithProduserTypeRepository.TAdd(producerWithProduserType);
        ////            }
        ////        }



        ////    }
        ////    return true;
        ////}
        ////public List<SelectListItem> GetProducerGroupIDListForDropdown()
        ////{


        ////    List<SelectListItem> grupNo = new List<SelectListItem>();


        ////    grupNo.Insert(0, (new SelectListItem { Text = "Hak Sahibi", Value = "1" }));
        ////    grupNo.Insert(1, (new SelectListItem { Text = "Diğer", Value = "2" }));


        ////    return grupNo.ToList();

        ////}
        //public List<SelectListItem> GetProducerTypeListForDropdown()
        //{

        //    List<SelectListItem> list = (from x in context.Set<ProducerType>().Where(i => i.ISActive == true).OrderByDescending(i => i.DisplayOrderNumber).ToList()
        //                                 select new SelectListItem
        //                                 {
        //                                     Text = x.Name,
        //                                     Value = x.ProducerTypeID.ToString()
        //                                 }).ToList();
        //    return list;

        //}
        //public ProducersAddModel getProducersByID(int id)
        //{
        //    ProducersAddModel mymodel = new ProducersAddModel();
        //    var Item = TgetItemByID(id);
        //    mymodel.Name = Item.Name;
        //    mymodel.Email = Item.Email;
        //    mymodel.Phone = Item.Phone;
        //    mymodel.ProducerSeqID = Item.ProducerSeqID;
        //    mymodel.SecondName = Item.SecondName;
        //    mymodel.IsActive = Item.IsActive;
        //    mymodel.Remark = Item.Remark;
        //    mymodel.History = Item.History;
        //    mymodel.ImagePathStr = Item.ImagePath;
        //    mymodel.GroupID = Item.GroupID;
        //    var producerWithProduserTypes = context.Set<ProducerWithProduserType>().Where(x => x.IsActive == true && x.ProducerSeqID == id).ToList();

        //    var producerTypes = context.Set<ProducerType>().Where(x => x.ISActive == true).ToList();

        //    List<ProducerTypeModel> producerTypeList = new List<ProducerTypeModel>();

        //    foreach (var item in producerTypes)
        //    {
        //        ProducerTypeModel producerTypeModel = new ProducerTypeModel();
        //        producerTypeModel.ProducerTypeSeqID = item.ProducerTypeSeqID;
        //        producerTypeModel.Name = item.Name;
        //        foreach (var producerTypeRelation in producerWithProduserTypes)
        //        {
        //            if (producerTypeModel.ProducerTypeSeqID == producerTypeRelation.ProducerTypeSeqID)
        //            {
        //                producerTypeModel.Status = true;
        //                break;
        //            }
        //            else
        //            {
        //                producerTypeModel.Status = false;
        //            }
        //        }
        //        producerTypeList.Add(producerTypeModel);
        //    }

        //    mymodel.producerTypeList = producerTypeList;


        //    return mymodel;
        //}
        //public bool UpdateProducers(ProducersAddModel model)
        //{
        //    var Item = TgetItemByID(model.ProducerSeqID);

        //    Item.Name = model.Name;
        //    Item.Email = model.Email;
        //    Item.Phone = model.Phone;
        //    Item.ProducerSeqID = model.ProducerSeqID;
        //    Item.SecondName = model.SecondName;
        //    Item.IsActive = model.IsActive;
        //    Item.Remark = model.Remark;
        //    Item.History = model.History;
        //    Item.GroupID = model.GroupID;
        //    Producer p = new Producer();

        //    if (model.ImagePath != null)
        //    {
        //        var path = Path.GetExtension(model.ImagePath.FileName);
        //        var newPath = Guid.NewGuid() + path;
        //        var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProducerImg/" + newPath;
        //        var ThumbImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProducerImg/Thump" + newPath;
        //        var steem = new FileStream(ImagePath, FileMode.Create);
        //        model.ImagePath.CopyTo(steem);
        //        Utility.ResizeImage(model.ImagePath, ProductImageSize.Height, ProductImageSize.Width, ThumbImagePath);
        //        p.ImagePath = "/AdminImage/ProducerImg/" + newPath;
        //        p.ImageThumpPath = "/AdminImage/ProducerImg/Thump" + newPath;
        //        Item.ImagePath = p.ImagePath;
        //        Item.ImageThumpPath = p.ImageThumpPath;
        //    }

        //    TUpdate(Item);


        //    foreach (var item in model.producerTypeList)
        //    {
        //        var producerWithProducerType = context.Set<ProducerWithProduserType>().Where(x => x.ProducerTypeSeqID == item.ProducerTypeSeqID && x.ProducerSeqID == model.ProducerSeqID).FirstOrDefault();
        //        if(producerWithProducerType != null)
        //        {
        //            producerWithProducerType.IsActive = item.Status;
        //            ProducerWithProduserTypeRepository producerWithProduserTypeRepository = new ProducerWithProduserTypeRepository(context);
        //            producerWithProduserTypeRepository.TUpdate(producerWithProducerType);

        //        }
        //        else
        //        {
        //            if (item.Status)
        //            {
        //                ProducerWithProduserType entity = new ProducerWithProduserType();
        //                entity.ProducerTypeSeqID = item.ProducerTypeSeqID;
        //                entity.ProducerSeqID = model.ProducerSeqID;
        //                entity.IsActive = true;
        //                ProducerWithProduserTypeRepository producerWithProduserTypeRepository = new ProducerWithProduserTypeRepository(context);
        //                producerWithProduserTypeRepository.TAdd(entity);
        //            }

        //        }
        //    }


        //    //TUpdate(p);


        //    //if (p.ProducerSeqID != null)
        //    //{



        //    //    foreach (var item in Item.producerTypeList)
        //    //    {
        //    //        if (item.Status == true)
        //    //        {
        //    //            ProducerWithProduserType producerWithProduserType = new ProducerWithProduserType();
        //    //            producerWithProduserType.CreatedOn = DateTime.Now;
        //    //            producerWithProduserType.IsActive = true;
        //    //            producerWithProduserType.ProducerSeqID = p.ProducerSeqID;

        //    //            producerWithProduserType.ProducerTypeSeqID = item.ProducerTypeSeqID;

        //    //            //producerWithProduserType.ProducerTypeSeqID = Item.ProducerTypeSeqID;
        //    //            producerWithProduserType.CreatedOn = DateTime.Now;
        //    //            ProducerWithProduserTypeRepository producerWithProduserTypeRepository = new ProducerWithProduserTypeRepository();
        //    //            producerWithProduserTypeRepository.TAdd(producerWithProduserType);
        //    //        }
        //    //    }

        //    //}

        //    return true;
        //}
        //public List<SelectListItem> GetAllBeneficiary()
        //{
        //    return dbset.Where(w => w.IsActive == true && w.GroupID == 1).Select(s => new SelectListItem
        //    {
        //        Value = s.ProducerSeqID.ToString(),
        //        Text = s.Name
        //    }).ToList();
        //}
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
    }
}
