namespace Application.Domain.Base
{
    public abstract class EstadoAndDateEntity
    {
        protected EstadoAndDateEntity()
        {
            FechaCreacion = DateTime.Now;
        }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
