using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Entity.Parameters;
using Quki.Interface;

namespace Quki.Common
{
    public static class Functions
    {

        public static T ToObject<T>(this JsonElement element)
        {
            var json = element.GetRawText();
            return JsonConvert.DeserializeObject<T>(json);
        }
        public static string GetCountryInfo(IPAddress headerIp)
        {
            string countryCode = "TR";
            IpInfo ipInfo = new IpInfo();
            try
            {
                string info = new WebClient().DownloadString("http://ipinfo.io/" + headerIp);
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);

                countryCode = ipInfo.country;
            }
            catch (System.Exception)
            {
                countryCode = "TR";
            }
            return countryCode;
        }
        public static string BuyGiftSubscription(
           string userID, int MemberShipTypePricePlaneSeqID, int campingSeq, SubscriptionCardInfo subscriptionCardInfo,out string result)
        {
            result = "";
            string code = "";
            string CustemerRefCode = "";
            string ErrorCode = "";
            using var contex = new ProjeDBContext();
            Customer customer = contex.Customers.Where(x => x.UserID == userID).FirstOrDefault();
            UserProfile userProfile = contex.UserProfiles.Where(x => x.Id == userID).FirstOrDefault();
            if (userProfile.MobPhone != null && userProfile.MobPhone != "")
            {
                userProfile.MobPhone = ControlMobilPhone(userProfile.MobPhone);
            }
            if (customer.email==null)
            {
                result = "Lütfen bilgilerinizi doldurun";
                return result;
            }
            MemberShipPaymentPlanWithPaymentChannel Plan = contex.MemberShipPaymentPlanWithPaymentChannel.Where(x => x.MemberShipTypePricePlaneSeqID == Convert.ToInt32(MemberShipTypePricePlaneSeqID)).FirstOrDefault();
            SubscriptionInitializeModel subscriptionInitializeModel = new SubscriptionInitializeModel();
            subscriptionInitializeModel.Customer.Email = customer.email;
            subscriptionInitializeModel.Customer.IdentityNumber = customer.customer_VknTckn;
            subscriptionInitializeModel.Customer.Name = customer.customer_def_name;
            subscriptionInitializeModel.Customer.Surname = customer.customer_def_surname;
            subscriptionInitializeModel.Customer.GsmNumber = userProfile.MobPhone;
            subscriptionInitializeModel.Customer.BillingAddress.City = userProfile.City;
            subscriptionInitializeModel.Customer.BillingAddress.ContactName = customer.customer_def_name;
            subscriptionInitializeModel.Customer.BillingAddress.Country = userProfile.Country;
            subscriptionInitializeModel.Customer.BillingAddress.Description = userProfile.Address1;
            subscriptionInitializeModel.Customer.BillingAddress.ZipCode = userProfile.PostalCode;
            subscriptionInitializeModel.PricingPlanReferenceCode = Plan.ReferenceCode;
            subscriptionInitializeModel.Price = contex.MembershipTypePricePlane.Where(x => x.MemberShipTypePricePlaneSeqID == Plan.MemberShipTypePricePlaneSeqID).FirstOrDefault().Price;
            subscriptionInitializeModel.PaymentCard = subscriptionCardInfo;
            //Iyzipay.Model.Payment PaymentResult = IyzipayEntegration
            //    .CreatePay(subscriptionInitializeModel, out ErrorCode);
            //if (String.IsNullOrEmpty(PaymentResult.ErrorMessage))
            //{
            //    CampaignDefWithCouponModel campaignDefWithCouponModel = new CampaignDefWithCouponModel();
            //    campaignDefWithCouponModel.Number = 1;
            //    campaignDefWithCouponModel.Prefix = CreateRandomCouponCode(3, "", "", false);
            //    campaignDefWithCouponModel.Sufix = CreateRandomCouponCode(3, "", "", false);
            //    campaignDefWithCouponModel.StartValidDatetime = DateTime.Now;
            //    campaignDefWithCouponModel.EndValidDatetime = DateTime.Now.AddMonths(1);
            //    campaignDefWithCouponModel.CampaignDefSeqID = campingSeq;
            //    code = AddCoupon(campaignDefWithCouponModel);


            //    var properties = SelectAllPropertiesByCampaignDefSeqIDSP(campingSeq);
            //    MemberShipWithCampaignDefCoupon memberShipWithCampaignDefCoupon = new MemberShipWithCampaignDefCoupon();
            //    memberShipWithCampaignDefCoupon.MemberShipTypeWithCustomer = 0;
            //    memberShipWithCampaignDefCoupon.MemberShipTypePricePlaneSeqID = MemberShipTypePricePlaneSeqID;
            //    memberShipWithCampaignDefCoupon.Status = (short)MemberShipWithCuponStatus.Active;
            //    memberShipWithCampaignDefCoupon.DiscountRate = 0;
            //    //memberShipWithCampaignDefCoupon.UsingDatetime = DateTime.Now;
            //    memberShipWithCampaignDefCoupon.CreatedDateTime = DateTime.Now;
            //    memberShipWithCampaignDefCoupon.CreatedBy = Guid.Parse(userID);
            //    if (properties != null)
            //    {
            //        if (properties.Count > 0)
            //        {
            //            for (int i = 0; i < properties.Count; i++)
            //            {
            //                if (properties[i].CampaignPropertiesFunction == "DiscountRateFunction")
            //                {
            //                    memberShipWithCampaignDefCoupon.DiscountRate = Convert.ToDecimal(properties[i].CampaignPropertiesValue);
            //                }
            //            }
            //        }
            //    }
            //    CuponWithMemberAdd(memberShipWithCampaignDefCoupon, 1, code);

            //   // GiftPayment(PaymentResult,userID, MemberShipTypePricePlaneSeqID);
            //    //CampaignRepository campaignRepository = new CampaignRepository();
            //    //AddCampaignModel addCampaignModel = new AddCampaignModel();
            //    //addCampaignModel.CampaignDefName = userID + " / - / Hediye Kampanya";
            //    //addCampaignModel.StartCampaignDateTime = DateTime.Now;
            //    //addCampaignModel.EndCampaignDefDateTime = DateTime.Now.AddMonths(1);
            //    //addCampaignModel.CampaignDefRemark = " ";
            //    //addCampaignModel.IsMonday = true;
            //    //addCampaignModel.IsTuesday = true;
            //    //addCampaignModel.IsWednesday = true;
            //    //addCampaignModel.IsThursday = true;
            //    //addCampaignModel.IsFriyday = true;
            //    //addCampaignModel.IsSaturday = true;
            //    //addCampaignModel.IsSunday = true;
            //    //addCampaignModel.LanguageID = 1;
            //    //int campingSeq = campaignRepository.AddCampaign(addCampaignModel);
            //    //if (campingSeq != null)
            //    //{
            //    //    if (campingSeq > 0)
            //    //    {
            //    //        CampaignPropertiesDefRepository campaignPropertiesDefRepository = new CampaignPropertiesDefRepository();
            //    //        var discountProperty = campaignPropertiesDefRepository.GetPropertieByFunctionName("DiscountRateFunction");
            //    //        CampaignDefWithCampaignPropertiesDefRepository campaignDefWithCampaignPropertiesDefRepository = new CampaignDefWithCampaignPropertiesDefRepository();
            //    //        CampaignDefWithCampaignPropertiesDef campaignDefWithCampaignPropertiesDef = new CampaignDefWithCampaignPropertiesDef();
            //    //        campaignDefWithCampaignPropertiesDef.CampaignDefSeqID = campingSeq;
            //    //        campaignDefWithCampaignPropertiesDef.Value = "100";
            //    //        campaignDefWithCampaignPropertiesDef.IsActive = true;
            //    //        campaignDefWithCampaignPropertiesDef.CreatedDateTime = DateTime.Now;
            //    //        campaignDefWithCampaignPropertiesDef.CampaignDefPropertiesDefSeqID = discountProperty.CampaignDefPropertiesDefSeqID;
            //    //        bool result = campaignDefWithCampaignPropertiesDefRepository.AddNew(campaignDefWithCampaignPropertiesDef);
            //    //        if (result)
            //    //        {
            //    //            CampaignDefWithMemberShipTypePricePlaneRepository campaignDefWithMemberShipTypePricePlaneRepository = new CampaignDefWithMemberShipTypePricePlaneRepository();
            //    //            CampaignDefWithMemberShipTypePricePlane campaignDefWithMemberShipTypePricePlane = new CampaignDefWithMemberShipTypePricePlane();
            //    //            campaignDefWithMemberShipTypePricePlane.isActive = true;
            //    //            campaignDefWithMemberShipTypePricePlane.CampaignDefSeqID = campingSeq;
            //    //            campaignDefWithMemberShipTypePricePlane.MemberShipTypePricePlaneSeqID = MemberShipTypePricePlaneSeqID;
            //    //            result = campaignDefWithMemberShipTypePricePlaneRepository.AddNew(campaignDefWithMemberShipTypePricePlane);
            //    //            if (result)
            //    //            {
            //    //                CampaignDefWithCouponRepository campaignDefWithCouponRepository = new CampaignDefWithCouponRepository();
            //    //                CampaignDefWithCouponModel campaignDefWithCouponModel = new CampaignDefWithCouponModel();
            //    //                campaignDefWithCouponModel.Number = 1;
            //    //                campaignDefWithCouponModel.Prefix = Functions.CreateRandomCouponCode(3, "", "", false);
            //    //                campaignDefWithCouponModel.Sufix = Functions.CreateRandomCouponCode(3, "", "", false);
            //    //                campaignDefWithCouponModel.StartValidDatetime = (DateTime)addCampaignModel.StartCampaignDateTime;
            //    //                campaignDefWithCouponModel.EndValidDatetime = (DateTime)addCampaignModel.EndCampaignDefDateTime;
            //    //                campaignDefWithCouponModel.CampaignDefSeqID = campingSeq;
            //    //                code = campaignDefWithCouponRepository.AddCoupon(campaignDefWithCouponModel);
            //    //            }
            //    //        }
            //    //    }
            //    //}
            //}
            //else
            //{
            //   // result = PaymentResult.ErrorMessage;
            //}
            return code;
        }

