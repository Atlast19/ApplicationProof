

using Application.Domain.Entities;
using FluentValidation;

namespace Application.Persistence.Validatiosn
{
    public class UsuarioValidations : AbstractValidator<Usuario>
    {
        public UsuarioValidations()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.NombreCompleto).NotEmpty().MaximumLength(50).Matches(@"^[A-Za-zÁÉÍÓÚáéíóúñÑ ]+$");
            RuleFor(x => x.Correo).NotEmpty().EmailAddress();
            RuleFor(x => x.IdRolUsuario).NotEmpty();
            RuleFor(x => x.Clave).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Estado).NotEmpty();
            RuleFor(x => x.FechaCreacion).NotEmpty();
        }
    }
}
