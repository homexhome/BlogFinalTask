namespace BlogFinalTask.Web.Repository
{
    public interface IRepositoryCollection : IDisposable
    {
        IArticleRepository Article { get; }
        ICommentRepository Comment { get; }
        ITagRepository Tag { get; }
        IArticleTagsRepository ArticleTags { get; }

        Task<int> Save();
    }
}
