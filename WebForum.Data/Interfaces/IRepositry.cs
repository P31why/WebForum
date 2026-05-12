
namespace WebForum.Infrastructure.Interfaces
{
    public interface IRepositry<TEntity,TKey> where TEntity : class
    {
        Task<TEntity> GetEntityAsync(TKey id, IQueryable<TEntity> include);
    }
}
