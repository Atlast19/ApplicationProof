using Application.Domain.Entities;
using Application.Domain.Repository;


namespace Application.Persistence.Interface
{
    public interface  IUsuarioRepository : IBaseRepository<Usuario, int>
    {
    }
}
