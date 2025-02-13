

using Application.Domain.Entities;
using FluentValidation;

namespace Application.Persistence.Validatiosn
{
    public class HabitacionValidations : AbstractValidator<Habitacion>
    {
        public HabitacionValidations() 
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Numero).NotEmpty().Must(valor => valor.All(char.IsDigit)).MaximumLength(50);
            RuleFor(x => x.Detalle).MaximumLength(50).Matches(@"^[A-Za-zÁÉÍÓÚáéíóúñÑ ]+$");
            RuleFor(x => x.Precio).NotEmpty();
            RuleFor(x => x.IdEstadoHabitacion).NotEmpty();
            RuleFor(x => x.IdEstadoHabitacion).NotEmpty();
            RuleFor(x =>x.IdPiso).NotEmpty();
            RuleFor(x => x.IdCategoria).NotEmpty();
            RuleFor(x => x.Estado).NotEmpty();
            RuleFor(x => x.FechaCreacion).NotEmpty();
        }
    }
}
