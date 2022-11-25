using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels.ApiModels
{
    public class GetAllMemberShipTypeApi
    {
    }

    public class GetAllMemberShipTypeApiRequest
    {
        public int languageId { get; set; }
        public string currencyName { get; set; }
        public string countryCode { get; set; }
        public string deviceType { get; set; }
        public int subribitionTypeStatus { get; set; }
    }
    public class GetAllMemberShipTypeApiResponse : Response
    {
        public List<GetAllMemberShipTypeModel> memberShipTypeList { get; set; }
    }
    public class GetAllMemberShipTypeRefenransCodeApiResponse : Response
    {
        public List<GetAllMemberShipTypeReferansCodeModel> pricePlaneCodeList { get; set; }
    }

    public class GetAllMemberShipTypeModel
    {
        public GetAllMemberShipTypePricePlaneModel pricePlane { get; set; }
        public List<GetAllMemberShipTypePropertiesModel> membershipTypePropertyList { get; set; }
        public List<GetAllMemberShipTypePaymentChanelModel> membershipTypePaymentChanelList { get; set; }
        public int memberShipTypeId { get; set; }
        public string memberShipTypeName { get; set; }
    }
    public class GetAllMemberShipTypeReferansCodeModel
    {
        public int pricePlaneId { get; set; }
        public string pricePlaneReferansCode { get; set; }
    }

    public class GetAllMemberShipTypePricePlaneModel
    {
        public int pricePlaneId { get; set; }
        public int memberShipTypeId { get; set; }
        public string pricePlaneName { get; set; }
        public decimal price { get; set; }
        public int autoRenewalCount { get; set; }
        public int PaymentPeriod { get; set; }
        public string paymentPeriodName { get; set; }
        public string pricePlaneReferansCode { get; set; }
        public int freeDay { get; set; }
        public string currencyName { get; set; }
    }
    public class GetAllMemberShipTypePropertiesModel
    {
        public int propertyId { get; set; }
        public int languageID { get; set; }
        public string Name { get; set; }
    }

    public class GetAllMemberShipTypePaymentChanelModel
    {
        public int paymentChaneId { get; set; }
        public string paymentChaneName { get; set; }
    }
}
