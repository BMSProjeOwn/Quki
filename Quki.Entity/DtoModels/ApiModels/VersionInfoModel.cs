using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels.ApiModels
{
    public class VersionInfoModel
    {

        public string version { get; set; }
        public bool isUpdateRequired { get; set; }
    }
}
