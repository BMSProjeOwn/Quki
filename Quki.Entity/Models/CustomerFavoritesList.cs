using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class CustomerFavoritesList:EntityBase
    {
        [Key]
        public int CustomerFavoritesListSeqID { get; set; }
        [MaxLength(450)]
        public string customer_def_no { get; set; }
    
        public int? FavoritesListDefSeqID { get; set; }
        public int? GroupID { get; set; }
        public int? RelatedFavoritesListSeqID { get; set; }
        public int? FavoritesListValue { get; set; }
        public int? DisplayOrderNumber { get; set; }
        [MaxLength(250)]
        public string Remark { get; set; }
        [MaxLength(250)]
        public string IPBlock { get; set; }
        [MaxLength(250)]
        public string PagePath { get; set; }


        public bool IsActive { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [MaxLength(450)]
        public string UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        [MaxLength(450)]
        public string CreatedBy { get; set; }
    }
}
