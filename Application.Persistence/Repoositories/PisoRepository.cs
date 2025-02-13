using Application.Domain.Base;
using Application.Domain.Entities;
using Application.Persistence.Base;
using Application.Persistence.Context;
using Application.Persistence.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence.Repoositories
{
    public class PisoRepository : BaseRepository<Piso, int>, IPisoRepository
    {
        private readonly ApplicationContext _contex;
        private readonly ILogger<PisoRepository> _loguer;
        private readonly IConfiguration _configuration;

        public PisoRepository(ApplicationContext context, ILogger<PisoRepository> loguer, IConfiguration configuracion) : base(context)
        {
            this._contex = context;
            this._loguer = loguer;
            this._configuration = configuracion;
        }

        public IConfiguration Configuracion { get; }

        public override Task<OperationResult> SaveEntityAsync(Piso entity)
        {
            //agregar las validaciones//


            return base.SaveEntityAsync(entity);
        }

        public override Task<OperationResult> UpdateEntityAsync(Piso entity)
        {
            return base.UpdateEntityAsync(entity);
        }
    }
}
