using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class ProducerType : EntityBase
    {
		[Key]
		public int ProducerTypeSeqID { get; set; }
		public int? ProducerTypeID { get; set; }
		[MaxLength(150)]
		public string Name { get; set; }
		[MaxLength(150)]
		public string SecondName { get; set; }
		public bool ISActive { get; set; }
		public int? LanguageID { get; set; }
		[MaxLength(1000)]
		public string ImageThumpPath { get; set; }
		[MaxLength(1000)]
		public string ImagePath { get; set; }
		public int? GroupID { get; set; }


		public DateTime? UpdatedOn { get; set; }
		[MaxLength(450)]
		public string UpdatedBy { get; set; }
		public DateTime? CreatedOn { get; set; }
		[MaxLength(450)]
		public string CreatedBy { get; set; }
		public int? DisplayOrderNumber { get; set; }

	}
}
