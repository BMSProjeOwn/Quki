using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;
using Quki.Entity.Models;

namespace Quki.Entity.DtoModels
{
    public class TDepartModel:DtoBase
    {
   
            [Key]
            public int DepartmanSeqID { get; set; }
            public int? DepartmanID { get; set; }
            public int? LanguageID { get; set; }
            [MaxLength(100)]
            public string Name { get; set; }
            [MaxLength(500)]
            public string Description { get; set; }
            public Int16? DisplayOrderNumber { get; set; }
            [MaxLength(500)]
            public string ImagePath { get; set; }
            public bool Status { get; set; }
        
            public DateTime? UpdatedOn { get; set; }
            public Guid? UpdatedBy { get; set; }
            public DateTime? CreatedOn { get; set; }
            public Guid? CreatedBy { get; set; }
            public List<Category> Categories { get; set; }
        

    }
}
