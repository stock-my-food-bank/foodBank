namespace Server.Models
{
    public class SurveysModel
    {
        public int surveyId { get; set; }
        public UsersModel user { get; set; }
        public CommentsModel comments { get; set; }

        private int userId;
        private int commentId;
        private int idCounter;

        public SurveysModel(int userId, int commentId, UsersModel user, CommentsModel comments)
        {
            idCounter++;
            this.surveyId = idCounter;
            this.userId = user.userId;
            this.commentId = comments.commentId;
        }
    }
}
