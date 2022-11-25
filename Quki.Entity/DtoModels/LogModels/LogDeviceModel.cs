using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels.LogModels
{
    public class LogDeviceModel
    {
        public int languageId { get; set; }

        public Guid? customerDefNo { get; set; }

        public short? counrtyId { get; set; }

        public string? type { get; set; }

        public int? versionSdkInt { get; set; }

        public string? model { get; set; }

        public string deviceId { get; set; }    
    }
}
