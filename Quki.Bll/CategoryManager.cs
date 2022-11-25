using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Quki.Bll.Base;
using Quki.Common;
using Quki.Dal.Abstract;

using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Entity.Parameters;
using Quki.Interface;
namespace Quki.Bll
{
    public class CategoryManager : BllBase<Category, CategoryAddModel>, ICategoryService
    {
        public readonly ICategoryRepository repo;
        public readonly IDepartmentsRepository departmentsRepository;

        public CategoryManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<ICategoryRepository>();
            departmentsRepository = service.GetService<IDepartmentsRepository>();
        }
        public List<Category> GetAllCategori(int languagaeId)
        {

            return repo.GetAllCategori(languagaeId) ;
        }

        public List<Category> GetAllCategori() 
        {
            return repo.GetAllCategori();
        }

        public List<Category> CategoriGetAllActive()
        {
            var categories = TGetList(x => x.Status == true).ToList();
            return categories;
        }
        public List<Category> CategoriGetTopCount(int productCount, int languageId)
        {
            var items = TGetList(u => u.Status == true && u.LanguageID.Equals(languageId)).OrderByDescending(u => u.DisplayOrderNumber).Take(productCount);
            return items.ToList();
        }
        public List<SelectListItem> GetDepartmanListForDropdown()
        {
            List<SelectListItem> list = (from x in departmentsRepository.TGetList(x => x.Status == true).ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.Name,
                                             Value = x.DepartmanSeqID.ToString()
                                         }).ToList();
            return list;
        }
        public bool AddCartegoryByModel(CategoryAddModel Item)
        {
            Category category = new Category();
            category.Name = Item.Name;
            category.Status = Item.Status;
            category.DisplayOrderNumber = (short)Item.DisplayOrderNumber;
            var department = departmentsRepository.TgetItemByID(Item.Depart.DepartmanSeqID);

            category.Depart = null;
            category.DepartmanSeqID = department.DepartmanSeqID;
            category.Description = Item.Description;
            category.LanguageID = Item.LanguageID;
            if (Item.ImagePath != null)
            {
                var path = Path.GetExtension(Item.ImagePath.FileName);
                var newPath = Guid.NewGuid() + path;
                //var FolderPath="/wwwroot/Image/ProductImg/"
                // var ImagePath = Path.Combine("", "/wwwroot/AdminImage/ProductImg/" + newPath);
                //var ImagePath = "/wwwroot/AdminImage/ProductImg/" + newPath;
                var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/CategoryImage/" + newPath;
                var ThumbImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/CategoryImage/Thump" + newPath;
                var steem = new FileStream(ImagePath, FileMode.Create);
                Item.ImagePath.CopyTo(steem);
                Utility.ResizeImage(Item.ImagePath, CategoryImageSize.Height, CategoryImageSize.Width, ThumbImagePath);
                category.ImagePath = "/AdminImage/CategoryImage/Thump" + newPath; ;
            }
            category.CreatedOn = DateTime.Now;

            //context.Categories.Add(Item);
            //context.SaveChanges();
            TAdd(category);
            return true;
        }
        public List<FliterListItem> GetAllCategoriForApi()
        {
            return repo.GetAllCategoriForApi();
        }
        public List<Filter> GetHomeCategoriForApi(int LanguageID)
        {
            return repo.GetHomeCategoriForApi(LanguageID);
        }
        public bool CategoryDeleteById(int id)
        {
            try
            {

                bool result = false;

                var x = TGetList(x => x.CategorySeqID == id).FirstOrDefault();

                x.Status = false;

                TUpdate(x);
                result = true;
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
