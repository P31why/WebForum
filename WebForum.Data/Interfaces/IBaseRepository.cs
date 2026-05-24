
using WebForum.Core;

namespace WebForum.Infrastructure.Interfaces
{
    public interface IBaseRepository<Tkey, TEntity> where TEntity : class
    {
        public Task CreateEntityAsync(TEntity entity);

        public Task CommitDbAsync();

        public Task DeleteEntityAsync(Tkey tkey, DeleteType type);
    }
}
