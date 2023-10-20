using AutoMapper;
using BlogFinalTask.Web.Data;
using BlogFinalTask.Web.Data.DTOS;
using BlogFinalTask.Web.Data.Models;

namespace BlogFinalTask.Web.Repository
{
    public class CommentRepository : GenericRepository<Comment, CommentDTO>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) {
        }
    }
}
