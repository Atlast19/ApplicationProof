

namespace Application.Model.Models
{
    public class HabitacionesCategoriaModels
    {
        public int IdHabitacion { get; set; }
        public string Numero { get; set; }
        public string? Detalle { get; set; }
        public double Precio { get; set; }
        public int Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdCategoria { get; set; }
        public string CategoriaDescripcion { get; set; }
    }
}
