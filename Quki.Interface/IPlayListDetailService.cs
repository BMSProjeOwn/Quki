using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface IPlayListDetailService : IGenericService<PlayListDetail, PlayListDetailModel>
    {
        public void AddItemApi(int? PlayListSeqID, int? ProductSeqID);
        public void DeletePlayListDetailApi(int PlayListSeqID, int ProductSeqID);
        public void ChangeDisplayOrderNumber(int PlayListSeqID, int ProductSeqID, int? DisplayOrderNumber); 
    }
}
