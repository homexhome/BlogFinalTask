using BlogFinalTask.Data.DTOS;
using BlogFinalTask.Data.Models;

namespace BlogFinalTask.Data.Repository
{
    public interface IArticleTagsRepository : IGenericRepository<ArticleTags, ArticleTagsDTO>
    {
        public Task<List<TagDTO>> GetArticleTagsById(string id);
    }
}
