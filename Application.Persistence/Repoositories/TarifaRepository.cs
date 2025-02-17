using Application.Domain.Base;
using Application.Domain.Entities;
using Application.Persistence.Base;
using Application.Persistence.Context;
using Application.Persistence.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace Application.Persistence.Repoositories
{
    public class TarifaRepository : BaseRepository<Tarifas, int>, ITarifaRepository
    {
        private readonly ApplicationContext _contex;
        private readonly ILogger<TarifaRepository> _logger;
        private readonly IConfiguration _configuration;


        public TarifaRepository(ApplicationContext context, ILogger<TarifaRepository> logger, IConfiguration configuracion) : base(context)
        {
            this._contex = context;
            this._logger = logger;
            this._configuration = configuracion;
        }

        public IConfiguration Configuracion { get; }

        public override Task<OperationResult> SaveEntityAsync(Tarifas entity)
        {
            //agregar las validaciones//
            return base.SaveEntityAsync(entity);
        }

        public override Task<OperationResult> UpdateEntityAsync(Tarifas entity)
        {
            return base.UpdateEntityAsync(entity);
        }
    }
}
