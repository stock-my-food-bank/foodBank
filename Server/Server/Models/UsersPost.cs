namespace Server.Models
{
    public class UsersPost
    {
        public int userId { get; set; }
        public string role { get; set; }
        private static int idCounter = 1;

        public UsersPost()
        {
            this.userId = idCounter++;
        }
    }
}
