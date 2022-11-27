using System;
using System.Linq;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;
using Quki.Entity.ViewModel;



namespace Quki.Dal.Abstract
{
    public interface ICustomerRatingsRepository
    {
        //public void UpdateORAddCustomerRatings(ProductDetailModel model);
        //public void UpdateORAddCustomerRatingsApi(string customer_def_no, int productID, string point);
        public string ProductPoint(int productID);
    }
}
