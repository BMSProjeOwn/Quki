using System;
using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.Parameters;

namespace Quki.Common
{
    public class IyzipayEntegration
    {

        //#region ProductProcces
        //public static bool CreateProduct(string Name, string Description, out string referansCode)
        //{
        //    referansCode = "";
        //    bool retunValue = false;

        //    CreateProductRequest request = new CreateProductRequest
        //    {
        //        Description = Description,
        //        Locale = Parameters.IzicooLanguegeCulture,
        //        Name = Name,
        //        ConversationId = "123456789"
        //    };

        //    ResponseData<ProductResource> response = Product.Create(request, Parameters.IzicooOptions);
        //    if (Status.SUCCESS.ToString() == response.Status)
        //    {
        //        referansCode = response.Data.ReferenceCode;
        //        retunValue = true;
        //    }
        //    return retunValue;
        //}

        //public static bool DeleteProduct(string productReferenceCode)
        //{
        //    bool retunValue = false;
        //    DeleteProductRequest updateProductRequest = new DeleteProductRequest
        //    {
        //        Locale = Parameters.IzicooLanguegeCulture,
        //        ConversationId = "123456789",
        //        ProductReferenceCode = productReferenceCode
        //    };
        //    IyzipayResourceV2 response = Product.Delete(updateProductRequest, Parameters.IzicooOptions);
        //    if (Status.SUCCESS.ToString() == response.Status)
        //    {
        //        retunValue = true;
        //    }
        //    return retunValue;
        //}
        //public static bool UpdateProduct(string Name, string Description, string productReferenceCode)
        //{
        //    bool retunValue = false;
        //    UpdateProductRequest updateProductRequest = new UpdateProductRequest
        //    {
        //        Description = Description,
        //        Locale = Parameters.IzicooLanguegeCulture,
        //        Name = Name,
        //        ConversationId = "123456789",
        //        ProductReferenceCode = productReferenceCode
        //    };
        //    ResponseData<ProductResource> response = Product.Update(updateProductRequest, Parameters.IzicooOptions);
        //    if (Status.SUCCESS.ToString() == response.Status)
        //    {
        //        retunValue = true;
        //    }
        //    return retunValue;
        //}
        //#endregion
        //#region ProductPlanProcces
        //public static bool CreateProductPlan(MembershipTypePricePlaneModel model, string productReferenceCode, string Period, out string refCode)
        //{
        //    string paymentInterval = PaymentInterval.MONTHLY.ToString();
        //    if (model.PaymentPeriod == 1)
        //        paymentInterval = PaymentInterval.MONTHLY.ToString();
        //    if (model.PaymentPeriod == 2)
        //        paymentInterval = PaymentInterval.WEEKLY.ToString();
        //    if (model.PaymentPeriod == 3)
        //        paymentInterval = "YEARLY";

        //    string curency = Iyzipay.Model.Currency.TRY.ToString();
        //    if (model.CurrencyID == 1)
        //        curency = Iyzipay.Model.Currency.TRY.ToString();
        //    if (model.CurrencyID == 2)
        //        curency = Iyzipay.Model.Currency.EUR.ToString();
        //    if (model.CurrencyID == 3)
        //        curency = Iyzipay.Model.Currency.USD.ToString();

        //    refCode = "";
        //    bool retunValue = false;
        //    CreatePlanRequest request = new CreatePlanRequest()
        //    {
        //        Locale = Parameters.IzicooLanguegeCulture,
        //        Name = model.PlaneName + " uniqueid:" + Guid.NewGuid(),
        //        ConversationId = "123456789",
        //        TrialPeriodDays = model.TrailPeriodDay,
        //        //Price = "5.23",
        //        Price = model.Price.ToString().Replace(',', '.'),

        //        CurrencyCode = curency,

        //        PaymentInterval = paymentInterval,// daha db den cekilecek Şimdilik tanımın karşılığı yok
        //        //PaymentInterval = Period,
        //        RecurrenceCount = model.AutoRenewalCount,// daha db den cekilecek Şimdilik tanımın karşılığı yok
        //        PaymentIntervalCount = 1,// daha db den cekilecek Şimdilik tanımın karşılığı yok
        //        PlanPaymentType = PlanPaymentType.RECURRING.ToString(),
        //        ProductReferenceCode = productReferenceCode
        //    };
            

