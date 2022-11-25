using Microsoft.Extensions.DependencyInjection;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Bll
{
    public class SluDefManager:BllBase<SluDef,SluDefModel>,ISluDefService
    {
        public readonly ISluDefRepository repo;
        public SluDefManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<ISluDefRepository>();


        }

       /* public List<SluDefModel> GetAllSluDef()
        {
            var sluDef = repo.TGetList(x=>x.).ToList();

        
        }*/
    }
}
