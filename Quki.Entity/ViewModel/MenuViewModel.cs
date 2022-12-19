using Quki.Entity.DtoModels;
using Quki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Entity.ViewModel
{
    public class MenuViewModel
    {
        public List<SluDefModel> sluDefModels = new List<SluDefModel>();
        public List<GetMenuItems> getMenuItems= new List<GetMenuItems>();
    }
}
