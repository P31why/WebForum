
namespace WebForum.Core.RequestModels
{
    public class UpdatePostRequestModel
    {
        public Guid Id { get; set; }

        public required string Title { get; set; }

        public string? Text { get; set; }
    }
}
