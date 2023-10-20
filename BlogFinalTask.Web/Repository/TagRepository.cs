using AutoMapper;
using BlogFinalTask.Web.Data;
using BlogFinalTask.Web.Data.DTOS;
using BlogFinalTask.Web.Data.Models;

namespace BlogFinalTask.Web.Repository
{
    public class TagRepository : GenericRepository<Tag, TagDTO>, ITagRepository
    {
        public TagRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) {
        }
    }
}
