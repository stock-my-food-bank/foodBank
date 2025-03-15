namespace Server.Models
{
    public class SurveyFoodItemResultsPost
    {
        //model for post request
        public int surveyId { get; set; }
        public int foodItemId { get; set; }
        public bool voteCountYes  { get; set; }
        public bool voteCountNo { get; set; }

        public SurveyFoodItemResultsPost(int foodItemId, bool voteCountYes, bool voteCountNo, int surveyId)
        {
            this.surveyId = surveyId;
            this.foodItemId = foodItemId;
            this.voteCountYes = voteCountYes;
            this.voteCountNo = voteCountNo;
        }
    }
}