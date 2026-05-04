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
        public readonly Islu_Rvc_RelationRepository rvc_RelationRepository;
        

        
        public RvcMenuItemDefManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IRvcMenuItemDefRepository>();
            RvcOptionsRight = service.GetService<IRvcOptionsRightRepository>();
            SluDef = service.GetService<ISluDefRepository>();
            RvcMenuItemPrice = service.GetService<IRvcMenuItemPriceRepository>();
            MenuItemBarcodeDef = service.GetService<IMenuItemBarcodeDefRepository>();
            rvcMenuItemDefWithLanguageRepository = service.GetService<IRvcMenuItemDefWithLanguageRepository>();
            sluDefWithLanguageRepository = service.GetService<ISluDefWithLanguageRepository>();
            rvc_RelationRepository = service.GetService<Islu_Rvc_RelationRepository>();
           

        }

        public List<RvcMenuItemDef> GetAllRvcMenuItems()
        {
            
            var allMenuItems = repo.GetAll().ToList();
            

            return allMenuItems;
        }

        public List<GetMenuItems> GetMenuItems(int languageId,long rvc_def_seq)
        {
            List<GetMenuItems> itemList = new List<GetMenuItems>();
            var isOnline = RvcOptionsRight.TGetList(w => w.rvc_def_seq == 2 && w.rvc_options_def_code == "rvc_opt_code_Online_Order")
               .FirstOrDefault();
            if (isOnline != null)
            {
                if (isOnline.rvc_options_def_status == 1)
                {// 1️⃣ Önce gerekli listeleri IQueryable olarak al
                    var menuItems = repo.TGetList();
                    var prices = RvcMenuItemPrice.TGetList();
                    var barcodes = MenuItemBarcodeDef.TGetList();
                    var langDefs = rvcMenuItemDefWithLanguageRepository.TGetList();
                    var slus = SluDef.TGetList();
                    var relations = rvc_RelationRepository.TGetList();

                    // 2️⃣ SluDefWithLanguage sadece 1 kere çek
                    var sluLangName = sluDefWithLanguageRepository
                                        .TGetList(x => x.LanguageId == languageId)
                                        .Select(x => x.Name)
                                        .FirstOrDefault();

                    itemList = (
                        from d in menuItems
                        join p in prices on d.mi_master_def_seq equals p.mi_master_def_seq
                        join b in barcodes on d.mi_master_def_seq equals b.mi_master_def_seq
                        join rs in langDefs on p.mi_master_def_seq equals rs.RvcMenuItemDefSeq
                        join s in slus on ConvertToLong(rs.Option1) equals s.slu_def_seq
                        join rel in relations on d.slu_seq equals rel.slu_seq
                        where rs.Option2 == "1"
                              && rel.rvc_seq == rvc_def_seq
                              && (d.mi_master_def_type == "menuitem" || d.mi_master_def_type == "condiment")
                              && p.mi_price_number == 1
                              && rs.LanguageId == languageId
                        orderby s.control_number, rs.Option3
                        select new GetMenuItems
                        {
                            slu_def_seq_view = s.slu_def_seq,
                            mi_master_def_seq = d.mi_master_def_seq,
                            mi_master_def_name = rs.Name.ToUpper(),
                            mi_barcode_id = b.mi_barcode_id,
                            mi_price = (double)p.mi_price,
                            slu_def_name = sluLangName != null ? sluLangName.ToUpper() : "",
                            mi_icon_path = d.mi_icon_path,
                            rvc_mi_second_name = d.rvc_mi_second_name,
                            rvc_mi_third_name = rs.Remark,
                            slu_priority = d.slu_priority ?? 0,
                            control_number = s.control_number ?? 0
                        }
                    ).ToList();
                }
            }
            return itemList;
        }
        public long ConvertToLong(string value)
        {
            if (long.TryParse(value, out long result))
            {
                return result;
            }
            return 0; // veya uygun bir varsayılan değer
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
                              mi_master_def_name = s.RMD.D.mi_master_def_name.ToUpper(),
                              mi_price = (double)s.RMD.P.mi_price,
                              slu_def_name = s.S.slu_def_name.ToUpper(),
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
                              mi_master_def_name = s.RS.Name.ToUpper(),
                              mi_price = (double)s.RVCWL.RMD.P.mi_price,
                              slu_def_name = sluDefWithLanguageRepository.TGetList(x => x.SluDefSeq == s.RVCWL.RMD.D.slu_seq && x.LanguageId == languageId).FirstOrDefault().Name.ToUpper(),
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
