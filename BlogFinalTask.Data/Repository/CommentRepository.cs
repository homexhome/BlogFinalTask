using AutoMapper;
using BlogFinalTask.Data.DTOS;
using BlogFinalTask.Data.Models;

namespace BlogFinalTask.Data.Repository
{
    public class CommentRepository : GenericRepository<Comment, CommentDTO>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) {
        }
    }
}
