using System.Collections.Generic;
using System.Linq;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface IPaymentChanelWithDeviceTypeService : IGenericService<PaymentChanelWithDeviceType, PaymentChanelWithDeviceTypeModel>
    {
        
        public List<PaymentChannel> GetPaymentChanelListByDeviceTypeAndPricePlane(int pricePalneSeqId, string deviceType);
    }
}
