namespace Server.Models
{
    public class CommentsPost
    {
        public int commentId;
        public string comment { get; set; }

    public CommentsPost(string comment)
        {
            this.comment = comment;
        }
    }
}
