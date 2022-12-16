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
        

        
        public RvcMenuItemDefManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IRvcMenuItemDefRepository>();
            RvcOptionsRight = service.GetService<IRvcOptionsRightRepository>();
            SluDef = service.GetService<ISluDefRepository>();
            RvcMenuItemPrice = service.GetService<IRvcMenuItemPriceRepository>();
            MenuItemBarcodeDef = service.GetService<IMenuItemBarcodeDefRepository>();
           

        }

        public List<RvcMenuItemDef> GetAllRvcMenuItems()
        {
            
            var allMenuItems = repo.GetAll().ToList();
            

            return allMenuItems;
        } 

        public List<GetMenuItems> GetMenuItems()
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
                          .Join(MenuItemBarcodeDef.TGetList(), DP => DP.D.mi_master_def_seq, B => B.mi_master_def_seq, (DP, B) => new
                          {
                              DP = DP,
                              B = B
                          })
                          .Join(SluDef.TGetList(), RMD => RMD.DP.D.slu_seq, SL => SL.slu_def_seq, (RMD, S) => new
                          {
                              RMD = RMD,
                              S = S
                          })
                          .Where(w => w.RMD.DP.D.mi_is_active == 1 && w.RMD.DP.D.rvc_def_seq == 10 && (w.RMD.DP.D.mi_master_def_type == "menuitem" || w.RMD.DP.D.mi_master_def_type == "condiment") && w.RMD.DP.P.mi_price_number == 1 && w.RMD.DP.P.rvc_def_seq == 10)
                          .Select(s => new GetMenuItems
                          {
                              slu_def_seq_view = s.S.slu_def_seq,
                              mi_master_def_seq = (long)s.RMD.DP.D.mi_master_def_seq,
                              mi_master_def_name = s.RMD.DP.D.mi_master_def_name,
                              mi_barcode_id = s.RMD.B.mi_barcode_id,
                              mi_price = (double)s.RMD.DP.P.mi_price,
                              slu_def_name = s.S.slu_def_name,
                              mi_icon_path = s.RMD.DP.D.mi_icon_path,
                              rvc_mi_second_name = s.RMD.DP.D.rvc_mi_second_name,
                              rvc_mi_third_name = s.RMD.DP.D.rvc_mi_third_name,
                              slu_priority = (int)s.RMD.DP.D.slu_priority,
                              control_number = s.S.control_number
                          }).OrderBy(o => o.control_number).ThenBy(o => o.slu_priority).ToList();

                    

                }
            }
            return itemList;
        }
        public List<GetMenuItems> GetMenuItemsWithId(long id)
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
                          .Join(MenuItemBarcodeDef.TGetList(), DP => DP.D.mi_master_def_seq, B => B.mi_master_def_seq, (DP, B) => new
                          {
                              DP = DP,
                              B = B
                          })
                          .Join(SluDef.TGetList(), RMD => RMD.DP.D.slu_seq, SL => SL.slu_def_seq, (RMD, S) => new
                          {
                              RMD = RMD,
                              S = S
                          })
                          .Where(w => w.RMD.DP.D.mi_is_active == 1 && w.RMD.DP.D.rvc_def_seq == 10 && (w.RMD.DP.D.mi_master_def_type == "menuitem" || w.RMD.DP.D.mi_master_def_type == "condiment") && w.RMD.DP.P.mi_price_number == 1 && w.RMD.DP.P.rvc_def_seq == 10&& w.RMD.DP.D.slu_seq==id)
                          .Select(s => new GetMenuItems
                          {
                              slu_def_seq_view = s.S.slu_def_seq,
                              mi_master_def_seq = (long)s.RMD.DP.D.mi_master_def_seq,
                              mi_master_def_name = s.RMD.DP.D.mi_master_def_name,
                              mi_barcode_id = s.RMD.B.mi_barcode_id,
                              mi_price = (double)s.RMD.DP.P.mi_price,
                              slu_def_name = s.S.slu_def_name,
                              mi_icon_path = s.RMD.DP.D.mi_icon_path,
                              rvc_mi_second_name = s.RMD.DP.D.rvc_mi_second_name,
                              rvc_mi_third_name = s.RMD.DP.D.rvc_mi_third_name,
                              slu_type_slu_image = s.S.slu_type_slu_image,
                              slu_priority = (int)s.RMD.DP.D.slu_priority,
                              
                              control_number = s.S.control_number
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
