namespace BlogFinalTask.Data.DTOS
{
    public class CommentDTO : IDTO
    {
        public string Id { get; set; } = string.Empty;

        public required string Content { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string UserId { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string ArticleId { get; set; } = null!;
    }
}
