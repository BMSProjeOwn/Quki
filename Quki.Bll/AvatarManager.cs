using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Bll;
using Quki.Interface;

namespace Quki.Bll
{
    public class AvatarManager : BllBase<Avatars, IconsModel>, IAvatarsService
    {
        public readonly IAvatarsRepository avatarsRepository;

        public AvatarManager(IServiceProvider service) :base(service)
        {
            avatarsRepository = service.GetService<IAvatarsRepository>();
        }
        public List<Avatars> GetAllProfileAvatars()
        {
            var result = TGetList(w => w.IsActive == true && w.TypeID == 1).ToList();
            return result;
        }
    }
}
