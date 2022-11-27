using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;
using Quki.Entity.Models;

namespace Quki.Entity.DtoModels
{
    public class ProtoectInformationModel:DtoBase
	{
		[Key]
		public int ProtectionInformationSeqID { get; set; }
		[MaxLength(250)]
		public string ProtectionInformationHeaderLine { get; set; }
		[MaxLength(150)]
		public string ProtectInformationCode { get; set; }
		[MaxLength(150)]
		public string ProtectInformationValue { get; set; }
		public string Remark { get; set; }
		public string Remark2 { get; set; }
		public Int16? TypeID { get; set; }
		public Int16? TypeGorupID { get; set; }
		public bool IsShowScreen { get; set; }
		public bool IsActive { get; set; }
		public int LanguageID { get; set; }
		public string ImageThumpPath { get; set; }
		public Int16? DisplayOrderNumber { get; set; }

		public DateTime? UpdatedOn { get; set; }
		[MaxLength(450)]
		public string UpdatedBy { get; set; }
		public DateTime? CreatedOn { get; set; }
		[MaxLength(450)]
		public string CreatedBy { get; set; }
		public List<UserProtoectInformationModel> UserProtoectInformation { get; set; }
		public bool IsForcedly { get; set; }
	}
}
