namespace Application.Domain.Base
{
    public abstract class EstadoAndDateEntity
    {
        protected EstadoAndDateEntity()
        {
            FechaCreacion = DateTime.Now;
        }
        public int Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
