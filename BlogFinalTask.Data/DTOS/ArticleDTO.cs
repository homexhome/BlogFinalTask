using System.ComponentModel.DataAnnotations;

namespace BlogFinalTask.Data.DTOS
{
    public class ArticleDTO : IDTO
    {
        public string Id { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [MaxLength(120)]
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string UserId { get; set; } = null!;
    }
}
