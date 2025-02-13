using Application.Domain.Base;
using Application.Domain.Entities;
using Application.Model.Models;
using Application.Persistence.Base;
using Application.Persistence.Context;
using Application.Persistence.Interface;
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
        private readonly ILogger<ServicioRepository> _loguer;
        private readonly IConfiguration _configuracion;

        public ServicioRepository(ApplicationContext context, ILogger<ServicioRepository> loguer, IConfiguration configuracion) : base(context)
        {
            this._context = context;
            this._loguer = loguer;
            this._configuracion = configuracion;
        }

        public IConfiguration Configuracion { get; }

        public async Task<OperationResult> GetServiciosByCategoriaId(int CategoriaId)
        {
            OperationResult result = new OperationResult();
            try
            {
                var querys = await (from Servicios in _context.Servicios
                                    join Categoria in _context.Categorias on Servicios.Id equals Categoria.IdServicio
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
                this._loguer.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public override Task<OperationResult> SaveEntityAsync(Servicios entity)
        {
            return base.SaveEntityAsync(entity);
        }
        public override Task<OperationResult> UpdateEntityAsync(Servicios entity)
        {
            return base.UpdateEntityAsync(entity);
        }
    }
}
