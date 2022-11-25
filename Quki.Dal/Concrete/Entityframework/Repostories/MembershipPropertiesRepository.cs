using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class MembershipPropertiesRepository : GenericRepository<MembershipProperties>, IMembershipPropertiesRepository
    {
        public MembershipPropertiesRepository(DbContext context) : base(context)
        {

        }
        //public List<MembershipProperties> GetPropertiesAll()
        //{
        //    var list = dbset
        //    .Where(w => w.Status == true).ToList();

        //    return list;
        //}

        public List<MemberShipTypeWithPropertiessAddModel> GetPropertiesAllWithValueTypes()
        {
            var list = dbset
            .Where(w => w.Status == true).Join(context.Set<ValueTypes>(), M => M.ValueTypeSeqID, V => V.ValueTypeSeqID, (memberShipTypeProp, valueType) => new
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
            var list = dbset.Join(context.Set<MemberShipTypeWithProperties>(), M1 => M1.MemberShipPropertiesSeqID, M2 => M2.MemberShipPropertiesSeqID, (memberShipProperties, memberShipTypeWithProperties) => new
            {
                MembershipProperties = memberShipProperties,
                MemberShipTypeWithPropertiess = memberShipTypeWithProperties
            }).Join(context.Set<MemberShipType>(), M3 => M3.MemberShipTypeWithPropertiess.MemberShipTypeSeqID, MemberShipType => MemberShipType.MemberShipTypeSeqID, (memberShipProperties, memberShipTypeWithProperties) => new
            {
                MTWP = memberShipProperties,
                MemberShipType = memberShipTypeWithProperties,
            })
            .Where(w => w.MemberShipType.MemberShipTypeSeqID == memberShipTypeId && w.MemberShipType.Status == true && w.MTWP.MembershipProperties.Status == true && w.MTWP.MemberShipTypeWithPropertiess.IsActive == true)
            .Select(s => s.MTWP.MembershipProperties).ToList().ToList();

            return list;
        }

        //public bool AddMemberShipTypeProp(MemberShipTypePropertiesAddModel model)
        //{
        //    bool returnvalue = false;

        //    MembershipProperties m = new MembershipProperties();

        //    m.Name = model.Name;
        //    m.InitialValue = model.InitialValue;
        //    m.EndValue = model.EndValue;
        //    m.LanguageID = 1;
        //    m.GroupID = 1;
        //    m.Status = model.Status;
        //    m.ValueTypeSeqID = model.ValueTypeSeqId;
        //    m.IsDynamic = model.IsDynamic;
        //    TAdd(m);
        //    m.MemberShipPropertiesID = m.MemberShipPropertiesSeqID;
        //    TUpdate(m);
        //    return returnvalue;
        //}


        //public void UpdateMemberShipTypeProp(MembershipProperties membershipProperties)
        //{
        //    MembershipProperties m = new MembershipProperties();

        //    m.Name = membershipProperties.Name;
        //    m.InitialValue = membershipProperties.InitialValue;
        //    m.EndValue = membershipProperties.EndValue;
        //    m.LanguageID = 1;
        //    m.GroupID = 1;
        //    m.Status = membershipProperties.Status;
        //    m.IsDynamic = membershipProperties.IsDynamic;
        //    TUpdate(m);
        //}
    }
}