        //    ResponseData<PlanResource> response = Plan.Create(request, Parameters.IzicooOptions);
        //    if (Status.SUCCESS.ToString() == response.Status)
        //    {
        //        refCode = response.Data.ReferenceCode;
        //        retunValue = true;
        //    }

        //    return retunValue;
        //}
        //public static bool DeleteProductPlan(string pricingPlanReferenceCode)
        //{

        //    bool retunValue = false;
        //    DeletePlanRequest request = new DeletePlanRequest
        //    {
        //        Locale = Parameters.IzicooLanguegeCulture,
        //        ConversationId = "123456789",
        //        PricingPlanReferenceCode = pricingPlanReferenceCode
        //    };

        //    IyzipayResourceV2 response = Plan.Delete(request, Parameters.IzicooOptions);

        //    if (Status.SUCCESS.ToString() == response.Status)
        //    {
        //        retunValue = true;
        //    }
        //    return retunValue;
        //}
        //#endregion
        //#region Abonelik işlemleri
        //public static bool IsSubscription(string SubscriptionReferenceCode)// abonelik Durumunu Şorgulamak için
        //{
        //    bool reult = false;

        //    RetrieveSubscriptionRequest request = new RetrieveSubscriptionRequest
        //    {
        //        Locale = Parameters.IzicooLanguegeCulture,
        //        ConversationId = "123456789",
        //        SubscriptionReferenceCode = SubscriptionReferenceCode
        //    };

        //    ResponseData<SubscriptionResource> response = Subscription.Retrieve(request, Parameters.IzicooOptions);
        //    if (response.Status.ToString() == Status.SUCCESS.ToString())
        //        if (response.Data.SubscriptionStatus == SubscriptionStatus.ACTIVE.ToString())
        //            reult = true;

        //    return reult;
        //}
        //public static List<SubscriptionOrder> SubscriptionInformation(string SubscriptionReferenceCode, string pricingPlanReferenceCode)// abone işlemlerini şorgulamak için
        //{
        //    //Test için Daha Sonradan kaldırılacak

        //    // SubscriptionReferenceCode = SubscriptionReferenceCode;
        //    // pricingPlanReferenceCode = pricingPlanReferenceCode;



        //    SearchSubscriptionRequest request = new SearchSubscriptionRequest
        //    {
        //        Locale = Parameters.IzicooLanguegeCulture,
        //        ConversationId = "123456789",
        //        SubscriptionReferenceCode = SubscriptionReferenceCode,
        //        Page = 1,
        //        Count = 20,
        //        SubscriptionStatus = SubscriptionStatus.ACTIVE.ToString(),
        //        PricingPlanReferenceCode = pricingPlanReferenceCode
        //    };

        //    ResponsePagingData<SubscriptionResource> response = Subscription.Search(request, Parameters.IzicooOptions);
        //    List<SubscriptionOrder> SubscriptionOrders = new List<SubscriptionOrder>();
        //    if (response.Status.ToString() == Status.SUCCESS.ToString())
        //    {
        //        foreach (var item in response.Data.Items)
        //        {
        //            foreach (var item2 in item.SubscriptionOrders)
        //            {
        //                SubscriptionOrders.Add(item2);
        //            }
        //        }

        //    }
        //    return SubscriptionOrders;

        //} // abone likleri 

        //public static bool CreateSubscription(SubscriptionInitializeModel subscriptionInitializeModel, out string ReferenceCode, out string ErrorMessage)
        //{
        //    ReferenceCode = "";
        //    ErrorMessage = "";
        //    bool returnValue = false;
        //    SubscriptionInitializeRequest request = new SubscriptionInitializeRequest
        //    {
        //        Locale = Parameters.IzicooLanguegeCulture,
        //        Customer = new CheckoutFormCustomer
        //        {
        //            Email = subscriptionInitializeModel.Customer.Email,
        //            Name = subscriptionInitializeModel.Customer.Name,
        //            Surname = subscriptionInitializeModel.Customer.Surname,
        //            BillingAddress = new Address
        //            {
        //                City = subscriptionInitializeModel.Customer.BillingAddress.City,
        //                Country = subscriptionInitializeModel.Customer.BillingAddress.Country,
        //                Description = subscriptionInitializeModel.Customer.BillingAddress.Description,
        //                ContactName = subscriptionInitializeModel.Customer.Name,
        //                ZipCode = subscriptionInitializeModel.Customer.BillingAddress.ZipCode,
        //            },
        //            ShippingAddress = new Address
        //            {
        //                City = subscriptionInitializeModel.Customer.BillingAddress.City,
        //                Country = subscriptionInitializeModel.Customer.BillingAddress.Country,
        //                Description = subscriptionInitializeModel.Customer.BillingAddress.Description,
        //                ContactName = subscriptionInitializeModel.Customer.Name,
        //                ZipCode = subscriptionInitializeModel.Customer.BillingAddress.ZipCode,
        //            },

