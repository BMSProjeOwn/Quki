﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels
{
    public class AddAgreementModel
    {
        public long? ProducerAgreementSeqID { get; set; }

        public long ProducerSeqID { get; set; }

        public string AgreementName { get; set; }

        public DateTime? AgreementStartDateTime { get; set; }

        public DateTime? AgreementEndDateTime { get; set; }

        public bool IsActive { get; set; }

        public decimal? AgreementRate { get; set; }

        public decimal? AgreementFee { get; set; }

        public short? CurrencyID { get; set; }

        public short? AgreementStatus { get; set; }

        public short? AgreementTypeID { get; set; }

        public string AgreementRemark { get; set; }

        public decimal? MinimumValue { get; set; }

        public decimal? MaximumValeu { get; set; }

        public int? LanguageID { get; set; }

        public string LanguageName { get; set; }

        public DateTime? InActivatedDateTime { get; set; }

        public bool? AutoRenew { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string BeneficiaryName { get; set; }
    }
}
