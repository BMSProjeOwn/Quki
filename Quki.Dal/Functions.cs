using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Entity.Parameters;
using Quki.Interface;

namespace Quki.Common.Dal
{
    public static class Functions
    {
        private readonly static IProductService productService;
        private readonly static IPaymentsService paymentsService;
        private readonly static IMembershipTypePricePlaneService membershipTypePricePlaneService;
        private readonly static IMemberShipPaymentPlanWithPaymentChannelService memberShipPaymentPlanWithPaymentChannelService;
        private readonly static IMemberShipTypeWithCustomersPaymentChanelService memberShipTypeWithCustomersPaymentChanelService;
        private readonly static IMemberShipTypeWithCustomerService memberShipTypeWithCustomerService;
        private readonly static IIntegrationPropertiesService integrationPropertiesService;
        private readonly static ISalesService salesService;
        private readonly static ISalesItemsService salesItemsService;
        private readonly static ICampaignDefWithCouponService campaignDefWithCouponService;
        private readonly static ICampaignDefWithCampaignPropertiesDefService campaignDefWithCampaignPropertiesDefService;
        private readonly static ICustomerService customerService;
        private readonly static IMemberShipTypeService membershipTypeService;
        private readonly static IMemberShipWithCampaignDefCouponService memberShipWithCampaignDefCouponService;
        public static List<SelectListItem> GenderList()
        {
            var listGender = new List<SelectListItem>();
            SelectListItem Choose = new SelectListItem();
            Choose.Value = "0";
            listGender.Add(Choose);
            Choose.Text = MultiLanguageOmni.ReadResourceKey.GetString("Choose", "MultiLanguageOmni.Index");
            SelectListItem Male = new SelectListItem();
            Male.Value = "1";
            Male.Text = MultiLanguageOmni.ReadResourceKey.GetString("Male", "MultiLanguageOmni.Index");
            listGender.Add(Male);
            SelectListItem Female = new SelectListItem();
            Female.Value = "2";
            Female.Text = MultiLanguageOmni.ReadResourceKey.GetString("Female", "MultiLanguageOmni.Index");
            listGender.Add(Female);
            return listGender;
        }
        public static int setLanguage(string ActiveLanguage)
        {
            string language = "tr-TR";
            int languageId = 1;

            try
            {
                if (ActiveLanguage != null)
                {
                    language = ActiveLanguage;
                    language = language.Split("|")[1];
                    language = language.Split("=")[1];
                }
            }
            catch (Exception ex) { }
            if (language == "tr-TR")
                languageId = 1;
            else if (language == "en-US")
                languageId = 2;
            else if (language == "de-DE")
                languageId = 3;
            MultiLanguageOmni.ReadResourceKey.cultureName = language;
            return languageId;
        }
        public static string GetProductName(int id)
        {
            var products = productService.TGetList(x => x.ProductID.Equals(id)).FirstOrDefault().ProductName;

            return products;
        }

        public static string StripHTML(string input)
        {
            input = Regex.Replace(input, "<.*?>", String.Empty);
            input = Regex.Replace(input, "&nbsp;", String.Empty);
            return input;
        }
}
}
