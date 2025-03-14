namespace Server.Models
{
    public class CommentsPost
    {
        public int commentId;
        public string comment { get; set; }
        private static int idCounter = 1;

    public CommentsPost(string comment)
        {
            this.commentId = idCounter++;
            this.comment = comment;
        }
    }
}
