using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;
using Quki.Entity.ViewModel;

namespace Quki.Dal.Abstract
{
    public interface IVisitorCommentsRepository
    {
        public List<VisitorComment> getVisitorCommentbytopcount(int count);
        public void AddVisitorCommandAndRaiting(ProductDetailModel model);
        public List<SelectListItem> GetProductListForDropdown();
        public List<VisitorCommentsModel> GetVisitorCommentsWithProduct();
        public List<VisitorCommentsModel> GetVisitorCommentsWithProduct(int count);
        public List<VisitorCommentsModel> GetProductComments(int productId);
        public List<VisitorCommentsModel> GetVisitorCommentsbyProductSeqID(int productID);
        public VisitorComment GetVisitorCommentsbyVisitorCommentsSeqId(int VisitorCommentsSeqId);
        
    }
}
