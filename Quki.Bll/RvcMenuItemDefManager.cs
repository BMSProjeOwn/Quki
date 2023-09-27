﻿using Microsoft.Extensions.DependencyInjection;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;
using Quki.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public readonly ICondimentMenuItemRelationRepository condimentMenuItemRelation;
        public readonly ICondimentRelationRepository condimentRelation;
        

        
        public RvcMenuItemDefManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IRvcMenuItemDefRepository>();
            RvcOptionsRight = service.GetService<IRvcOptionsRightRepository>();
            SluDef = service.GetService<ISluDefRepository>();
            RvcMenuItemPrice = service.GetService<IRvcMenuItemPriceRepository>();
            MenuItemBarcodeDef = service.GetService<IMenuItemBarcodeDefRepository>();
            rvcMenuItemDefWithLanguageRepository = service.GetService<IRvcMenuItemDefWithLanguageRepository>();
            condimentMenuItemRelation = service.GetService<ICondimentMenuItemRelationRepository>();
            condimentRelation = service.GetService<ICondimentRelationRepository>();
           

        }

        public List<RvcMenuItemDef> GetAllRvcMenuItems()
        {
            
            var allMenuItems = repo.GetAll().ToList();
            

            return allMenuItems;
        }

        public List<GetMenuItems> GetMenuItems(out List<Condiment> condimentRequired, out List<Condiment> condimentNonRequired, int languageId)
        {
            condimentRequired = new List<Condiment>();
            condimentNonRequired = new List<Condiment>();
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
                         }).Join(rvcMenuItemDefWithLanguageRepository.TGetList(), RVCWL => RVCWL.RMD.DP.P.mi_master_def_seq , RS=>RS.RvcMenuItemDefSeq, (RVCWL, RS) => new
                         {
                             RVCWL = RVCWL,
                             RS = RS
                         }).Where(w => w.RVCWL.RMD.DP.D.mi_is_active == 1 && w.RVCWL.RMD.DP.D.rvc_def_seq == 2 && (w.RVCWL.RMD.DP.D.mi_master_def_type == "menuitem" || w.RVCWL.RMD.DP.D.mi_master_def_type == "condiment") && w.RVCWL.RMD.DP.P.mi_price_number == 1 && w.RS.LanguageId.Equals(languageId))
                         .Select(s => new GetMenuItems
                         {
                             slu_def_seq_view = s.RVCWL.S.slu_def_seq,
                             mi_master_def_seq = (long)s.RVCWL.RMD.DP.D.mi_master_def_seq,
                             mi_master_def_name = s.RS.Name.ToUpper(),
                             mi_barcode_id = s.RVCWL.RMD.B.mi_barcode_id,
                             mi_price = (double)s.RVCWL.RMD.DP.P.mi_price,
                             slu_def_name = s.RVCWL.S.slu_def_name,
                             mi_icon_path = s.RVCWL.RMD.DP.D.mi_icon_path,
                             rvc_mi_second_name = s.RVCWL.RMD.DP.D.rvc_mi_second_name,
                             rvc_mi_third_name = s.RS.Remark,
                             slu_priority = s.RVCWL.RMD.DP.D.slu_priority == null ? 0 : s.RVCWL.RMD.DP.D.slu_priority.Value,
                             control_number = s.RVCWL.S.control_number == null ? 0 : s.RVCWL.S.control_number.Value,
                         }).OrderBy(o => o.control_number).ThenBy(o => o.slu_priority).ToList();

                    var menuitemList = repo.TGetList();

                    condimentNonRequired = menuitemList.Join(condimentRelation.TGetList(), MI => MI.condiment_main_group_def_seq, CR => CR.relation_seq, (MI, CR) => new
                    {
                        CR = CR,
                        MI = MI
                    }).Join(condimentMenuItemRelation.TGetList(), R => R.CR.condiment_sub_group_def_seq, CMR => CMR.condiment_sub_group_def_seq, (R, CMR) => new
                    {
                        R = R,
                        CMR = CMR
                    }).Join(repo.TGetList(), R => R.CMR.mi_master_def_seq, MI => MI.mi_master_def_seq, (R, MI) => new {
                        R = R,
                        MI = MI
                    }).Join(RvcMenuItemPrice.TGetList(x => x.rvc_mi_price_no == 1), R => R.MI.mi_master_def_seq, RMIP => RMIP.mi_master_def_seq, (R, RMIP) => new
                    {
                        R = R,
                        RMIP = RMIP
                    }).Join(rvcMenuItemDefWithLanguageRepository.TGetList(x => x.LanguageId == languageId), R => R.RMIP.mi_master_def_seq, MIL => MIL.RvcMenuItemDefSeq, (R, MIL) => new Condiment
                    {
                        mi_master_def_name = MIL.Name,
                        mi_price = R.RMIP.mi_price,
                        mi_master_def_seq = R.R.R.R.MI.mi_master_def_seq,
                        mi_icon_path = R.R.MI.mi_icon_path

                    }).ToList();

                    condimentRequired = menuitemList.Join(condimentRelation.TGetList(), MI => MI.condiment_profile_def_seq, CR => CR.relation_seq, (MI, CR) => new
                    {
                        CR = CR,
                        MI = MI
                    }).Join(condimentMenuItemRelation.TGetList(), R => R.CR.condiment_sub_group_def_seq, CMR => CMR.condiment_sub_group_def_seq, (R, CMR) => new
                    {
                        R = R,
                        CMR = CMR
                    }).Join(repo.TGetList(), R => R.CMR.mi_master_def_seq, MI => MI.mi_master_def_seq, (R, MI) => new {
                        R = R,
                        MI = MI
                    }).Join(RvcMenuItemPrice.TGetList(x => x.rvc_mi_price_no == 1), R => R.MI.mi_master_def_seq, RMIP => RMIP.mi_master_def_seq, (R, RMIP) => new
                    {
                        R = R,
                        RMIP = RMIP
                    }).Join(rvcMenuItemDefWithLanguageRepository.TGetList(x => x.LanguageId == languageId), R => R.RMIP.mi_master_def_seq, MIL => MIL.RvcMenuItemDefSeq, (R, MIL) => new Condiment
                    {
                        mi_master_def_name = MIL.Name,
                        mi_price = R.RMIP.mi_price,
                        mi_master_def_seq = R.R.R.R.MI.mi_master_def_seq,
                        mi_icon_path = R.R.MI.mi_icon_path

                    }).ToList();

                }
            }
            return itemList;
        }
        public List<GetMenuItems> GetMenuItems()
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
                          .Join(MenuItemBarcodeDef.TGetList(), DP => DP.D.mi_master_def_seq, B => B.mi_master_def_seq, (DP, B) => new
                          {
                              DP = DP,
                              B = B
                          })
                          .Join(SluDef.TGetList(), RMD => RMD.DP.D.slu_seq, SL => SL.slu_def_seq, (RMD, S) => new
                          {
                              RMD = RMD,
                              S = S
                          }).Where(w => w.RMD.DP.D.mi_is_active == 1 && w.RMD.DP.D.rvc_def_seq == 2 && (w.RMD.DP.D.mi_master_def_type == "menuitem" || w.RMD.DP.D.mi_master_def_type == "condiment") && w.RMD.DP.P.mi_price_number == 1)
                          .Select(s => new GetMenuItems
                          {
                              slu_def_seq_view = s.S.slu_def_seq,
                              mi_master_def_seq = (long)s.RMD.DP.D.mi_master_def_seq,
                              mi_master_def_name = s.RMD.DP.D.mi_master_def_name.ToUpper(),
                              mi_barcode_id = s.RMD.B.mi_barcode_id,
                              mi_price = (double)s.RMD.DP.P.mi_price,
                              slu_def_name = s.S.slu_def_name,
                              mi_icon_path = s.RMD.DP.D.mi_icon_path,
                              rvc_mi_second_name = s.RMD.DP.D.rvc_mi_second_name,
                              rvc_mi_third_name = s.RMD.DP.D.rvc_mi_third_name,
                              slu_priority = s.RMD.DP.D.slu_priority==null?0:s.RMD.DP.D.slu_priority.Value ,
                              control_number = s.S.control_number==null?0:s.S.control_number.Value ,
                          }).OrderBy(o => o.control_number).ThenBy(o => o.slu_priority).ToList();

                    

                }
            }
            return itemList;
        }
        public List<GetMenuItems> GetMenuItemsWithId(long id,out List<Condiment> condimentRequired, out List<Condiment> condimentNonRequired, int languageId)
        {
            condimentRequired = new List<Condiment>();
            condimentNonRequired= new List<Condiment>();
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
                          .Join(MenuItemBarcodeDef.TGetList(), DP => DP.D.mi_master_def_seq, B => B.mi_master_def_seq, (DP, B) => new
                          {
                              DP = DP,
                              B = B
                          })
                          .Join(SluDef.TGetList(), RMD => RMD.DP.D.slu_seq, SL => SL.slu_def_seq, (RMD, S) => new
                          {
                              RMD = RMD,
                              S = S
                          }).Join(rvcMenuItemDefWithLanguageRepository.TGetList(), RVCWL => RVCWL.RMD.DP.P.mi_master_def_seq, RS => RS.RvcMenuItemDefSeq, (RVCWL, RS) => new
                          {
                              RVCWL = RVCWL,
                              RS = RS
                          })
                          .Where(w => w.RVCWL.RMD.DP.D.mi_is_active == 1 && w.RVCWL.RMD.DP.D.rvc_def_seq == 2 && w.RVCWL.RMD.DP.P.mi_price_number == 1 && w.RVCWL.RMD.DP.D.slu_seq==id && w.RS.LanguageId.Equals(languageId))
                          .Select(s => new GetMenuItems
                          {
                              slu_def_seq_view = s.RVCWL.S.slu_def_seq,
                              mi_master_def_seq = (long)s.RVCWL.RMD.DP.D.mi_master_def_seq,
                              mi_master_def_name = s.RS.Name.ToUpper(),
                              mi_barcode_id = s.RVCWL.RMD.B.mi_barcode_id,
                              mi_price = (double)s.RVCWL.RMD.DP.P.mi_price,
                              slu_def_name = s.RVCWL.S.slu_def_name,
                              mi_icon_path = s.RVCWL.RMD.DP.D.mi_icon_path,
                              rvc_mi_second_name = s.RVCWL.RMD.DP.D.rvc_mi_second_name,
                              rvc_mi_third_name = s.RS.Remark,
                              slu_type_slu_image = s.RVCWL.S.slu_type_slu_image,
                              slu_priority = (int)s.RVCWL.RMD.DP.D.slu_priority,
                              control_number = s.RVCWL.S.control_number
                          }).OrderBy(o => o.control_number).ThenBy(o => o.slu_priority).ToList();
                    var menuitemList = repo.TGetList(x=>x.slu_seq==id);
                   
                    condimentNonRequired = menuitemList.Join(condimentRelation.TGetList(), MI => MI.condiment_main_group_def_seq, CR => CR.relation_seq, (MI, CR) => new
                    {
                        CR = CR,
                        MI = MI
                    }).Join(condimentMenuItemRelation.TGetList(), R => R.CR.condiment_sub_group_def_seq, CMR => CMR.condiment_sub_group_def_seq, (R, CMR) => new
                    {
                        R = R,
                        CMR = CMR
                    }).Join(repo.TGetList(), R => R.CMR.mi_master_def_seq, MI => MI.mi_master_def_seq, (R, MI) => new {
                        R = R,
                        MI = MI
                    }).Join(rvcMenuItemDefWithLanguageRepository.TGetList(x => x.LanguageId == languageId), R => R.MI.mi_master_def_seq, MIL => MIL.RvcMenuItemDefSeq, (R, MIL) => new Condiment
                    {
                        mi_master_def_name = MIL.Name,
                        mi_price = RvcMenuItemPrice.TGetList(x => x.mi_master_def_seq == R.MI.mi_master_def_seq && x.rvc_mi_price_no == 1).FirstOrDefault() == null ? 0 : RvcMenuItemPrice.TGetList(x => x.mi_master_def_seq == R.MI.mi_master_def_seq && x.rvc_mi_price_no == 1).FirstOrDefault().rvc_mi_price_seq,
                        mi_master_def_seq = R.R.R.MI.mi_master_def_seq,
                        mi_icon_path = R.MI.mi_icon_path

                    }).ToList();

                    var condimentRequired2= menuitemList.Join(condimentRelation.TGetList(), MI => MI.condiment_profile_def_seq, CR => CR.relation_seq, (MI, CR) => new
                     {
                         CR = CR,
                         MI = MI
                     }).Join(condimentMenuItemRelation.TGetList(), R => R.CR.condiment_sub_group_def_seq, CMR => CMR.condiment_sub_group_def_seq, (R, CMR) => new
                     {
                         R = R,
                         CMR = CMR
                     }).Join(repo.TGetList(), R => R.CMR.mi_master_def_seq, MI => MI.mi_master_def_seq, (R, MI) => new                      {
                         R = R,
                         MI = MI
                     }).Join(rvcMenuItemDefWithLanguageRepository.TGetList(x=>x.LanguageId==languageId),R=>R.MI.mi_master_def_seq,MIL=>MIL.RvcMenuItemDefSeq,(R,MIL)=>new Condiment
                     {
                         mi_master_def_name = MIL.Name,
                         mi_price = RvcMenuItemPrice.TGetList(x=>x.mi_master_def_seq==R.MI.mi_master_def_seq && x.rvc_mi_price_no==1).FirstOrDefault()==null?0: RvcMenuItemPrice.TGetList(x => x.mi_master_def_seq == R.MI.mi_master_def_seq && x.rvc_mi_price_no == 1).FirstOrDefault().rvc_mi_price_seq,
                         mi_master_def_seq = R.R.R.MI.mi_master_def_seq,
                         mi_icon_path = R.MI.mi_icon_path

                     }).ToList();
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
        public List<GetMenuItems> GetMenuItemsWithId(long id)
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
                          .Join(MenuItemBarcodeDef.TGetList(), DP => DP.D.mi_master_def_seq, B => B.mi_master_def_seq, (DP, B) => new
                          {
                              DP = DP,
                              B = B
                          })
                          .Join(SluDef.TGetList(), RMD => RMD.DP.D.slu_seq, SL => SL.slu_def_seq, (RMD, S) => new
                          {
                              RMD = RMD,
                              S = S
                          }).Where(w => w.RMD.DP.D.mi_is_active == 1 && w.RMD.DP.D.rvc_def_seq == 2 && (w.RMD.DP.D.mi_master_def_type == "menuitem" || w.RMD.DP.D.mi_master_def_type == "condiment") && w.RMD.DP.P.mi_price_number == 1 && w.RMD.DP.D.slu_seq==id)
                          .Select(s => new GetMenuItems
                          {
                              slu_def_seq_view = s.S.slu_def_seq,
                              mi_master_def_seq = (long)s.RMD.DP.D.mi_master_def_seq,
                              mi_master_def_name = s.RMD.DP.D.mi_master_def_name.ToUpper(),
                              mi_barcode_id = s.RMD.B.mi_barcode_id,
                              mi_price = (double)s.RMD.DP.P.mi_price,
                              slu_def_name = s.S.slu_def_name,
                              mi_icon_path = s.RMD.DP.D.mi_icon_path,
                              rvc_mi_second_name = s.RMD.DP.D.rvc_mi_second_name,
                              //rvc_mi_third_name = s.Remark,
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
