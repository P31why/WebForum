
using Microsoft.EntityFrameworkCore;
using WebForum.Core;
using WebForum.Data;
using WebForum.Infrastructure.Interfaces;

namespace WebForum.Infrastructure.Repository
{
    public class BaseRepository<TKey, TEntity> (AppDbContext dbContext): IBaseRepository<TKey, TEntity> where TEntity : class
    {

        private readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();

        public async Task CreateEntityAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task CommitDbAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteEntityAsync(TKey tkey, DeleteType type)
        {

            if (type == DeleteType.NoVisible)
                await _dbSet.Where(e => EF.Property<TKey>(e, "Id").Equals(tkey))
                                                              .ExecuteDeleteAsync();

        }
    }
}
