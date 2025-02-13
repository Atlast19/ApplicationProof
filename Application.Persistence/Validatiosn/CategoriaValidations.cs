
using Application.Domain.Entities;
using FluentValidation;

namespace Application.Persistence.Validatiosn
{
    public class CategoriaValidations : AbstractValidator<Categoria>
    {
        public CategoriaValidations() 
        {
            //valida que el id de la entidad Categoria no este vacio y sea mayor a 0
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            //valida que la descripcion de la entidad Categoria que tenga un maximmo de 50 caracteres y que solo acepte letras
            RuleFor(x => x.Descripcion).MaximumLength(50).Matches(@"^[A-Za-zÁÉÍÓÚáéíóúñÑ ]+$");
            //valida que el IdServicion de la enticadad Categoria no este vacio y sea mayor que 0
            RuleFor(x => x.IdServicio).NotEmpty().GreaterThan(0);
            //valida que el Esado de la entidad Categoria no este vacio
            RuleFor(x => x.Estado).NotEmpty();
            //valida que Fecha de la entidad Categoria no este vacia
            RuleFor(x =>x.FechaCreacion).NotEmpty();

        }
    }
}
