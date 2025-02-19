

using Application.Domain.Entities;

namespace Application.Model.Models
{
    public class CategoriaHabitacion
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioPorNoche { get; set; }
        public string Caracteristica { get; set; }
        public int IdServicio { get; set; }
    }
}
