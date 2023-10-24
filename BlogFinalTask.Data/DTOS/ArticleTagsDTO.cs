using BlogFinalTask.Data.Models;

namespace BlogFinalTask.Data.DTOS
{
    public class ArticleTagsDTO : IDTO
    {
        public string Id { get; set; } = string.Empty;
        public string ArcticleId { get; set; } = null!;
        public Article? Article { get; set; } = null!;
        public string TagId { get; set; } = null!;
        public Tag Tag { get; set; } = null!;
    }
}
