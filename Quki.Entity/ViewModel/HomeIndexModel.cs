using System.Collections.Generic;

using Quki.Entity.Models;

namespace Quki.Entity.ViewModel
{
    public class HomeIndexModel
    {
        public List<Category> Category { get; set; }
        public List<Products> ProductsGroup1 { get; set; }
        public List<Products> ProductsGroup2 { get; set; }
        public List<Products> ProductsGroup3 { get; set; }
        public List<Menu> Menu { get; set; }
    }
}
