namespace Server.Models
{
    public class SurveyFoodItemResultsPost
    {
        //model for post request
        public int surveyFoodItemResultsId { get; set; }
        public int surveyId { get; set; }
        public int foodItemId { get; set; }
        public int voteCountYes  { get; set; }
        public int voteCountNo { get; set; }
        private static int idCounter = 1;

        public SurveyFoodItemResultsPost(int foodItemId, bool voteCountYes, bool voteCountNo, int surveyId)
        {
            this.surveyFoodItemResultsId = idCounter++;
            this.surveyId = surveyId;
            this.foodItemId = foodItemId;
            if (voteCountYes && !voteCountNo)
            {
                this.voteCountYes++;
            }
            else if (voteCountNo && !voteCountYes)
            {
                this.voteCountNo++;
            }
        }
    }
}