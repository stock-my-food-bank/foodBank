namespace Server.Models
{
    public class SurveyFoodItemResultsPut
    {
        //model for put request
        public int voteCountYes { get; set; }
        public int voteCountNo { get; set; }

        public SurveyFoodItemResultsPut( int voteCountYes, int voteCountNo)
        {
            this.voteCountYes = voteCountYes;
            this.voteCountNo = voteCountNo;
        }
    }
}
