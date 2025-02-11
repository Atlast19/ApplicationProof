

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Application.Domain.Entities
{
    public sealed class Piso : Base.BaseEntity<int>
    {
        [Column("IdPiso")]
        [Key]
        public override int Id { get; set; }
        public string Descripcion { get; set; }

    }
}
