
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebForum.Core;
using WebForum.Data;
using WebForum.Infrastructure.Interfaces;

namespace WebForum.Infrastructure.Repository
{
    public class BaseRepository<TKey, TEntity> : IBaseRepository<TKey, TEntity> where TEntity : class, IId<TKey>
    {
        protected readonly AppDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task<TEntity> CreateEntityAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);

            return entity;
        }

        public async Task<bool> CommitDbAsync()
        {
            int rowsAffected = await _dbContext.SaveChangesAsync();

            return rowsAffected > 0;
        }

        public virtual async Task<bool> DeleteEntityAsync(TKey tkey, DeleteType type)
        {
            int rows = 0;

            if (type == DeleteType.Full)
            {
                var parameter = Expression.Parameter(typeof(TEntity), "e");

                var property = Expression.Call(
                    typeof(EF),
                    nameof(EF.Property),
                    new[] { typeof(TKey) },
                    parameter,
                    Expression.Constant("Id")
                );

                var equals = Expression.Equal(property, Expression.Constant(tkey));

                var lambda = Expression.Lambda<Func<TEntity, bool>>(equals, parameter);

                rows = await _dbSet.Where(lambda).ExecuteDeleteAsync();
            }

            return rows > 0;
        }
    }
}
