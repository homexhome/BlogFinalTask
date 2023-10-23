using System.ComponentModel.DataAnnotations.Schema;

namespace BlogFinalTask.Web.Data.Models
{
    public class ArticleTags : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string ArcticleId { get; set; } = String.Empty;
        public Article? Article { get; set; } = null!;

        public string TagId { get; set; } = String.Empty;
        public Tag? Tag { get; set; } = null!;
    }
}
