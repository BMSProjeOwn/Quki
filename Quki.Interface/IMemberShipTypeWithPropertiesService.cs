using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface IMemberShipTypeWithPropertiesService : IGenericService<MemberShipTypeWithProperties, MemberShipTypeWithPropertiessAddModel>
        
    { public MemberShipTypeWithProperties GetMemberShipTypeWithProperties(int MemberShipTypeSeqID, int MemberShipPropertiesSeqID);
        public List<MemberShipTypeWithProperties> GetMemberShipTypeWithPropertyList(int MemberShipTypeSeqID);
        public List<MembershipProperties> GetMemberShipTypeWithProperties(int MemberShipTypeSeqID);
        public List<MembershipProperties> GetMembershipPricePlaneProperties(int MemberShipPricePlanSeqId);
        public void AddMemberShipTypeWithPropertie(MemberShipTypeWithProperties Item);
        public void UpdateMemberShipTypeWithProperties(MemberShipTypeWithProperties Item);
        public void DeleteMemberShipTypeWithPropertie(MemberShipTypeWithProperties Item);
        public List<MemberShipProperties> SelectCustomerMemberShipTypeWithPropertiesApi(string customer_def_no);
        public string PropertiesValue(string customer_def_no, int MemberShipTypeSeqID, string StartValue, string EndValue, string FunctionName);
        public MemberShipStatus SelectCustomerMemberShipStatus(string customer_def_no, int MemberShipPropertiesID);
        public Response ListenPermissionControlSP(string customer_def_no, int languageId);
        public Response DownloadPermissionControlSP(string customer_def_no, int languageId);
        public int CreateProfileRightCount(string customer_def_no);
    public class MemberShipPropertiesFunctions
        {
            public static string FunctionIsTemporaryProductListening = "FunctionIsTemporaryProductListening";
            public static string UseMemeberhipTypeXMonth = "UseMemeberhipTypeXMonth";
            public static string UseMemeberhipTypeXMonthRate = "UseMemeberhipTypeXMonthRate";
        } 
    }
}