        //            GsmNumber = subscriptionInitializeModel.Customer.GsmNumber,
        //            IdentityNumber = subscriptionInitializeModel.Customer.IdentityNumber,
        //        },
        //        PaymentCard = new CardInfo
        //        {
        //            CardNumber = subscriptionInitializeModel.PaymentCard.CardNumber1,
        //            CardHolderName = subscriptionInitializeModel.PaymentCard.CardHolderName,
        //            ExpireMonth = subscriptionInitializeModel.PaymentCard.ExpireMonth.ToString(),
        //            ExpireYear = subscriptionInitializeModel.PaymentCard.ExpireYear.ToString(),
        //            Cvc = subscriptionInitializeModel.PaymentCard.Cvc.ToString(),
        //            RegisterConsumerCard = true
        //        },
        //        ConversationId = "123456789",
        //        PricingPlanReferenceCode = subscriptionInitializeModel.PricingPlanReferenceCode
        //    };

        //    ResponseData<SubscriptionCreatedResource> response = Subscription.Initialize(request, Parameters.IzicooOptions);
        //    if (Status.SUCCESS.ToString() == response.Status)
        //    {
        //        ReferenceCode = response.Data.ReferenceCode;

        //        returnValue = true;
        //    }
        //    else
        //        ErrorMessage = response.ErrorMessage.ToString();
        //    return returnValue;

        //    //Assert.AreEqual(Status.SUCCESS.ToString(), response.Status);
        //    //Assert.IsNotNull(response.SystemTime);
        //    //Assert.Null(response.ErrorMessage);
        //    //Assert.NotNull(response.Data.ReferenceCode);
        //    //Assert.NotNull(response.Data.ParentReferenceCode);
        //    //Assert.AreEqual("pricingPlanReferenceCode", response.Data.PricingPlanReferenceCode);
        //    //Assert.AreEqual(SubscriptionStatus.ACTIVE.ToString(), response.Data.SubscriptionStatus);
        //    //Assert.AreEqual(3, response.Data.TrialDays);
        //    //Assert.NotNull(response.Data.TrialStartDate);
        //    //Assert.NotNull(response.Data.TrialEndDate);
        //    //Assert.NotNull(response.Data.StartDate);
        //} //
        //public static bool CancelSubscription(string SubscriptionReferenceCode, out string ErrorMessage)// abone işlemlerini şorgulamak için
        //{
        //    bool returnValue = false;
        //    ErrorMessage = "";
        //    CancelSubscriptionRequest request = new CancelSubscriptionRequest
        //    {
        //        Locale = Parameters.IzicooLanguegeCulture,
        //        ConversationId = "123456789",
        //        SubscriptionReferenceCode = SubscriptionReferenceCode
        //    };

        //    IyzipayResourceV2 response = Subscription.Cancel(request, Parameters.IzicooOptions);
        //    if (Status.SUCCESS.ToString() == response.Status)
        //    {
        //        returnValue = true;
        //    }
        //    else
        //        ErrorMessage = response.ErrorMessage.ToString();

        //    return returnValue;

        //    //PrintResponse(response);

        //    //Assert.AreEqual(Status.SUCCESS.ToString(), response.Status);
        //    //Assert.IsNotNull(response.SystemTime);
        //    //Assert.Null(response.ErrorMessage);

        //}
        //public static Payment CreatePay(SubscriptionInitializeModel subscriptionInitializeModel,out string ErrorMessage)
        //{
        //    ErrorMessage = "";
        //    Guid basketId = Guid.NewGuid();
        //    CreatePaymentRequest request = new CreatePaymentRequest();
        //    request.Locale = Locale.TR.ToString();
        //    request.ConversationId = "123456789";
        //    request.Price = subscriptionInitializeModel.Price.ToString().Replace(",",".");
        //    request.PaidPrice = subscriptionInitializeModel.Price.ToString().Replace(",", "."); ;
        //    request.Currency = subscriptionInitializeModel.Currncy;
        //    request.Installment = 1;
        //    request.BasketId = basketId.ToString();
        //    request.PaymentChannel = PaymentChannel.WEB.ToString();
        //    request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

