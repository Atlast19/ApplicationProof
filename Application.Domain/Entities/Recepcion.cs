

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Application.Domain.Entities
{
    public sealed class Recepcion : Base.BaseEntity<int>
    {
        [Column("IdRecepcion")]
        [Key]
        public override int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdHabitacion { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaSalidaConfirmacion { get; set; }
        public double PrecioInicial { get; set; }
        public double Adelanto { get; set; }
        public double PrecioRestante { get; set; }
        public double TotalPago { get; set; }
        public double CostoPenalidad { get; set; }
        public string Observacion { get; set; }
    }
}
