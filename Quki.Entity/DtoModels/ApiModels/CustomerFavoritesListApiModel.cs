using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Quki.Entity.DtoModels.ApiModels
{
    public class CustomerFavoritesListApiModel : Response
    {
        public List<Product> CustomerFavoritesList { get; set; }
    }
}
