using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels.ApiModels
{
    public class MembershipPropertiesApiModel
    {
        public int languageID { get; set; }
        public int propertyId { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        
    }
}