        public static string CreateRandomCouponCode(int lenght, string Prefix, string Sufix, bool Control)
        {
            using var contex = new ProjeDBContext();

            string couponCode = "";


            while (true)
            {
                couponCode = "";
                var rnd = new Random();


                for (int i = 0; i < lenght; i++)
                {
                    couponCode += ((char)rnd.Next('A', 'Z')).ToString();

                }
                couponCode = Prefix + couponCode + Sufix;
                CampaignDefWithCoupon couponCode1 = null;
                if (Control)
                {
                    couponCode1 = contex.CampaignDefWithCoupon.Where(x => x.CouponDefCode == couponCode).FirstOrDefault();

                }

                if (couponCode1 == null)
                    break;
            }

            return couponCode;
        }
        public static void CreateInUseMemberWithCupon(int MemberShipWithCampaignDefCouponSeq, long MemberShipTypeWithCustomerSeq, int MemberShipTypePricePlaneSeqID, string UserID, int NumberOfUses, string campingCode)
        {
            using var contex = new ProjeDBContext();

            if (MemberShipWithCampaignDefCouponSeq <= 0)
            {
                MemberShipWithCampaignDefCoupon memberShipWithCampaignDefCoupon = new MemberShipWithCampaignDefCoupon();
                memberShipWithCampaignDefCoupon.MemberShipTypeWithCustomer = MemberShipTypeWithCustomerSeq;
                memberShipWithCampaignDefCoupon.MemberShipTypePricePlaneSeqID = MemberShipTypePricePlaneSeqID;
                memberShipWithCampaignDefCoupon.Status = (short)MemberShipWithCuponStatus.Kullanımda;
                memberShipWithCampaignDefCoupon.UsingDatetime = DateTime.Now;
                memberShipWithCampaignDefCoupon.CreatedDateTime = DateTime.Now;
                memberShipWithCampaignDefCoupon.CreatedBy = Guid.Parse(UserID);
                CuponWithMemberAdd(memberShipWithCampaignDefCoupon, NumberOfUses, campingCode);
            }
            else
            {
                MemberShipWithCampaignDefCouponRepository memberShipWithCampaignDefCouponRepository = new MemberShipWithCampaignDefCouponRepository(contex);
                var memberShipWithCampaignDefCoupon = memberShipWithCampaignDefCouponRepository.TgetItemByID(MemberShipWithCampaignDefCouponSeq);
                memberShipWithCampaignDefCoupon.MemberShipTypeWithCustomer = MemberShipTypeWithCustomerSeq;
                memberShipWithCampaignDefCoupon.Status = (short)MemberShipWithCuponStatus.Kullanımda;
                memberShipWithCampaignDefCoupon.UsingDatetime = DateTime.Now;
                memberShipWithCampaignDefCoupon.UpdatedBy = Guid.Parse(UserID);
                memberShipWithCampaignDefCoupon.UpdateDateTime = DateTime.Now;
                CuponWithMemberUpdate(memberShipWithCampaignDefCoupon);
            }
        }

