using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Quki.Entity.Base;
using Quki.Entity.Models;

namespace Quki.Entity.DtoModels.ApiModels
{
    public class MemberShipTypeInfoApiModel : Response
    {
        [Key]
        public int MemberShipTypeSeqID { get; set; }
        public int? MemberShipTypeID { get; set; }
        public string Email;
        [MaxLength(150)]
        public string Name { get; set; }
        public List<MembershipPropertiesApiModel> memberShipTypeWithPropertiessList { get; set; }
        public MembershipTypePricePlanApiModel pricePlane { get; set; } = new MembershipTypePricePlanApiModel();

    }
    public class RequestMemberShip
    {
        public int languageId { get; set; }
        public string customerDefNo { get; set; }
    }
}
