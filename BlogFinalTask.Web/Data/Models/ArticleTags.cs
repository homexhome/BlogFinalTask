using System.ComponentModel.DataAnnotations.Schema;

namespace BlogFinalTask.Web.Data.Models
{
    public class ArticleTags : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string ArcticleId { get; set; } = null!;
        public Article? Article { get; set; }

        public string TagId { get; set; } = null!;
        public Tag? Tag { get; set; }
    }
}
