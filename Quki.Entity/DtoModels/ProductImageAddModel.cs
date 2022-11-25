using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class ProductImageAddModel:DtoBase
    {
        public int ProductImageSeqID { get; set; }
        public int ProductSeqID { get; set; }
        public int MediaTypeId { get; set; }
        public int GroupId { get; set; }
        public string GroupValue { get; set; }
        public string Remark { get; set; }
        public IFormFile ImagePath { get; set; }
        public string ImagePathName { get; set; }
        public string ImageName { get; set; }
        public bool Status { get; set; }

        public string ProductName { get; set; }



    }
}
