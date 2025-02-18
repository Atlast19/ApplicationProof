using Application.Domain.Base;
using Application.Domain.Entities;
using Application.Persistence.Base;
using Application.Persistence.Context;
using Application.Persistence.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Application.Persistence.Repoositories
{
    public class ClienteRepository : BaseRepository<Cliente, int>, IClienteRepository
    {
        private readonly ApplicationContext _contex;
        private readonly ILogger<ClienteRepository> _loguer;
        private readonly IConfiguration _configuration;

        public ClienteRepository(ApplicationContext context, ILogger<ClienteRepository> loguer, IConfiguration configuracion) : base(context)
        {
            _contex = context;
            _loguer = loguer;
            _configuration = configuracion;
        }

        public Task<System.ClientModel.Primitives.OperationResult> ObtenerHistorialDeClientePorID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
