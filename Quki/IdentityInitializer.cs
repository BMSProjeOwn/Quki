using Microsoft.AspNetCore.Identity;
using Quki.Entity.Models;

namespace Quki
{
    public class IdentityInitializer
    {
        public static void CreateAdmin(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            AppUser app = new AppUser();
            app.Name = "Necmettin";
            app.SurName = "DAĞ";
            app.UserName = "NDag";
            if (userManager.FindByNameAsync("NDag").Result == null)
            {
                var identityResult = userManager.CreateAsync(app,"1").Result;
            }

            if (roleManager.FindByNameAsync("Admin").Result == null)
            {
                IdentityRole rolo = new IdentityRole
                {
                    Name="Admin"
                };
                var identityResult = roleManager.CreateAsync(rolo).Result;

             var result=   userManager.AddToRoleAsync(app, rolo.Name).Result;
            }
        }
    }
}