        public static void CuponWithMemberAdd(MemberShipWithCampaignDefCoupon memberShipWithCampaignDefCoupon, int NumberOfUses, string campingCode)
        {
            using var contex = new ProjeDBContext();

            var cupon = contex.CampaignDefWithCoupon.Where(x => x.CouponDefCode == campingCode).FirstOrDefault();
            memberShipWithCampaignDefCoupon.CampaignDefWithCouponSeqID = cupon.CampaignDefWithCouponSeqID;
            contex.MemberShipWithCampaignDefCoupon.Add(memberShipWithCampaignDefCoupon);
            contex.SaveChanges();
            NumberOfUses = NumberOfUses - 1;
            if (NumberOfUses <= 0)
            {
                cupon.IsActive = false;
                contex.CampaignDefWithCoupon.Update(cupon);
            }
        }
        public static List<CampingWithPropertiesRelationModel> SelectAllPropertiesByCampaignDefSeqIDSP(int CampaignDefSeqID)
        {

            using var context = new ProjeDBContext();
            string sql = @"SelectAllPropertiesByCampaignDefSeqIDSP @CampaignDefSeqID= " + CampaignDefSeqID;
            return context.Set<CampingWithPropertiesRelationModel>().FromSqlRaw(sql).ToList();
        }
        public static void CuponWithMemberUpdate(MemberShipWithCampaignDefCoupon memberShipWithCampaignDefCoupon)
        {
            using var context = new ProjeDBContext();

            context.MemberShipWithCampaignDefCoupon.Update(memberShipWithCampaignDefCoupon);

        }
        public static string AddCoupon(CampaignDefWithCouponModel campaignDefWithCouponModel)
        {
            using var contex = new ProjeDBContext();
            var entity = new CampaignDefWithCoupon();
            string result = "";

            for (int i = 0; i < campaignDefWithCouponModel.Number; i++)
            {

                entity = new CampaignDefWithCoupon();

                entity.Prefix = campaignDefWithCouponModel.Prefix;
                entity.Sufix = campaignDefWithCouponModel.Sufix;

                entity.CouponDefCode =
                    CreateRandomCouponCode(6, entity.Prefix, entity.Sufix, true);
                //entity.CouponDefCode = entity.Prefix + entity.CouponDefCode + entity.Sufix;
                entity.StartValidDatetime = campaignDefWithCouponModel.StartValidDatetime;
                entity.EndValidDatetime = campaignDefWithCouponModel.EndValidDatetime;

                entity.IsActive = true;
                entity.CreatedDateTime = DateTime.Now;
                entity.CampaignDefSeqID = campaignDefWithCouponModel.CampaignDefSeqID;



                contex.CampaignDefWithCoupon.Add(entity);
                contex.SaveChanges();
                result = entity.CouponDefCode;
            }
            return result;
        }
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
        public static string ReplaceString(string input)
        {
            if (input != null)
            {
                input = input.Trim();
                input = input.ToLower();
                input = input.Replace("?", "").Replace("\'", "").Replace('_', '-').Replace("+", "_").Replace("(", "").Replace(")", "").Replace("!", "").Replace(":", "").Replace("'", "").Replace("’", "").Replace(' ', '-');
                input = input.Replace('ı', 'i');
                input = input.Replace('ğ', 'g');
                input = input.Replace('ü', 'u');
                input = input.Replace('ş', 's');
                input = input.Replace('ö', 'o');
                input = input.Replace('ç', 'c');

                input = input.Replace('Ğ', 'G');
                input = input.Replace('Ü', 'U');
                input = input.Replace('Ş', 'S');
                input = input.Replace('İ', 'I');
                input = input.Replace('Ö', 'O');
                input = input.Replace('Ç', 'C');
            }
            return input;
        }

