using AutoMapper;
using BlogFinalTask.Web.Data;
using BlogFinalTask.Web.Data.DTOS;
using BlogFinalTask.Web.Data.Models;
using System.Security.Claims;

namespace BlogFinalTask.Web.Repository
{
    public class ArticleRepository : GenericRepository<Article, ArticleDTO>, IArticleRepository
    {
        public ArticleRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) {
        }

        public async Task<string> CreateAtricle(ClaimsPrincipal user, ArticleDTO articleDTO) {
            string? userId = GetMyUserId(user);
            if (userId is not null) {
                articleDTO.UserId = userId;
                articleDTO.Id = System.Guid.NewGuid().ToString();
                Article articleToAdd = mapper.Map<Article>(articleDTO);
                await context.Set<Article>().AddAsync(articleToAdd);
                return articleToAdd.Id;
            } else {
                return null!;
            }
        }
    }
}
