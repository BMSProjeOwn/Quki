using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface IIntegrationPropertiesService : IGenericService<IntegrationProperties, Entity.DtoModels.IntegrationPropertiesModel>
    {
       // public Integrations.IntegrationCls.GeneralModels.IntegrationModel GetIntegrationByIntegrationId(IntegrationTypes integration);
    }
}
