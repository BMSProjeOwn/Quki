using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DocumentController : Controller
    {
        private readonly IDocumentsService documentsService;
        private readonly IMenuService menuService;
        private readonly ILanguageService languageService;
        private readonly UserManager<AppUser> userMeneger;
        public DocumentController(UserManager<AppUser> userMeneger, IDocumentsService documentsService, IMenuService menuService, ILanguageService languageService)
        {
            this.userMeneger = userMeneger;
            this.documentsService = documentsService;
            this.menuService = menuService;
            this.languageService = languageService;
        }

        public IActionResult Index()
        {
            try
            {
                var value = menuService.GetUserMenusForDocument();
                return View(value);
            }
            catch (Exception ex)
            {
                Log.LogProcess.LogClass.LogType = Log.LogProcess.LogType.Error;
                Log.LogProcess.LogClass.LogLevel = Log.LogProcess.LogLevel.Error;
                Log.LogProcess.LogClass.Message = "GET DocumentController Index yüklenirken hata oluştu: \n" +
                    ex.Message;
                Log.LogProcess.setLogForError();
                return View("Error");
            }
        }
       
        [HttpGet]
        public IActionResult Update(int id)
        {
            try
            {
                List<SelectListItem> languageList = languageService.GetAllLanguages2();
                ViewBag.language = languageList;


                var Item = documentsService.GetDocumentByMenuId(id);
                if (Item != null)
                {
                    if (Item.Contents == null || Item.Contents == "")
                        Item.Contents = "Content";
                    return View(Item);
                }
                else
                {
                    Document document = new Document();
                    document.Contents = "Content";
                    document.MenuID = id;
                    return View(document);
                }

            }
            catch (Exception ex)
            {
                Log.LogProcess.LogClass.LogType = Log.LogProcess.LogType.Error;
                Log.LogProcess.LogClass.LogLevel = Log.LogProcess.LogLevel.Error;
                Log.LogProcess.LogClass.Message = "GET DocumentController Index yüklenirken hata oluştu: \n" +
                    ex.Message;
                Log.LogProcess.setLogForError();
                return View("Error");
            }


        }
        [HttpPost]
        public IActionResult Update(Document model)
        {
            try
            {
                if (model.DocumentSeqID > 0)
                {
                    model.DocumentID = model.MenuID;
                    model.LanguageID = model.LanguageID;

                    documentsService.DocumentUpdateByDocumetSeqID(model);

                    ClaimsPrincipal currentUser = this.User;
                    var currentUserInfo = userMeneger.GetUserAsync(User);
                    Log.LogProcess.LogClass.LogType = Log.LogProcess.LogType.Update;
                    Log.LogProcess.LogClass.LogLevel = Log.LogProcess.LogLevel.Info;
                    Log.LogProcess.LogClass.UserID = new Guid(currentUserInfo.Result.Id);
                    Log.LogProcess.LogClass.Message = "Döküman Güncellendi : Güncellenen Döküman Adı : " + model.Header;
                    Log.LogProcess.setLogForDefiniton();
                }
                else
                {
                    model.DocumentID = model.MenuID;
                    model.LanguageID = model.LanguageID;
                    documentsService.TAdd(model);
                    ClaimsPrincipal currentUser = this.User;
                    var currentUserInfo = userMeneger.GetUserAsync(User);
                    Log.LogProcess.LogClass.LogType = Log.LogProcess.LogType.Insert;
                    Log.LogProcess.LogClass.LogLevel = Log.LogProcess.LogLevel.Info;
                    Log.LogProcess.LogClass.UserID = new Guid(currentUserInfo.Result.Id);
                    Log.LogProcess.LogClass.Message = "Döküman Eklendi : Eklenen Döküman Adı : " + model.Header;
                    Log.LogProcess.setLogForDefiniton();
                }


                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                Log.LogProcess.LogClass.LogType = Log.LogProcess.LogType.Error;
                Log.LogProcess.LogClass.LogLevel = Log.LogProcess.LogLevel.Error;
                Log.LogProcess.LogClass.Message = "GET DocumentController Update yüklenirken hata oluştu: \n" +
                    ex.Message;
                Log.LogProcess.setLogForError();
                return View("Error");
            }

        }


        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                DocumentModel documentModel = new DocumentModel();
                List<SelectListItem> list = languageService.GetAllLanguages2();
                ViewBag.language = list;
                return View(documentModel);

            }
            catch (Exception ex)
            {
                Log.LogProcess.LogClass.LogType = Log.LogProcess.LogType.Error;
                Log.LogProcess.LogClass.LogLevel = Log.LogProcess.LogLevel.Error;
                Log.LogProcess.LogClass.Message = "GET DocumentController Create yüklenirken hata oluştu: \n" +
                    ex.Message;
                Log.LogProcess.setLogForError();
                return View("Error");
            }
        }



        [HttpPost]
        public IActionResult Create(DocumentModel documentModel)
        {
            try
            {

                documentsService.Create(documentModel);
                ClaimsPrincipal currentUser = this.User;
                var currentUserInfo = userMeneger.GetUserAsync(User);
                Log.LogProcess.LogClass.LogType = Log.LogProcess.LogType.Insert;
                Log.LogProcess.LogClass.LogLevel = Log.LogProcess.LogLevel.Info;
                Log.LogProcess.LogClass.UserID = new Guid(currentUserInfo.Result.Id);
                Log.LogProcess.LogClass.Message = "Döküman Eklendi : Eklenen Döküman Adı : " + documentModel.Header;
                Log.LogProcess.setLogForDefiniton();
                return RedirectToAction("Index", "Document");
            }
            catch (Exception ex)
            {
                Log.LogProcess.LogClass.LogType = Log.LogProcess.LogType.Error;
                Log.LogProcess.LogClass.LogLevel = Log.LogProcess.LogLevel.Error;
                Log.LogProcess.LogClass.Message = "POST DocumentController Create yüklenirken hata oluştu: \n" +
                    ex.Message;
                Log.LogProcess.setLogForError();
                return View("Error");
            }
        }
    }
}
