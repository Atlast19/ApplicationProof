using Application.Domain.Base;
using Application.Domain.Repository;
using Application.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models;
using System.Linq.Expressions;
using OperationResult = Application.Domain.Base.OperationResult;

namespace Application.Persistence.Base
{
    public abstract class BaseRepository<TEntity, TType> : IBaseRepository<TEntity, TType> where TEntity : class
    {
        private readonly ApplicationContext _context;
        private DbSet<TEntity> _entity { get; set; }

        protected BaseRepository(ApplicationContext context)
        {
            _context = context;
            _entity= _context.Set<TEntity>();
        }

        public virtual async Task<bool> ExistisAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _entity.AnyAsync(filter);
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _entity.ToListAsync();
        }

        public virtual async Task<OperationResult> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            OperationResult result = new OperationResult();

            try
            {
                var datos = _entity.Where(filter).ToListAsync();

                result.Data = datos;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Ocurrio un error obteniendo los datos.";
            }

            return result;
        }

        public virtual async Task<TEntity> GetEntityByIdAsync(TType id)
        {
            return await _entity.FindAsync(id);
        }

        public virtual async Task<OperationResult>SaveEntityAsync(TEntity entity)
        {
            OperationResult result = new OperationResult();

            try
            {
                _entity.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Ocurrio un error guardando los datos.";
            }
            return result;
        }

        public virtual async Task<OperationResult> UpdateEntityAsync(TEntity entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                _entity.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Ocurrio un error guardando los datos.";
            }
            return result;
        }

    }

}
