using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Models;

namespace Quki.Entity.ViewModel
{
    public class ProductSearchViewModel
    {
        public string ProductName { get; set; }
        public List<Products> PorductList { get; set; }
    }
}
