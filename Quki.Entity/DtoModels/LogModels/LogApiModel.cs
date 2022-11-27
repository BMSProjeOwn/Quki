using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels.LogModels
{
    public class LogApiModel
    {
        public short languageId { get; set; }

        public Guid? customerDefNo { get; set; }
        public short? logLevel { get; set; }
        public short? counrtyId { get; set; }

        public string? type { get; set; }

        public string? versionSdkInt { get; set; }
        public string? countryCode { get; set; }
        public string? model { get; set; }
        public string? brand { get; set; }
        public string? email { get; set; }
        public string? profileName { get; set; }
        public string deviceId { get; set; }
        public string appVersion { get; set; }
        public bool isPhysicalDevice { get; set; }
        public string environtment { get; set; }
        public List<LogMobilModel> logList { get; set; }
    }
}
