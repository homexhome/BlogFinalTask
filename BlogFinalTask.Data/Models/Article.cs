using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogFinalTask.Data.Models
{
    public class Article : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [MaxLength(120)]
        public required string Title { get; set; } = string.Empty;
        public required string Content { get; set; } = string.Empty;
        public string UserId { get; set; } = null!;
        public CustomIdentity? User { get; set; } = null!;

    }
}
