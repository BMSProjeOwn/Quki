using System.Collections.Generic;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Entity.ViewModel;

namespace Quki.Interface
{
    public interface ICustomerFovoriListService : IGenericService<CustomerFavoritesList, CustomerFovoriListApiModel>
    {
        public void AddCustomerFavoriList(CustomerFovoriListApiModel model);
        public void DeleteCustomerFavoriList(CustomerFovoriListApiModel model);
        public void DeleteListOfCustomerFavoriList(string customer_def_no);
        public List<CustomerFavoritesList> getCustomerFovoriList(string customer_def_no);
        public List<CustomerFavoritesList> getCustomerFovoriListWithType(string customer_def_no, int? TypeID);
        public List<Product> getCustomerFovoriListApi(string customer_def_no);
        public List<Product> GetCustomerFavoriListFromSP(string customer_def_no, int languageId);
        
    }
}
