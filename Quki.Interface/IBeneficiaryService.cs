using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface IBeneficiaryService : IGenericService<Producer, ProducersAddModel>
    {
        public List<ProducersAgreementModel> getProducersList();
        public bool GetProducerByName(string producerName, int producerTypeId);
        public bool ProducersAdd(ProducersAddModel Item);
        public List<SelectListItem> GetProducerGroupIDListForDropdown();
        public List<SelectListItem> GetProducerTypeListForDropdown();
        public ProducersAddModel getProducersByID(int id);
        public bool UpdateProducers(ProducersAddModel model);
        public List<SelectListItem> GetAllBeneficiary();
        public bool ProducerDeleteById(int id);
    }
}
