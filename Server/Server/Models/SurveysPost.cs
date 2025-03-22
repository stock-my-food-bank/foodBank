namespace Server.Models
{
    public class SurveysPost
    {
        public int userId { get; set; }
        public int commentId { get; set; }

        public SurveysPost(int userId, int commentId)
        {
            this.userId = userId;
            this.commentId = commentId;
        }
    }
}
