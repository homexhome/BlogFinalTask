using System.ComponentModel.DataAnnotations;

namespace BlogFinalTask.Data.DTOS
{
    public class ArticleDTO : IDTO
    {
        public string Id { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [MaxLength(120)]
        public required string Title { get; set; }
        public required string Content { get; set; }
        public string UserId { get; set; } = null!;
    }
}
