using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Areas.Admin.ViewComponents
{
    public class ActiveUser : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = (System.Security.Claims.ClaimsPrincipal)User;
          ViewBag.user=   currentUser.Identity.Name;
            return View();
        }
    }
}
