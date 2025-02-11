

namespace Application.Domain.Base
{
    public abstract class BaseEntity<Ttype> : EstadoAndDateEntity
    {
        public abstract Ttype Id { get; set; }
    }
}
