using AutoMapper;
using BlogFinalTask.Web.CustomExceptions;
using BlogFinalTask.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BlogFinalTask.Web.Repository
{
    public class RepositoryCollection : IRepositoryCollection
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public IArticleRepository Article { get; private set; }
        public ICommentRepository Comment { get; private set; }
        public ITagRepository Tag { get; private set; }
        public IArticleTagsRepository ArticleTags { get; private set; }

        public RepositoryCollection(IDbContextFactory<ApplicationDbContext> dbContextFactory, IMapper mapper) {
            this.context = dbContextFactory.CreateDbContext();
            this.mapper = mapper;
            Article = new ArticleRepository(context,mapper);
            Comment = new CommentRepository(context,mapper);
            Tag = new TagRepository(context,mapper);
            ArticleTags = new ArticleTagsRepository(context,mapper);
        }

        public async Task<int> Save() {
            try {
                return await context.SaveChangesAsync();
            }
            catch (DbUpdateException ex) {
                foreach (EntityEntry item in ex.Entries) {
                    if (item.State == EntityState.Modified) {
                        item.CurrentValues.SetValues(item.OriginalValues);
                        item.State = EntityState.Unchanged;
                        throw new RepositoryUpdateException();
                    }
                    else if (item.State == EntityState.Deleted) {
                        item.State = EntityState.Unchanged;
                        throw new RepositoryDeleteException();
                    }
                    else if (item.State == EntityState.Added) {
                        throw new RepositoryAddException();
                    }
                }
                return 0;
            }
        }

        public void Dispose() {
            context.Dispose();
        }
    }
}
