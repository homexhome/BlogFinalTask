using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogFinalTask.Web.Data.Models
{
    public class Tag : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [MaxLength(50)][Required]
        public required string Text { get; set; }

    }
}
