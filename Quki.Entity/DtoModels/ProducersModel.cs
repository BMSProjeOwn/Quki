using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class ProducersModel
    {

        public int ProducerSeqID { get; set; }
        public string Name { get; set; }
        public string TypeName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public bool IsActive { get; set; }
        public string ImageThumpPath { get; set; }
        public string ImagePath { get; set; }

        public int? GroupID { get; set; }
    }

    public class ProducersAgreementModel : DtoBase
    {

        public int ProducerSeqID { get; set; }
        public string Name { get; set; }
        public List<string> TypeName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public bool IsActive { get; set; }
        public string ImageThumpPath { get; set; }
        public string ImagePath { get; set; }

        public int? GroupID { get; set; }
    }
}
