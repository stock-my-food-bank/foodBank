namespace Server.Models
{
    public class CommentsPost
    {
        public string comment { get; set; }

    public CommentsPost(string comment)
        {
            this.comment = comment;
        }
    }
}
