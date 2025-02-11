using Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models;


namespace Application.Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> option) : base(option)
        {
             
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<EstadoHabitacion> EstadoHabitacions { get; set; }
        public DbSet<Habitacion> Habitacion { get; set; }
        public DbSet<Piso> Pisos { get; set; }
        public DbSet<Recepcion> Recepcions { get; set; }
        public DbSet<RolUsuario> RolUsuarios { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<Tarifas> Tarifas { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
    }
}
