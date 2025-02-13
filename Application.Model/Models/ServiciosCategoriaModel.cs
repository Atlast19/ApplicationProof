

namespace Application.Model.Models
{
    public class ServiciosCategoriaModel
    {
        public int IdServicio { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdCategoria { get; set; }

    }
}
