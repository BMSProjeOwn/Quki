using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class LogForTransaction : EntityBase
    {
        [Key]
        public long LogForTransactionSeqID { get; set; }

        public short? LogLevel { get; set; }

        public short? LogTypeID { get; set; }

        public short? LogTypeGroupID { get; set; }

        public short? ClientLanguageID { get; set; }

        public short? CounrtyID { get; set; }

        public string? ClientLogKeyId { get; set; }

        public string VersionForSDK { get; set; }

        public string ApplicationName { get; set; }

        public string VersionApp { get; set; }

        public string VersionOperationSystem { get; set; }

        public string OperationSystem { get; set; }

        public string DeviceInformation { get; set; }

        public string DeviceModelID { get; set; }

        public bool? IsFiscalDevice { get; set; }

        public string ClassName { get; set; }
        public string Environtment { get; set; }
        public string MethodName { get; set; }

        public string Message { get; set; }

        public string Exception { get; set; }

        public string CodeBlock { get; set; }

        public string PageURL { get; set; }

        public string IPBlock { get; set; }

        public string TimeZone { get; set; }

        public string? Email { get; set; }
        public string? ProfileName { get; set; }
        public string? CounrtyCode { get; set; }
        public DateTime? CreatedTimeOnClient { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

    }
}
