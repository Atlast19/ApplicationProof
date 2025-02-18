using Application.Domain.Entities;
using Application.Domain.Repository;
using System.ClientModel.Primitives;

namespace Application.Persistence.Interface
{
    public interface  IClienteRepository : IBaseRepository<Cliente, int>
    {
        public Task<OperationResult> ObtenerHistorialDeClientePorID(int id);

    }
}
