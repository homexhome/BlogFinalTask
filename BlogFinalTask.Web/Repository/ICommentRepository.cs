using BlogFinalTask.Web.Data.DTOS;
using BlogFinalTask.Web.Data.Models;

namespace BlogFinalTask.Web.Repository
{
    public interface ICommentRepository : IGenericRepository<Comment, CommentDTO>
    {
    }
}
