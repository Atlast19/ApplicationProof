using Application.Domain.Base;
using Application.Domain.Entities;
using Application.Domain.Repository;

namespace Application.Persistence.Interface
{
    public interface IServiciosRepositoty : IBaseRepository<Servicios, int>
    {
        Task<OperationResult> GetServiciosByCategoriaId(int CategoriaId);
    }
}
