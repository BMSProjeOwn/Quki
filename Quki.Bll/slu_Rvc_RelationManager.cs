using Microsoft.Extensions.DependencyInjection;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;
using Quki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Bll
{
    public class slu_Rvc_RelationManager: BllBase<slu_Rvc_Relation,slu_Rvc_RelationModel>,Islu_Rvc_RelationService
    {
        public readonly Islu_Rvc_RelationRepository repo;
        public readonly ISluDefRepository sluDef;
        public readonly ISluDefWithLanguageRepository sluDefWithLanguageRepository;
        public slu_Rvc_RelationManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<Islu_Rvc_RelationRepository>();
            sluDef = service.GetService<ISluDefRepository>();
            sluDefWithLanguageRepository = service.GetService<ISluDefWithLanguageRepository>();

        }
        public List<slu_Rvc_Relation> GetAllSluDefRelation()
        {
            var slurelation=repo.TGetList(x => x.rvc_seq == 10).ToList();

            return slurelation;
        } 
        public List<SluDefModel> GetAllSluDefRelationWithSlu2()
        {
            var itemList = sluDef.TGetList()
                          .Join(repo.TGetList(), x => x.slu_def_seq, s => s.slu_seq, (D, P) => new
                          {
                              D = D,
                              P = P
                          }).Where(w => w.P.rvc_seq == 10 && w.D.slu_type=="MI").OrderBy(x=>x.D.control_number.Value)
                          .Select(s => new SluDefModel
                          {
                              slu_def_name=s.D.slu_def_name,
                              slu_def_seq=s.D.slu_def_seq,
                              slu_type_slu_image=s.D.slu_type_slu_image


                          }).ToList();

            foreach (var item in itemList)
            {
                string text=item.slu_def_name;
                string[] parca = text.Split("-");
                item.slu_def_name=parca[0];
            }
           
            
            return itemList;
        }
        public List<SluDefModel> GetAllSluDefRelationWithSlu()
        {
            var itemList = sluDef.TGetList()
                          .Join(repo.TGetList(), x => x.slu_def_seq, s => s.slu_seq, (D, P) => new
                          {
                              D = D,
                              P = P
                          }).Join(sluDefWithLanguageRepository.TGetList(), x => x.D.slu_def_seq, s => s.SluDefSeq, (R, SwR) => new
                          {
                              R = R,
                              SwR = SwR
                          })

                          .Where(w => w.R.P.rvc_seq == 2 && w.R.D.slu_type == "MI").OrderBy(x => x.R.D.control_number.Value)
                          .Select(s => new SluDefModel
                          {
                              slu_def_name = s.R.D.slu_def_name,
                              slu_def_seq = s.R.D.slu_def_seq,
                              slu_type_slu_image = s.R.D.slu_type_slu_image


                          }).ToList();

            foreach (var item in itemList)
            {
                string text = item.slu_def_name;
                string[] parca = text.Split("-");
                item.slu_def_name = parca[0];
            }


            return itemList;
            }


        }
    }
