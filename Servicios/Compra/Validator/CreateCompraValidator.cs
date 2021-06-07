using FluentValidation;
using Objects.Compra.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios.Compra.Validator
{
    public class CreateCompraValidator : AbstractValidator<CompraRequest>
    {
        public CreateCompraValidator()
        {
            RuleFor(x => x.IdUsuario).NotNull().GreaterThan(0).WithMessage("El id de usuario es requerido."); ;

            RuleFor(x => x.Moneda).NotNull().NotEmpty().WithMessage("La moneda es requerida."); ;

            RuleFor(x => x.Monto).NotNull().GreaterThan(0).WithMessage("El monto es requerido."); ;
        }
    }
}
