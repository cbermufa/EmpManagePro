using System.ComponentModel.DataAnnotations; // Importo para usar anotaciones de datos

namespace EmpManagePro.Models
{
    // Esta clase representa la relación entre un empleado y un turno
    public class TurnoEmpleado
    {
        [Key] // Establezco la propiedad TurnoEmpleadoID como clave primaria
        public int TurnoEmpleadoID { get; set; }

        [Required]
        public string EmpleadoID { get; set; } = string.Empty; // Asocio un turno con un empleado

        [Required]
        public int TurnoID { get; set; } // Asocio un turno con la tabla de Turnos

        // Propiedades de navegación para las relaciones
        public Turno? Turno { get; set; }
        public Empleado? Empleado { get; set; }
    }
}
