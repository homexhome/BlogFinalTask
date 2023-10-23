using BlogFinalTask.Web.Data.DTOS;
using BlogFinalTask.Web.Data.Models;
using System.Security.Claims;

namespace BlogFinalTask.Web.Repository
{
    public interface IArticleRepository : IGenericRepository<Article,ArticleDTO>
    {
    }
}
