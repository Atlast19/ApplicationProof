using Application.Domain.Base;
using Application.Domain.Entities;
using Application.Model.Models;
using Application.Persistence.Base;
using Application.Persistence.Context;
using Application.Persistence.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using 


namespace Application.Persistence.Repoositories
{
    public class HabitacionRepository : BaseRepository<Domain.Entities.Habitacion, int>, IHabitacionRepository
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<HabitacionRepository> _loguer;
        private readonly IConfiguration _configuration;

        public HabitacionRepository(ApplicationContext context, ILogger<HabitacionRepository> loguer, IConfiguration configuracion) : base(context)
        {
            this._context = context;
            this._loguer = loguer;
            this._configuration = configuracion;
        }

        public async Task<OperationResult> GetHabitacionesByCategoriaId(int categoriaId)
        {
            var result = new OperationResult();
            try
            {
                var habitaciones = await (from h in _context.Habitacion
                                          join c in _context.Categorias on h.IdCategoria equals c.Id
                                          where h.IdCategoria == categoriaId
                                          select new HabitacionesCategoriaModels
                                          {
                                              IdHabitacion = h.Id,
                                              Numero = h.Numero,
                                              Detalle = h.Detalle,
                                              Precio = h.Precio,
                                              Estado = h.Estado,
                                              FechaCreacion = h.FechaCreacion,
                                              IdCategoria = c.Id,
                                              CategoriaDescripcion = c.Descripcion
                                          }).ToListAsync();

                result.Data = habitaciones;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorHabitacionRepository:GetHabitacionesByCategoriaId"];
                result.Success = false;
                this._loguer.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public IConfiguration Configuracion { get; }
    }
}
