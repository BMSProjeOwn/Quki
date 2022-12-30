using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quki.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MesajController : Controller
    {
        private readonly IVisitorCommentService service;
        public MesajController(IVisitorCommentService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            var items = service.GetUserComment2().ToList();
            return View(items);
        }



        public IActionResult Publish(int id)
        {
            service.PublishComment(id);
            return RedirectToAction("Index", "Mesaj");
        }

        public IActionResult NotPublish(int id)
        {
            service.NotPublishComment(id);
            return RedirectToAction("Index", "Mesaj");
        }


        public IActionResult ShowComment(int id)
        {

            VisitorComment model = new VisitorComment();

            model = service.GetVisitorCommentsbyVisitorCommentsSeqId(id);


            return View(model);
        }


    }
}
