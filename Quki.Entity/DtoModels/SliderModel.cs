using Microsoft.AspNetCore.Http;
using Quki.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels
{
    public class SliderModel : DtoBase
    {
        public int SliderSeqId { get; set; }

        public string SliderName { get; set; }

        public string ImagePath { get; set; }

        public string Header { get; set; }

        public string Remark { get; set; }

        public bool IsActive { get; set; }

        public int? LanguageId { get; set; }

        public short? GroupId { get; set; }

        public int? DocumentIId { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string CreatedBy { get; set; }


        public IFormFile ImagePathName { get; set; }
    }
}