        public static string ControlMobilPhone(string phone)
        {
            string NewPhone = "";
            string mobphonFirstCar = phone.Substring(0, 1).ToString();
            if (mobphonFirstCar == "0")
            {
                NewPhone = "+9" + phone;
            }
            else if (mobphonFirstCar == "9")
            {
                NewPhone = "+9" + phone;
            }
            else if (mobphonFirstCar == "+")
            {
                NewPhone = phone;
            }
            else if (mobphonFirstCar == "5")
            {
                NewPhone = "+90" + phone;
            }
            else
            {
                NewPhone = phone;
            }
            return NewPhone;
        }
        //public static Integrations.IntegrationCls.GeneralModels.IntegrationModel GetIntegrationByIntegrationId(IntegrationTypes integration)
        //{
        //    using var contex = new ProjeDBContext();
        //    Integrations.IntegrationCls.GeneralModels.IntegrationModel model = new Integrations.IntegrationCls.GeneralModels.IntegrationModel();
        //    model.Integration = integration;
        //    model.IntegrationProperties = new List<Integrations.IntegrationCls.GeneralModels.IntegrationPropertiesModel>();
        //    var result = contex.Set<IntegrationProperties>().Where(w => w.IntegrationSeqID == (long)integration && w.isActive == true).ToList();
        //    foreach (var item in result)
        //    {
        //        Integrations.IntegrationCls.GeneralModels.IntegrationPropertiesModel integrationPropertiesModel = new Integrations.IntegrationCls.GeneralModels.IntegrationPropertiesModel();
        //        integrationPropertiesModel.Name = item.Name;
        //        integrationPropertiesModel.Value = item.Value;
        //        model.IntegrationProperties.Add(integrationPropertiesModel);
        //    }
        //    return model;
        //}
        //public static void SendUyumSoft(Sales sale, List<SalesItems> salesItems)
        //{
        //    using var contex = new ProjeDBContext();
        //    var branch = contex.Branch.Where(w => w.status == true && w.BranchSeqID == Convert.ToInt32(sale.SalesBranchID)).FirstOrDefault();
        //    CreateInvoiceRequestModel model = new CreateInvoiceRequestModel();
        //    model.ProfileIdType = ProfileIdType.TEMELFATURA;
        //    model.DocumentDate = DateTime.Now;
        //    model.InvoiceDocumantType = InvoiceDocumantType.SATIS;
        //    model.Not = "";
        //    model.CurrencyType = sale.CurrencyCode;// "TRY";
        //    model.StartPeriodDate = sale.SalesOpenDateTime;
        //    model.EndPeriodDate = sale.SalesCloseDateTime;
        //    model.TotalAmount = sale.SalesTotal;
        //    model.VATRate = sale.VatRate;
        //    model.TotalVATAmount = sale.SalesVatTotal;
        //    model.WithholdingTaxTotal = sale.SalesTotalWithoutVAT;
        //    if (sale.SalesTypeID == (int)DocumentTypeTypes.İrsaliye)
        //        model.DocumentTypeType = DocumentTypeTypes.İrsaliye;
        //    model.DocumentNo = sale.DocumentNumber;
        //    model.InvoiceSerialNo = sale.DocumentNumber;
        //    model.RecipientFirstName = sale.CustomerName;
        //    model.RecipientLastName = sale.CustomerSurname;
        //    model.RecipientCity = sale.CustomerCity;
        //    model.RecipientCountry = sale.CustomerCountry;
        //    model.RecipientEmail = sale.CustomerEmail;
        //    model.RecipientPhone = sale.CustomerPhone;
        //    model.RecipientVKN = sale.CustomerVKN;
        //    model.isEArchive = true;
        //    model.EArchivePaymentType = "KREDIKARTI/BANKAKARTI";
        //    model.EArchivePaymentMidierName = "";

        //    model.CompanyName = branch.Name;
        //    model.CompanyCounty = contex.Counrty.Where(w => w.CounrtySeqID == branch.CountrySeqID).FirstOrDefault().CountryName;
        //    model.CompanyCity = branch.CityName;
        //    model.CompanyTAXName = branch.company_tax_office;//"Kağıthane"

        //    model.IntegrationModel = GetIntegrationByIntegrationId(IntegrationTypes.UyumSoft);
        //    for (int i = 0; i < salesItems.Count; i++)
        //    {
        //        CreateInvoiceDetail detail = new CreateInvoiceDetail();
        //        detail.ItemName = salesItems[0].SalesItemName;
        //        detail.CurrencyType = sale.CurrencyCode;
        //        detail.Not = "";
        //        detail.Quantity = salesItems[0].SalesItemCount;
        //        detail.UnitPrice = model.TotalAmount;
        //        detail.VATRate = model.VATRate;
        //        detail.VATAmount = model.TotalVATAmount;
        //        detail.WithholdingTaxTotal = model.WithholdingTaxTotal;
        //        model.DetailList = new List<CreateInvoiceDetail>();
        //        model.DetailList.Add(detail);
        //    }
        //    string result = InvoiceFunctions.SendInvoice(model);
        //    if (result != null)
        //        if (result != "")
        //        {
        //            GetInvoiceStatusRequestModel requestModel = new GetInvoiceStatusRequestModel();
        //            requestModel.IntegrationModel = model.IntegrationModel;
        //            requestModel.invoiceIds = new List<string>();
        //            requestModel.invoiceIds.Add(result);
        //            GetInvoiceStatusResponseModel status = InvoiceFunctions.GetInvoiceStatus(requestModel);
        //            UpdateSaleSendStatus(Convert.ToInt64(model.DocumentNo), result, true, 1, (short)status.items[0].status);
        //        }
        //}

        //public static void SendInvoice(MemberShipTypeWithCustomer memberShipTypeWithCustomer, MembershipTypePricePlane pricePlane)
        //{
        //    using var contex = new ProjeDBContext();
        //    var UserProfile = contex.UserProfiles.Where(w => w.Id == memberShipTypeWithCustomer.Id).FirstOrDefault();
        //    var user = contex.Users.Where(w => w.Id == memberShipTypeWithCustomer.Id).FirstOrDefault();
        //    var memberShipTypes = contex.MemberShipTypes.Where(w => w.MemberShipTypeSeqID == pricePlane.MemberShipTypeSeqID).FirstOrDefault();
        //    var curency = contex.Currency.Where(w => w.CurrencyID == pricePlane.CurrencyID).FirstOrDefault();
        //    var branch = contex.Branch.Where(w => w.status == true).FirstOrDefault();
        //    var tax = contex.Tax.Where(w => w.Status == true).FirstOrDefault();
        //    var payments = contex.Payments.Where(w => w.MemberShipTypeWithCustomerSeqID == memberShipTypeWithCustomer.MemberShipTypeWithCustomerSeqID).ToList();

        //    DateTime starDate, endDate;

