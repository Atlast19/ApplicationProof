


using Application.Domain.Entities;
using FluentValidation;

namespace Application.Persistence.Validatiosn
{
    public class ClienteValidations : AbstractValidator<Cliente>
    {
        public ClienteValidations() 
        {

            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.TipoDocumento).NotEmpty().MaximumLength(15).Matches(@"^[A-Za-zÁÉÍÓÚáéíóúñÑ ]+$");
            RuleFor(x => x.Documento).NotEmpty().MaximumLength(15).Matches(@"^[A-Za-zÁÉÍÓÚáéíóúñÑ ]+$");
            RuleFor(x => x.NombreCompleto).NotEmpty().MaximumLength(50).Matches(@"^[A-Za-zÁÉÍÓÚáéíóúñÑ ]+$");
            RuleFor(x => x.Correo).NotEmpty().EmailAddress();
            RuleFor(x => x.Estado).NotEmpty();
            RuleFor(x => x.FechaCreacion).NotEmpty();
        }
    }
}
