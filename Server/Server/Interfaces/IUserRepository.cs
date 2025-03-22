using Server.Models;

namespace Server.Interfaces
{
    public interface IUsersRepository
    {
        int? InsertUser(string role);
        UsersGet GetUser(int id);
        int GetCount();
    }
}
