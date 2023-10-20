namespace BlogFinalTask.Web.Data.DTOS
{
    public class TagDTO : IDTO
    {
        public string Id { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public required string Text;
    }
}
