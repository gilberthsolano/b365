using Aplicacion.Dominio.Comunes;
using Aplicacion.Dominio.Entidades.CodigoVerificacion;
using Aplicacion.Dominio.Entidades.Cuenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Dominio.Entidades.Usuario
{
    public class Usuario : EntidadBase
    {
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public string CodigoDactilar { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Provincia { get; set; } = string.Empty;
        public string FotoRostroURL { get; set; } = string.Empty;
        public string SituacionLaboral { get; set; } = string.Empty;
        public string? Empresa { get; set; }
        public string PaisPagoImpuestos { get; set; } = string.Empty;
        public bool AceptoTerminosYConcidiones { get; set; } = false;
        public bool CodigoVerificado { get; set; } = false;
        public bool Inactivo { get; set; } = false;
        public List<Cuenta.Cuenta> Cuentas { get; set; } = new();
        public List<CodigoVerificacion.CodigoVerificacion> CodigosDeVerificacion { get; set; } = new();
    }
}
