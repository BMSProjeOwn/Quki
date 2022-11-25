using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;
using Quki.Entity.ViewModel;



namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class CustomerRatingsRepository : GenericRepository<CustomerRatings>, ICustomerRatingsRepository
    {
        public CustomerRatingsRepository(DbContext context):base(context)
        {
        }
        //public void UpdateORAddCustomerRatings(ProductDetailModel model)
        //{
        //    var value = dbset.Where(I => I.customer_def_no == model.VisitorComments.VisitorEmail).FirstOrDefault();
        //    if (value != null)
        //    {
        //        value.ReatingValue = model.VisitorComments.CustomerRaiting.ToString();
        //        value.UpdatedOn = DateTime.Now;
        //        TUpdate(value);
        //    }
        //    else
        //    {
        //        CustomerRatings customerRatings = new CustomerRatings();
        //        customerRatings.RelatedRatingSeqID = model.VisitorComments.ComantSeqID;
        //        customerRatings.customer_def_no = model.VisitorComments.VisitorEmail;
        //        customerRatings.ReatingValue = model.VisitorComments.CustomerRaiting.ToString();
        //        customerRatings.CreatedOn = DateTime.Now;
        //        customerRatings.UpdatedOn = DateTime.Now;
        //        TAdd(customerRatings);
        //    }
        //    //if(model.VisitorComments.VisitorEmail)
        //}

        //public void UpdateORAddCustomerRatingsApi(string customer_def_no, int productID, string point)
        //{
        //    var value = dbset.Where(I => I.customer_def_no == customer_def_no && I.IsActive == true && I.RelatedRatingSeqID == productID).FirstOrDefault();
        //    if (value != null)
        //    {
        //        value.ReatingValue = point;
        //        value.UpdatedOn = DateTime.Now;
        //        TUpdate(value);
        //    }
        //    else
        //    {
        //        CustomerRatings customerRatings = new CustomerRatings();
        //        customerRatings.RelatedRatingSeqID = productID;
        //        customerRatings.customer_def_no = customer_def_no;
        //        customerRatings.ReatingValue = point;
        //        customerRatings.IsActive = true;
        //        customerRatings.CreatedOn = DateTime.Now;
        //        customerRatings.UpdatedOn = DateTime.Now;
        //        TAdd(customerRatings);
        //    }
        //}

        public string ProductPoint(int productID)
        {
            string returnValue = "0";
            //int sameProductID = context.Products.Where(w => w.ProductSeqID == productID).Select(s => s.ProductID).FirstOrDefault();
            var value = dbset.Where(I => I.IsActive == true && I.RelatedRatingSeqID == productID).Select(s => s.ReatingValue).ToList();
            if (value != null)
            {
                if (value.Count > 0)
                {
                    double top = 0;
                    for (int i = 0; i < value.Count; i++)
                    {
                        top = top + Convert.ToDouble(value[i].ToString());
                    }
                    returnValue = (top / value.Count).ToString();
                }
            }
            return returnValue;
        }
    }
}
