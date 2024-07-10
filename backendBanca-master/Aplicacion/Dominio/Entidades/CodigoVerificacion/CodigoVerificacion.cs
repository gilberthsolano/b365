using Aplicacion.Dominio.Comunes;
using Aplicacion.Dominio.Entidades.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Dominio.Entidades.CodigoVerificacion
{
    public class CodigoVerificacion:EntidadBase
    {
        public string Codigo { get; set; } =  string.Empty;
        public DateTime FechaExpiracion { get; set; }
        public int IdUsuario { get; set; }
        public Usuario.Usuario Usuario { get; set; } = new();
    }
}
