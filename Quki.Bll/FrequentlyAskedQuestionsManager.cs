using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class FrequentlyAskedQuestionsManager : BllBase<FrequentlyAskedQuestions, FrequentlyAskedQuestionsModel>, IFrequentlyAskedQuestionsService
    {
        public readonly IFrequentlyAskedQuestionsRepository repo;
        public FrequentlyAskedQuestionsManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IFrequentlyAskedQuestionsRepository>();
        }
        public void AddQuestion(FrequentlyAskedQuestionsModel model) {
            var frequentlyAskedQuestions = new FrequentlyAskedQuestions();

            if (model.ImagePath != null)
            {
                var path = Path.GetExtension(model.ImagePath.FileName);
                var newPath = Guid.NewGuid() + path;
                var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/FrequentlyAskedQuestionImg/" + newPath;
                var steem = new FileStream(ImagePath, FileMode.Create);
                model.ImagePath.CopyTo(steem);
                //Utility.ResizeImage(model.ImagePath, FrequentlyAskedQuestionImageSize.Height, FrequentlyAskedQuestionImageSize.Width, ImagePath);
                frequentlyAskedQuestions.ImagePath = "/AdminImage/FrequentlyAskedQuestionImg/" + newPath;
            }


            frequentlyAskedQuestions.LanguageID = model.LanguageID;
            frequentlyAskedQuestions.FrequentlyAskedQuestionsName = model.FrequentlyAskedQuestionsName;
            frequentlyAskedQuestions.FrequentlyAskedQuestionHeader = model.FrequentlyAskedQuestionHeader;
            frequentlyAskedQuestions.FrequentlyAskedQuestionsGroupID = model.FrequentlyAskedQuestionsGroupID;
            frequentlyAskedQuestions.FrequentlyAskedQuestionsTypeID = model.FrequentlyAskedQuestionsTypeID;
            frequentlyAskedQuestions.FrequentlyAskedQuestionsRemark = model.FrequentlyAskedQuestionsRemark;
            frequentlyAskedQuestions.DisplayOrderNumber = model.DisplayOrderNumber;
            frequentlyAskedQuestions.IsShowCustomer = model.IsShowCustomer;
            frequentlyAskedQuestions.IsDynamicOption = model.IsDynamicOption;
            frequentlyAskedQuestions.IsActive = model.IsActive;

            TAdd(frequentlyAskedQuestions);
        }
        public void UpdateQuestion(FrequentlyAskedQuestionsModel model) {
            var frequentlyAskedQuestions = new FrequentlyAskedQuestions();

            var entity = TgetItemByID(model.FrequentlyAskedQuestionsSeqID);


            entity.FrequentlyAskedQuestionsSeqID = model.FrequentlyAskedQuestionsSeqID;
            entity.FrequentlyAskedQuestionsName = model.FrequentlyAskedQuestionsName;
            entity.FrequentlyAskedQuestionHeader = model.FrequentlyAskedQuestionHeader;
            entity.FrequentlyAskedQuestionsRemark = model.FrequentlyAskedQuestionsRemark;
            entity.FrequentlyAskedQuestionsGroupID = model.FrequentlyAskedQuestionsGroupID;
            entity.FrequentlyAskedQuestionsTypeID = model.FrequentlyAskedQuestionsTypeID;
            entity.LanguageID = model.LanguageID;
            entity.IsShowCustomer = model.IsShowCustomer;
            entity.DisplayOrderNumber = model.DisplayOrderNumber;
            entity.IsDynamicOption = model.IsDynamicOption;

            if (model.ImagePath != null)
            {
                var path = Path.GetExtension(model.ImagePath.FileName);
                var newPath = Guid.NewGuid() + path;
                var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/FrequentlyAskedQuestionImg/" + newPath;
                var steem = new FileStream(ImagePath, FileMode.Create);
                model.ImagePath.CopyTo(steem);
                //Utility.ResizeImage(model.ImagePath, ProductImageSize.Height, ProductImageSize.Width, ThumbImagePath);
                frequentlyAskedQuestions.ImagePath = "/AdminImage/FrequentlyAskedQuestionImg/" + newPath;
                entity.ImagePath = frequentlyAskedQuestions.ImagePath;
            }


            TUpdate(entity);
        }
        public FrequentlyAskedQuestionsModel getFrequentlyAskedQuestionsByID(int id) {

            FrequentlyAskedQuestionsModel model = new FrequentlyAskedQuestionsModel();
            var Item = TgetItemByID(id);
            model.FrequentlyAskedQuestionsSeqID = Item.FrequentlyAskedQuestionsSeqID;
            model.FrequentlyAskedQuestionsName = Item.FrequentlyAskedQuestionsName;
            model.FrequentlyAskedQuestionHeader = Item.FrequentlyAskedQuestionHeader;
            model.FrequentlyAskedQuestionsRemark = Item.FrequentlyAskedQuestionsRemark;
            model.FrequentlyAskedQuestionsGroupID = Item.FrequentlyAskedQuestionsGroupID;
            model.FrequentlyAskedQuestionsTypeID = Item.FrequentlyAskedQuestionsTypeID;
            model.LanguageID = Item.LanguageID;
            model.IsShowCustomer = Item.IsShowCustomer;
            model.DisplayOrderNumber = Item.DisplayOrderNumber;
            model.IsDynamicOption = Item.IsDynamicOption;
            model.IsActive = Item.IsActive;
            return model;
        }
        public void DeleteQuestion(int id) {
            var x = TGetList(x => x.FrequentlyAskedQuestionsSeqID == id).FirstOrDefault();

            x.IsActive = false;

            TUpdate(x);
        }
    }
}
