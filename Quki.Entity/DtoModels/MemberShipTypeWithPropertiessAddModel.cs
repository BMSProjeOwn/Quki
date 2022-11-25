using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class MemberShipTypeWithPropertiessAddModel:DtoBase
    {
        //public int MemberShipTypeWithPropertiesSeqID { get; set; }

        [Key]
        public int MemberShipPropertiesSeqID { get; set; }  
        public int MemberShipTypeSeqID { get; set; }
        public int MemberShipTypeWithPropertiesSeqID { get; set; }
        public string Name { get; set; }
        public int? Type { get; set; }
        public bool isHas { get; set; }
        public int GroupID { get; set; }
        public bool IsActive { get; set; }
        public bool IsDynamic { get; set; }
        public string InitialValue { get; set; }
        public string EndValue { get; set; }
        public int ValueTypeSeqId { get; set; }
        public string ValueTypeName { get; set; }
        public string ValueTypeSecondName { get; set; }
        public bool IsshowScreen { get; set; }

    }
}
