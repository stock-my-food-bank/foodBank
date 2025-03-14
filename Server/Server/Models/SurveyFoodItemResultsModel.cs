namespace Server.Models
{
    public class SurveyFoodItemResultsModel
    {
        public int surveyFoodItemResultsId { get; set; }
        public FoodItemModel foodItem { get; set; }
        public SurveysModel survey { get; set; }
        private int surveyId;
        private int foodItemId;
        private int voteCountYes { get; set; }
        private int voteCountNo { get; set; }
        public int rank { get; set; }
        public int dateTime { get; set; }

    public SurveyFoodItemResultsModel(int surveyId, int foodItemId, int voteCountYes, int voteCountNo, int rank, int dateTime, FoodItemModel foodItem, SurveysModel survey)
        {
            this.surveyId = survey.surveyId;
            this.foodItemId = foodItem.foodId;
            this.voteCountYes = voteCountYes;
            this.voteCountNo = voteCountNo;
            this.rank = rank;
            this.dateTime = dateTime;
        }
    }
}