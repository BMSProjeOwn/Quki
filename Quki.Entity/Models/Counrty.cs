using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class Counrty:EntityBase
	{
		[Key]
		public int CounrtySeqID { get; set; }
		public int? RegionSeqID { get; set; }
		public int? LanguageID { get; set; }
		[MaxLength(50)]
		public string CountryCode { get; set; }
		[MaxLength(150)]
		public string CountryName { get; set; }
		[MaxLength(250)]
		public string ImagePath { get; set; }

		[MaxLength(250)]
		public string ImageThumpPath { get; set; }
		[MaxLength(250)]
		public string FlagImage { get; set; }

		public bool Status { get; set; }

		public DateTime? UpdatedOn { get; set; }
		[MaxLength(450)]
		public string UpdatedBy { get; set; }
		public DateTime? CreatedOn { get; set; }
		[MaxLength(450)]
		public string CreatedBy { get; set; }
	}
}
