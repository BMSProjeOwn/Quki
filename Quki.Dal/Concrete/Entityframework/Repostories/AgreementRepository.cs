
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class AgreementRepository : GenericRepository<ProducerAgreement>, IAgreementRepository
    {

        public AgreementRepository(DbContext context) : base(context)
        {
            
        }


        //public List<ProducerAgreement> AgreementList()
        //{
        //    //var agreementList = context.Set<ProducerAgreement>().Where(x => x.IsActive == true).ToList();
        //    //return agreementList;
        //}



        //public bool AgreementAdd(AddAgreementModel Item)
        //{
        //    ProducerAgreement p = new ProducerAgreement();

        //    p.LanguageID = Item.LanguageID;
        //    p.ProducerSeqID = Item.ProducerSeqID;
        //    p.CurrencyID = Item.CurrencyID;
        //    p.AgreementName = Item.AgreementName;
        //    p.AgreementStartDateTime = Item.AgreementStartDateTime;
        //    p.AgreementEndDateTime = Item.AgreementEndDateTime;
        //    p.AgreementFee = Item.AgreementFee;
        //    p.AgreementRate = Item.AgreementRate;
        //    p.MinimumValue = Item.MinimumValue;
        //    p.MaximumValeu = Item.MaximumValeu;
        //    p.AgreementRemark = Item.AgreementRemark;
        //    p.CreatedOn = DateTime.Now;
        //    p.IsActive = Item.IsActive;

        //    TAdd(p);
        //    return true;
        //}


        //public UpdateAgreementModel AgreementGetUpdateValue(long id)
        //{
        //    var Item = context.Set<ProducerAgreement>().Where(w => w.ProducerAgreementSeqID == id).FirstOrDefault();

        //    UpdateAgreementModel mymodel = new UpdateAgreementModel();

        //    mymodel.ProducerAgreementSeqID = Item.ProducerAgreementSeqID;
        //    mymodel.AgreementName = Item.AgreementName;
        //    mymodel.AgreementRate = Item.AgreementRate;
        //    mymodel.AgreementRemark = Item.AgreementRemark;
        //    mymodel.AgreementFee = Item.AgreementFee;
        //    mymodel.AgreementStartDateTime = Item.AgreementStartDateTime;
        //    mymodel.AgreementEndDateTime = Item.AgreementEndDateTime;
        //    mymodel.MinimumValue = Item.MinimumValue;
        //    mymodel.MaximumValeu = Item.MaximumValeu;
        //    mymodel.LanguageID = Item.LanguageID;
        //    mymodel.CurrencyID = Item.CurrencyID;
        //    mymodel.ProducerSeqID = Item.ProducerSeqID;
        //    //mymodel.BeneficiaryName = Item.ProducerSeqID;
        //    mymodel.AgreementTypeID = Item.AgreementTypeID;

        //    //tüm ürünler
        //    var productList = context.Set<Products>().Where(x => x.Status == true).Select(I => new ProductAgreement
        //    {
        //        ProductSeqID = I.ProductSeqID,
        //        ProductName = I.ProductName,
        //        ProductStatus = false

        //    }).OrderByDescending(x => x.ProductSeqID).ToList();


        //    //Anlaşmaya ait ürünlerin listesi
        //    //seçili anlaşmaya ait ürün listesi
        //    var relationProductList = context.Set<ProducerAgreementWithProduct>().Where(x => x.IsActive == true && x.ProducerAgreementSeqID == id).ToList();


        //    foreach (var productItem in productList)
        //    {
        //        foreach (var relationItem in relationProductList)
        //        {
        //            if (productItem.ProductSeqID == relationItem.ProductSeqID)
        //            {
        //                productItem.ProductStatus = true;
        //                break;
        //            }
        //        }
        //    }








        //    mymodel.Products = productList;

        //    return mymodel;
        ////}




        //public bool AgreementUpdate(UpdateAgreementModel Item)
        //{
        //    bool returnvalue = false;

        //    ProducerAgreement p = dbset.Where(w => w.ProducerAgreementSeqID == Item.ProducerAgreementSeqID).FirstOrDefault();
        //    p.LanguageID = Item.LanguageID;
        //    p.ProducerSeqID = Item.ProducerSeqID;
        //    p.CurrencyID = Item.CurrencyID;
        //    p.IsActive = true;
        //    p.AgreementRemark = Item.AgreementRemark;
        //    p.AgreementRate = Item.AgreementRate;
        //    p.AgreementStartDateTime = Item.AgreementStartDateTime;
        //    p.AgreementEndDateTime = Item.AgreementEndDateTime;
        //    p.AgreementFee = Item.AgreementFee;
        //    p.AgreementName = Item.AgreementName;
        //    p.MinimumValue = Item.MinimumValue;
        //    p.MaximumValeu = Item.MaximumValeu;

        //    TUpdate(p);

        //    ProducerAgreementWithProductRepository repository = new ProducerAgreementWithProductRepository(context);



        //    for (int i = 0; i < Item.Products.Count; i++)
        //    {

        //        ProducerAgreementWithProduct producerAgreementWithProduct = new ProducerAgreementWithProduct();

        //        producerAgreementWithProduct.ProducerAgreementSeqID = Item.ProducerAgreementSeqID;
        //        producerAgreementWithProduct.ProductSeqID = Item.Products[i].ProductSeqID;
        //        producerAgreementWithProduct.MinimumValue = Item.MinimumValue;
        //        producerAgreementWithProduct.MaximumValue = Item.MaximumValeu;
        //        producerAgreementWithProduct.IsActive = Item.IsActive;

        //        var relationProductList = context.Set<ProducerAgreementWithProduct>().Where(x => x.IsActive == true).ToList();

        //        //ürün varsa kaydetme.

        //        //Seçili olan ürünler için 
        //        if (Item.Products[i].ProductStatus == true)
        //        {
        //            var relationProduct = context.Set<ProducerAgreementWithProduct>().Where(x => x.ProducerAgreementSeqID == Item.ProducerAgreementSeqID && x.ProductSeqID == Item.Products[i].ProductSeqID).FirstOrDefault();
        //            if (relationProduct == null)
        //            {
        //                repository.TAdd(producerAgreementWithProduct);
        //            }
        //            else
        //            {
        //                relationProduct.IsActive = true;
        //                repository.TUpdate(relationProduct);
        //            }

        //        }
        //        else
        //        {
        //            var relationProduct = context.Set<ProducerAgreementWithProduct>().Where(x => x.ProducerAgreementSeqID == Item.ProducerAgreementSeqID && x.ProductSeqID == Item.Products[i].ProductSeqID).FirstOrDefault();
        //            if (relationProduct != null)
        //            {
        //                relationProduct.IsActive = false;
        //                repository.TUpdate(relationProduct);
        //            }
        //        }

        //    }




        //    return returnvalue;
        ////}




        //public bool AgreementDelete(int id)
        //{
        //    bool result = false;

        //    var x = dbset.Where(x => x.ProducerAgreementSeqID == id).FirstOrDefault();

        //    x.IsActive = false;

        //    TUpdate(x);
        //    result = true;
        //    return result;
        ////}



        //public List<SelectListItem> GetAllAgreement()
        //{
        //    return dbset.Where(w => w.IsActive == true).Select(s => new SelectListItem
        //    {
        //        Value = s.ProducerAgreementSeqID.ToString(),
        //        Text = s.AgreementName
        //    }).ToList();
        ////}

        //public List<SelectListItem> GetAgreementByProducerSeqID(int ProducerSeqID)
        //{
        //    var list = new List<SelectListItem>();
        //    if (ProducerSeqID != 0)
        //    {
        //        list = dbset.Where(w => w.IsActive == true && w.ProducerSeqID == ProducerSeqID).Select(s => new SelectListItem
        //        {
        //            Value = s.ProducerAgreementSeqID.ToString(),
        //            Text = s.AgreementName
        //        }).ToList();
        //    }
        //    else
        //    {
        //        list = dbset.Where(w => w.IsActive == true).Select(s => new SelectListItem
        //        {
        //            Value = s.ProducerAgreementSeqID.ToString(),
        //            Text = s.AgreementName
        //        }).ToList();
        //    }
        //    return list;
        //}
    }
}
