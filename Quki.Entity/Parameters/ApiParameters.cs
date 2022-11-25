using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Parameters
{
    public class ApiParameters
    {
        public static string URL = "https://www.Quki.com";//"http://www.bmsyazilim.com/Quki";
    }

    public class ApiMainPageGroupID
    {
        public static int TheNewests = 1;
        public static int TopRateProducts = 2;
        public static int KeepListening = 3;
        public static int PopularAudioTheaterProducts = 4;
        public static int ByAgeRrangeProducts = 5;
        public static int Producers = 6;
    }

    public class ApiFavoriListType
    {
        public static int? Favorite = 1;
        public static int? Library = 2;
    }

    public class ApiProductMediaType
    {
        public static int? Resim = 1;
        public static int? Muzik = 2;
        public static int? Tiyatro = 3;
        public static int? OnDinleme = 4;
        public static int? Orjinal = 5;
    }

    public class ApiProductMediaGroupType
    {
        public static int? Kisa = 4;
        public static int? Tamami = 5;
    }


    public class ApiProductOrderIDs
    {
        public static int allAudioTheaters = 1;
        public static int productOrderAZ = 2;
        public static int productOrderZA = 3;
        public static int productOrderPoint = 4;
        public static int productOrderLastCreate = 5;
    }

    public class AppParameters
    {
        public static int SetProfileActiveSecondTime = 30;
    }
}
