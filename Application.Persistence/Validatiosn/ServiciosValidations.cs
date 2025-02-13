using Application.Domain.Entities;
using FluentValidation;


namespace Application.Persistence.Validatiosn
{
    public class ServiciosValidations: AbstractValidator<Servicios>
    {
        public ServiciosValidations()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Nombre).NotEmpty().MaximumLength(200).Matches(@"^[A-Za-zÁÉÍÓÚáéíóúñÑ ]+$");
            RuleFor(x => x.Descripcion).Matches(@"^[A-Za-zÁÉÍÓÚáéíóúñÑ ]+$").NotEmpty();

        }
    }
}
