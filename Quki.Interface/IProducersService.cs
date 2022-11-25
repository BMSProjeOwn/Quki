
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Entity.Parameters;
using Quki.Entity.ViewModel;

namespace Quki.Interface
{
    public interface IProducersService : IGenericService<Producer, ProducersAddModel>
    {
        public List<Producer> GetLastProducer(int count); // ilk 8 seslendireni getir
        public List<Producer> getProducersLitForHomePage();
        public List<SelectListItem> GetProducerTypeListForDropdown();
        public List<SelectListItem> GetProducerListForDropdown();
        public bool ProducersAdd(ProducersAddModel Item);
        public ProducersAddModel getProducersByID(int id);
        public bool UpdateProducers(ProducersAddModel model);
        #region Onder

        public ProducerDetailModel GetProducerDetailByProducerID(int prodcureID, int languageId);
        public List<ProducersModel> getProducersLit();
        public List<ProducersModel> getProducersLitApi();
        public List<ViewValueItems> getProducersLitMainMenu(int Count, string customer_def_no);
        public List<ProductDetailForMobile> GetProductDetailByProducerID(int ProducerSeqID, string customer_def_no, int count);
        public ProducersApiDetailModel GetProducerByIDApi(int ProducerSeqID, string customer_def_no, int count);
        public List<Menu> GetUserMenusForDocument(int LanguageID);
        public PerformerGroup GetHomeProducerGroupApi(int GroupID, string customer_def_no, int count, int languageId);
        public List<Performer> getHomeProducersList(int Count, string customer_def_no);
        public List<Product> GetProductByPerformerID(int ProducerSeqID, string customer_def_no, int count, int languageId);
        #endregion Onder
        public bool ProducerDeleteById(int id);
        public bool GetProducerByName(string producerName, int producerTypeId);
        public List<ProducerTypeModel> GetProducerTypeListForCheckBox();

    }
}
