﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class RatingTypes
    {
        [Key]



        public int RatingTypeSeqID { get; set; }
        public int RatingTypeID { get; set; }
  

        [MaxLength(150)]
        public string RatingTypeName { get; set; }
		[MaxLength(250)]
		public string Remark { get; set; }
		public int? LanguageID { get; set; }
		[MaxLength(500)]
		public string ImagePath { get; set; }
		[MaxLength(500)]
		public string ImageThumpPath { get; set; }
		public int? GroupID { get; set; }
		public bool IsActive { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [MaxLength(450)]
        public string UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        [MaxLength(450)]
        public string CreatedBy { get; set; }
        public Int16 DisplayOrderNumber { get; set; }




    }
}