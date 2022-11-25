using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels.ApiModels
{
    public class PlayListModelApi
    {
        public int? PlayListSeqID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public List<Product> productList { get; set; }
    }

    public class PlayListDetailModelApi
    {
        public int PlayListDetailSeqID { get; set; }
        public int? ProductSeqID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int? DisplayOrderNumber { get; set; }
    }

    public class CreatePlayListRequest
    {
        public int languageId { get; set; }
        public string customerDefNo { get; set; }
        public string playListName { get; set; }
        public string imagePath { get; set; }
    }

    public class GetAllPlayListApi : Response
    {
        public List<PlayListModelApi> PlayList { get; set; }
    }

    public class GetAllPlayListCreateApi : Response
    {
        public PlayListModelApi PlayList { get; set; }
    }

    public class PlayListProductApiRequest
    {
        public int languageId { get; set; }
        public int playListID { get; set; }
        public string customerDefNo { get; set; }
        public List<PlayListChangeOrderDisPlayNo> playList { get; set; }
    }

    public class PlayListChangeOrderDisPlayNo
    {
        public int productID { get; set; }
        public int displayOrderNumber { get; set; }
    }

    public class PlayListAddOrDeleteRequest
    {
        public int languageId { get; set; }
        public int productID { get; set; }
        public int displayOrderNumber { get; set; }
        public int playListID { get; set; }
        public string customerDefNo { get; set; }
    }

}
