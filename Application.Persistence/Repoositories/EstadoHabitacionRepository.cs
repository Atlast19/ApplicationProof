using Application.Domain.Base;
using Application.Domain.Entities;
using Application.Persistence.Base;
using Application.Persistence.Context;
using Application.Persistence.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Application.Persistence.Repoositories
{
    public class EstadoHabitacionRepository : BaseRepository<EstadoHabitacion, int>, IEstadoHabitacionRepository
    {
        private readonly ApplicationContext _contex;
        private readonly ILogger<EstadoHabitacionRepository> _loguer;
        private readonly IConfiguration _configuration;

        public EstadoHabitacionRepository(ApplicationContext context, ILogger<EstadoHabitacionRepository> loguer, IConfiguration configuracion) : base(context)
        {
            this._contex = context;
            this._loguer = loguer;
            this._configuration = configuracion;
        }

        public IConfiguration Configuracion { get; }

        public override Task<OperationResult> SaveEntityAsync(EstadoHabitacion entity)
        {
            //agregar las validaciones//


            return base.SaveEntityAsync(entity);
        }

        public override Task<OperationResult> UpdateEntityAsync(EstadoHabitacion entity)
        {
            return base.UpdateEntityAsync(entity);
        }
    }
}
