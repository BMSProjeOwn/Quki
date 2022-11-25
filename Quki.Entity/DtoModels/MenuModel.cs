using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class MenuModel:DtoBase
    {
        [Key]
        public int MenuSeqID { get; set; }
        public int MenuID { get; set; }
        public int ParentMenuID { get; set; }
        public int ContentTypeID { get; set; }
        public int LanguageID { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string URL { get; set; }
        public int? PositionID { get; set; }
        public Int16? DisplayOrderNumber { get; set; }
        [MaxLength(500)]
        public string ImagePath { get; set; }
        [MaxLength(500)]
        public string AdminURL { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        [MaxLength(150)]
        public string action { get; set; }
        [MaxLength(150)]
        public string controller { get; set; }

        public string Body { get; set; }


        public bool Status { get; set; }


    }
}
