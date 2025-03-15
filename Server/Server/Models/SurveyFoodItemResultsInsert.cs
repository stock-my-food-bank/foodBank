namespace Server.Models
{
    public class SurveyFoodItemResultsInsert
    {
        public int surveyId { get; set; }
        public int foodItemId { get; set; }
        public int voteCountYes { get; set; }
        public int voteCountNo { get; set; }
    }
}
