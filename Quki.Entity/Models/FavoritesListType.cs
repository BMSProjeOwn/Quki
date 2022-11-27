using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class FavoritesListType
    {
        [Key]
        public int FavoritesListTypeSeqID { get; set; }
        public int? FavoritesTypeID { get; set; }
        public int? LanguageID { get; set; }
        public int? GroupID { get; set; }
        [MaxLength(250)]
        public string FavoritesTypeName { get; set; }
        [MaxLength(250)]
        public string Remark { get; set; }
        [MaxLength(250)]
        public string ImagePath { get; set; }
        [MaxLength(250)]
        public string ImageThumpPath { get; set; }
 
       public bool IsActive  {   get; set; }
        public DateTime? UpdatedOn { get; set; }
        [MaxLength(450)]
        public string UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        [MaxLength(450)]
        public string CreatedBy { get; set; }
    }
}
