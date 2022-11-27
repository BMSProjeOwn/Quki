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
using Quki.Entity.Models;
using Quki.Entity.Parameters;
using Quki.Interface;

namespace Quki.Bll
{
    public class BeneficiaryManager : BllBase<Producer, ProducersAddModel>, IBeneficiaryService
    {
        public readonly IBeneficiaryRepository beneficiaryRepository;
        public readonly IProducerWithProduserTypeRepository producerWithProduserTypeRepository;
        public readonly IProducerTypeRepository producerTypeRepository;

        public BeneficiaryManager(IServiceProvider service) :base(service)
        {
            beneficiaryRepository = service.GetService<IBeneficiaryRepository>();
            producerWithProduserTypeRepository = service.GetService<IProducerWithProduserTypeRepository>();
            producerTypeRepository = service.GetService<IProducerTypeRepository>();
        }

        public List<ProducersAgreementModel> getProducersList()
        {
            List<ProducersAgreementModel> list2 = TGetList()
            .Select(I => new ProducersAgreementModel
            {
                ProducerSeqID = I.ProducerSeqID,
                Name = I.Name,
                TypeName = producerWithProduserTypeRepository.TGetList().Join(producerTypeRepository.TGetList(), iki => iki.ProducerTypeSeqID, ProducerType => ProducerType.ProducerTypeSeqID,
                (PC, C) => new
                {
                    ProducersW = PC,
                    ProducerType = C,
                }).Where(w => w.ProducersW.ProducerSeqID == I.ProducerSeqID && w.ProducersW.IsActive == true).Select(s => s.ProducerType.Name + ", ").ToList(),
                Phone = I.Phone,
                Email = I.Email,
                Adress = I.Adress,
                IsActive = I.IsActive,
                ImagePath = I.ImagePath,
                ImageThumpPath = I.ImageThumpPath,
                GroupID = I.GroupID

            }).Where(x => x.IsActive == true)
            .OrderBy(x => x.Name).ToList();

            return list2;
        }
        public bool GetProducerByName(string producerName, int producerTypeId)
        {
            bool result = false;

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
        public bool ProducersAdd(ProducersAddModel Item)
        {
            try
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
                p.GroupID = Item.GroupID;
                TAdd(p);

                if (p.ProducerSeqID != null)
                {



                    foreach (var item in Item.producerTypeList)
                    {
                        if (item.Status == true)
                        {

                            ProducerWithProduserType producerWithProduserType = new ProducerWithProduserType();
                            producerWithProduserType.CreatedOn = DateTime.Now;
                            producerWithProduserType.IsActive = true;
                            producerWithProduserType.ProducerSeqID = p.ProducerSeqID;

                            producerWithProduserType.ProducerTypeSeqID = item.ProducerTypeSeqID;

                            //producerWithProduserType.ProducerTypeSeqID = Item.ProducerTypeSeqID;
                            producerWithProduserType.CreatedOn = DateTime.Now;

                            producerWithProduserTypeRepository.TAdd(producerWithProduserType);
                        }
                    }



                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }
        public List<SelectListItem> GetProducerGroupIDListForDropdown()
        {

            List<SelectListItem> grupNo = new List<SelectListItem>();


            grupNo.Insert(0, (new SelectListItem { Text = "Hak Sahibi", Value = "1" }));
            grupNo.Insert(1, (new SelectListItem { Text = "Diğer", Value = "2" }));


            return grupNo.ToList();
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
            mymodel.GroupID = Item.GroupID;
            var producerWithProduserTypes = producerWithProduserTypeRepository.TGetList(x => x.IsActive == true && x.ProducerSeqID == id).ToList();

            var producerTypes = producerTypeRepository.TGetList(x => x.ISActive == true).ToList();

            List<ProducerTypeModel> producerTypeList = new List<ProducerTypeModel>();

            foreach (var item in producerTypes)
            {
                ProducerTypeModel producerTypeModel = new ProducerTypeModel();
                producerTypeModel.ProducerTypeSeqID = item.ProducerTypeSeqID;
                producerTypeModel.Name = item.Name;
                foreach (var producerTypeRelation in producerWithProduserTypes)
                {
                    if (producerTypeModel.ProducerTypeSeqID == producerTypeRelation.ProducerTypeSeqID)
                    {
                        producerTypeModel.Status = true;
                        break;
                    }
                    else
                    {
                        producerTypeModel.Status = false;
                    }
                }
                producerTypeList.Add(producerTypeModel);
            }

            mymodel.producerTypeList = producerTypeList;


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
            Item.GroupID = model.GroupID;
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


            foreach (var item in model.producerTypeList)
            {
                var producerWithProducerType = producerWithProduserTypeRepository.TGetList(x => x.ProducerTypeSeqID == item.ProducerTypeSeqID && x.ProducerSeqID == model.ProducerSeqID).FirstOrDefault();
                if (producerWithProducerType != null)
                {
                    producerWithProducerType.IsActive = item.Status;
                    producerWithProduserTypeRepository.TUpdate(producerWithProducerType);

                }
                else
                {
                    if (item.Status)
                    {
                        ProducerWithProduserType entity = new ProducerWithProduserType();
                        entity.ProducerTypeSeqID = item.ProducerTypeSeqID;
                        entity.ProducerSeqID = model.ProducerSeqID;
                        entity.IsActive = true;
                        producerWithProduserTypeRepository.TAdd(entity);
                    }

                }
            }


            //TUpdate(p);


            //if (p.ProducerSeqID != null)
            //{



            //    foreach (var item in Item.producerTypeList)
            //    {
            //        if (item.Status == true)
            //        {
            //            ProducerWithProduserType producerWithProduserType = new ProducerWithProduserType();
            //            producerWithProduserType.CreatedOn = DateTime.Now;
            //            producerWithProduserType.IsActive = true;
            //            producerWithProduserType.ProducerSeqID = p.ProducerSeqID;

            //            producerWithProduserType.ProducerTypeSeqID = item.ProducerTypeSeqID;

            //            //producerWithProduserType.ProducerTypeSeqID = Item.ProducerTypeSeqID;
            //            producerWithProduserType.CreatedOn = DateTime.Now;
            //            ProducerWithProduserTypeRepository producerWithProduserTypeRepository = new ProducerWithProduserTypeRepository();
            //            producerWithProduserTypeRepository.TAdd(producerWithProduserType);
            //        }
            //    }

            //}

            return true;
        }
        public List<SelectListItem> GetAllBeneficiary()
        {
            return TGetList(w => w.IsActive == true && w.GroupID == 1).Select(s => new SelectListItem
            {
                Value = s.ProducerSeqID.ToString(),
                Text = s.Name
            }).ToList();
        }
        public bool ProducerDeleteById(int id)
        {
            try
            {
                bool result = false;

                var x = TGetList(x => x.ProducerSeqID == id).FirstOrDefault();

                x.IsActive = false;

                //var y = context.ProducerWithProduserType.

                TUpdate(x);
                result = true;
                return result;
            }
            catch (Exception)
            {

                return false;
            }
            
        }
    }
}
