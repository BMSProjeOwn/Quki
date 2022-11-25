using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Parameters
{
    public static class Parameters
    {
        public static bool isHasIzicoo = true;
        //public static Options IzicooOptions = new Options
        //{
        //    ApiKey = "LYfHeVO1gHkoYkKIVgO0RRcALf2irCif",
        //    SecretKey = "OxTw7UnfJuxRnQWHC8l6Ov5wS22Qli5n",
        //    BaseUrl = "https://api.iyzipay.com"
        //    //ApiKey = "sandbox-Jz6VgzKEpmz1Pij4HzXt3058CKNqtA0E",
        //    //SecretKey = "sandbox-d4Cxflq9wWZLTtt0nEqSrsEQKnx6cOJW",
        //    //BaseUrl = "https://sandbox-api.iyzipay.com"
        //};
        //public static string IzicooLanguegeCulture = Locale.TR.ToString();

        public static string ActivationTemplate = "";
        public static int TempPageNumber = 1;
    }
    public static class PamentChannel
    {
        public static int PamentChannelIzicoo = 1;
    }
    public static class CategoryImageSize
    {
        public static int Height = 170;
        public static int Width = 160;
    }
    public static class ProductImageSize
    {
        public static int Height = 400;
        public static int Width = 400;
    }



    public static class MediaTypes
    {
        public static int Resim = 1;
        public static int Muzik = 2;
        public static int Tiyatro = 3;
        public static int PreLissen = 4;
        public static int Orjinal = 5;
    }
    public static class MediaGroup
    {
        public static int Grup1 = 1;// reşim mi video mu
        public static int Grup2 = 2;// şeçilen reşim ücretşiz mi ucretlimi
    }
    public static class ProducerImageSize
    {
        public static int Height = 700;
        public static int Width = 700;
    }
    public static class MenuContentType
    {
        public static int User = 1;
        public static int Admin = 2;
        public static int MobilAndroid = 3;
    }
    public static class SubscriptionOrderStatus
    {
        public static string SUCCESS = "BAŞARILI";
        public static string FAILED = "HATALI";
        public static string WAITING = "BEKLEMEDE";
        public static string PROCESSING = "İŞLEMDE";
        public static string SUBSCRIPTION_UPGRADED = "ABONELİK GÜNCELENDİ";
        public static string SUBSCRIPTION_CANCELED = "ABONELİK İPTAL EDİLDİ";
        public static string QUEUED = "SIRADA";
        public static string MERCHANT_SUSPENDED = "ASKIYA ALINDI";
    }
    public static class LogTerminal
    {
        public static string Web = "Web";
        public static string MobilAndroid = "MobilAndroid";
        public static string MobilIos = "MobilIos";
    }
    public static class LogType
    {
        public static int info = 1;
        public static int error = 2;
    }
    public static class MailInfo
    {
        public static string Server = "smtp.gmail.com";
        public static string Port = "587";
        public static string SenderName = "BMSPROJE";
        public static string SenderEmail = "zupos@bmsproje.com";
        public static string Password = "zuposbms2021";
    }
    public enum PaymentPeriyod
    {
        HAFTALIK = 2,
        AYLIK = 1,
        YILLIK = 3
    }
    public enum CurrencyEnum
    {
        TRY = 1,
        EUR = 2,
        USD = 3
    }
    public enum SqlServerComandType
    {
        SqlText,
        StoredProcedure
    }

    public enum MemberShipWithCuponStatus
    {
        Active=1,
        Pasif=0,
        Kullanımda=2
    }
}
