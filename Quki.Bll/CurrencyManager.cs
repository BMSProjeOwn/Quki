using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class CurrencyManager : BllBase<Currency, CurrencyModel>, ICurrencyService
    {
        public readonly ICurrencyRepository repo;

        public CurrencyManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<ICurrencyRepository>();
        }
        public List<SelectListItem> GetAllCurrency() {
            return TGetList().Select(s => new SelectListItem
            {
                Value = s.CurrencyID.ToString(),
                Text = s.CurrencyName
            }).ToList();
        }
        
    }
}
