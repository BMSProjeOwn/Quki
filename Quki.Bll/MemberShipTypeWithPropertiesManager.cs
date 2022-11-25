using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class MemberShipTypeWithPropertiesManager : BllBase<MemberShipTypeWithProperties, MemberShipTypeWithPropertiessAddModel>, IMemberShipTypeWithPropertiesService
    {
        public readonly IMemberShipTypeWithPropertiesRepository repo;
        public readonly IMembershipPropertiesRepository membershipPropertiesRepository;
        public readonly IMemberShipTypeWithPropertiesRepository memberShipTypeWithPropertiesRepository;
        public readonly IMembershipTypePricePlaneRepository membershipTypePricePlaneRepository;
        public readonly IMemberShipTypeWithCustomerRepository memberShipTypeWithCustomerRepository;
        public readonly ICustomerTrackingTypeRepository customerTrackingTypeRepository;
        public readonly IPaymentsRepository paymentsRepository;
        public MemberShipTypeWithPropertiesManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IMemberShipTypeWithPropertiesRepository>();
            membershipPropertiesRepository = service.GetService<IMembershipPropertiesRepository>();
            memberShipTypeWithPropertiesRepository = service.GetService<IMemberShipTypeWithPropertiesRepository>();
            membershipTypePricePlaneRepository = service.GetService<IMembershipTypePricePlaneRepository>();
            memberShipTypeWithCustomerRepository = service.GetService<IMemberShipTypeWithCustomerRepository>();
            customerTrackingTypeRepository = service.GetService<ICustomerTrackingTypeRepository>();
            paymentsRepository = service.GetService<IPaymentsRepository>();
        }
        public MemberShipTypeWithProperties GetMemberShipTypeWithProperties(int MemberShipTypeSeqID, int MemberShipPropertiesSeqID)
        {

            return TGetList(p => p.MemberShipTypeSeqID == MemberShipTypeSeqID && p.MemberShipPropertiesSeqID == MemberShipPropertiesSeqID).FirstOrDefault();
        }

        public List<MemberShipTypeWithProperties> GetMemberShipTypeWithPropertyList(int MemberShipTypeSeqID)
        {

            return TGetList(p => p.MemberShipTypeSeqID == MemberShipTypeSeqID).ToList();
        }

        public List<MembershipProperties> GetMemberShipTypeWithProperties(int MemberShipTypeSeqID)
        {
            var MembershipProperties = membershipPropertiesRepository.TGetList().Join(memberShipTypeWithPropertiesRepository.TGetList(), MemberShipTypeWithPropertiess => MemberShipTypeWithPropertiess.MemberShipPropertiesSeqID, MembershipProperties => MembershipProperties.MemberShipPropertiesSeqID, (MSP, MSTWP) => new
            {
                MembershipProperties = MSP,
                MemberShipTypeWithPropertiess = MSTWP
            }).Where(I => I.MembershipProperties.Status == true && I.MemberShipTypeWithPropertiess.MemberShipTypeSeqID == MemberShipTypeSeqID && I.MemberShipTypeWithPropertiess.IsshowScreen.Equals(true)).Select(I => new MembershipProperties
            {
                Name = I.MembershipProperties.Name
            }).ToList();
            return MembershipProperties;
        }
        public List<MembershipProperties> GetMembershipPricePlaneProperties(int MemberShipPricePlanSeqId)
        {
            var MemberShipTypeInfo = membershipTypePricePlaneRepository.TGetList(x => x.MemberShipTypePricePlaneSeqID.Equals(MemberShipPricePlanSeqId)).FirstOrDefault();
            var MembershipProperties = membershipPropertiesRepository.TGetList().Join(memberShipTypeWithPropertiesRepository.TGetList(), MemberShipTypeWithPropertiess => MemberShipTypeWithPropertiess.MemberShipPropertiesSeqID, MembershipProperties => MembershipProperties.MemberShipPropertiesSeqID, (MSP, MSTWP) => new
            {
                MembershipProperties = MSP,
                MemberShipTypeWithPropertiess = MSTWP
            }).Where(I => I.MembershipProperties.Status == true && I.MemberShipTypeWithPropertiess.MemberShipTypeSeqID == MemberShipTypeInfo.MemberShipTypeSeqID).Select(I => new MembershipProperties
            {
                Name = I.MembershipProperties.Name
            }).ToList();
            return MembershipProperties;
        }
        public void AddMemberShipTypeWithPropertie(MemberShipTypeWithProperties Item)
        {
            var ControlItem = GetMemberShipTypeWithProperties(Item.MemberShipTypeSeqID, Item.MemberShipPropertiesSeqID);
            if (ControlItem == null)
            {
                TAdd(Item);
            }
        }

        public void UpdateMemberShipTypeWithProperties(MemberShipTypeWithProperties Item)
        {
            var ControlItem = GetMemberShipTypeWithProperties(Item.MemberShipTypeSeqID, Item.MemberShipPropertiesSeqID);
            if (ControlItem == null)
            {
                ControlItem.InitialValue = Item.InitialValue;
                TUpdate(Item);
            }
        }

        public void DeleteMemberShipTypeWithPropertie(MemberShipTypeWithProperties Item)
        {
            var ControlItem = GetMemberShipTypeWithProperties(Item.MemberShipTypeSeqID, Item.MemberShipPropertiesSeqID);
            if (ControlItem != null)
            {
                TDelete(Item);
            }
        }

        public List<MemberShipProperties> SelectCustomerMemberShipTypeWithPropertiesApi(string customer_def_no)
        {
            var customerMemberShip = memberShipTypeWithCustomerRepository.TGetList(u => u.Id == customer_def_no && u.IsActive == true).FirstOrDefault();
            int typeID = 0;
            if (customerMemberShip != null)
            {
                typeID = customerMemberShip.MemberShipTypeSeqID;
            }
            else
            {
                return null;
            }


            var allProperties = membershipPropertiesRepository.TGetList(w => w.Status == true).ToList();
            var memberShipTypeProperties = TGetList(w => w.MemberShipTypeSeqID == typeID).ToList();

            List<MemberShipProperties> Properties = new List<MemberShipProperties>();
            foreach (var aProperty in allProperties)
            {
                MemberShipProperties property = new MemberShipProperties();
                property.countryList = new List<int>();
                property.productList = new List<int>();
                property.PropertiesCode = aProperty.MemberShipPropertiesSeqID.ToString();
                property.PropertiesName = aProperty.Name;
                property.PropertiesStatus = 0;
                if (memberShipTypeProperties != null)
                {
                    foreach (var tProperty in memberShipTypeProperties)
                    {
                        if (tProperty.MemberShipPropertiesSeqID == aProperty.MemberShipPropertiesSeqID)
                        {
                            property.PropertiesStatus = 1;
                            if (aProperty.IsDynamic)
                            {
                                property.value = PropertiesValue(customer_def_no, typeID, tProperty.InitialValue, aProperty.EndValue, aProperty.FunctionName);
                                property.countryList.Add(0);
                                property.productList.Add(0);
                            }
                            else
                            {
                                property.value = PropertiesValue(customer_def_no, typeID, aProperty.InitialValue, aProperty.EndValue, aProperty.FunctionName);
                                property.countryList.Add(0);
                                property.productList.Add(0);
                            }
                            break;
                        }
                    }
                }
                Properties.Add(property);
            }
            return Properties;
        }

        public string PropertiesValue(string customer_def_no, int MemberShipTypeSeqID, string StartValue, string EndValue, string FunctionName)
        {
            var custumerMemberShipType = memberShipTypeWithCustomerRepository.TGetList(u => u.Id == customer_def_no && u.IsActive == true).FirstOrDefault();
            var memberShipPricePlanInfo = memberShipTypeWithCustomerRepository.TGetList(u => u.Id == customer_def_no && u.IsActive == true).FirstOrDefault();
            var result = membershipTypePricePlaneRepository.TgetItemByID(memberShipPricePlanInfo.MemberShipTypePricePlaneSeqID);
            MembershipTypePricePlane membershipTypePricePlane = result;

            string returnValue;
            if (FunctionName == MemberShipPropertiesFunctions.FunctionIsTemporaryProductListening)
            {

                if (DateTime.Now.AddDays(Convert.ToInt32(StartValue)) >= custumerMemberShipType.StartDateTime)
                {
                    int? time = customerTrackingTypeRepository.GetCustomerToDayListenTimeApi(customer_def_no);
                    int? timeValue = Convert.ToInt32(EndValue) - time;
                    returnValue = timeValue.ToString();
                }
                else
                {
                    returnValue = "99999999";
                }
            }
            else if (FunctionName == MemberShipPropertiesFunctions.UseMemeberhipTypeXMonth)
            {
                if (custumerMemberShipType.StartDateTime.AddMonths(Convert.ToInt32(StartValue)) <= DateTime.Now)
                {
                    returnValue = "Mounth=1";
                }
                else
                {
                    returnValue = "Mounth=-1";
                }
            }
            else if (FunctionName == MemberShipPropertiesFunctions.UseMemeberhipTypeXMonthRate)
            {

                double totalLastDays = (custumerMemberShipType.EndDateTime - DateTime.Now).TotalDays;

                decimal totalprice = Convert.ToDecimal((membershipTypePricePlane.AutoRenewalCount * Convert.ToDouble(membershipTypePricePlane.Price)).ToString());
                var paymentList = paymentsRepository.
                    TGetList(w => w.Status == 1
&& w.MemberShipTypePricePlaneSeqID == membershipTypePricePlane.MemberShipTypePricePlaneSeqID
&& w.MemberShipTypeWithCustomerSeqID == custumerMemberShipType.MemberShipTypeWithCustomerSeqID);
                decimal totalPayment = 0;
                if (paymentList != null)
                {
                    foreach (var payment in paymentList)
                    {
                        totalPayment = totalPayment + payment.PaymentAmount;
                    }
                }
                totalprice = totalprice - totalPayment;
                totalprice = totalprice - totalprice * Convert.ToInt32(StartValue) / 100;
                totalprice = Decimal.Round(totalprice, 2);
                returnValue = "Price=" + totalprice;
            }
            else
            {
                returnValue = StartValue;
            }
            return returnValue;
        }
        public MemberShipStatus SelectCustomerMemberShipStatus(string customer_def_no, int MemberShipPropertiesID)
        {
            var customerMemberShip = memberShipTypeWithCustomerRepository.TGetList(u => u.Id == customer_def_no && u.IsActive == true).FirstOrDefault(); 
            int typeID = 0;
            MemberShipStatus status = new MemberShipStatus();
            status.message = "Bu İşlemi Yapacak Yetkiniz Bulunmamaktadır!";
            status.status = false;
            if (customerMemberShip != null)
            {
                typeID = customerMemberShip.MemberShipTypeSeqID;
            }
            else
            {
                return status;
            }


            var allProperties = membershipPropertiesRepository.TGetList(w => w.Status == true).ToList();
            var memberShipTypeProperties = TGetList().Join(membershipPropertiesRepository.TGetList(), wp => wp.MemberShipPropertiesSeqID, p => p.MemberShipPropertiesSeqID, (wp, p) => new
            {
                wp = wp,
                p = p
            })
                .Where(w => w.p.MemberShipPropertiesID == MemberShipPropertiesID).Select(s => s.wp).ToList();

            foreach (var aProperty in allProperties)
            {

                if (memberShipTypeProperties != null)
                {
                    if (memberShipTypeProperties.Count > 0)
                    {
                        foreach (var tProperty in memberShipTypeProperties)
                        {
                            if (tProperty.MemberShipPropertiesSeqID == aProperty.MemberShipPropertiesSeqID)
                            {
                                if (aProperty.IsDynamic)
                                {
                                    string value = PropertiesValue(customer_def_no, typeID, tProperty.InitialValue, tProperty.EndValue, aProperty.FunctionName);
                                    if (Convert.ToInt64(value) > 0)
                                    {
                                        status.message = "Bu işlem Yapılabilir!";
                                        status.status = true;
                                    }
                                }
                                else
                                {
                                    string value = PropertiesValue(customer_def_no, typeID, aProperty.InitialValue, aProperty.EndValue, aProperty.FunctionName);
                                    if (Convert.ToInt64(value) > 0)
                                    {
                                        status.message = "Bu işlem Yapılabilir!";
                                        status.status = true;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    else
                    {
                        status.message = "Bu işlem Yapılabilir!";
                        status.status = true;
                        break;
                    }
                }
            }
            return status;
        }

        public Response ListenPermissionControlSP(string customer_def_no, int languageId)
        {
            return repo.ListenPermissionControlSP(customer_def_no, languageId);
        }

        public Response DownloadPermissionControlSP(string customer_def_no, int languageId)
        {
            return repo.DownloadPermissionControlSP(customer_def_no, languageId);
        }


        public int CreateProfileRightCount(string customer_def_no)
        {
            int result = 1;
            var customerMemberShip = memberShipTypeWithCustomerRepository.TGetList(u => u.Id == customer_def_no && u.IsActive == true).FirstOrDefault();
            int typeID = 0;
            if (customerMemberShip != null)
            {
                typeID = customerMemberShip.MemberShipTypeSeqID;
                var memberShipTypeProperties = memberShipTypeWithPropertiesRepository.TGetList()
                    .Join(membershipPropertiesRepository.TGetList(), wp => wp.MemberShipPropertiesSeqID, p => p.MemberShipPropertiesSeqID, (wp, p) => new
                    {
                        wp = wp,
                        p = p
                    })
               .Where(w => w.p.FunctionName == "CreateProfileRightCount" && w.wp.IsActive == true && w.p.Status == true && w.wp.MemberShipTypeSeqID == customerMemberShip.MemberShipTypeSeqID)
               .Select(s => s.wp.InitialValue).FirstOrDefault();
                if (memberShipTypeProperties != null)
                {
                    try
                    {
                        result = Convert.ToInt32(memberShipTypeProperties.ToString());
                    }
                    catch
                    {
                        result = 1;
                    }
                }
            }
            return result;
        }


    }

    public class MemberShipPropertiesFunctions
    {
        public static string FunctionIsTemporaryProductListening = "FunctionIsTemporaryProductListening";
        public static string UseMemeberhipTypeXMonth = "UseMemeberhipTypeXMonth";
        public static string UseMemeberhipTypeXMonthRate = "UseMemeberhipTypeXMonthRate";
    }
}

