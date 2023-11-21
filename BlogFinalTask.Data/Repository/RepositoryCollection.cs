using AutoMapper;
using BlogFinalTask.Data.CustomDataExceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;

namespace BlogFinalTask.Data.Repository
{
    public class RepositoryCollection : IRepositoryCollection
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public IArticleRepository Article { get; private set; }
        public ICommentRepository Comment { get; private set; }
        public ITagRepository Tag { get; private set; }
        public IArticleTagsRepository ArticleTags { get; private set; }
        public ILogger<IRepositoryCollection> logger { get; private set; }

        public RepositoryCollection(IDbContextFactory<ApplicationDbContext> dbContextFactory, IMapper mapper,
            ILogger<IRepositoryCollection> logger) {
            this.logger = logger;
            this.context = dbContextFactory.CreateDbContext();
            this.mapper = mapper;
            Article = new ArticleRepository(context, mapper);
            Comment = new CommentRepository(context, mapper);
            Tag = new TagRepository(context, mapper);
            ArticleTags = new ArticleTagsRepository(context, mapper);
        }

        public async Task<int> Save() {
            try {
                logger.LogDebug(1, $"Successfully saving changes to repo at {DateTime.UtcNow}");
                return await context.SaveChangesAsync();
            }
            catch (DbUpdateException ex) {
                foreach (EntityEntry item in ex.Entries) {
                    if (item.State == EntityState.Modified) {
                        logger.LogDebug(1, $"Caught Exception trying to update repository with {item} : " +
                            $"original values - {item.OriginalValues}, updated values - {item.CurrentValues}");
                        item.CurrentValues.SetValues(item.OriginalValues);
                        item.State = EntityState.Unchanged;
                        throw new RepositoryUpdateException();
                    }
                    else if (item.State == EntityState.Deleted) {
                        item.State = EntityState.Unchanged;
                        logger.LogDebug(1, $"Caught Exception trying to delete item in repository - {item}");
                        throw new RepositoryDeleteException();
                    }
                    else if (item.State == EntityState.Added) {
                        logger.LogDebug(1, $"Caught Exception trying to add item in repository - {item}");
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
