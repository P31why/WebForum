
using WebForum.Core;

namespace WebForum.Infrastructure.Interfaces
{
    public interface IBaseRepository<TKey, TEntity> where TEntity : class, IId<TKey>
    {
        public Task<TEntity> CreateEntityAsync(TEntity entity);

        public Task<bool> CommitDbAsync();

        public Task<bool> DeleteEntityAsync(TKey tkey, DeleteType type);
    }
}
