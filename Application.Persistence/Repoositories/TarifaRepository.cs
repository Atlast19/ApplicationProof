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
        private readonly ILogger<TarifaRepository> _loguer;
        private readonly IConfiguration _configuration;

        public TarifaRepository(ApplicationContext context, ILogger<TarifaRepository> loguer, IConfiguration configuracion) : base(context)
        {
            _contex = context;
            _loguer = loguer;
            _configuration = configuracion;
        }
    }
}
