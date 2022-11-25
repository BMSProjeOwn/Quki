using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Quki.Dal.Abstract;

using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Entity.Parameters;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context):base(context)
        {
        }
        public List<Category> GetAllCategori(int languagaeId)
        {
            var categories = dbset.Where(x => x.Status == true && x.LanguageID == languagaeId).Include(x => x.Depart).ToList();
            return categories;
        }
        public List<Category> GetAllCategori()
        {
            var categories = dbset.Where(x => x.Status == true).ToList();
            return categories;
        }

        //public List<Category> CategoriGetAllActive()
        //{
        //    var categories = dbset.Where(x => x.Status == true).ToList();
        //    return categories;
        //}

        //public List<Category> CategoriGetTopCount(int productCount,int languageId)
        //{
        //    var items = dbset.Where(u => u.Status == true && u.LanguageID.Equals(languageId)).OrderByDescending(u => u.DisplayOrderNumber).Take(productCount);
        //    return items.ToList();
        //}

        //public List<SelectListItem> GetDepartmanListForDropdown()
        //{
        //    List<SelectListItem> list = (from x in context.Set<TDepart>().Where(x=>x.Status==true).ToList()
        //                                 select new SelectListItem
        //                                 {
        //                                     Text = x.Name,
        //                                     Value = x.DepartmanSeqID.ToString()
        //                                 }).ToList();
        //    return list;
        //}

        //public bool AddCartegoryByModel(CategoryAddModel Item)
        //{
        //    Category category = new Category();
        //    category.Name = Item.Name;
        //    category.Status = Item.Status;
        //    category.DisplayOrderNumber = (short)Item.DisplayOrderNumber;
        //    DepartmentsRepository departmentsRepository = new DepartmentsRepository(context);
        //    var department = departmentsRepository.TgetItemByID(Item.Depart.DepartmanSeqID);

        //    category.Depart = null;
        //    category.DepartmanSeqID = department.DepartmanSeqID;
        //    category.Description = Item.Description;
        //    category.LanguageID = Item.LanguageID;
        //    if (Item.ImagePath != null)
        //    {
        //        var path = Path.GetExtension(Item.ImagePath.FileName);
        //        var newPath = Guid.NewGuid() + path;
        //        //var FolderPath="/wwwroot/Image/ProductImg/"
        //        // var ImagePath = Path.Combine("", "/wwwroot/AdminImage/ProductImg/" + newPath);
        //        //var ImagePath = "/wwwroot/AdminImage/ProductImg/" + newPath;
        //        var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/CategoryImage/" + newPath;
        //        var ThumbImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/CategoryImage/Thump" + newPath;
        //        var steem = new FileStream(ImagePath, FileMode.Create);
        //        Item.ImagePath.CopyTo(steem);
        //        Utility.ResizeImage(Item.ImagePath, CategoryImageSize.Height, CategoryImageSize.Width, ThumbImagePath);
        //        category.ImagePath = "/AdminImage/CategoryImage/Thump" + newPath; ;
        //    }
        //    category.CreatedOn = DateTime.Now;

        //    //context.Categories.Add(Item);
        //    //context.SaveChanges();
        //    TAdd(category);
        //    return true;
        //}

        public List<FliterListItem> GetAllCategoriForApi()
        {
            var categories = dbset.Include(x => x.Depart).Select(s => new FliterListItem
            {
                ID = s.CategorySeqID,
                Name = s.Name,
                ImagePath = ApiParameters.URL + s.ImagePath
            }).ToList();
            return categories;
        }

        public List<Filter> GetHomeCategoriForApi(int LanguageID)
        {
            var categories = dbset.Include(x => x.Depart).Where(w => w.Status == true && w.LanguageID == LanguageID).Select(s => new Quki.Entity.DtoModels.ApiModels.Filter
            {
                filterId = s.CategorySeqID,
                name = s.Name,
                ImagePath = ApiParameters.URL + s.ImagePath
            }).ToList();
            return categories;
        }

        //public bool CategoryDeleteById(int id)
        //{
        //    bool result = false;

        //    var x = dbset.Where(x => x.CategorySeqID == id).FirstOrDefault();

        //    x.Status = false;

        //    TUpdate(x);
        //    result = true;
        //    return result;
        //}
    }
}
