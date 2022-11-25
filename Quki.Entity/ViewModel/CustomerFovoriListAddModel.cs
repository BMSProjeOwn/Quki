using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.ViewModel
{
    public class CustomerFovoriListApiModel : DtoBase
    {
        public string customerDefNo { get; set; }
        public int FavoritesListDefSeqID { get; set; }
        public int productId { get; set; }
        public int GroupID { get; set; }
    }
}
