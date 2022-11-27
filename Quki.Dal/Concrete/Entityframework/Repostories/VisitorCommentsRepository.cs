using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;
using Quki.Entity.ViewModel;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class VisitorCommentsRepository : GenericRepository<VisitorComment>, IVisitorCommentsRepository
    {
        public VisitorCommentsRepository(DbContext context) : base(context)
        {
            
        }
        public List<VisitorComment> getVisitorCommentbytopcount(int count)
        {
            var items = dbset.Where(u => u.Status == true && u.ShowOnHomePage == true).OrderByDescending(u => u.DisplayOrderID).Take(count);
            return items.ToList();
        }

        public void AddVisitorCommandAndRaiting(ProductDetailModel model)
        {

            if (model.VisitorComments != null)
            {
                VisitorComment comment = new VisitorComment();
                comment.ComantSeqID = model.VisitorComments.ComantSeqID;
                comment.Comment = model.VisitorComments.Comment;
                comment.CreatedDate = DateTime.Now;
                comment.Status = true;
                comment.VisitorEmail = model.VisitorComments.VisitorEmail;
                comment.Name = model.VisitorComments.Name;
                comment.CreatedBy = model.VisitorComments.CreatedBy;
                TAdd(comment);
            }
        }

        public List<SelectListItem> GetProductListForDropdown()
        {
            List<SelectListItem> list = dbset.Join(context.Set<Products>(), V => V.ComantSeqID, P => P.ProductSeqID, (visitorComments, product) => new
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

        public List<VisitorCommentsModel> GetVisitorCommentsWithProduct()
        {
            List<VisitorCommentsModel> list = dbset.Join(context.Set<Products>(), V => V.ComantSeqID, P => P.ProductSeqID, (visitorComments, product) => new
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
            }).OrderByDescending(I=>I.ComantSeqID).ToList();

            return list;
        }

        public List<VisitorCommentsModel> GetVisitorCommentsWithProduct(int count)
        {
            List<VisitorCommentsModel> list = dbset.Join(context.Set<Products>(), V => V.ComantSeqID, P => P.ProductSeqID, (visitorComments, product) => new
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
            List<VisitorCommentsModel> list = dbset.Join(context.Set<Products>(), V => V.ComantSeqID, P => P.ProductSeqID, (visitorComments, product) => new
            {
                Products = product,
                VisitorComments = visitorComments,
            }).Where(x=>x.Products.ProductSeqID == productId).Select(I => new VisitorCommentsModel
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
            List<VisitorCommentsModel> list = dbset.Join(context.Set<Products>(), V => V.ComantSeqID, P => P.ProductSeqID, (visitorComments, product) => new
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
            var Visitor= dbset.Where(I => I.VisitorCommentsSeqId == VisitorCommentsSeqId).FirstOrDefault();
            return null;
        }

    }
}
