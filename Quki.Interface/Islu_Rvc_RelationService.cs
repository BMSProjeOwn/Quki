using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Interface
{
    public interface Islu_Rvc_RelationService :IGenericService<slu_Rvc_Relation,slu_Rvc_RelationModel>
    {
        public List<slu_Rvc_Relation> GetAllSluDefRelation();
        public List<SluDefModel> GetAllSluDefRelationWithSlu(int languageId,long rvc_def_seq);
    }
}