        //    int day = (memberShipTypeWithCustomer.EndDateTime - memberShipTypeWithCustomer.StartDateTime).Days;
        //    int autoRenewalCount = Convert.ToInt32(pricePlane.AutoRenewalCount.ToString());
        //    if (payments != null)
        //    {
        //        if (payments.Count > 0)
        //        {
        //            starDate = memberShipTypeWithCustomer.StartDateTime.AddDays(day / autoRenewalCount * (payments.Count - 1));
        //            endDate = memberShipTypeWithCustomer.StartDateTime.AddDays(day / autoRenewalCount * payments.Count);
        //        }
        //        else
        //        {
        //            starDate = memberShipTypeWithCustomer.StartDateTime;
        //            endDate = memberShipTypeWithCustomer.StartDateTime.AddDays(day / autoRenewalCount);
        //        }
        //    }
        //    else
        //    {
        //        starDate = memberShipTypeWithCustomer.StartDateTime;
        //        endDate = memberShipTypeWithCustomer.StartDateTime.AddDays(day / autoRenewalCount);
        //    }

        //    SalesRepository salesRepository = new SalesRepository(contex);
        //    Sales sales = new Sales();
        //    sales.DocumentTypeSeqID = (int)InvoiceDocumantType.SATIS; // (int)uyumInvoice.InvoiceDocumantType;
        //    sales.CustomerSeqID = memberShipTypeWithCustomer.MemberShipTypeWithCustomerSeqID;
        //    sales.IntegratorsSeqID = (int)IntegrationTypes.UyumSoft;//(int)uyumInvoice.IntegrationModel.Integration;
        //    sales.ApplicationSeqID = 1;//Şimdilik
        //    sales.DocumentNumber = "0";//uyumInvoice.DocumentNo;
        //    sales.SalesID = "0";
        //    sales.SalesTypeID = (short)DocumentTypeTypes.İrsaliye;// (short)uyumInvoice.InvoiceStatus;
        //    sales.SalesOpenDateTime = starDate;//uyumInvoice.StartPeriodDate;
        //    sales.SalesCloseDateTime = endDate;// uyumInvoice.EndPeriodDate;
        //    sales.SalesOpenPersonel = new Guid("00000000-0000-0000-0000-000000000000");
        //    sales.SalesClosePersonel = new Guid("00000000-0000-0000-0000-000000000000");
        //    sales.SalesTotal = pricePlane.Price;//uyumInvoice.TotalAmount;
        //    sales.VatRate = tax.TaxPercentage;
        //    if (tax.IsIncludedTax)
        //        sales.SalesVatTotal = pricePlane.Price * sales.VatRate / (100 + sales.VatRate);
        //    else
        //        sales.SalesVatTotal = pricePlane.Price * sales.VatRate / 100;
        //    //sales.SalesVatTotal = uyumInvoice.TotalVATAmount;
        //    if (tax.IsIncludedTax)
        //        sales.SalesTotalWithoutVAT = pricePlane.Price - sales.SalesVatTotal;
        //    else
        //        sales.SalesTotalWithoutVAT = pricePlane.Price;
        //    // uyumInvoice.WithholdingTaxTotal.ToString();
        //    sales.CustomerVKN = "11111111111"; //uyumInvoice.RecipientVKN;
        //    sales.CustomerTCKN = "11111111111";//uyumInvoice.RecipientVKN;

        //    string uName = "Belirtilmemiş";
        //    string uSurname = "Belirtilmemiş";

        //    try
        //    {
        //        if (UserProfile != null)
        //        {
        //            if (UserProfile.Name != null && UserProfile.Name != "")
        //            {
        //                uName = UserProfile.Name;
        //            }
        //        }
        //    }
        //    catch { }
        //    try
        //    {
        //        if (user != null)
        //        {
        //            if (user.Name != null && user.Name != "")
        //            {
        //                uName = user.Name;
        //            }
        //        }
        //    }
        //    catch { }


        //    try
        //    {
        //        if (UserProfile != null)
        //        {
        //            if (UserProfile.Surname != null && UserProfile.Surname != "")
        //            {
        //                uSurname = UserProfile.Surname;
        //            }
        //        }
        //    }
        //    catch { }
        //    try
        //    {
        //        if (user != null)
        //        {
        //            if (user.SurName != null && user.SurName != "")
        //            {
        //                uSurname = user.SurName;
        //            }
        //        }
        //    }
        //    catch { }

        //    sales.CustomerName = uName;
        //    sales.CustomerSurname = uSurname;
        //    try { sales.CustomerEmail = user.Email; } catch { }
        //    sales.CreatedDateTime = DateTime.Now;//uyumInvoice.DocumentDate;
        //    sales.DiscountTotal = 0; //Şimdilik
        //    sales.SalesTerminalID = "0";
        //    sales.SalesRevenueCenterID = "0";
        //    sales.SalesBranchID = branch.BranchSeqID.ToString();
        //    sales.FiscalReceiptNumber = "0";
        //    sales.FicalDeviceSerialNumber = "0";
        //    sales.FiscalEKUNumber = 0;
        //    sales.FiscalZNumber = 0;
        //    sales.IsTransfer = false;//gönderildiğinde değişecek
        //    sales.TransferStatus = 0;// 0 gönder, 1 gönderme vs. konuşulacak.
        //    sales.Status = -1; //-1 aktarıldı fakat durumu kontrol edilmedi.
        //    sales.CreatedBy = new Guid("00000000-0000-0000-0000-000000000000");
        //    sales.CurrencyCode = curency.CurrencyName;//uyumInvoice.CurrencyType;
        //    sales.Description = sales.CustomerName + " " + sales.CustomerSurname + " " + memberShipTypes.Name + " " + payments.Count() + " Dönem Ödemesi."; //uyumInvoice.Not;
        //    sales.SpecialCode1 = "";
        //    sales.SpecialCode2 = "";
        //    sales = AddSale(sales);
        //    List<SalesItems> items = SaveSaleItem(sales, memberShipTypes);
        //    SendUyumSoft(sales, items);
        //}
        //public static void SendInvoiceforPayment( string UserId, MembershipTypePricePlane pricePlane)
        //{
        //    using var contex = new ProjeDBContext();
        //    var UserProfile = contex.UserProfiles.Where(w => w.Id == UserId).FirstOrDefault();
        //    var user = contex.Users.Where(w => w.Id == UserId).FirstOrDefault();
        //    var curency = contex.Currency.Where(w => w.CurrencyID == pricePlane.CurrencyID).FirstOrDefault();
        //    var branch = contex.Branch.Where(w => w.status == true).FirstOrDefault();
        //    var tax = contex.Tax.Where(w => w.Status == true).FirstOrDefault();
        //    var memberShipTypes = contex.MemberShipTypes.Where(x => x.MemberShipTypeSeqID == pricePlane.MemberShipTypeSeqID).FirstOrDefault();
        //    SalesRepository salesRepository = new SalesRepository(contex);
        //    Sales sales = new Sales();

