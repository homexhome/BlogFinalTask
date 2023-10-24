using AutoMapper;
using BlogFinalTask.Data.DTOS;
using BlogFinalTask.Data.Models;

namespace BlogFinalTask.Data.Repository
{
    public class TagRepository : GenericRepository<Tag, TagDTO>, ITagRepository
    {
        public TagRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) {
        }
    }
}
