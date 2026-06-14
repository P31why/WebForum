
namespace WebForum.Core.Models
{
    public class CommentDto 
    {
        public long Id { get; set; }

        public Guid PostId { get; set; }

        public Guid UserId { get; set; }

        public required string Text { get; set; }

        public required bool IsDeleted {  get; set; }

        public DateTime CreationDate { get; set; }
    }
}
