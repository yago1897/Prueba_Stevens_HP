using FluentValidation;
using Services.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Infraestructure.Validators
{
    public class AutoreValidator : AbstractValidator<AutoreDTO>
    {
        public AutoreValidator()
        {
            RuleFor(autor => autor.NombreAutor)

            .NotEmpty().WithMessage("campo obrigatório");

            RuleFor(autor => autor.AutorFechaNacimiento)
                .NotNull()
                .NotEmpty().WithMessage("campo obrigatório");
            //.LessThan(p => DateTime.Now);

            RuleFor(autor => autor.CiudadAutor)
               .NotEmpty().WithMessage("campo obrigatório");

            RuleFor(autor => autor.EmailAutor)
               .NotNull()

               .NotEmpty().WithMessage("campo obrigatório")
            .EmailAddress().WithMessage("email inválido");
            //.OnAnyFailure(autor => autor.EmailAutor = "");

        }
    }
}
