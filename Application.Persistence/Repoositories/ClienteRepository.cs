using Application.Domain.Base;
using Application.Domain.Entities;
using Application.Persistence.Base;
using Application.Persistence.Context;
using Application.Persistence.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace Application.Persistence.Repoositories
{
    public  class ClienteRepository : BaseRepository<Cliente, int>, IClienteRepository
    {
        private readonly ApplicationContext _contex;
        private readonly ILogger<ClienteRepository> _loguer;
        private readonly IConfiguration _configuration;

        public ClienteRepository(ApplicationContext context, ILogger<ClienteRepository> loguer, IConfiguration configuracion) : base(context)
        {
            this._contex = context;
            this._loguer = loguer;
            this._configuration = configuracion;
        }

        public IConfiguration Configuracion { get; }

        public override Task<OperationResult> SaveEntityAsync(Cliente entity)
        {
            //agregar las validaciones//


            return base.SaveEntityAsync(entity);
        }

        public override Task<OperationResult> UpdateEntityAsync(Cliente entity)
        {
            return base.UpdateEntityAsync(entity);
        }
    }
}
