using Application.Domain.Entities;
using FluentValidation;


namespace Application.Persistence.Validatiosn
{
    public class TarifaValidations : AbstractValidator<Tarifas>
    {
        public TarifaValidations()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.IdHabitacion).NotEmpty().GreaterThan(0);
            RuleFor(x => x.FechaInicio).NotEmpty().Must((valor, _) =>
            {
                return valor.FechaInicio < valor.FechaFin;

            });
            RuleFor(x => x.PrecioPorNoche).NotEmpty();
            RuleFor(x => x.Descripcion).NotEmpty().MaximumLength(225).Matches(@"^[A-Za-zÁÉÍÓÚáéíóúñÑ ]+$");
            RuleFor(x => x.Estado).NotEmpty();
            RuleFor(x => x.FechaCreacion).NotEmpty();
        }
    }
}
