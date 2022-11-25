using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;
using Quki.Entity.ViewModel;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class UserProtoectInformationRepository : GenericRepository<UserProtoectInformation>, IUserProtoectInformationRepository
    {
        public UserProtoectInformationRepository(DbContext context) : base(context)
        {
            
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
            var list = dbset.Where(w => w.ProtectionInformationSeqID == id && w.UserId == customer_def_no).ToList();
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
