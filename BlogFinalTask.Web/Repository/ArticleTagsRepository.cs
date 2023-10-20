using AutoMapper;
using BlogFinalTask.Web.Data;
using BlogFinalTask.Web.Data.DTOS;
using BlogFinalTask.Web.Data.Models;
using System.Security.Claims;

namespace BlogFinalTask.Web.Repository
{
    public class ArticleTagsRepository : GenericRepository<ArticleTags, ArticleTagsDTO>, IArticleTagsRepository
    {
        public ArticleTagsRepository(ApplicationDbContext context, IMapper mapper) : base (context, mapper){

        }
    }
}
