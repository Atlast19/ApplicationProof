using Application.Domain.Base;
using Application.Domain.Entities;
using Application.Persistence.Base;
using Application.Persistence.Context;
using Application.Persistence.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Application.Persistence.Repoositories
{
    public class UsuarioRepository : BaseRepository<Usuario,int>, IUsuarioRepository
    {
        private readonly ApplicationContext _contex;
        private readonly ILogger<UsuarioRepository> _loguer;
        private readonly IConfiguration _configuration;

        public UsuarioRepository(ApplicationContext context, ILogger<UsuarioRepository> loguer, IConfiguration configuracion) : base(context)
        {
            _contex = context;
            _loguer = loguer;
            _configuration = configuracion;
        }
    }
}
