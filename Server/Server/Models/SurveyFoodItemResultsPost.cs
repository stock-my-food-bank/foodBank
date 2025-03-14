namespace Server.Models
{
    public class SurveyFoodItemResultsPost
    {
        //model for post request
        public int surveyFoodItemResultsId { get; set; }
        public int surveyId { get; set; }
        public int foodItemId { get; set; }
        public int voteCountYes { get; set; }
        public int voteCountNo { get; set; }
        public int rank { get; set; }
        private int idCounter;

        public SurveyFoodItemResultsPost(int foodItemId, int voteCountYes, int voteCountNo, int rank, int surveyId)
        {
            idCounter++;
            this.surveyFoodItemResultsId = idCounter;
            this.surveyId = surveyId;
            this.foodItemId = foodItemId;
            this.voteCountYes = voteCountYes;
            this.voteCountNo = voteCountNo;
            this.rank = rank;
        }
    }
}