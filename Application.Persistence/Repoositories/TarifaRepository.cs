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
    public class TarifaRepository : BaseRepository<Tarifas, int>, ITarifaRepository
    {
        private readonly ApplicationContext _contex;
        private readonly ILogger<TarifaRepository> _logger;
        private readonly IConfiguration _configuration;
        TarifaValidations Validations = new TarifaValidations();

        public TarifaRepository(ApplicationContext context, ILogger<TarifaRepository> logger, IConfiguration configuracion) : base(context)
        {
            this._contex = context;
            this._logger = logger;
            this._configuration = configuracion;
        }

        public IConfiguration Configuracion { get; }

        public override async Task<OperationResult> SaveEntityAsync(Tarifas entity)
        {
            //agregar las validaciones//
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
                    await _contex.Tarifas.AddAsync(entity);
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

        public override Task<OperationResult> UpdateEntityAsync(Tarifas entity)
        {
            return base.UpdateEntityAsync(entity);
        }
    }
}
