namespace Server.Models
{
    public class SurveysPost
    {
        public int surveyId { get; set; }
        public int userId { get; set; }
        public int commentId { get; set; }
        private int idCounter=1;

        public SurveysPost(int userId, int commentId)
        {
            this.surveyId = idCounter++;
            this.userId = userId;
            this.commentId = commentId;
        }
    }
}
