using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Entity.Parameters;
using Quki.Entity.ViewModel;

namespace Quki.Dal.Abstract
{
    public interface ICustomerFovoriListRepository : IGenericRepository<CustomerFavoritesList>
    {
        //public void AddCustomerFavoriList(CustomerFovoriListApiModel model);
        //public void DeleteCustomerFavoriList(CustomerFovoriListApiModel model);
        //public void DeleteListOfCustomerFavoriList(string customer_def_no);
        //public List<CustomerFavoritesList> getCustomerFovoriList(string customer_def_no);
        public List<CustomerFavoritesList> getCustomerFovoriListWithType(string customer_def_no, int? TypeID);
        //public List<Product> getCustomerFovoriListApi(string customer_def_no);
        public List<SelectHomeProduct> GetCustomerFavoriListFromSP(string customer_def_no, int languageId);
        
    }
}
