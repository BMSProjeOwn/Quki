using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class PlayListDetailManager : BllBase<PlayListDetail, PlayListDetailModel>, IPlayListDetailService
    {
        public readonly IPlayListDetailRepository repo;
        public PlayListDetailManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IPlayListDetailRepository>();
        }
        public void AddItemApi(int? PlayListSeqID, int? ProductSeqID)
        {
            var detaillist = TGetList(w => w.PlayListSeqID == PlayListSeqID).ToList();
            PlayListDetail playListDetail = new PlayListDetail();
            playListDetail.PlayListSeqID = PlayListSeqID;
            playListDetail.RelatedItemSeqID = ProductSeqID;
            playListDetail.CreatedOn = DateTime.Now;
            playListDetail.IsActive = true;
            playListDetail.IsDelet = false;
            try
            {
                playListDetail.DisplayOrderNumber = detaillist.Count + 1;
            }
            catch
            {
                playListDetail.DisplayOrderNumber = 1;
            }
            var value = TGetList(w => w.IsActive == true && w.IsDelet == false && w.PlayListSeqID == PlayListSeqID && w.RelatedItemSeqID == ProductSeqID).ToList();
            if (value.Count <= 0)
                TAdd(playListDetail);
        }

        public void DeletePlayListDetailApi(int PlayListSeqID, int ProductSeqID)
        {
            var values = TGetList(w => w.PlayListSeqID == PlayListSeqID && w.RelatedItemSeqID == ProductSeqID).ToList();
            foreach (var value in values)
            {
                //var value = TgetItemByID(PlayListDetailSeqID);
                value.IsDelet = true;
                value.IsActive = false;
                value.UpdatedOn = DateTime.Now;
                TUpdate(value);
            }
        }

        public void ChangeDisplayOrderNumber(int PlayListSeqID, int ProductSeqID, int? DisplayOrderNumber)
        {
            var values = TGetList(w => w.PlayListSeqID == PlayListSeqID && w.RelatedItemSeqID == ProductSeqID).ToList();
            foreach (var value in values)
            {
                //var value = TgetItemByID(PlayListDetailSeqID);
                value.DisplayOrderNumber = DisplayOrderNumber;
                value.UpdatedOn = DateTime.Now;
                TUpdate(value);
            }
        }
    }
}
