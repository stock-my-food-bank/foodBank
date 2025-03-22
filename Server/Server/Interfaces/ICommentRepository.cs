using Server.Models;

namespace Server.Interfaces
{
    public interface ICommentsRepository
    {
        int? AddComment(CommentsPost newComment);
        List<CommentsGet> GetAllComments();
        int GetCount();
    }
}
