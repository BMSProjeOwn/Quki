using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Dal.Abstract
{
    public interface IAgreementRepository : IGenericRepository<ProducerAgreement>
    {
        //public List<ProducerAgreement> AgreementList();
        //public bool AgreementAdd(AddAgreementModel Item);
        //public UpdateAgreementModel AgreementGetUpdateValue(long id);
        //public bool AgreementUpdate(UpdateAgreementModel Item);
        //public bool AgreementDelete(int id);
        //public List<SelectListItem> GetAllAgreement();
        //public List<SelectListItem> GetAgreementByProducerSeqID(int ProducerSeqID);
        
    }
}
