using Application.Domain.Base;
using Application.Domain.Entities;
using Application.Persistence.Base;
using Application.Persistence.Context;
using Application.Persistence.Interface;
using Application.Persistence.Validatiosn;
using FluentValidation.Results;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence.Repoositories
{
    public class RecepcionRepository : BaseRepository<Recepcion, int>, IRecepcionRepository
    {
        private readonly ApplicationContext _contex;
        private readonly ILogger<RecepcionRepository> _logger;
        private readonly IConfiguration _configuration;
        RecepcionValidations Validations = new RecepcionValidations();

        public RecepcionRepository(ApplicationContext context, ILogger<RecepcionRepository> logger, IConfiguration configuracion) : base(context)
        {
            this._contex = context;
            this._logger = logger;
            this._configuration = configuracion;
        }

        public IConfiguration Configuracion { get; }

        public override async Task<OperationResult> SaveEntityAsync(Recepcion entity)
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
                    await _contex.Recepcions.AddAsync(entity);
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

        public override Task<OperationResult> UpdateEntityAsync(Recepcion entity)
        {
            return base.UpdateEntityAsync(entity);
        }
    }
}