        //    sales.DocumentTypeSeqID = (int)InvoiceDocumantType.SATIS; // (int)uyumInvoice.InvoiceDocumantType;
        //    sales.CustomerSeqID = -1;
        //    sales.IntegratorsSeqID = (int)IntegrationTypes.UyumSoft;//(int)uyumInvoice.IntegrationModel.Integration;
        //    sales.ApplicationSeqID = 1;//Şimdilik
        //    sales.DocumentNumber = "0";//uyumInvoice.DocumentNo;
        //    sales.SalesID = "0";
        //    sales.SalesTypeID = (short)DocumentTypeTypes.İrsaliye;// (short)uyumInvoice.InvoiceStatus;
        //    sales.SalesOpenDateTime = DateTime.Now;//uyumInvoice.StartPeriodDate;
        //    sales.SalesCloseDateTime = DateTime.Now;// uyumInvoice.EndPeriodDate;
        //    sales.SalesOpenPersonel = new Guid("00000000-0000-0000-0000-000000000000");
        //    sales.SalesClosePersonel = new Guid("00000000-0000-0000-0000-000000000000");
        //    sales.SalesTotal = pricePlane.Price;//uyumInvoice.TotalAmount;
        //    sales.VatRate = tax.TaxPercentage;
        //    if (tax.IsIncludedTax)
        //        sales.SalesVatTotal = pricePlane.Price * sales.VatRate / (100 + sales.VatRate);
        //    else
        //        sales.SalesVatTotal = pricePlane.Price * sales.VatRate / 100;
        //    //sales.SalesVatTotal = uyumInvoice.TotalVATAmount;
        //    if (tax.IsIncludedTax)
        //        sales.SalesTotalWithoutVAT = pricePlane.Price - sales.SalesVatTotal;
        //    else
        //        sales.SalesTotalWithoutVAT = pricePlane.Price;
        //    // uyumInvoice.WithholdingTaxTotal.ToString();
        //    sales.CustomerVKN = "11111111111"; //uyumInvoice.RecipientVKN;
        //    sales.CustomerTCKN = "11111111111";//uyumInvoice.RecipientVKN;

        //    string uName = "Belirtilmemiş";
        //    string uSurname = "Belirtilmemiş";

        //    try
        //    {
        //        if (UserProfile != null)
        //        {
        //            if (UserProfile.Name != null && UserProfile.Name != "")
        //            {
        //                uName = UserProfile.Name;
        //            }
        //        }
        //    }
        //    catch { }
        //    try
        //    {
        //        if (user != null)
        //        {
        //            if (user.Name != null && user.Name != "")
        //            {
        //                uName = user.Name;
        //            }
        //        }
        //    }
        //    catch { }


        //    try
        //    {
        //        if (UserProfile != null)
        //        {
        //            if (UserProfile.Surname != null && UserProfile.Surname != "")
        //            {
        //                uSurname = UserProfile.Surname;
        //            }
        //        }
        //    }
        //    catch { }
        //    try
        //    {
        //        if (user != null)
        //        {
        //            if (user.SurName != null && user.SurName != "")
        //            {
        //                uSurname = user.SurName;
        //            }
        //        }
        //    }
        //    catch { }

        //    sales.CustomerName = uName;
        //    sales.CustomerSurname = uSurname;
        //    try { sales.CustomerEmail = user.Email; } catch { }
        //    sales.CreatedDateTime = DateTime.Now;//uyumInvoice.DocumentDate;
        //    sales.DiscountTotal = 0; //Şimdilik
        //    sales.SalesTerminalID = "0";
        //    sales.SalesRevenueCenterID = "0";
        //    sales.SalesBranchID = branch.BranchSeqID.ToString();
        //    sales.FiscalReceiptNumber = "0";
        //    sales.FicalDeviceSerialNumber = "0";
        //    sales.FiscalEKUNumber = 0;
        //    sales.FiscalZNumber = 0;
        //    sales.IsTransfer = false;//gönderildiğinde değişecek
        //    sales.TransferStatus = 0;// 0 gönder, 1 gönderme vs. konuşulacak.
        //    sales.Status = -1; //-1 aktarıldı fakat durumu kontrol edilmedi.
        //    sales.CreatedBy = new Guid("00000000-0000-0000-0000-000000000000");
        //    sales.CurrencyCode = curency.CurrencyName;//uyumInvoice.CurrencyType;
        //    sales.Description = sales.CustomerName + " " + sales.CustomerSurname + " " + memberShipTypes.Name + " Hediye Copuan Ödemesi."; //uyumInvoice.Not;
        //    sales.SpecialCode1 = "";
        //    sales.SpecialCode2 = "";
        //    sales = AddSale(sales);
        //    List<SalesItems> items = SaveSaleItem(sales, memberShipTypes);
        //    SendUyumSoft(sales, items);
        //}

