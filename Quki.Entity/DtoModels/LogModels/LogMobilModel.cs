using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels.LogModels
{
    public class LogMobilModel
    {
        public string keyId { get; set; }

        public string? className { get; set; }
        public string? methodName { get; set; }
        public string? logLevel { get; set; }

        public string? text { get; set; }

        public DateTime? dateTime { get; set; }

        public string? timeZone { get; set; }
        public string? errorString { get; set; }

        public string? stacktraceString { get; set; }

        public string version { get; set; }
        public string logType { get; set; }
        public string error { get; set; }
        public string? logTypeGroup { get; set; }

    }
}
