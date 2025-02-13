using Application.Domain.Base;
using Application.Domain.Entities;
using Application.Persistence.Base;
using Application.Persistence.Context;
using Application.Persistence.Interface;
using Application.Persistence.Validatiosn;
using FluentValidation.Results;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace Application.Persistence.Repoositories
{
    public class HabitacionRepository : BaseRepository<Habitacion, int>, IHabitacionRepository
    {
        private readonly ApplicationContext _contex;
        private readonly ILogger<HabitacionRepository> _logger;
        private readonly IConfiguration _configuration;
        HabitacionValidations Validations = new HabitacionValidations();

        public HabitacionRepository(ApplicationContext context, ILogger<HabitacionRepository> logger, IConfiguration configuracion) : base(context)
        {
            this._contex = context;
            this._logger = logger;
            this._configuration = configuracion;
        }

        public IConfiguration Configuracion { get; }

        public override async Task<OperationResult> SaveEntityAsync(Habitacion entity)
        {
            OperationResult Operation = new OperationResult();
            ValidationResult result = await Validations.ValidateAsync(entity);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    Operation.Message = "Datos no guardatos";
                    _logger.LogError($"Error: {item.PropertyName}");
                }
                return Operation;
            }
            else
            {
                try
                {
                    await _contex.Habitacion.AddAsync(entity);
                    Operation.Success = true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    Operation.Message = $"Error: {ex.Message}";
                }
            }
            return Operation;
        }

        public override Task<OperationResult> UpdateEntityAsync(Habitacion entity)
        {
            return base.UpdateEntityAsync(entity);
        }
    }
}
