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
    public class MemberShipTypeWithCustomersProfilesManager : BllBase<MemberShipTypeWithCustomersProfiles, MemberShipTypeWithCustomersProfilesModel>, IMemberShipTypeWithCustomersProfilesService
    {
        public readonly IMemberShipTypeWithCustomersProfilesRepository repo;
        public readonly IMemberShipTypeWithCustomerRepository memberShipTypeWithCustomerRepository;
        public readonly IMemberShipTypeWithPropertiesRepository memberShipTypeWithPropertiesRepository;
        public MemberShipTypeWithCustomersProfilesManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IMemberShipTypeWithCustomersProfilesRepository>();
            memberShipTypeWithCustomerRepository = service.GetService<IMemberShipTypeWithCustomerRepository>();
            memberShipTypeWithPropertiesRepository = service.GetService<IMemberShipTypeWithPropertiesRepository>();
        }
        public List<GetUserProfiles> GelMemberShipTypeWithCustomersProfilesByUserID(string UserID, string DeviceID, string DeviceType, string Version)
        {
            return repo.GelMemberShipTypeWithCustomersProfilesByUserID(UserID, DeviceID, DeviceType, Version);
        }

        public GetUserProfiles GelMemberShipTypeWithCustomersProfilesByProfileUserID(string ProfileUserID, string DeviceID, string DeviceType, string Version)
        {
            return repo.GelMemberShipTypeWithCustomersProfilesByProfileUserID(ProfileUserID, DeviceID, DeviceType, Version);
        }

        public bool UpdateMemberShipTypeWithCustomersProfilesByProfileUserID(string ProfileUserID, string Name, string IconPhat)
        {
            bool result = false;

            try
            {
                var profil = TGetList(w => w.ProfileUserID == ProfileUserID).FirstOrDefault();
                profil.ProfileName = Name;
                profil.ProfileIconPath = IconPhat;
                profil.UpdateDateTime = DateTime.Now;
                TUpdate(profil);
                result = true;
            }
            catch (Exception ex) { }
            return result;
        }

        public string AddMemberShipTypeWithCustomersProfilesByProfileUserID(string UserID, string Name, string IconPhat)
        {
            string result = "";

            try
            {
                MemberShipTypeWithCustomersProfiles profil = new MemberShipTypeWithCustomersProfiles();
                profil.MemberShipTypeWithCustomersSeqID = 0;
                profil.ProfileUserID = Guid.NewGuid().ToString();
                profil.UserID = UserID;
                profil.ProfileName = Name;
                profil.ProfileIconPath = IconPhat;
                profil.TerminalID = "";
                profil.TerminalModel = "";
                profil.IsActive = true;
                profil.CreatedDateTime = DateTime.Now;
                profil.CreatedBy = "";
                profil.UpdatedBy = "";
                profil.UpdateDateTime = DateTime.Now;
                TAdd(profil);
                result = profil.ProfileUserID.ToString();
            }
            catch (Exception ex) { }
            return result;
        }

        public bool DeleteMemberShipTypeWithCustomersProfilesByProfileUserID(string ProfileUserID)
        {
            bool result = false;
            try
            {
                var profil = TGetList(w => w.ProfileUserID == ProfileUserID).FirstOrDefault();
                profil.IsActive = false;
                TUpdate(profil);
                result = true;
            }
            catch (Exception ex) { }
            return result;
        }


        public bool CanAddNewProfile(string UserID)
        {
            bool result = false;
            try
            {
                var mwc = memberShipTypeWithCustomerRepository.TGetList(w => w.Id == UserID && w.IsActive == true).ToList();
                if (mwc != null)
                {
                    if (mwc.Count > 0)
                    {
                        var mwp = memberShipTypeWithPropertiesRepository.TGetList(w => w.IsActive == true && w.MemberShipTypeSeqID == mwc[0].MemberShipTypeSeqID).ToList();
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
