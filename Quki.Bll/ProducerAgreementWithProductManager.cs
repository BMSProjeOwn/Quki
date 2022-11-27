using System;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class ProducerAgreementWithProductManager : BllBase<ProducerAgreementWithProduct,ProducerAgreementWithProductModel> ,IProducerAgreementWithProductService
    {
        public ProducerAgreementWithProductManager(IServiceProvider service) : base(service)
        {
            
        }

    }
}
