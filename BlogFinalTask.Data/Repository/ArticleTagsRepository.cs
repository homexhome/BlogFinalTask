using AutoMapper;
using BlogFinalTask.Data.DTOS;
using BlogFinalTask.Data.Models;

namespace BlogFinalTask.Data.Repository
{
    public class ArticleTagsRepository : GenericRepository<ArticleTags, ArticleTagsDTO>, IArticleTagsRepository
    {
        public ArticleTagsRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) {

        }
    }
}
