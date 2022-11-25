using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class FrequentlyAskedQuestions: EntityBase
    {
        [Key]
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
        public bool IsActive { get; set; }

        public short DisplayOrderNumber { get; set; }

        public string ImagePath { get; set; }

        public string Value { get; set; }

        public bool IsDynamicOption { get; set; }

        public short? ValueTypeID { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
