using AutoMapper;
using BlogFinalTask.Data.DTOS;
using BlogFinalTask.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlogFinalTask.Data.Repository
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

        public async Task<ArticleDTO> GetById(string id) {
            Article? entitiy = await context.Set<Article>().FirstOrDefaultAsync(a => a.Id == id);
            if (entitiy is not null) {
                ArticleDTO result = mapper.Map<ArticleDTO>(entitiy);
                return result;
            } else {
                throw new Exception("No article was found");
            }
        }
    }
}
