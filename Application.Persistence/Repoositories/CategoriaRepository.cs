

using Application.Domain.Base;
using Application.Domain.Entities;
using Application.Persistence.Base;
using Application.Persistence.Context;
using Application.Persistence.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Application.Persistence.Repoositories
{
    public class CategoriaRepository : BaseRepository<Categoria, int>, ICategoriaRepository
    {
        private readonly ApplicationContext _contex;
        private readonly ILogger<CategoriaRepository> _loguer;
        private readonly IConfiguration _configuration;

        public CategoriaRepository(ApplicationContext context, ILogger<CategoriaRepository> loguer,IConfiguration configuracion) : base(context)
        {
            this._contex = context;
            this._loguer = loguer;
            this._configuration = configuracion;
        }

        public IConfiguration Configuracion { get; }

        public override Task<OperationResult> SaveEntityAsync(Categoria entity) 
        {
            //agregar las validaciones//


            return base.SaveEntityAsync(entity);
        }

        public override Task<OperationResult> UpdateEntityAsync(Categoria entity) 
        {
            return base.UpdateEntityAsync(entity);
        }
    }
}
