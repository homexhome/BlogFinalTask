using AutoMapper;
using BlogFinalTask.Data.DTOS;
using BlogFinalTask.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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

        public async Task<List<ArticleTagsDTO>> GetDTOByArticleId(string id) {
            List<ArticleTags> articleTags = await context.Set<ArticleTags>().Where(at => at.ArticleId == id)
                .ToListAsync();
            List<ArticleTagsDTO> result = mapper.Map<List<ArticleTagsDTO>>(articleTags);
            return result;
        }

        public async Task<int> GetArticleCountByTag(string tagId) {
            List<ArticleTags> articleTags = await context.Set<ArticleTags>()
                                                         .Where(at => at.TagId == tagId)
                                                         .ToListAsync();
            return articleTags.Count;
        }
    }
}
