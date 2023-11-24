using AutoMapper;
using BlogFinalTask.Data.DTOS;
using BlogFinalTask.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace BlogFinalTask.Data.Repository
{
    [Route("articleController")]
    [ApiController]
    public class ArticleRepository : GenericRepository<Article, ArticleDTO>, IArticleRepository
    {
        public ArticleRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) {

        }
        [NonAction]
        public override async Task<List<ArticleDTO>> GetAllAsync(ClaimsPrincipal User) {
            List<Article> entities = await context.Set<Article>().ToListAsync();
            List<ArticleDTO> result = mapper.Map<List<ArticleDTO>>(entities);
            return result;
        }

        /// <summary>
        /// Возвращает статью по её id.
        /// </summary>
        /// <param name="id">ID по которому возвращается статья. </param>
        /// <returns>Статья с определённым ID.</returns>
        /// <response code="200">Возвращает запрошенную статью.</response>
        /// <response code="500">Если не существует такой статьи - выкинет ошибку</response>
        [HttpGet("getArticleById")]
        [SwaggerOperation(Summary = "Возвращает статью по её id.")]
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
