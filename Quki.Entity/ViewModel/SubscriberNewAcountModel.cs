using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.ViewModel
{
    public class SubscriberNewAcountModel
    {
        public LoginViewModel LoginViewModel { get; set; }
        public RegisterViewModel RegisterViewModel { get; set; }
        public UserProfileViewModel UserProfileViewModel { get; set; }
        public List<MemberShipPricePlanGetModel> MemberShipPricePlanGetModelList { get; set; }

        public string LoginTab { get; set; }
        public string RegisterTab { get; set; }
        public string LoginMenu { get; set; }
        public string RegisterMenu { get; set; }


    }
}
