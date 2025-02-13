using Application.Domain.Entities;
using Application.Domain.Repository;

namespace Application.Persistence.Interface
{
    public interface  IClienteRepository : IBaseRepository<Cliente, int>
    {
    }
}
