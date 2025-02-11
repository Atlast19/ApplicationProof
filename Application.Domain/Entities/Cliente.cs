
using Application.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Domain.Entities
{
    public sealed class Cliente : Base.BaseEntity<int>
    {
        [Column("IdCliente")]
        [Key]
        public override int Id { get; set; }

        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }

    }
}
