using System;
using System.Collections.Generic;
using Quki.Entity.Base;
using Quki.Entity.DtoModels.ApiModels;

namespace Quki.Entity.DtoModels
{
    public class ProductWithCategoryModel :DtoBase
    {

        public int CategorySeqID { get; set; }
        public string CategoryName { get; set; }
        public string ImagePath { get; set; }
        public Int16? DisplayOrderNumber { get; set; }
        public List<ViewValueItems> Products { get; set; }
    }



}
