using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class DeviceTypeModel: DtoBase
    {
        [Key]
        public short DeviceTypeSeqID { get; set; }

        public short? DeviceTypeID { get; set; }

        public string DeviceTypeName { get; set; }

        public int? DeviceStatus { get; set; }

        public short? LanguageID { get; set; }

        public string OSsytem { get; set; }

        public bool? IsActive { get; set; }

        public string LastVersion { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public Guid? CreatedBy { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdateDateTime { get; set; }
    }
}
