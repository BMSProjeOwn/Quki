using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface ICategoryService : IGenericService<Category, CategoryAddModel>
    {

        public List<Category> GetAllCategori(int languagaeId);
        public List<Category> GetAllCategori();
        public List<Category> CategoriGetAllActive();
        public List<Category> CategoriGetTopCount(int productCount, int languageId);

        public List<SelectListItem> GetDepartmanListForDropdown();
        public bool AddCartegoryByModel(CategoryAddModel Item);
        public List<FliterListItem> GetAllCategoriForApi();
        public List<Quki.Entity.DtoModels.ApiModels.Filter> GetHomeCategoriForApi(int LanguageID);
        public bool CategoryDeleteById(int id);
    }
}
