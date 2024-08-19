using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // Importo el contexto base de Identity
using Microsoft.EntityFrameworkCore; // Importo Entity Framework Core para trabajar con bases de datos
using EmpManagePro.Models; // Importo mis modelos

namespace EmpManagePro.BaseDatos
{
    public class EmpleadosDBContext : IdentityDbContext<ApplicationUser>
    {
        public EmpleadosDBContext(DbContextOptions<EmpleadosDBContext> options)
            : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; } // Defino el DbSet para Empleados
        public DbSet<Turno> Turnos { get; set; } // Defino el DbSet para Turno
        public DbSet<TurnoEmpleado> TurnoEmpleados { get; set; } // Defino el DbSet para TurnoEmpleado
        
        public DbSet<Puesto> Puesto { get; set; } // Defino la tabla Puestos en el contexto de la base de datos

        public DbSet<Bonificacion> Bonificacion { get; set; } // Defino la tabla Bonificacion en el contexto de la base de datos
        public DbSet<Deduccion> Deduccion { get; set; } // Defino la tabla Deduccion en el contexto de la base de datos

        public DbSet<EmpleadoBonif> EmpleadosBonificaciones { get; set; }
        public DbSet<EmpleadoDeduc> EmpleadosDeducciones { get; set; }

        public DbSet<EvaluacionRendimiento> EvaluacionesRendimiento { get; set; } //Defino la tabla EvaluacionesRendimiento en el contexto de la base de datos

        public DbSet<Pago> Pagos { get; set; } // Defino la tabla Pagos




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configuro la relación entre ApplicationUser y Empleado
            builder.Entity<ApplicationUser>()
                .HasOne(a => a.Empleado)
                .WithOne(e => e.User)
                .HasForeignKey<ApplicationUser>(a => a.EmpleadoID)
                .OnDelete(DeleteBehavior.Cascade); // Configuro que si se borra el usuario, también se borre el empleado relacionado

            // Defino las relaciones entre TurnoEmpleado, Turno y Empleado
            builder.Entity<TurnoEmpleado>()
                .HasOne(te => te.Turno)
                .WithMany(t => t.TurnoEmpleados)
                .HasForeignKey(te => te.TurnoID);

            builder.Entity<TurnoEmpleado>()
                .HasOne(te => te.Empleado)
                .WithMany(e => e.Turnos)
                .HasForeignKey(te => te.EmpleadoID);
            
            // Configuración de las llaves compuestas
            builder.Entity<EmpleadoBonif>()
                .HasKey(eb => new { eb.EmpleadoID, eb.BonificacionID });

            builder.Entity<EmpleadoDeduc>()
                .HasKey(ed => new { ed.EmpleadoID, ed.DeduccionID });

            // Configuración de las relaciones
            builder.Entity<EmpleadoBonif>()
                .HasOne(eb => eb.Empleado)
                .WithMany(e => e.EmpleadoBonif)
                .HasForeignKey(eb => eb.EmpleadoID);

            builder.Entity<EmpleadoBonif>()
                .HasOne(eb => eb.Bonificacion)
                .WithMany(b => b.EmpleadoBonif)
                .HasForeignKey(eb => eb.BonificacionID);

            builder.Entity<EmpleadoDeduc>()
                .HasOne(ed => ed.Empleado)
                .WithMany(e => e.EmpleadoDeduc)
                .HasForeignKey(ed => ed.EmpleadoID);

            builder.Entity<EmpleadoDeduc>()
                .HasOne(ed => ed.Deduccion)
                .WithMany(d => d.EmpleadoDeducciones)
                .HasForeignKey(ed => ed.DeduccionID);
        }

    }
}
