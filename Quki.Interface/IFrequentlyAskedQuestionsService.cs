using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface IFrequentlyAskedQuestionsService : IGenericService<FrequentlyAskedQuestions, FrequentlyAskedQuestionsModel>
    {

        public void AddQuestion(FrequentlyAskedQuestionsModel model);
        public void UpdateQuestion(FrequentlyAskedQuestionsModel model);
        public FrequentlyAskedQuestionsModel getFrequentlyAskedQuestionsByID(int id);
        public void DeleteQuestion(int id);
    }
}