        public static Sales AddSale(Sales sale)
        {
            using var contex = new ProjeDBContext();
            contex.Set<Sales>().Add(sale);
            contex.SaveChanges();   
            sale.DocumentNumber = contex.Set<Sales>().Max(x => x.SalesSeqID).ToString();
            contex.Set<Sales>().Update(sale);
            contex.SaveChanges();
            return sale;
        }
        public static List<SalesItems> SaveSaleItem(Sales sales, MemberShipType memberShipType)
        {
            using var contex = new ProjeDBContext();
            List<SalesItems> list = new List<SalesItems>();
            SalesItemsRepository salesItemsRepository = new SalesItemsRepository(contex);
            SalesItems salesItems = new SalesItems();
            salesItems.SalesSeqID = sales.SalesSeqID;
            salesItems.SalesItemLineNumber = 1;
            salesItems.SalesItemName = memberShipType.Name;
            salesItems.SalesItemPrice = sales.SalesTotal;
            salesItems.SalesItemVateRate = sales.VatRate;
            salesItems.SalesItemCount = 1;
            salesItems.SalesItemUnitType = "Adet";
            salesItems.SalesItemCancelTypeID = 0; //şimdilik
            salesItems.SalesItemTypeID = 1; // şimdilik. konuşulacak.
            salesItems.SalesItemStatus = 1; //şimdilik. konuşulacak.
            salesItems.SalesItemSalePersonel = new Guid("00000000-0000-0000-0000-000000000000");
            salesItems.SalesItemRelatedSalesItemNumber = "0";
            salesItems.TransferStatus = 0;//gönderildiğinde değişecek
            salesItems.CreatedDateTime = sales.CreatedDateTime;
            salesItems.CreatedBy = new Guid("00000000-0000-0000-0000-000000000000");
            salesItems.DiscountRate = 0;
            salesItems.StockCode = "0";
            salesItemsRepository.AddSalesItems(salesItems);
            list.Add(salesItems);
            return list;
        }
        public static string GetProductName(int id)
        {
            using var contex = new ProjeDBContext();

            var products = contex.Set<Products>().Where(x => x.ProductID.Equals(id)).FirstOrDefault().ProductName;

            return products;
        }

        public static string StripHTML(string input)
        {
            input = Regex.Replace(input, "<.*?>", String.Empty);
            input = Regex.Replace(input, "&nbsp;", String.Empty);
            return input;
        }
        //public static void SubscribePaymentControl(string subscriptionReferenceCode)
        //{
        //    using var contex = new ProjeDBContext();
        //    var orderResponse = IyzipayEntegration.SubscriptionReturnOrder(subscriptionReferenceCode);

        //    if (orderResponse.Status != null)
        //    {

        //        if (orderResponse.Status.ToString() == Status.SUCCESS.ToString())
        //        {


        //            if (orderResponse.Data.SubscriptionStatus == SubscriptionStatus.ACTIVE.ToString())
        //            {

        //                for (int i = 0; i < orderResponse.Data.SubscriptionOrders.Count; i++)
        //                {


        //                    var pay = contex.Set<Payments>().Where(w => w.OrderReferenceCode == orderResponse.Data.SubscriptionOrders[i].ReferenceCode).FirstOrDefault();

        //                    if (pay == null)
        //                    {
        //                        Payments payments = new Payments();

        //                        var princPlane = contex.Set<MembershipTypePricePlane>().ToList()
        //                            .Join(contex.Set<MemberShipPaymentPlanWithPaymentChannel>().ToList(), mpp => mpp.MemberShipTypePricePlaneSeqID,
        //                            mpc => mpc.MemberShipTypePricePlaneSeqID
        //                            , (MembershipTypePricePlane, memberShipPaymentPlanWithPaymentChannel) => new
        //                            {
        //                                MembershipTypePricePlane = MembershipTypePricePlane,
        //                                MemberShipPaymentPlanWithPaymentChannel = memberShipPaymentPlanWithPaymentChannel
        //                            }).Where(w => w.MemberShipPaymentPlanWithPaymentChannel.ReferenceCode == orderResponse.Data.PricingPlanReferenceCode)
        //                            .FirstOrDefault();

        //                        var
        //                            meberShipWithCustomer = contex.Set<MemberShipTypeWithCustomersPaymentChanel>().Where(w => w.ReferenceCode == orderResponse.Data.ReferenceCode).FirstOrDefault();



        //                        payments.CustomerReferenceCode = orderResponse.Data.CustomerReferenceCode;
        //                        payments.OrderReferenceCode = orderResponse.Data.SubscriptionOrders[i].ReferenceCode;
        //                        payments.PaymentAmount = Convert.ToDecimal(orderResponse.Data.SubscriptionOrders[i].Price.Replace('.', ','));
        //                        payments.PaymentChannelSeqID = 1;
        //                        payments.PaymentChannelReferenceCode = orderResponse.Data.PricingPlanReferenceCode;

        //                        if (orderResponse.Data.SubscriptionOrders[i].CurrencyCode == CurrencyEnum.TRY.ToString())
        //                            payments.PaymentCurrencyTypeSeqID = (int)CurrencyEnum.TRY;
        //                        else if (orderResponse.Data.SubscriptionOrders[i].CurrencyCode == CurrencyEnum.EUR.ToString())
        //                            payments.PaymentCurrencyTypeSeqID = (int)CurrencyEnum.EUR;
        //                        else if (orderResponse.Data.SubscriptionOrders[i].CurrencyCode == CurrencyEnum.USD.ToString())
        //                            payments.PaymentCurrencyTypeSeqID = (int)CurrencyEnum.USD;
        //                        else
        //                            payments.PaymentCurrencyTypeSeqID = 0;
        //                        try { payments.MemberShipTypePricePlaneSeqID = princPlane.MembershipTypePricePlane.MemberShipTypePricePlaneSeqID; }
        //                        catch { payments.MemberShipTypePricePlaneSeqID = 0; }
        //                        try { payments.MemberShipTypeWithCustomerSeqID = meberShipWithCustomer.MemberShipTypeWithCustomerSeqID; }
        //                        catch { payments.MemberShipTypeWithCustomerSeqID = 0; }
        //                        payments.EventTime = 0;

        //                        if (orderResponse.Data.SubscriptionOrders[i].OrderStatus == "SUCCESS")
        //                            payments.Status = 1;
        //                        else
        //                            payments.Status = 2;
        //                        payments.Remark = "";
        //                        payments.ReturnMessage = "";
        //                        payments.PeriodNumber = 0;
        //                        payments.Type = 0;
        //                        payments.CreatedDate = DateTime.Now;
        //                        contex.Set<Payments>().Add(payments);

        //                        var mwcustomer = contex.Set<MemberShipTypeWithCustomer>().Where(w => w.MemberShipTypeWithCustomerSeqID == meberShipWithCustomer.MemberShipTypeWithCustomerSeqID).FirstOrDefault();

