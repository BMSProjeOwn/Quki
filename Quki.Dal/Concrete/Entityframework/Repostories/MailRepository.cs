using Microsoft.AspNetCore.Identity;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class MailRepository //: ControllerBase
    {
        public UserManager<AppUser> UserMeneger { get; }
        public SignInManager<AppUser> SignInManager { get; }
        public RoleManager<IdentityRole> RoleManager { get; }
        public MailRepository(UserManager<AppUser> userMeneger, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            UserMeneger = userMeneger;
            SignInManager = signInManager;
            RoleManager = roleManager;
        }
       
        
    }
    public class MailInformation
    {

    }
}
