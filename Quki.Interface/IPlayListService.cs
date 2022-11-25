using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface IPlayListService : IGenericService<PlayList, PlayListModel>
    {
        public List<PlayListModelApi> GetCustomerPlayListApi(string customer_def_no, int count, int languageID);
        public void CreatePlayListApi(CreatePlayListRequest createPlayListRequest);
        public void DeletePlayListApi(int? PlayListSeqID);
        public List<PlayListModelApi> GetCustomerPlayListSP(string customer_def_no, int count, int languageID);      
    }
}
