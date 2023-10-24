using BlogFinalTask.Data.DTOS;
using BlogFinalTask.Data.Models;

namespace BlogFinalTask.Data.Repository
{
    public interface IArticleRepository : IGenericRepository<Article, ArticleDTO>
    {
    }
}
