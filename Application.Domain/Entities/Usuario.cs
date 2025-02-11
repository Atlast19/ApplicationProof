

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Application.Domain.Entities
{
    public sealed class Usuario : Base.BaseEntity<int>
    {
        [Column("IdUsuario")]
        [Key]
        public override int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public int IdRolUsuario { get; set; }
        public string Descripcion { get; set; }
    }
}
