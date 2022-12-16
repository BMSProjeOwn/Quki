using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        public UserManager<AppUser> UserMeneger { get; }
        public SignInManager<AppUser> SignInManager { get; }
        public RoleManager<IdentityRole> RoleManager { get; }
        public ILogger<HomeController> Logger { get; }
        private readonly IUserProfileService userProfileService;
        public HomeController(UserManager<AppUser> userMeneger, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager,
            ILogger<HomeController> logger, IUserProfileService userProfileService)
        {
            UserMeneger = userMeneger;
            SignInManager = signInManager;
            RoleManager = roleManager;
            Logger = logger;
            this.userProfileService = userProfileService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MainAdminPage()
        {
            return View();
        }
        public IActionResult MainAdmin()
        {
            return View();
        }

        public async Task<IActionResult> logout()
        {
            await SignInManager.SignOutAsync();
            return Redirect("https://Quki.com/account/AdminLogin");
        }
    }
}
