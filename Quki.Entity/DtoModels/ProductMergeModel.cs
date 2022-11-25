using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels
{
    public class ProductMergeModel
    {
        public List<CategoryAtaModel> catagoriAtaListModel { get; set; }
        public List<ProductAttirubuteStaticValueAtaModel> productAttirubuteStaticValueAtaListModel { get; set; }
        public ProductAddModel ProductUpdateModel { get; set; }
        public List<AttributeStaticModel> AttributeStaticListModel { get; set; }
        public List<ProductImageAddModel> ProductImageAddListModel { get; set; }
        public List<ProductWithProducersModel> ProductWithProducersListModel { get; set; }

    }
}
