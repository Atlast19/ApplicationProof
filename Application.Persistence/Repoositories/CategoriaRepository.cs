


using Application.Domain.Entities;
using Application.Persistence.Base;
using Application.Persistence.Context;
using Application.Persistence.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Application.Persistence.Repoositories
{
    public class CategoriaRepository : BaseRepository<Categoria, int>, ICategoriaRepository
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<CategoriaRepository> _loguer;
        private readonly IConfiguration _configuration;

        public CategoriaRepository(ApplicationContext context, ILogger<CategoriaRepository> loguer,IConfiguration configuracion) : base(context)
        {
            this._context = context;
            this._loguer = loguer;
            this._configuration = configuracion;
        }

        public IConfiguration Configuracion { get; }

        //public override async Task<OperationResult> SaveEntityAsync(Categoria entity)
        //{
        //    var result = new OperationResult();
        //    try
        //    {
        //        bool exists = await _context.Categorias
        //            .AnyAsync(c => c.Descripcion.ToLower() == entity.Descripcion.ToLower());

        //        if (exists)
        //        {
        //            result.Success = false;
        //            result.Message = "El nombre de la categoría ya está registrado en el sistema.";
        //            return result;
        //        }


        //        var categoria = new Categoria
        //        {
        //            Descripcion = entity.Descripcion,
        //            Estado = "Activo",
        //            FechaCreacion = DateTime.Now,
        //            IdServicio = entity.IdServicio 
        //        };

                
        //        await _context.Categorias.AddAsync(categoria);
        //        await _context.SaveChangesAsync();

               
        //        var tarifa = new Tarifas
        //        {
        //            IdHabitacion = categoria.Id, 
        //            Descuento = 0,
        //            Descripcion = entity.Descripcion, 
        //            FechaInicio = DateTime.Now,
        //            FechaFin = DateTime.Now.AddYears(1), 
        //            Estado = "Activo" 
        //        };

                
        //        await _context.Tarifas.AddAsync(tarifa);
        //        await _context.SaveChangesAsync();

        //        result.Success = true;
        //        result.Message = "Categoría de habitación creada correctamente, con su tarifa asociada.";
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Success = false;
        //        result.Message = "Ocurrió un error al guardar la categoría o tarifa.";
        //        _loguer.LogError(result.Message, ex.ToString());
        //    }

        //    return result;
        //}
    }
}
