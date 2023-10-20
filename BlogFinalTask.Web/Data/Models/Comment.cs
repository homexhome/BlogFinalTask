using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogFinalTask.Web.Data.Models
{
    public class Comment : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [MaxLength(500)]
        public required string Content { get; set; } = String.Empty;

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public string UserId { get; set; } = null!;
        public CustomIdentity? User { get; set; } = null!;

        public string ArticleId { get; set; } = null!;
        public Article Article { get; set; } = null!;

    }
}
