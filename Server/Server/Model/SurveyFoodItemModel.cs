namespace Server.Model
{
    public class SurveyFoodItemModel
    {
        public int Id { get; set; }
        public int VoteCountYes { get; set; }
        public int VoteCountNo { get; set; }
        public int Rank { get; set; }
        public int DateTime { get; set; }
        public FoodItemModel FoodItem { get; set; }
        public SurveyModel Survey { get; set; }
        public int FoodItemId;
        public int SurveyId;
    }

    public SurveyFoodItemModel(int Id, int VoteCountYes, int VoteCountNo, int Rank, int DateTime, FoodItemModel FoodItem, SurveyModel Survey)
        {
            Id = 0;
            VoteCountYes = 0;
            VoteCountNo = 0;
            Rank = 0;
            DateTime = 0;
            FoodItemId = FoodItem.Id;
            SurveyId = Survey.Id;
        }
}
