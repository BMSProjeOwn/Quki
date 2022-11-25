using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Entity.Parameters;

namespace Quki.Dal.Abstract
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {

        public List<Category> GetAllCategori(int languagaeId);
        public List<Category> GetAllCategori();
        //public List<Category> CategoriGetAllActive();
        //public List<Category> CategoriGetTopCount(int productCount, int languageId);

        //public List<SelectListItem> GetDepartmanListForDropdown();
        //public bool AddCartegoryByModel(CategoryAddModel Item);
        public List<FliterListItem> GetAllCategoriForApi();
        public List<Filter> GetHomeCategoriForApi(int LanguageID);
        //public bool CategoryDeleteById(int id);
    }
}
