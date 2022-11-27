using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class MembershipPropertiesManager : BllBase<MembershipProperties, MemberShipTypeWithPropertiessAddModel>, IMembershipPropertiesService
    {
        public readonly IMembershipPropertiesRepository repo;
        public readonly IValueTypesRepository valueTypesRepository;
        public readonly IMemberShipTypeWithPropertiesRepository memberShipTypeWithPropertiesRepository;
        public readonly IMemberShipTypeRepository memberShipTypeRepository;
        public MembershipPropertiesManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IMembershipPropertiesRepository>();
            valueTypesRepository = service.GetService<IValueTypesRepository>();
            memberShipTypeWithPropertiesRepository = service.GetService<IMemberShipTypeWithPropertiesRepository>();
            memberShipTypeRepository = service.GetService<IMemberShipTypeRepository>();
        }
        public List<MembershipProperties> GetPropertiesAll()
        {
            var list = TGetList(w => w.Status == true).ToList();

            return list;
        }

        public List<MemberShipTypeWithPropertiessAddModel> GetPropertiesAllWithValueTypes()
        {
            var list = TGetList(w => w.Status == true).Join(valueTypesRepository.TGetList(), M => M.ValueTypeSeqID, V => V.ValueTypeSeqID, (memberShipTypeProp, valueType) => new
            {
                M = memberShipTypeProp,
                V = valueType
            }).Select(s => new MemberShipTypeWithPropertiessAddModel
            {
                ValueTypeName = s.V.ValueTypeName,
                ValueTypeSecondName = s.V.ValueTypeSecondName,
                ValueTypeSeqId = s.V.ValueTypeSeqID,
                Name = s.M.Name,
                MemberShipPropertiesSeqID = s.M.MemberShipPropertiesSeqID,
                InitialValue = s.M.InitialValue,
                EndValue = s.M.EndValue,
                IsDynamic = s.M.IsDynamic,
                IsshowScreen = s.M.IsshowScreen,
                Type = s.M.Type
            }
                ).ToList();

            return list;
        }

        public List<MembershipProperties> GetProperties(int memberShipTypeId)
        {
            var list = TGetList().Join(memberShipTypeWithPropertiesRepository.TGetList(), M1 => M1.MemberShipPropertiesSeqID, M2 => M2.MemberShipPropertiesSeqID, (memberShipProperties, memberShipTypeWithProperties) => new
            {
                MembershipProperties = memberShipProperties,
                MemberShipTypeWithPropertiess = memberShipTypeWithProperties
            }).Join(memberShipTypeRepository.TGetList(), M3 => M3.MemberShipTypeWithPropertiess.MemberShipTypeSeqID, MemberShipType => MemberShipType.MemberShipTypeSeqID, (memberShipProperties, memberShipTypeWithProperties) => new
            {
                MTWP = memberShipProperties,
                MemberShipType = memberShipTypeWithProperties,
            })
            .Where(w => w.MemberShipType.MemberShipTypeSeqID == memberShipTypeId && w.MemberShipType.Status == true && w.MTWP.MembershipProperties.Status == true && w.MTWP.MemberShipTypeWithPropertiess.IsActive == true)
            .Select(s => s.MTWP.MembershipProperties).ToList().ToList();

            return list;
        }

        public bool AddMemberShipTypeProp(MemberShipTypePropertiesAddModel model)
        {
            bool returnvalue = false;

            MembershipProperties m = new MembershipProperties();

            m.Name = model.Name;
            m.InitialValue = model.InitialValue;
            m.EndValue = model.EndValue;
            m.LanguageID = 1;
            m.GroupID = 1;
            m.Status = model.Status;
            m.ValueTypeSeqID = model.ValueTypeSeqId;
            m.IsDynamic = model.IsDynamic;
            TAdd(m);
            m.MemberShipPropertiesID = m.MemberShipPropertiesSeqID;
            TUpdate(m);
            return returnvalue;
        }


        public void UpdateMemberShipTypeProp(MembershipProperties membershipProperties)
        {
            MembershipProperties m = new MembershipProperties();

            m.Name = membershipProperties.Name;
            m.InitialValue = membershipProperties.InitialValue;
            m.EndValue = membershipProperties.EndValue;
            m.LanguageID = 1;
            m.GroupID = 1;
            m.Status = membershipProperties.Status;
            m.IsDynamic = membershipProperties.IsDynamic;
            TUpdate(m);
        }
    }
}
