using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels
{
    public class ClientModel
    {
        public string Id { get; set; }
        public string Secret { get; set; }
        public string DeviceType { get; set; }
        public string DeviceId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProviderName { get; set; }
        public string ProviderKey { get; set; }
        public List<string> Audiences { get; set; }
    }
}
