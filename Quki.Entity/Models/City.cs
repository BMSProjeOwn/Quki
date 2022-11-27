using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class City
	{
		[Key]
		public int CitySeqID { get; set; }
		public int? CityId { get; set; }
		public int? CountrySeqID { get; set; }
		[MaxLength(150)]
		public string CityName { get; set; }

		public int? LanguageID { get; set; }
		[MaxLength(250)]
		public string Remark { get; set; }

		public DateTime? UpdatedOn { get; set; }
		[MaxLength(450)]
		public string UpdatedBy { get; set; }
		public DateTime? CreatedOn { get; set; }
		[MaxLength(450)]
		public string CreatedBy { get; set; }

	}
}
