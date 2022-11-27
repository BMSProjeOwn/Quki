using System.Collections.Generic;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;

namespace Quki.Dal.Abstract
{
    public interface ICustomerTrackingTypeRepository : IGenericRepository<CustomerTrackingType>
    {
        //public List<Product> GetCustomerTrackingTypeApi(int Count, string customer_def_no, int LanguageID);
        //public void AddCustomerTrackingTypeApi(AddCustomerTrackingTypeRequest addCustomerTrackingTypeApi);
        //public int GetCustomerTrackingTypeLastApi(string customer_def_no, int ProductImageSeqID);
        //public int? GetCustomerToDayListenTimeApi(string customer_def_no);
        //public void UpdateListenTimeApi(AddCustomerTrackingTypeRequest addCustomerTrackingTypeApi);
        //public List<Product> GetCustomerTrackingTypeSP(int Count, string customer_def_no, int LanguageID);
        //public bool ControlStopPorcess(string customer_def_no);
        public int GetCustomerTrackingTypeLastApi(string customer_def_no, int ProductImageSeqID);
        public int? GetCustomerToDayListenTimeApi(string customer_def_no);
        public List<SelectHomeProduct> ExecuteSql(string sql);
    }
}
