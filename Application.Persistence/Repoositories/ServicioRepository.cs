using Application.Domain.Base;
using Application.Domain.Entities;
using Application.Model.Models;
using Application.Persistence.Base;
using Application.Persistence.Context;
using Application.Persistence.Interface;
using Application.Persistence.Validatiosn;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence.Repoositories
{
    public class ServicioRepository : BaseRepository<Servicios, int>, IServiciosRepositoty
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<ServicioRepository> _logger;
        private readonly IConfiguration _configuracion;
        ServiciosValidations Validations = new ServiciosValidations();

        public ServicioRepository(ApplicationContext context, ILogger<ServicioRepository> logger, IConfiguration configuracion) : base(context)
        {
            this._context = context;
            this._logger = logger;
            this._configuracion = configuracion;
        }

        public IConfiguration Configuracion { get; }

        public async Task<OperationResult> GetServiciosByCategoriaId(int CategoriaId)
        {
            OperationResult result = new OperationResult();
            try
            {
                var querys = await (from Servicios in _context.Servicios
                                    join Categoria in _context.Categoria on Servicios.Id equals Categoria.IdServicio
                                    where Servicios.Id == CategoriaId
                                    select new ServiciosCategoriaModel()
                                    {
                                        IdServicio = Servicios.Id,
                                        FechaCreacion = Servicios.FechaCreacion,
                                        Nombre = Servicios.Nombre,
                                        Descripcion = Servicios.Descripcion,
                                        IdCategoria = Categoria.Id
                                    }).ToListAsync();
                result.Data = querys;

            }
            catch (Exception ex)
            {
                result.Message = this._configuracion["ErrorServiciosRepository:GetServiciosCategoriaModel"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public override async Task<OperationResult> SaveEntityAsync(Servicios entity)
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
                    await _context.Servicios.AddAsync(entity);
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
        public override Task<OperationResult> UpdateEntityAsync(Servicios entity)
        {
            return base.UpdateEntityAsync(entity);
        }
    }
}
