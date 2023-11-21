using Microsoft.Extensions.Logging;

namespace BlogFinalTask.Data.Repository
{
    public interface IRepositoryCollection : IDisposable
    {
        IArticleRepository Article { get; }
        ICommentRepository Comment { get; }
        ITagRepository Tag { get; }
        IArticleTagsRepository ArticleTags { get; }
        ILogger<IRepositoryCollection> logger { get; }


        Task<int> Save();
    }
}
