using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class MediaTypesManager : BllBase<MediaType, MediaTypeModel>, IMediaTypesService
    {
        public readonly IMediaTypesRepository repo;
        public MediaTypesManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IMediaTypesRepository>();
        }
        public List<MediaType> GetMediaType()
        {
            return TGetList(i => i.Status == true).OrderByDescending(i => i.DisplayOrderID).ToList();
        }
        public List<SelectListItem> GetMediaTypeDefListForDropdown(int GrupId)
        {

            List<SelectListItem> list = (from x in TGetList(i => i.Status == true && i.GroupID == GrupId).OrderByDescending(i => i.DisplayOrderID).ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.Name,
                                             Value = x.MediaTypeID.ToString()
                                         }).ToList();
            return list;

        }


        public List<SelectListItem> GetAllMediaType()
        {
            return TGetList(w => w.Status == true).Select(s => new SelectListItem
            {
                Value = s.MediaTypeSeqID.ToString(),
                Text = s.Name
            }).ToList();
        }
    }
}
