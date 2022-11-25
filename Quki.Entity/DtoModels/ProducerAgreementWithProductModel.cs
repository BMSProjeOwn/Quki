using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class ProducerAgreementWithProductModel:DtoBase
    {
        
        public long ProducerAgreementWithProductSeqID { get; set; }

        public long? ProducerAgreementSeqID { get; set; }

        public long? ProductSeqID { get; set; }

        public decimal? MinimumValue { get; set; }

        public decimal? MaximumValue { get; set; }

        public decimal? Value { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? InActivatedDateTime { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
