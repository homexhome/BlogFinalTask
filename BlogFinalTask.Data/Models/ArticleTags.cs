using System.ComponentModel.DataAnnotations.Schema;

namespace BlogFinalTask.Data.Models
{
    public class ArticleTags : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [ForeignKey("ArticleId")]
        public string ArticleId { get; set; } = string.Empty;
        public Article? Article { get; set; } = null!;
        [ForeignKey("TagId")]
        public string TagId { get; set; } = string.Empty;
        public Tag? Tag { get; set; } = null!;
    }
}
