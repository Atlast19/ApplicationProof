

using Application.Domain.Entities;
using FluentValidation;

namespace Application.Persistence.Validatiosn
{
    public class RecepcionValidations: AbstractValidator<Recepcion>
    {
        public RecepcionValidations() 
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.IdCliente).NotEmpty().GreaterThan(0);
            RuleFor(x => x.IdHabitacion).NotEmpty().GreaterThan(0);
            RuleFor(x => x.FechaEntrada).NotEmpty().Must((valor, _) => 
            {
                return valor.FechaEntrada < valor.FechaSalida;
            });
            RuleFor(x => x.FechaSalidaConfirmacion).NotEmpty();
            RuleFor(x => x.PrecioInicial).NotEmpty();
            RuleFor(x => x.Adelanto).NotEmpty();
            RuleFor(x => x.PrecioRestante).NotEmpty();
            RuleFor(x => x.TotalPago).NotEmpty();
            RuleFor(x => x.CostoPenalidad).NotEmpty();
            RuleFor(x => x.Observacion).MaximumLength(500);
            RuleFor(x => x.Estado).NotEmpty();
        }
    }
}
