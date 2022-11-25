using Microsoft.AspNetCore.Http;
using System;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class FrequentlyAskedQuestionsModel : DtoBase
    {
        public int FrequentlyAskedQuestionsSeqID { get; set; }

        public int? FrequentlyAskedQuestionsID { get; set; }

        public string FrequentlyAskedQuestionsName { get; set; }

        public string FrequentlyAskedQuestionHeader { get; set; }

        public string FrequentlyAskedQuestionsRemark { get; set; }

        public short? FrequentlyAskedQuestionsGroupID { get; set; }

        public short? FrequentlyAskedQuestionsTypeID { get; set; }

        public string FrequentlyAskedQuestionCode { get; set; }

        public int LanguageID { get; set; }

        public bool IsShowCustomer { get; set; }

        public short DisplayOrderNumber { get; set; }

        public IFormFile ImagePath { get; set; }
        public string ImagePathName { get; set; }

        public string Value { get; set; }

        public bool IsDynamicOption { get; set; }

        public bool IsActive { get; set; }

        public short? ValueTypeID { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