        //                        if (orderResponse.Data.SubscriptionOrders[i].OrderStatus == "SUCCESS")
        //                        {
        //                            SendInvoice(mwcustomer, princPlane.MembershipTypePricePlane);
        //                            Thread t = new Thread(new ThreadStart(ThreadInvoceControl));
        //                            t.Start();
        //                        }
        //                    }
        //                    else
        //                    {
        //                        short? st = 0;
        //                        if (orderResponse.Data.SubscriptionOrders[i].OrderStatus == "SUCCESS")
        //                            st = 1;
        //                        else
        //                            st = 2;
        //                        if (pay.Status != st)
        //                        {
        //                            pay.UpdateDate = DateTime.Now;
        //                            pay.Status = st;
        //                            contex.Set<Payments>().Update(pay);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
        //public static void GiftPayment(Payment payment,string UserId,int pricePlaneSeqId)
        //{
        //    using var contex = new ProjeDBContext();
            
        //    Payments payments = new Payments();

        //    payments.CustomerReferenceCode = payment.PaymentId;
        //    payments.OrderReferenceCode = payment.ConversationId;
        //    payments.PaymentAmount = Convert.ToDecimal(payment.PaidPrice.Replace('.', ','));
        //    payments.PaymentChannelSeqID = 1;
        //    payments.PaymentChannelReferenceCode = payment.HostReference;

        //    if (payment.Currency == CurrencyEnum.TRY.ToString())
        //        payments.PaymentCurrencyTypeSeqID = (int)CurrencyEnum.TRY;
        //    else if (payment.Currency == CurrencyEnum.EUR.ToString())
        //        payments.PaymentCurrencyTypeSeqID = (int)CurrencyEnum.EUR;
        //    else if (payment.Currency == CurrencyEnum.USD.ToString())
        //        payments.PaymentCurrencyTypeSeqID = (int)CurrencyEnum.USD;
        //    else
        //        payments.PaymentCurrencyTypeSeqID = 0;
        //    try { payments.MemberShipTypePricePlaneSeqID = pricePlaneSeqId; }
        //    catch { payments.MemberShipTypePricePlaneSeqID = 0; }
        //    try { payments.MemberShipTypeWithCustomerSeqID = 0; }
        //    catch { payments.MemberShipTypeWithCustomerSeqID = 0; }
        //    payments.EventTime = 0;
        //    payments.Status = 2;
        //    payments.Remark = "";
        //    payments.ReturnMessage = "";
        //    payments.PeriodNumber = 0;
        //    payments.Type = 0;
        //    payments.CreatedDate = DateTime.Now;
        //    contex.Set<Payments>().Add(payments);
        //    contex.SaveChanges();
        //    var memberShipPricePlan = contex.MembershipTypePricePlane.Where(x => x.MemberShipTypePricePlaneSeqID == pricePlaneSeqId).FirstOrDefault();
        //        SendInvoiceforPayment(UserId, memberShipPricePlan);
        //        Thread t = new Thread(new ThreadStart(ThreadInvoceControl));
        //        t.Start();
            

        //}


        //public static void ThreadInvoceControl()
        //{
        //    using var contex = new ProjeDBContext();

        //    var sales = contex.Set<Sales>().Where(w => w.Status != (int)InvoiceStatus.SentToGib).ToList();
        //    GetInvoiceStatusRequestModel requestModel = new GetInvoiceStatusRequestModel();
        //    requestModel.IntegrationModel = GetIntegrationByIntegrationId(IntegrationTypes.UyumSoft);
        //    requestModel.invoiceIds = new List<string>();
        //    for (int i = 0; i < sales.Count; i++)
        //    {
        //        requestModel.invoiceIds.Add(sales[i].SalesID);
        //    }
        //    GetInvoiceStatusResponseModel result = InvoiceFunctions.GetInvoiceStatus(requestModel);
        //    for (int i = 0; i < result.items.Count; i++)
        //    {
        //        UpdateSaleSendStatus(result.items[i].invoiceIds, true, 1, (short)result.items[i].status);
        //    }

        //}
        public static void UpdateSaleSendStatus(long SalesSeqID, string SalesID, bool status, short TransferStatus, short statusType)
        {
            UpdateSendStatus(SalesSeqID, SalesID, status, TransferStatus, statusType);
            UpdateSendStatus(SalesSeqID, TransferStatus);
        }
        public static void UpdateSendStatus(long SalesSeqID, short statusType)
        {
            using var contex = new ProjeDBContext();

            try
            {
                var result = contex.Set<SalesItems>().Where(w => w.SalesSeqID == SalesSeqID).ToList();
                foreach (var saleItem in result)
                {
                    saleItem.TransferStatus = statusType;
                    contex.Set<SalesItems>().Update(saleItem);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void UpdateSendStatus(long SalesSeqID, string SalesID, bool status, short TransferStatus, short statusType)
        {
            using var contex = new ProjeDBContext();
            var sale = contex.Set<Sales>().Where(w => w.SalesSeqID == SalesSeqID).FirstOrDefault();
            sale.SalesID = SalesID;
            sale.IsTransfer = status;
            sale.TransferStatus = TransferStatus;
            sale.Status = statusType;
            contex.Set<Sales>().Update(sale);
        }

        public static void UpdateSendStatus(string SalesID, bool status, short TransferStatus, short statusType)
        {
            using var contex = new ProjeDBContext();

            var sale = contex.Set<Sales>().Where(w => w.SalesID == SalesID).FirstOrDefault();
            sale.IsTransfer = status;
            sale.TransferStatus = TransferStatus;
            sale.Status = statusType;
            contex.Set<Sales>().Update(sale);
        }

        public static void UpdateSaleSendStatus(string SalesID, bool status, short TransferStatus, short statusType)
        {
            using var contex = new ProjeDBContext();
            UpdateSendStatus(SalesID, status, TransferStatus, statusType);
        }

        public static int ConvertStringToInt(string value)
        {
            int result = 0;
            try { result = Convert.ToInt32(0); } catch { }
            return result;
        }

    }
}
