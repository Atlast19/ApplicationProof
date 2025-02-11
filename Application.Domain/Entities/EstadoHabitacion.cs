

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Domain.Entities
{
    public sealed class EstadoHabitacion : Base.BaseEntity<int>
    {
        [Column("IdEstadoHabitacion")]
        [Key]
        public override int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
