using Application.Domain.Base;
using Application.Domain.Entities;
using Application.Domain.Repository;

namespace Application.Persistence.Interface
{
    public interface  ICategoriaRepository : IBaseRepository<Categoria, int>
    {
        public Task<OperationResult> DefinirTarifaBase(Categoria categoria);
        public Task<OperationResult> TarifaPorTemporada(Categoria categoria);

    }
}
