using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class RvcMenuItemsDefRepository: GenericRepository<RvcMenuItemDef>,IRvcMenuItemDefRepository
    {
        RvcOptionRightRepository rvcOptionRightRepository;
        
        public RvcMenuItemsDefRepository(DbContext context) : base(context)
        {

        }
        public List<RvcMenuItemDef> GetAll()
        {
            
            var rvcMenuList = TGetList(w => w.mi_is_active == 1).ToList();
           

            return rvcMenuList;
        }

        //public List<GetMenuItems> GetAllProductAndProp()
        //{
        //    using var context = new ProjeDBZuposDBContext();
        //    var isOnline = context.RvcOptionsRight
        //       .Where(w => w.rvc_def_seq == 2 && w.rvc_options_def_code == "rvc_opt_code_Online_Order")
        //       .FirstOrDefault();
        //    if (isOnline != null)
        //    {
        //        if (isOnline.rvc_options_def_status == true)
        //        {
        //            var itemList = context.RvcMenuItemDef
        //                  .Join(context.RvcMenuItemPrice, RMD => RMD.mi_master_def_seq, RMP => RMP.mi_master_def_seq, (D, P) => new
        //                  {
        //                      D = D,
        //                      P = P
        //                  })
        //                  .Join(context.MenuItemBarcodeDef, DP => DP.D.mi_master_def_seq, B => B.mi_master_def_seq, (DP, B) => new
        //                  {
        //                      DP = DP,
        //                      B = B
        //                  })
        //                  .Join(context.SluDef, RMD => RMD.DP.D.slu_seq, SL => SL.slu_def_seq, (RMD, S) => new
        //                  {
        //                      RMD = RMD,
        //                      S = S
        //                  })
        //                  .Where(w => w.RMD.DP.D.mi_is_active == true && w.RMD.DP.D.rvc_def_seq == 2 && (w.RMD.DP.D.mi_master_def_type == "menuitem" || w.RMD.DP.D.mi_master_def_type == "condiment") && w.RMD.DP.P.mi_price_number == 1 && w.RMD.DP.P.rvc_def_seq == rvc_def_seq)
        //                  .Select(s => new GetMenuItems
        //                  {
        //                      mi_master_def_seq = s.RMD.DP.D.mi_master_def_seq,
        //                      mi_master_def_name = s.RMD.DP.D.mi_master_def_name,
        //                      mi_barcode_id = s.RMD.B.mi_barcode_id,
        //                      mi_price = s.RMD.DP.P.mi_price,
        //                      slu_def_name = s.S.slu_def_name,
        //                      mi_icon_path = s.RMD.DP.D.mi_icon_path,
        //                      rvc_mi_second_name = s.RMD.DP.D.rvc_mi_second_name,
        //                      rvc_mi_third_name = s.RMD.DP.D.rvc_mi_third_name,
        //                      slu_priority = s.RMD.DP.D.slu_priority,
        //                      control_number = s.S.control_number
        //                  }).OrderBy(o => o.control_number).ThenBy(o => o.slu_priority).ToList();

        //            return itemList;

        //        }
        //    }
        //    return null;
            
        //}

    }
}
