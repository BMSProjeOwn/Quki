using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;

namespace Quki.Dal.Abstract
{
    public interface IPlayListDetailRepository : IGenericRepository<PlayListDetail>
    {
    //    public void AddItemApi(int? PlayListSeqID, int? ProductSeqID);
    //    public void DeletePlayListDetailApi(int PlayListSeqID, int ProductSeqID);
    //    public void ChangeDisplayOrderNumber(int PlayListSeqID, int ProductSeqID, int? DisplayOrderNumber); 
    }
}
