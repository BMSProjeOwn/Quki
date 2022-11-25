using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface ILanguageService : IGenericService<Languages, LanguageApiModel>
    {

        public List<LanguageItem> GetAllLanguages();
        public List<SelectListItem> GetAllLanguages2();
        
    }
}
