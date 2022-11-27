using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.ViewModel;

namespace Quki.Entity.DtoModels.ApiModels
{
    public class ApiRegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public List<ProtoectInformationGetModel> ProtoectInformationGetModels { get; set; }
    }
}
