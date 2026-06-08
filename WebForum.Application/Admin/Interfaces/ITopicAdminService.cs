
using WebForum.Core.Models;

namespace WebForum.Application.Admin.Interfaces
{
    public interface ITopicAdminService
    {
        public Task<IReadOnlyCollection<TopicShortDto>> GetAllShortAsync(Guid? userId = null);
    }
}
