using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class PaymentChanelWithDeviceTypeModel:DtoBase
    {
        [Key]
        public int PaymentChanelWithDeviceTypeSeqID { get; set; }

        public int? PaymentChanelSeqID { get; set; }

        public int? DeviceTypeSeqID { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public Guid? CreatedBy { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdateDateTime { get; set; }
    }
}
