using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class CurrencyModel:DtoBase
    {
        [Key]
        public int CurrencySeqID { get; set; }

        public int? CurrencyID { get; set; }

        public int? LanguageID { get; set; }

        public string CurrencyCode { get; set; }

        public string CurrencyName { get; set; }

        public string CurrencyDisplayName { get; set; }

        public string CurrencyBaseSymbol { get; set; }

        public short? CurrencyDecimalDigitNumber { get; set; }

        public string CurrencyThousandSeparator { get; set; }

        public string CurrencyDesimalSeparator { get; set; }

        public decimal? CurrencyRoundFactor { get; set; }

        public decimal? CurrencyConvertionRate { get; set; }

        public byte? CurrencyShowSymbolAfterorBefore { get; set; }

        public bool? CurrencyIsBase { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
