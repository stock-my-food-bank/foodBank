namespace Server.Models
{
    public class SurveyFoodItemResultsGet
    {
        //model for Get request
        public int surveyFoodItemResultsId { get; set; }
        public int surveyId { get; set; }
        public int foodItemId { get; set; }
        public int voteCountYes { get; set; }
        public int voteCountNo { get; set; }
        public int rank { get; set; }
        public DateTime dateTime { get; set; }
    }
}
