using Aplicacion.Dominio.Entidades.CodigoVerificacion;
using Aplicacion.Dominio.Entidades.Cuenta;
using Aplicacion.Dominio.Entidades.Usuario;
using Aplicacion.Infraestructura.Persistencia.Configuracion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Infraestructura.Persistencia
{
    public partial class ContextoDB:DbContext
    {
        public ContextoDB() { }
        public ContextoDB(DbContextOptions<ContextoDB> options)
            : base(options) { }

        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Cuenta> Cuenta { get; set; }
        public virtual DbSet<CodigoVerificacion> CodigoVerificacion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguracion());
            modelBuilder.ApplyConfiguration(new CuentaConfiguracion());
            modelBuilder.ApplyConfiguration(new CodigoVerificacionConfiguracion());

            OnModelCreatingPartial(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => base.OnConfiguring(optionsBuilder);

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
