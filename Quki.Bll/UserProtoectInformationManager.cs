using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Entity.ViewModel;
using Quki.Interface;

namespace Quki.Bll
{
    public class UserProtoectInformationManager : BllBase<UserProtoectInformation, UserProtoectInformationModel>, IUserProtoectInformationService
    {
        public readonly IUserProtoectInformationRepository repo;
        public UserProtoectInformationManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IUserProtoectInformationRepository>();
        }
        public void AddUserProtoectInformation(List<ProtoectInformationGetModel> list, string userID)
        {
            foreach (var item in list)
            {
                UserProtoectInformation userProtoectInformation = new UserProtoectInformation();
                userProtoectInformation.ProtectionInformationSeqID = item.ProtectionInformationSeqID;
                userProtoectInformation.UserId = userID;
                userProtoectInformation.IsConfirmation = item.isHas;
                userProtoectInformation.UpdatedOn = DateTime.Now;
                userProtoectInformation.CreatedOn = DateTime.Now;

                TAdd(userProtoectInformation);
            }
        }

        public bool SettingUpdateApi(string customer_def_no, int id, bool status)
        {
            var list = TGetList(w => w.ProtectionInformationSeqID == id && w.UserId == customer_def_no).ToList();
            bool addNew = true;
            if (list != null)
            {
                if (list.Count > 0)
                {
                    addNew = false;
                    foreach (var item in list)
                    {
                        item.IsConfirmation = status;
                        item.UpdatedOn = DateTime.Now;
                        TUpdate(item);
                    }
                }
            }
            if (addNew)
            {
                UserProtoectInformation userProtoectInformation = new UserProtoectInformation();
                userProtoectInformation.ProtectionInformationSeqID = id;
                userProtoectInformation.UserId = customer_def_no;
                userProtoectInformation.IsConfirmation = status;
                userProtoectInformation.UpdatedOn = DateTime.Now;
                userProtoectInformation.CreatedOn = DateTime.Now;
                TAdd(userProtoectInformation);

            }
            return true;
        }

    }
}
