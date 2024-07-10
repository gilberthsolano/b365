using Aplicacion.Infraestructura.RegistroCivil.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Throw;

namespace Aplicacion.Caracteristicas.RegistroCivil
{
    public class ValidarRostro
    {
        public record DatosValidarRostro(string Base64);
        public record Comando(DatosValidarRostro DatosValidarRostro) : IRequest<RespuestaDTO>;
        public class Validador : AbstractValidator<Comando>
        {
            public Validador()
            {
                RuleFor(x => x.DatosValidarRostro.Base64)
                    .NotEmpty();
            }
        }
        public class Handler : IRequestHandler<Comando, RespuestaDTO>
        {
            private readonly IRegistroCivil registroCivil;

            public Handler(IRegistroCivil registroCivil)
            {
                this.registroCivil = registroCivil;
            }

            public async Task<RespuestaDTO> Handle(Comando request, CancellationToken cancellationToken)
            {
                var rostroValido = await registroCivil.ValidarRostro(request.DatosValidarRostro.Base64);
                rostroValido.Throw(x => new Exception("El rostro no es válido")).IfFalse();
                return new RespuestaDTO("Rostro válido");
            }
        }
        public record RespuestaDTO(string Mensaje);
    }
}
