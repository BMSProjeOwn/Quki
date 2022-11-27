using System.Collections.Generic;
using Quki.Entity.DtoModels.ApiModels;

namespace Quki.Dal.Abstract
{
    public interface IPlayListRepository
    {
        //public List<PlayListModelApi> GetCustomerPlayListApi(string customer_def_no, int count, int languageID);
        //public void CreatePlayListApi(CreatePlayListRequest createPlayListRequest);
        //public void DeletePlayListApi(int? PlayListSeqID);
        //public List<PlayListModelApi> GetCustomerPlayListSP(string customer_def_no, int count, int languageID);
        public List<SelectHomeProduct> ExecuteSql(string sql);
    }
}
