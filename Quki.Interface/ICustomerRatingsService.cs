using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Entity.ViewModel;



namespace Quki.Interface
{
    public interface ICustomerRatingsService : IGenericService<CustomerRatings, CustomerRatingsModel> 
    {
        public void UpdateORAddCustomerRatings(ProductDetailModel model);
        public void UpdateORAddCustomerRatingsApi(string customer_def_no, int productID, string point);
        public string ProductPoint(int productID);
    }
}