        //    PaymentCard paymentCard = new PaymentCard();
        //    paymentCard.CardHolderName = subscriptionInitializeModel.PaymentCard.CardHolderName;
        //    paymentCard.CardNumber = subscriptionInitializeModel.PaymentCard.CardNumber1;
        //    paymentCard.ExpireMonth = subscriptionInitializeModel.PaymentCard.ExpireMonth.ToString();
        //    paymentCard.ExpireYear = subscriptionInitializeModel.PaymentCard.ExpireYear.ToString();
        //    paymentCard.Cvc = subscriptionInitializeModel.PaymentCard.Cvc;
        //    paymentCard.RegisterCard = 0;
        //    request.PaymentCard = paymentCard;

        //    Buyer buyer = new Buyer();
        //    buyer.Id = basketId.ToString();
        //    buyer.Name = "Quki";
        //    buyer.Surname = "Quki";
        //    buyer.GsmNumber = "+905350000000";
        //    buyer.Email = "email@email.com";
        //    buyer.IdentityNumber = "74300864791";
        //    buyer.LastLoginDate = "2015-10-05 12:43:35";
        //    buyer.RegistrationDate = "2013-04-21 15:12:09";
        //    buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
        //    buyer.Ip = "85.34.78.112";
        //    buyer.City = "Istanbul";
        //    buyer.Country = "Turkey";
        //    buyer.ZipCode = "34732";
        //    request.Buyer = buyer;

        //    Address shippingAddress = new Address();
        //    shippingAddress.ContactName = subscriptionInitializeModel.Customer.ShippingAddress.ContactName;
        //    shippingAddress.City = subscriptionInitializeModel.Customer.ShippingAddress.City;
        //    shippingAddress.Country = subscriptionInitializeModel.Customer.ShippingAddress.Country;
        //    shippingAddress.Description = subscriptionInitializeModel.Customer.ShippingAddress.Description;
        //    shippingAddress.ZipCode = subscriptionInitializeModel.Customer.ShippingAddress.ZipCode;
        //    request.ShippingAddress = shippingAddress;

        //    Address billingAddress = new Address();
        //    billingAddress.ContactName = subscriptionInitializeModel.Customer.BillingAddress.ContactName;
        //    billingAddress.City = subscriptionInitializeModel.Customer.BillingAddress.City;
        //    billingAddress.Country = subscriptionInitializeModel.Customer.BillingAddress.Country;
        //    billingAddress.Description = subscriptionInitializeModel.Customer.BillingAddress.Description;
        //    billingAddress.ZipCode = subscriptionInitializeModel.Customer.BillingAddress.ZipCode;
        //    request.BillingAddress = billingAddress;

        //    List<BasketItem> basketItems = new List<BasketItem>();
        //    BasketItem firstBasketItem = new BasketItem();
        //    firstBasketItem.Id = Guid.NewGuid().ToString();
        //    firstBasketItem.Name = subscriptionInitializeModel.PricingPlanReferenceCode;
        //    firstBasketItem.ItemType = BasketItemType.VIRTUAL.ToString();
        //    firstBasketItem.Category1 = "Booking";
        //    firstBasketItem.Price = subscriptionInitializeModel.Price.ToString().Replace(",", "."); ;
        //    basketItems.Add(firstBasketItem);
        //    request.BasketItems = basketItems;

        //    Payment payment = Payment.Create(request, Parameters.IzicooOptions);

        //    if (payment.ErrorMessage != null)
        //    {
        //        ErrorMessage = payment.ErrorMessage;
        //        return payment;
        //    }
            
        //    return payment;
        //}
        //#endregion





        //public static bool CreateProductPlanForAlternativeOfCancle(MembershipTypePricePlaneModel model, string productReferenceCode, string Period, out string refCode)// Önder Özbek
        //{

        //    string curency = "";
        //    string paymentInterval = "";
        //    if (model.CurrencyID == 1)
        //    {
        //        curency = Iyzipay.Model.Currency.TRY.ToString();
        //    }
        //    else if (model.CurrencyID == 2)
        //    {
        //        curency = Iyzipay.Model.Currency.EUR.ToString();
        //    }
        //    else if (model.CurrencyID == 3)
        //    {
        //        curency = Iyzipay.Model.Currency.USD.ToString();
        //    }
        //    else
        //    {
        //        curency = Iyzipay.Model.Currency.TRY.ToString();
        //    }

