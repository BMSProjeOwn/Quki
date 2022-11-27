using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class LanguageManager : BllBase<Languages, LanguageApiModel>, ILanguageService
    {
        public readonly ILanguageRepository repo;
        public LanguageManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<ILanguageRepository>();
        }
        public List<LanguageItem> GetAllLanguages()
        {
            return TGetList(w => w.Status == true).Select(s => new LanguageItem
            {
                ID = s.LanguageID,
                Name = s.Name,
                Code = s.CultureName
            }).ToList();
        }

        public List<SelectListItem> GetAllLanguages2()
        {
            return TGetList(w => w.Status == true).Select(s => new SelectListItem
            {
                Value = s.LanguageID.ToString(),
                Text = s.Name
            }).ToList();
        }

    }
}
