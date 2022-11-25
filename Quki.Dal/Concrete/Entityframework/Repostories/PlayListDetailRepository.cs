using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class PlayListDetailRepository : GenericRepository<PlayListDetail>, IPlayListDetailRepository
    {
        public PlayListDetailRepository(DbContext context) : base(context)
        {
            
        }
        //public void AddItemApi(int? PlayListSeqID, int? ProductSeqID)
        //{
        //    var detaillist = dbset.Where(w => w.PlayListSeqID == PlayListSeqID).ToList();
        //    PlayListDetail playListDetail = new PlayListDetail();
        //    playListDetail.PlayListSeqID = PlayListSeqID;
        //    playListDetail.RelatedItemSeqID = ProductSeqID;
        //    playListDetail.CreatedOn = DateTime.Now;
        //    playListDetail.IsActive = true;
        //    playListDetail.IsDelet = false;
        //    try
        //    {
        //        playListDetail.DisplayOrderNumber = detaillist.Count + 1;
        //    }
        //    catch
        //    {
        //        playListDetail.DisplayOrderNumber = 1;
        //    }
        //    var value = dbset.Where(w => w.IsActive == true && w.IsDelet == false && w.PlayListSeqID == PlayListSeqID && w.RelatedItemSeqID == ProductSeqID).ToList();
        //    if (value.Count <= 0)
        //        TAdd(playListDetail);
        //}

        //public void DeletePlayListDetailApi(int PlayListSeqID, int ProductSeqID)
        //{
        //    var values = dbset.Where(w => w.PlayListSeqID == PlayListSeqID && w.RelatedItemSeqID == ProductSeqID).ToList();
        //    foreach (var value in values)
        //    {
        //        var value = TgetItemByID(PlayListDetailSeqID);
        //        value.IsDelet = true;
        //        value.IsActive = false;
        //        value.UpdatedOn = DateTime.Now;
        //        TUpdate(value);
        //    }
        //}

        //public void ChangeDisplayOrderNumber(int PlayListSeqID, int ProductSeqID, int? DisplayOrderNumber)
        //{
        //    var values = dbset.Where(w => w.PlayListSeqID == PlayListSeqID && w.RelatedItemSeqID == ProductSeqID).ToList();
        //    foreach (var value in values)
        //    {
        //        var value = TgetItemByID(PlayListDetailSeqID);
        //        value.DisplayOrderNumber = DisplayOrderNumber;
        //        value.UpdatedOn = DateTime.Now;
        //        TUpdate(value);
        //    }
        //}
    }
}