        //    if (model.PaymentPeriod == 1)
        //    {

        //        paymentInterval = PaymentInterval.MONTHLY.ToString();
        //    }
        //    else if (model.PaymentPeriod == 2)
        //    {
        //        paymentInterval = PaymentInterval.WEEKLY.ToString();
        //    }
        //    else if (model.PaymentPeriod == 3)
        //    {
        //        paymentInterval = "YEARLY";
        //    }
        //    else
        //    {
        //        paymentInterval = PaymentInterval.MONTHLY.ToString();
        //    }


        //    refCode = "";
        //    bool retunValue = false;
        //    CreatePlanRequest request = new CreatePlanRequest()
        //    {
        //        Locale = Parameters.IzicooLanguegeCulture,
        //        Name = model.PlaneName,
        //        ConversationId = "123456789",
        //        TrialPeriodDays = model.TrailPeriodDay,
        //        Price = model.Price.ToString().Replace(',', '.'),
        //        CurrencyCode = curency,
        //        PaymentInterval = paymentInterval,
        //        PaymentIntervalCount = 1,
        //        PlanPaymentType = PlanPaymentType.RECURRING.ToString(),
        //        ProductReferenceCode = productReferenceCode
        //    };

        //    ResponseData<PlanResource> response = Plan.Create(request, Parameters.IzicooOptions);
        //    if (Status.SUCCESS.ToString() == response.Status)
        //    {
        //        refCode = response.Data.ReferenceCode;
        //        retunValue = true;
        //    }

        //    return retunValue;
        //}

        //public static bool ChangeCustomerPricePlane(string SubscriptionReferenceCode, string NewPricingPlanReferenceCode, string UpgradePeriod, bool UseTrial, bool ResetRecurrenceCount, out string newCustomerReferanceCode)
        //{
        //    bool returnValues = false;
        //    newCustomerReferanceCode = "";
        //    UpgradeSubscriptionRequest request = new UpgradeSubscriptionRequest
        //    {
        //        Locale = Parameters.IzicooLanguegeCulture,
        //        ConversationId = "123456789",
        //        SubscriptionReferenceCode = SubscriptionReferenceCode,
        //        NewPricingPlanReferenceCode = NewPricingPlanReferenceCode,
        //        UpgradePeriod = "NOW",
        //        UseTrial = UseTrial,
        //        ResetRecurrenceCount = ResetRecurrenceCount
        //    };

        //    ResponseData<ProductResource> response = Subscription.Upgrade(request, Parameters.IzicooOptions);
        //    if (Status.SUCCESS.ToString() == response.Status)
        //    {
        //        newCustomerReferanceCode = response.Data.ReferenceCode;
        //        returnValues = true;
        //    }
        //    else
        //        returnValues = false;
        //    return returnValues;
        //}

        //public static ResponseData<SubscriptionResource> SubscriptionReturnOrder(string SubscriptionReferenceCode)
        //{
        //    ResponseData<SubscriptionResource> reult = new ResponseData<SubscriptionResource>();

        //    RetrieveSubscriptionRequest request = new RetrieveSubscriptionRequest
        //    {
        //        Locale = Parameters.IzicooLanguegeCulture,
        //        ConversationId = "123456789",
        //        SubscriptionReferenceCode = SubscriptionReferenceCode
        //    };

        //    ResponseData<SubscriptionResource> response = Subscription.Retrieve(request, Parameters.IzicooOptions);
        //    if (response.Status.ToString() == Status.SUCCESS.ToString())
        //        if (response.Data.SubscriptionStatus == SubscriptionStatus.ACTIVE.ToString())
        //        {
        //            reult = response;
        //        }

        //    return reult;
        //}

        //public static bool Retry(string SubscriptionOrderReferenceCode)
        //{
        //    bool reult = false;

        //    RetrySubscriptionRequest request = new RetrySubscriptionRequest
        //    {
        //        Locale = Parameters.IzicooLanguegeCulture,
        //        ConversationId = "123456789",
        //        SubscriptionOrderReferenceCode = SubscriptionOrderReferenceCode
        //    };

        //    var response = Subscription.Retry(request, Parameters.IzicooOptions);
        //    if (response.Status != null)
        //        if (response.Status.ToString() == Status.SUCCESS.ToString())
        //            reult = true;

        //    return reult;
        //}

    }
}
