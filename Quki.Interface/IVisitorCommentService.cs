using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Quki.Entity.Models;
using Quki.Entity.ViewModel;

namespace Quki.Interface
{
    public interface IVisitorCommentService : IGenericService<VisitorComment, VisitorCommentsModel>
    {
        public List<VisitorComment> getVisitorCommentbytopcount(int count);
        
        public List<SelectListItem> GetProductListForDropdown();
        public List<VisitorCommentsModel> GetVisitorCommentsWithProduct();
        public List<VisitorComment> GetUserComment();
        public List<VisitorComment> GetUserComment2();
        public List<VisitorCommentsModel> GetVisitorCommentsWithProduct(int count);
        public List<VisitorCommentsModel> GetProductComments(int productId);
        public List<VisitorCommentsModel> GetVisitorCommentsbyProductSeqID(int productID);
        public VisitorComment GetVisitorCommentsbyVisitorCommentsSeqId(int VisitorCommentsSeqId);


        public void AddVisitorCommand(VisitorComment model);

        public void PublishComment(int id);
        public void NotPublishComment(int id);


    }
}
