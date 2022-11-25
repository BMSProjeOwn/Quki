using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Quki.Entity.DtoModels.ApiModels
{
    public class ApiFavoritesListType : Response
    {
        public List<FavoritesListTypes> FavoritesListType { get; set; }
    }

    public class FavoritesListTypes
    {
        public int? favoritesTypeID { get; set; }
        public string favoritesTypeName { get; set; }
    }
}
