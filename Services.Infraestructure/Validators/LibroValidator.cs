using FluentValidation;
using Services.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Infraestructure.Validators
{
    public class LibroValidator : AbstractValidator<LibroDTO>
    {
        public LibroValidator()
        {
            RuleFor(autor => autor.LibroTitulo)

            .NotEmpty().WithMessage("campo obrigatório");

            RuleFor(autor => autor.LibroFecha)
                .NotNull()
                .NotEmpty().WithMessage("campo obrigatório");


            RuleFor(autor => autor.LibroGenero)
               .NotEmpty().WithMessage("campo obrigatório");

            RuleFor(autor => autor.NumeroPaginas)
               .NotEmpty().WithMessage("campo obrigatório");

            RuleFor(autor => autor.IdAutor)
                .NotNull().WithMessage("Campo Obligatorio")
               .NotEmpty().WithMessage("campo obrigatório");
            //.InclusiveBetween(0, 24).WithMessage("Ingrese solo números");


        }
    }
}
