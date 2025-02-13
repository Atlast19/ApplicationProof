

using Application.Domain.Base;
using Application.Domain.Entities;
using Application.Persistence.Base;
using Application.Persistence.Context;
using Application.Persistence.Interface;
using Application.Persistence.Validatiosn;
using FluentValidation.Results;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;


namespace Application.Persistence.Repoositories
{
    public class CategoriaRepository : BaseRepository<Categoria, int>, ICategoriaRepository
    {
        private readonly ApplicationContext _contex;
        private readonly ILogger<CategoriaRepository> _logger;
        private readonly IConfiguration _configuration;
        CategoriaValidations Validations = new CategoriaValidations();

        public CategoriaRepository(ApplicationContext context, ILogger<CategoriaRepository> loguer,IConfiguration configuracion) : base(context)
        {
            this._contex = context;
            this._logger = loguer;
            this._configuration = configuracion;
        }

        public IConfiguration Configuracion { get; }

        public override async Task<OperationResult> SaveEntityAsync(Categoria entity) 
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
                    await _contex.Categoria.AddAsync(entity);
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

        public override Task<OperationResult> UpdateEntityAsync(Categoria entity) 
        {
            return base.UpdateEntityAsync(entity);
        }
    }
}
