

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Application.Domain.Entities
{
    public sealed class RolUsuario : Base.BaseEntity<int>
    {
        [Column("IdRolUsuario")]
        [Key]
        public override int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
