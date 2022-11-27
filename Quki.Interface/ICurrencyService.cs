using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface ICurrencyService : IGenericService<Currency, CurrencyModel>
    {

        public List<SelectListItem> GetAllCurrency();
        
    }
}
