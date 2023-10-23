using AutoMapper;
using BlogFinalTask.Web.Data;
using BlogFinalTask.Web.Data.DTOS;
using BlogFinalTask.Web.Data.Models;
using Microsoft.EntityFrameworkCore;
using Radzen;
using System.Security.Claims;

namespace BlogFinalTask.Web.Repository
{
    public class ArticleRepository : GenericRepository<Article, ArticleDTO>, IArticleRepository
    {
        public ArticleRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) {

        }
        public override async Task<List<ArticleDTO>> GetAllAsync(ClaimsPrincipal User) {
            List<Article> entities = await context.Set<Article>().ToListAsync();
            List<ArticleDTO> result = mapper.Map<List<ArticleDTO>>(entities);
            return result;
        }

    }
}
