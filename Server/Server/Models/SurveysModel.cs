namespace Server.Models
{
    public class SurveysModel
    {
        public int surveyId { get; set; }
        public UsersModel user { get; set; }
        public CommentsModel comments { get; set; }

        private int userId;
        private int commentId;

        public SurveysModel(int userId, int commentId, UsersModel user, CommentsModel comments)
        {
            this.userId = user.userId;
            this.commentId = comments.commentId;
        }

    }
}
