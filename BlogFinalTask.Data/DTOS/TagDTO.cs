namespace BlogFinalTask.Data.DTOS
{
    public class TagDTO : IDTO
    {
        public string Id { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public string Text { get; set; } = null!;
    }
}
