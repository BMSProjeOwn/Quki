using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Bll;
using Quki.Interface;

namespace Quki.Bll
{
    public class AgreementManager : BllBase<ProducerAgreement, ProducersAgreementModel>, IAgreementService
    {
        public readonly IProductsRepository productRepository;
        public readonly IProducerAgreementWithProductRepository producerAgreementWithProductRepository;



        public AgreementManager(IServiceProvider service) : base(service)
        {
            productRepository = service.GetService<IProductsRepository>();
            producerAgreementWithProductRepository = service.GetService<IProducerAgreementWithProductRepository>();
        }

        public List<ProducerAgreement> AgreementList()
        {
            var agreementList = TGetList(x => x.IsActive == true).ToList();
            return agreementList;
        }

        public bool AgreementAdd(AddAgreementModel Item)
        {
            try
            {
                var model = ObjectMapper.Mapper.Map<ProducerAgreement>(Item);
                model.CreatedOn = DateTime.Now;
                TAdd(model);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }



            //ProducerAgreement p = new ProducerAgreement();

            //p.LanguageID = Item.LanguageID;
            //p.ProducerSeqID = Item.ProducerSeqID;
            //p.CurrencyID = Item.CurrencyID;
            //p.AgreementName = Item.AgreementName;
            //p.AgreementStartDateTime = Item.AgreementStartDateTime;
            //p.AgreementEndDateTime = Item.AgreementEndDateTime;
            //p.AgreementFee = Item.AgreementFee;
            //p.AgreementRate = Item.AgreementRate;
            //p.MinimumValue = Item.MinimumValue;
            //p.MaximumValeu = Item.MaximumValeu;
            //p.AgreementRemark = Item.AgreementRemark;
            //p.CreatedOn = DateTime.Now;
            //p.IsActive = Item.IsActive;


            //return agreementRepository.AgreementAdd(Item);
        }
        public UpdateAgreementModel AgreementGetUpdateValue(long id)
        {
            var Item = TGetList(w => w.ProducerAgreementSeqID == id).FirstOrDefault();

            UpdateAgreementModel mymodel = new UpdateAgreementModel();

            mymodel.ProducerAgreementSeqID = Item.ProducerAgreementSeqID;
            mymodel.AgreementName = Item.AgreementName;
            mymodel.AgreementRate = Item.AgreementRate;
            mymodel.AgreementRemark = Item.AgreementRemark;
            mymodel.AgreementFee = Item.AgreementFee;
            mymodel.AgreementStartDateTime = Item.AgreementStartDateTime;
            mymodel.AgreementEndDateTime = Item.AgreementEndDateTime;
            mymodel.MinimumValue = Item.MinimumValue;
            mymodel.MaximumValeu = Item.MaximumValeu;
            mymodel.LanguageID = Item.LanguageID;
            mymodel.CurrencyID = Item.CurrencyID;
            mymodel.ProducerSeqID = Item.ProducerSeqID;
            //mymodel.BeneficiaryName = Item.ProducerSeqID;
            mymodel.AgreementTypeID = Item.AgreementTypeID;

            //tüm ürünler
            var productList = productRepository.TGetList(x => x.Status == true).Select(I => new ProductAgreement
            {
                ProductSeqID = I.ProductSeqID,
                ProductName = I.ProductName,
                ProductStatus = false

            }).OrderByDescending(x => x.ProductSeqID).ToList();


            //Anlaşmaya ait ürünlerin listesi
            //seçili anlaşmaya ait ürün listesi
            var relationProductList = producerAgreementWithProductRepository.TGetList(x => x.ProducerAgreementSeqID == id && x.IsActive == true).ToList();


            foreach (var productItem in productList)
            {
                foreach (var relationItem in relationProductList)
                {
                    if (productItem.ProductSeqID == relationItem.ProductSeqID)
                    {
                        productItem.ProductStatus = true;
                        break;
                    }
                }
            }








            mymodel.Products = productList;

            return mymodel;

        }
        public bool AgreementUpdate(UpdateAgreementModel Item)
        {
            bool returnvalue = false;

            ProducerAgreement p = TGetList(w => w.ProducerAgreementSeqID == Item.ProducerAgreementSeqID).FirstOrDefault();
            p.LanguageID = Item.LanguageID;
            p.ProducerSeqID = Item.ProducerSeqID;
            p.CurrencyID = Item.CurrencyID;
            p.IsActive = true;
            p.AgreementRemark = Item.AgreementRemark;
            p.AgreementRate = Item.AgreementRate;
            p.AgreementStartDateTime = Item.AgreementStartDateTime;
            p.AgreementEndDateTime = Item.AgreementEndDateTime;
            p.AgreementFee = Item.AgreementFee;
            p.AgreementName = Item.AgreementName;
            p.MinimumValue = Item.MinimumValue;
            p.MaximumValeu = Item.MaximumValeu;

            TUpdate(p);

            for (int i = 0; i < Item.Products.Count; i++)
            {

                ProducerAgreementWithProduct producerAgreementWithProduct = new ProducerAgreementWithProduct();

                producerAgreementWithProduct.ProducerAgreementSeqID = Item.ProducerAgreementSeqID;
                producerAgreementWithProduct.ProductSeqID = Item.Products[i].ProductSeqID;
                producerAgreementWithProduct.MinimumValue = Item.MinimumValue;
                producerAgreementWithProduct.MaximumValue = Item.MaximumValeu;
                producerAgreementWithProduct.IsActive = Item.IsActive;

                var relationProductList = producerAgreementWithProductRepository.TGetList(x => x.IsActive == true).ToList();

                //ürün varsa kaydetme.

                //Seçili olan ürünler için 
                if (Item.Products[i].ProductStatus == true)
                {
                    var relationProduct = producerAgreementWithProductRepository.TGetList(x => x.ProducerAgreementSeqID == Item.ProducerAgreementSeqID && x.ProductSeqID == Item.Products[i].ProductSeqID).FirstOrDefault();
                    if (relationProduct == null)
                    {
                        producerAgreementWithProductRepository.TAdd(producerAgreementWithProduct);
                    }
                    else
                    {
                        relationProduct.IsActive = true;
                        producerAgreementWithProductRepository.TUpdate(relationProduct);
                    }

                }
                else
                {
                    var relationProduct = producerAgreementWithProductRepository.TGetList(x => x.ProducerAgreementSeqID == Item.ProducerAgreementSeqID && x.ProductSeqID == Item.Products[i].ProductSeqID).FirstOrDefault();
                    if (relationProduct != null)
                    {
                        relationProduct.IsActive = false;
                        producerAgreementWithProductRepository.TUpdate(relationProduct);
                    }
                }

            }




            return returnvalue;

        }
        public bool AgreementDelete(int id)
        {
            try
            {
                bool result = false;

                var x = TGetList(x => x.ProducerAgreementSeqID == id).FirstOrDefault();

                x.IsActive = false;

                TUpdate(x);
                result = true;
                return result;
            }
            catch (Exception)
            {


                return false;
            }

        }
        public List<SelectListItem> GetAllAgreement()
        {
            return TGetList(w => w.IsActive == true).Select(s => new SelectListItem
            {
                Value = s.ProducerAgreementSeqID.ToString(),
                Text = s.AgreementName
            }).ToList();
        }
        public List<SelectListItem> GetAgreementByProducerSeqID(int ProducerSeqID)
        {
            var list = new List<SelectListItem>();
            if (ProducerSeqID != 0)
            {
                //var result = TGetList(w => w.IsActive == true && w.ProducerSeqID == ProducerSeqID);
                //return ObjectMapper.Mapper.Map<List<SelectListItem>>(result);

                list = TGetList(w => w.IsActive == true && w.ProducerSeqID == ProducerSeqID).Select(s => new SelectListItem
                {
                    Value = s.ProducerAgreementSeqID.ToString(),
                    Text = s.AgreementName
                }).ToList();
            }
            else
            {
                list = TGetList(w => w.IsActive == true).Select(s => new SelectListItem
                {
                    Value = s.ProducerAgreementSeqID.ToString(),
                    Text = s.AgreementName
                }).ToList();
            }
            return list;



            //return agreementRepository.GetAgreementByProducerSeqID(ProducerSeqID);
        }
    }
}
