

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Application.Domain.Entities
{
    public sealed class Servicios : Base.BaseEntity<int>
    {
        [Column("IdServicio")]
        [Key]
        public override int Id { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
