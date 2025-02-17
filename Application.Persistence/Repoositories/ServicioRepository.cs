using Application.Domain.Base;
using Application.Domain.Entities;
using Application.Model.Models;
using Application.Persistence.Base;
using Application.Persistence.Context;
using Application.Persistence.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Application.Persistence.Repoositories
{
    public class ServicioRepository : BaseRepository<Servicios, int>, IServiciosRepositoty
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<ServicioRepository> _logger;
        private readonly IConfiguration _configuracion;

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

        public override Task<OperationResult> SaveEntityAsync(Servicios entity)
        {
            //Agregar validaciones//
            return base.SaveEntityAsync(entity);
        }
        public override Task<OperationResult> UpdateEntityAsync(Servicios entity)
        {
            return base.UpdateEntityAsync(entity);
        }
    }
}
