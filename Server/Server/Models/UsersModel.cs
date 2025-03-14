namespace Server.Models
{
    public class UsersModel
    {
        public int userId { get; set; }
        public string role { get; set; }
        private int idCounter;

        public UsersModel()
        {
            idCounter++;
            this.userId = idCounter;
        }
    }
}
