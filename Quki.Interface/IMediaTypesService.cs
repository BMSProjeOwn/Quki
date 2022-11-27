using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface IMediaTypesService : IGenericService<MediaType, MediaTypeModel>
    {

        public List<MediaType> GetMediaType();
        public List<SelectListItem> GetMediaTypeDefListForDropdown(int GrupId);
        public List<SelectListItem> GetAllMediaType();
    }
}
