using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;
using Quki.Entity.Parameters;




namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class MemberShipTypeWithCustomersProfilesRepository : GenericRepository<MemberShipTypeWithCustomersProfiles>, IMemberShipTypeWithCustomersProfilesRepository
    {
        public MemberShipTypeWithCustomersProfilesRepository(DbContext context):base(context)
        {
            
        }
        public List<GetUserProfiles> GelMemberShipTypeWithCustomersProfilesByUserID(string UserID, string DeviceID, string DeviceType, string Version)
        {
            List<GetUserProfiles> result = new List<GetUserProfiles>();

            try
            {
                //string sql = "exec GetUserProfiles @UserID='" + UserID + "' , @Time=" + AppParameters.SetProfileActiveSecondTime;
                string sql = "exec GetUserProfilesV1 " +
                    " @UserID='" + UserID + "' , " +
                    " @Time=" + AppParameters.SetProfileActiveSecondTime + " , " +
                    " @DeviceID='" + DeviceID + "' , " +
                    " @DeviceType='" + DeviceType + "' , " +
                    " @Version='" + Version + "' ";
                result = context.Set<GetUserProfiles>().FromSqlRaw(sql).ToList();
            }
            catch (Exception ex) { }
            return result;
        }

        public GetUserProfiles GelMemberShipTypeWithCustomersProfilesByProfileUserID(string ProfileUserID, string DeviceID, string DeviceType, string Version)
        {
            GetUserProfiles result = new GetUserProfiles();
            try
            {
                //string sql = "exec GetUserProfileByProfileUserID @ProfileUserID='" + ProfileUserID + "' , @Time=" + AppParameters.SetProfileActiveSecondTime;
                string sql = "exec GetUserProfileByProfileUserIDV1 " +
                    " @ProfileUserID='" + ProfileUserID + "' , " +
                    " @Time=" + AppParameters.SetProfileActiveSecondTime + " , " +
                    " @DeviceID='" + DeviceID + "' , " +
                    " @DeviceType='" + DeviceType + "' , " +
                    " @Version='" + Version + "' ";

                result = context.Set<GetUserProfiles>().FromSqlRaw(sql).ToList()[0];
            }
            catch (Exception ex) { }
            return result;
        }

        //public bool UpdateMemberShipTypeWithCustomersProfilesByProfileUserID(string ProfileUserID, string Name, string IconPhat)
        //{
        //    bool result = false;

        //    try
        //    {
        //        var profil = dbset.Where(w => w.ProfileUserID == ProfileUserID).FirstOrDefault();
        //        profil.ProfileName = Name;
        //        profil.ProfileIconPath = IconPhat;
        //        profil.UpdateDateTime = DateTime.Now;
        //        TUpdate(profil);
        //        result = true;
        //    }
        //    catch (Exception ex) { }
        //    return result;
        //}

        //public string AddMemberShipTypeWithCustomersProfilesByProfileUserID(string UserID, string Name, string IconPhat)
        //{
        //    string result = "";

        //    try
        //    {
        //        MemberShipTypeWithCustomersProfiles profil = new MemberShipTypeWithCustomersProfiles();
        //        profil.MemberShipTypeWithCustomersSeqID = 0;
        //        profil.ProfileUserID = Guid.NewGuid().ToString();
        //        profil.UserID = UserID;
        //        profil.ProfileName = Name;
        //        profil.ProfileIconPath = IconPhat;
        //        profil.TerminalID = "";
        //        profil.TerminalModel = "";
        //        profil.IsActive = true;
        //        profil.CreatedDateTime = DateTime.Now;
        //        profil.CreatedBy = "";
        //        profil.UpdatedBy = "";
        //        profil.UpdateDateTime = DateTime.Now;
        //        TAdd(profil);
        //        result = profil.ProfileUserID.ToString();
        //    }
        //    catch (Exception ex) { }
        //    return result;
        //}

        //public bool DeleteMemberShipTypeWithCustomersProfilesByProfileUserID(string ProfileUserID)
        //{
        //    bool result = false;
        //    try
        //    {
        //        var profil = dbset.Where(w => w.ProfileUserID == ProfileUserID).FirstOrDefault();
        //        profil.IsActive = false;
        //        TUpdate(profil);
        //        result = true;
        //    }
        //    catch (Exception ex) { }
        //    return result;
        //}


        //public bool CanAddNewProfile(string UserID)
        //{
        //    bool result = false;
        //    try
        //    {
        //        var mwc = context.Set<MemberShipTypeWithCustomer>().Where(w => w.Id == UserID && w.IsActive == true).ToList();
        //        if (mwc != null)
        //        {
        //            if (mwc.Count > 0)
        //            {
        //                var mwp = context.Set<MemberShipTypeWithProperties>().Where(w => w.IsActive == true && w.MemberShipTypeSeqID == mwc[0].MemberShipTypeSeqID).ToList();
        //                if (mwp != null)
        //                {
        //                    if (mwp.Count > 0)
        //                    {
        //                        foreach (var item in mwp)
        //                        {
        //                            if (item.FunctionContent == "ProfielesCount")
        //                            {
        //                                var list = GelMemberShipTypeWithCustomersProfilesByUserID(UserID, "", "", "");
        //                                if (list.Count < Convert.ToInt32(item.InitialValue))
        //                                {
        //                                    result = true;
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex) { }
        //    return result;
        //}

        public bool CanAddNewProfile(string UserID)
        {
            bool result = false;
            try
            {
                var mwc = context.Set<MemberShipTypeWithCustomer>().Where(w => w.Id == UserID && w.IsActive == true).ToList();
                if (mwc != null)
                {
                    if (mwc.Count > 0)
                    {
                        var mwp = context.Set<MemberShipTypeWithProperties>().Where(w => w.IsActive == true && w.MemberShipTypeSeqID == mwc[0].MemberShipTypeSeqID).ToList();
                        if (mwp != null)
                        {
                            if (mwp.Count > 0)
                            {
                                foreach (var item in mwp)
                                {
                                    if (item.FunctionContent == "ProfielesCount")
                                    {
                                        var list = GelMemberShipTypeWithCustomersProfilesByUserID(UserID, "", "", "");
                                        if (list.Count < Convert.ToInt32(item.InitialValue))
                                        {
                                            result = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return result;
        }
    }
}
