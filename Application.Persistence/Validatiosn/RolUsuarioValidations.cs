

using Application.Domain.Entities;
using FluentValidation;

namespace Application.Persistence.Validatiosn
{
    public class RolUsuarioValidations : AbstractValidator<RolUsuario>
    {
        public RolUsuarioValidations()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Descripcion).MaximumLength(50).Matches(@"^[A-Za-zÁÉÍÓÚáéíóúñÑ ]+$");
            RuleFor(x => x.Estado).NotEmpty();
            RuleFor(x => x.FechaCreacion).NotEmpty();
        }
    }
}
