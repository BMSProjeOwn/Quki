using Microsoft.AspNetCore.Mvc;
using Quki.Entity.DtoModels;
using Quki.Entity.ViewModel;
using Quki.Interface;
using System.Collections.Generic;

namespace Quki.Controllers
{
    public class MenuController : Controller
    {

        private readonly IRvcMenuItemDefService rvcMenuItemDefService;
        private readonly Islu_Rvc_RelationService slu_Rvc_RelationService;
        public MenuController(IRvcMenuItemDefService rvcMenuItemDefService, Islu_Rvc_RelationService slu_Rvc_RelationService)
        {
            this.rvcMenuItemDefService = rvcMenuItemDefService;
            this.slu_Rvc_RelationService = slu_Rvc_RelationService;

        }

        public IActionResult Index()
        {
            List<SluDefModel> sluDefModels = new List<SluDefModel>();

            var getMenuItems = rvcMenuItemDefService.GetMenuItems();
            try
            {
                sluDefModels = slu_Rvc_RelationService.GetAllSluDefRelationWithSlu();
            }
            catch
            {

            }
            MenuViewModel menuViewModel = new MenuViewModel();
            menuViewModel.getMenuItems = getMenuItems;
            menuViewModel.sluDefModels=sluDefModels;
            return View(menuViewModel);
        }
    }
}
