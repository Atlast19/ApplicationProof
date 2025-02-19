using Application.Domain.Base;
using Application.Domain.Entities;
using Application.Domain.Repository;
using Application.Model.Models;


namespace Application.Persistence.Interface
{
    public interface IHabitacionRepository : IBaseRepository<Domain.Entities.Habitacion, int>
    {
        Task<OperationResult> GetHabitacionesByCategoriaId(int categoriaId);
    }
}
