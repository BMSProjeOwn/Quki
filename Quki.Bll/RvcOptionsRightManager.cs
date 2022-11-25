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
    public class RvcOptionsRightManager:BllBase<RvcOptionsRight,RvcOptionsRightModel>,IRvcOptionsRightService
    {
        public RvcOptionsRightManager(IServiceProvider service) : base(service)
        {
           


        }

    }
}
