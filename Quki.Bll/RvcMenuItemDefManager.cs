using Microsoft.Extensions.DependencyInjection;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Interface;
using Quki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Bll
{
    public class RvcMenuItemDefManager : BllBase<RvcMenuItemDef,RvcMenuItemDefModel>,IRvcMenuItemDefService
    {
        public readonly IRvcMenuItemDefRepository repo;
        public readonly IRvcOptionsRightRepository RvcOptionsRight;
        public readonly ISluDefRepository SluDef;
        public readonly IRvcMenuItemPriceRepository RvcMenuItemPrice;
        public readonly IMenuItemBarcodeDefRepository MenuItemBarcodeDef;
        public readonly IRvcMenuItemDefWithLanguageRepository rvcMenuItemDefWithLanguageRepository;
        public readonly ISluDefWithLanguageRepository sluDefWithLanguageRepository;
        

        
        public RvcMenuItemDefManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IRvcMenuItemDefRepository>();
            RvcOptionsRight = service.GetService<IRvcOptionsRightRepository>();
            SluDef = service.GetService<ISluDefRepository>();
            RvcMenuItemPrice = service.GetService<IRvcMenuItemPriceRepository>();
            MenuItemBarcodeDef = service.GetService<IMenuItemBarcodeDefRepository>();
            rvcMenuItemDefWithLanguageRepository = service.GetService<IRvcMenuItemDefWithLanguageRepository>();
            sluDefWithLanguageRepository = service.GetService<ISluDefWithLanguageRepository>();
           

        }

        public List<RvcMenuItemDef> GetAllRvcMenuItems()
        {
            
            var allMenuItems = repo.GetAll().ToList();
            

            return allMenuItems;
        }

        public List<GetMenuItems> GetMenuItems(int languageId)
        {
            List<GetMenuItems> itemList = new List<GetMenuItems>();
            var isOnline = RvcOptionsRight.TGetList(w => w.rvc_def_seq == 10 && w.rvc_options_def_code == "rvc_opt_code_Online_Order")
               .FirstOrDefault();
            if (isOnline != null)
            {
                if (isOnline.rvc_options_def_status == 1)
                {
                    itemList = repo.TGetList()
                         .Join(RvcMenuItemPrice.TGetList(), RMD => RMD.mi_master_def_seq, RMP => RMP.mi_master_def_seq, (D, P) => new
                         {
                             D = D,
                             P = P
                         })
                         .Join(SluDef.TGetList(), RMD => RMD.D.slu_seq, SL => SL.slu_def_seq, (RMD, S) => new
                         {
                             RMD = RMD,
                             S = S
                         }).Join(rvcMenuItemDefWithLanguageRepository.TGetList(), RVCWL => RVCWL.RMD.P.rvc_mi_def_seq, RS => RS.RvcMenuItemDefSeq, (RVCWL, RS) => new
                         {
                             RVCWL = RVCWL,
                             RS = RS
                         }).
                         Where(w => w.RVCWL.RMD.D.mi_is_active == 1 && w.RVCWL.RMD.D.rvc_def_seq == 10 && (w.RVCWL.RMD.D.mi_master_def_type == "menuitem" || w.RVCWL.RMD.D.mi_master_def_type == "condiment") && w.RVCWL.RMD.P.mi_price_number == 1 && w.RVCWL.RMD.P.rvc_def_seq == 10 && w.RS.LanguageId.Equals(languageId))
                         .Select(s => new GetMenuItems
                         {
                             slu_def_seq_view = s.RS.RvcMenuItemDefWithLanguageSeqId,
                             mi_master_def_seq = (long)s.RS.LanguageId,
                             mi_master_def_name = s.RS.Name,
                             mi_price = (double)s.RVCWL.RMD.P.mi_price,
                             slu_def_name = s.RVCWL.S.slu_def_name,
                             mi_icon_path = s.RVCWL.RMD.D.mi_icon_path,
                             rvc_mi_second_name = s.RVCWL.RMD.D.rvc_mi_second_name,
                             rvc_mi_third_name = s.RS.Remark,
                             slu_priority = s.RVCWL.RMD.D.slu_priority == null ? 0 : s.RVCWL.RMD.D.slu_priority.Value,
                             control_number = s.RVCWL.S.control_number == null ? 0 : s.RVCWL.S.control_number.Value,
                         }).OrderBy(o => o.control_number).ThenBy(o => o.slu_priority).ToList();



                }
            }
            return itemList;
        }
        public List<GetMenuItems> GetMenuItems2()
        {
            List<GetMenuItems> itemList = new List<GetMenuItems>();
            var isOnline = RvcOptionsRight.TGetList(w => w.rvc_def_seq == 10 && w.rvc_options_def_code == "rvc_opt_code_Online_Order")
               .FirstOrDefault();
            if (isOnline != null)
            {
                if (isOnline.rvc_options_def_status == 1)
                {
                     itemList = repo.TGetList()
                          .Join(RvcMenuItemPrice.TGetList(), RMD => RMD.mi_master_def_seq, RMP => RMP.mi_master_def_seq, (D, P) => new
                          {
                              D = D,
                              P = P
                          })
                          .Join(SluDef.TGetList(), RMD => RMD.D.slu_seq, SL => SL.slu_def_seq, (RMD, S) => new
                          {
                              RMD = RMD,
                              S = S
                          }).Where(w => w.RMD.D.mi_is_active == 1 && w.RMD.D.rvc_def_seq == 10 && (w.RMD.D.mi_master_def_type == "menuitem" || w.RMD.D.mi_master_def_type == "condiment") && w.RMD.P.mi_price_number == 1 && w.RMD.P.rvc_def_seq == 10)
                          .Select(s => new GetMenuItems
                          {
                              slu_def_seq_view = s.S.slu_def_seq,
                              mi_master_def_seq = (long)s.RMD.D.mi_master_def_seq,
                              mi_master_def_name = s.RMD.D.mi_master_def_name,
                              mi_price = (double)s.RMD.P.mi_price,
                              slu_def_name = s.S.slu_def_name,
                              mi_icon_path = s.RMD.D.mi_icon_path,
                              rvc_mi_second_name = s.RMD.D.rvc_mi_second_name,
                              rvc_mi_third_name = s.RMD.D.rvc_mi_third_name,
                              slu_priority = s.RMD.D.slu_priority==null?0:s.RMD.D.slu_priority.Value ,
                              control_number = s.S.control_number==null?0:s.S.control_number.Value ,
                          }).OrderBy(o => o.control_number).ThenBy(o => o.slu_priority).ToList();

                    

                }
            }
            return itemList;
        }
        public List<GetMenuItems> GetMenuItemsWithId(long id, int languageId)
        {
            List<GetMenuItems> itemList = new List<GetMenuItems>();
            var isOnline = RvcOptionsRight.TGetList(w => w.rvc_def_seq == 2 && w.rvc_options_def_code == "rvc_opt_code_Online_Order")
               .FirstOrDefault();
            if (isOnline != null)
            {
                if (isOnline.rvc_options_def_status == 1)
                {
                     itemList = repo.TGetList()
                          .Join(RvcMenuItemPrice.TGetList(), RMD => RMD.mi_master_def_seq, RMP => RMP.mi_master_def_seq, (D, P) => new
                          {
                              D = D,
                              P = P
                          })
                          .Join(SluDef.TGetList(), RMD => RMD.D.slu_seq, SL => SL.slu_def_seq, (RMD, S) => new
                          {
                              RMD = RMD,
                              S = S
                          }).Join(rvcMenuItemDefWithLanguageRepository.TGetList(), RVCWL => RVCWL.RMD.P.mi_master_def_seq, RS => RS.RvcMenuItemDefSeq, (RVCWL, RS) => new
                          {
                              RVCWL = RVCWL,
                              RS = RS
                          })
                          .Where(w => w.RVCWL.RMD.D.mi_is_active == 1 && w.RVCWL.RMD.D.rvc_def_seq == 10 && (w.RVCWL.RMD.D.mi_master_def_type == "menuitem" || w.RVCWL.RMD.D.mi_master_def_type == "condiment") && w.RVCWL.RMD.P.mi_price_number == 1 && w.RVCWL.RMD.P.rvc_def_seq == 10 && w.RVCWL.RMD.D.slu_seq==id && w.RS.LanguageId.Equals(languageId))
                          .Select(s => new GetMenuItems
                          {
                              slu_def_seq_view = s.RVCWL.S.slu_def_seq,
                              mi_master_def_seq = (long)s.RVCWL.RMD.D.mi_master_def_seq,
                              mi_master_def_name = s.RS.Name,
                              mi_price = (double)s.RVCWL.RMD.P.mi_price,
                              slu_def_name = sluDefWithLanguageRepository.TGetList(x => x.SluDefSeq == s.RVCWL.RMD.D.slu_seq && x.LanguageId == languageId).FirstOrDefault().Name,
                              mi_icon_path = s.RVCWL.RMD.D.mi_icon_path,
                              rvc_mi_second_name = s.RVCWL.RMD.D.rvc_mi_second_name,
                              rvc_mi_third_name = s.RS.Remark,
                              slu_type_slu_image = s.RVCWL.S.slu_type_slu_image,
                              slu_priority = (int)s.RVCWL.RMD.D.slu_priority,
                              
                              control_number = s.RVCWL.S.control_number
                          }).OrderBy(o => o.control_number).ThenBy(o => o.slu_priority).ToList();

                    foreach (var item in itemList)
                    {
                        string text = item.slu_def_name;
                        string[] parca = text.Split("-");
                        item.slu_def_name = parca[0];
                    }

                    

                }
            }
            return itemList;
        }
    }
}
