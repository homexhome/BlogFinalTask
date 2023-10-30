using BlogFinalTask.Data.DTOS;
using BlogFinalTask.Data.Models;

namespace BlogFinalTask.Data.Repository
{
    public interface IArticleTagsRepository : IGenericRepository<ArticleTags, ArticleTagsDTO>
    {
        public Task<List<TagDTO>> GetArticleTagsById(string id);
        public Task<List<ArticleTagsDTO>> GetDTOByArticleId(string id);
        public Task<int> GetArticleCountByTag(string tagId);
    }
}
