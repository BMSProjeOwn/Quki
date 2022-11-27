using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class MediaTypesRepository : GenericRepository<MediaType>, IMediaTypesRepository
    {
        public MediaTypesRepository(DbContext context):base(context)
        {

        }
        //public List<MediaType> GetMediaType()
        //{
        //    return dbset.Where(i => i.Status == true).OrderByDescending(i => i.DisplayOrderID).ToList();
        //}
        //public List<SelectListItem> GetMediaTypeDefListForDropdown(int GrupId)
        //{

        //    List<SelectListItem> list = (from x in dbset.Where(i => i.Status == true &&i.GroupID==GrupId).OrderByDescending(i => i.DisplayOrderID).ToList()
        //                                 select new SelectListItem
        //                                 {
        //                                     Text = x.Name,
        //                                     Value = x.MediaTypeID.ToString()
        //                                 }).ToList();
        //    return list;

        //}


        //public List<SelectListItem> GetAllMediaType()
        //{
        //    return dbset.Where(w => w.Status == true).Select(s => new SelectListItem
        //    {
        //        Value = s.MediaTypeSeqID.ToString(),
        //        Text = s.Name
        //    }).ToList();
        //}
    }
}
