﻿using System;
using System.ComponentModel.DataAnnotations;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class MemberShipTypePropertiesTypeModel:DtoBase
    {
        [Key]
        public int MemberShipTypePropertiesTypeSeqId { get; set; }

        public int? MemberShipTypePropertiesId { get; set; }

        public string MemberShipTypePropertiesName { get; set; }

        public bool? Status { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? LanguageId { get; set; }

        public short? GroupId { get; set; }

    }
}
