using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;

namespace Quki.Dal.Abstract
{
    public interface IPaymentChanelWithDeviceTypeRepository : IGenericRepository<PaymentChanelWithDeviceType>
    {

        public List<PaymentChannel> GetPaymentChanelListByDeviceTypeAndPricePlane(int pricePalneSeqId, string deviceType);
    }
}
