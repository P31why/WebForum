
using Microsoft.EntityFrameworkCore;
using WebForum.Core;
using WebForum.Data;
using WebForum.Infrastructure.Interfaces;

namespace WebForum.Infrastructure.Repository
{
    public class BaseRepository<TKey, TEntity> : IBaseRepository<TKey, TEntity> where TEntity : class
    {
        protected readonly AppDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task CreateEntityAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<bool> CommitDbAsync()
        {
            int rowsAffected = await _dbContext.SaveChangesAsync();

            return rowsAffected > 0;
        }

        public virtual async Task DeleteEntityAsync(TKey tkey, DeleteType type)
        {

            if (type == DeleteType.NoVisible)
                await _dbSet.Where(e => EqualityComparer<TKey>.Default.Equals(EF.Property<TKey>(e,"Id"),tkey))
                                                              .ExecuteDeleteAsync();

        }
    }
}
