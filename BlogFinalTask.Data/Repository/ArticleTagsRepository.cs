using AutoMapper;
using BlogFinalTask.Data.DTOS;
using BlogFinalTask.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogFinalTask.Data.Repository
{
    public class ArticleTagsRepository : GenericRepository<ArticleTags, ArticleTagsDTO>, IArticleTagsRepository
    {
        public ArticleTagsRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) {

        }
        public async Task<List<TagDTO>> GetArticleTagsById(string id) {
            List<Tag?> articleTagsList = await context.Set<ArticleTags>()
                                                         .Where(a => a.ArticleId == id)
                                                         .Select(t => t.Tag)
                                                         .ToListAsync();
            List<TagDTO> result = mapper.Map<List<TagDTO>>(articleTagsList);
            return result;
        }
    }
}
