using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Bll.Base;

using Quki.Entity.Models;
using Quki.Entity.ViewModel;
using Quki.Interface;
using Quki.Dal.Abstract;

namespace Quki.Bll
{
    public class VisitorCommentsManager : BllBase<VisitorComment, VisitorCommentsModel>, IVisitorCommentService
    {
        public readonly IVisitorCommentsRepository repo;
        public readonly IProductsRepository productRepository;
        public VisitorCommentsManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IVisitorCommentsRepository>();
            productRepository = service.GetService<IProductsRepository>();
        }
        public List<VisitorComment> getVisitorCommentbytopcount(int count)
        {
            var items = TGetList(u => u.Status == true && u.ShowOnHomePage == true).OrderByDescending(u => u.DisplayOrderID).Take(count);
            return items.ToList();
        }

      

        public void AddVisitorCommand(VisitorComment model)
        {

            if (model.Comment != null)
            {
                VisitorComment comment = new VisitorComment();  
                comment.Comment = model.Comment;
                comment.CreatedDate = DateTime.Now;
                comment.Status = true;
                comment.ShowOnHomePage = false;
                comment.VisitorEmail = model.VisitorEmail;
                comment.Name = model.Name;              
                comment.Phone = model.Phone;
                comment.Surname = model.Surname;
                TAdd(comment);
            }
            
        }

        public void PublishComment(int id)
        {

            
            var x = TGetList(x => x.VisitorCommentsSeqId == id).FirstOrDefault();
            x.ShowOnHomePage = true;

            TUpdate(x);
            
           

        }
        
        public void NotPublishComment(int id)
        {

            
            var x = TGetList(x => x.VisitorCommentsSeqId == id).FirstOrDefault();
            x.ShowOnHomePage = false;

            TUpdate(x);
            
           

        }



        public List<SelectListItem> GetProductListForDropdown()
        {
            List<SelectListItem> list = TGetList().Join(productRepository.TGetList(), V => V.ComantSeqID, P => P.ProductSeqID, (visitorComments, product) => new
            {
                Products = product,
                VisitorComments = visitorComments
            }).Select(I => new SelectListItem
            {
                Value = I.Products.ProductSeqID.ToString(),
                Text = I.Products.ProductName

            }).ToList();

            return list;
        }

        public List<VisitorComment> GetUserComment()
        {
            var list = TGetList(x=>x.ShowOnHomePage==true).ToList();
            

            return list;
        }
        public List<VisitorComment> GetUserComment2()
        {
            var list = TGetList().ToList();


            return list;
        }
        public List<VisitorCommentsModel> GetVisitorCommentsWithProduct()
        {
            List<VisitorCommentsModel> list = TGetList().Join(productRepository.TGetList(), V => V.ComantSeqID, P => P.ProductSeqID, (visitorComments, product) => new
            {
                Products = product,
                VisitorComments = visitorComments
            }).Select(I => new VisitorCommentsModel
            {
                VisitorCommentsSeqId = I.VisitorComments.VisitorCommentsSeqId,
                ComantSeqID = I.Products.ProductSeqID,
                Comment = I.VisitorComments.Comment.Substring(0, I.VisitorComments.Comment.Length > 20 ? 20 : I.VisitorComments.Comment.Length) + "...",
                Name = I.VisitorComments.Name,
                VisitorEmail = I.VisitorComments.VisitorEmail,
                Status = I.VisitorComments.Status,
                ProductName = I.Products.ProductName
            }).OrderByDescending(I => I.ComantSeqID).ToList();

            return list;
        }

        public List<VisitorCommentsModel> GetVisitorCommentsWithProduct(int count)
        {
            List<VisitorCommentsModel> list = TGetList().Join(productRepository.TGetList(), V => V.ComantSeqID, P => P.ProductSeqID, (visitorComments, product) => new
            {
                Products = product,
                VisitorComments = visitorComments
            }).Select(I => new VisitorCommentsModel
            {
                VisitorCommentsSeqId = I.VisitorComments.VisitorCommentsSeqId,
                ComantSeqID = I.Products.ProductSeqID,
                Comment = I.VisitorComments.Comment.Substring(0, I.VisitorComments.Comment.Length > 150 ? 150 : I.VisitorComments.Comment.Length) + "...",
                Name = I.VisitorComments.Name,
                VisitorEmail = I.VisitorComments.VisitorEmail,
                Status = I.VisitorComments.Status,
                ProductName = I.Products.ProductName,
                CreatedDate = I.VisitorComments.CreatedDate
            }).OrderByDescending(I => I.ComantSeqID).ToList().Take(count).ToList();

            return list;
        }

        public List<VisitorCommentsModel> GetProductComments(int productId)
        {
            List<VisitorCommentsModel> list = TGetList().Join(productRepository.TGetList(), V => V.ComantSeqID, P => P.ProductSeqID, (visitorComments, product) => new
            {
                Products = product,
                VisitorComments = visitorComments,
            }).Where(x => x.Products.ProductSeqID == productId).Select(I => new VisitorCommentsModel
            {
                VisitorCommentsSeqId = I.VisitorComments.VisitorCommentsSeqId,
                ComantSeqID = I.Products.ProductSeqID,
                Comment = I.VisitorComments.Comment.Substring(0, I.VisitorComments.Comment.Length > 200 ? 200 : I.VisitorComments.Comment.Length) + "...",
                Name = I.VisitorComments.Name,
                VisitorEmail = I.VisitorComments.VisitorEmail,
                Status = I.VisitorComments.Status,
                CreatedDate = I.VisitorComments.CreatedDate
            }).OrderByDescending(I => I.ComantSeqID).ToList();

            return list;
        }


        public List<VisitorCommentsModel> GetVisitorCommentsbyProductSeqID(int productID)
        {
            List<VisitorCommentsModel> list = TGetList().Join(productRepository.TGetList(), V => V.ComantSeqID, P => P.ProductSeqID, (visitorComments, product) => new
            {
                Products = product,
                VisitorComments = visitorComments
            }).Where(I => I.VisitorComments.ComantSeqID == productID).Select(I => new VisitorCommentsModel
            {
                ComantSeqID = I.Products.ProductSeqID,
                Comment = I.VisitorComments.Comment,
                Name = I.VisitorComments.Name,
                VisitorEmail = I.VisitorComments.VisitorEmail,
                Status = I.VisitorComments.Status,
                ProductName = I.Products.ProductName
            }).ToList();
            return list;
        }

        public VisitorComment GetVisitorCommentsbyVisitorCommentsSeqId(int VisitorCommentsSeqId)
        {
            var Visitor = TGetList(I => I.VisitorCommentsSeqId == VisitorCommentsSeqId).FirstOrDefault();
            return Visitor;
        }

    }
}
