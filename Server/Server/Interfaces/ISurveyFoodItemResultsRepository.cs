using Server.Models;

namespace Server.Interfaces
{
    public interface ISurveyFoodItemResultsRepository
    {
        int? InsertSurvey(SurveyFoodItemResultsInsert surveyFoodItemResult);
        int TallyVotes(SurveyFoodItemResultsPut surveyFoodItemResult, int id);
        List<SurveyFoodItemResultsGet> GetVotes();
        int GetCount();
    }
}
