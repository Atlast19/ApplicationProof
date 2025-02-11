using Application.Domain.Repository;
using Application.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Persistence.Base
{
    public abstract class BaseRepository<TEntity, TType> : IBaseRepository<TEntity, TType> where TEntity : class
    {
        private readonly ApplicationContext _context;
        private TEntity _entity { get; set; }

        protected BaseRepository(ApplicationContext context, TEntity entity)
        {
            _context = context;
            _entity = entity;
            _ = _context.Set<TEntity>();
        }

        public Task DeleteEntityAsync(TEntity entity)
        {
            
            throw new NotImplementedException();
        }

        public virtual async Task<bool> ExistisAsync(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Base.OperationResult> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetEntityAsync(TType id)
        {
            throw new NotImplementedException();
        }

        public Task SaveEntityAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntity(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }

}
