using AutoMapper;
using BlogFinalTask.Data.DTOS;
using BlogFinalTask.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlogFinalTask.Data.Repository
{
    public class CommentRepository : GenericRepository<Comment, CommentDTO>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) {
        }

        public async Task<List<CommentDTO>> GetAllCommentsFromArticle(string articleId) {
            List<Comment> comments = await context.Comments.Include(c => c.User)
                                                           .Where(c => c.ArticleId == articleId)
                                                           .ToListAsync();
            List<CommentDTO> result = mapper.Map<List<CommentDTO>>(comments);
            return result;
        }

        public override async Task<string> AddObj(ClaimsPrincipal User, CommentDTO dto) {
            string? userId = GetMyUserId(User);
            if (userId is not null && User is not null) {
                dto.Id = System.Guid.NewGuid().ToString();
                dto.UserId = userId;
                dto.UserName = User.FindFirstValue(ClaimTypes.Name)!;
                Comment toAdd = mapper.Map<Comment>(dto);
                await context.Set<Comment>().AddAsync(toAdd);
                return toAdd.Id;
            }
            else {
                return null!;
            }
        }
    }
}
