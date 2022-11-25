using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Quki.Entity.ViewModel;

namespace Quki.Entity.DtoModels.ApiModels
{
    public class MainMenuValues : Response
    {
        public ViewValue TheNewests { get; set; }
        public ViewValue TopRateProducts { get; set; }
        public ViewValue KeepListening { get; set; }
        public ViewValue PopularAudioTheaterProducts { get; set; }
        public ViewValue ByAgeRrangeProducts { get; set; }
        public ViewValue Producers { get; set; }
    }

    public class ViewValue
    {
        public int GroupID { get; set; }
        public string Title { get; set; }
        public string TitleImagePhat { get; set; }
        public List<ViewValueItems> Data { get; set; }
        public List<FliterListItem> FliterList { get; set; }
    }

    public class ViewValueItems
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        //public List<int> CategorySeqIDList { get; set; }
        public List<ProductDetailForMobile> ProductDetailList { get; set; }
    }

    public class FliterListItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }

}
