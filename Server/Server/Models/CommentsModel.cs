namespace Server.Models
{
    public class CommentsModel
    {
        public int commentId;
        public string comment { get; set; }
        public int dateTime { get; set; }
        private int idCounter;

    public CommentsModel(int commentId, string comment, int dateTime)
        {
            idCounter++;
            this.commentId = idCounter;
            this.comment = comment;
            this.dateTime = dateTime;
        }
    }
}
