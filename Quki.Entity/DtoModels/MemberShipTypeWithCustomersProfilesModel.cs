using System;
using System.ComponentModel.DataAnnotations;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class MemberShipTypeWithCustomersProfilesModel : DtoBase
    {
        [Key]
        public long MemberShipTypeWithCustomersProfileSeqID { get; set; }
        public long MemberShipTypeWithCustomersSeqID { get; set; }
        public string ProfileUserID { get; set; }
        public string UserID { get; set; }
        public string ProfileName { get; set; }
        public string ProfileIconPath { get; set; }
        public string TerminalID { get; set; }
        public string TerminalModel { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}
