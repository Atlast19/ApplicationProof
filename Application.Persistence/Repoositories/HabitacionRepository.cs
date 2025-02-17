using Application.Domain.Base;
using Application.Domain.Entities;
using Application.Persistence.Base;
using Application.Persistence.Context;
using Application.Persistence.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace Application.Persistence.Repoositories
{
    public class HabitacionRepository : BaseRepository<Habitacion, int>, IHabitacionRepository
    {
        private readonly ApplicationContext _contex;
        private readonly ILogger<HabitacionRepository> _logger;
        private readonly IConfiguration _configuration;
        

        public HabitacionRepository(ApplicationContext context, ILogger<HabitacionRepository> logger, IConfiguration configuracion) : base(context)
        {
            this._contex = context;
            this._logger = logger;
            this._configuration = configuracion;
        }

        public IConfiguration Configuracion { get; }

        public override  Task<OperationResult> SaveEntityAsync(Habitacion entity)
        {
            return  base.SaveEntityAsync(entity);
        }

        public override Task<OperationResult> UpdateEntityAsync(Habitacion entity)
        {
            return base.UpdateEntityAsync(entity);
        }
    }
}
