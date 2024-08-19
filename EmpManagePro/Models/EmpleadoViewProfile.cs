namespace EmpManagePro.Models
{
    public class EmpleadoViewProfile
    {
        public string EmpleadoID { get; set; } = string.Empty;// ID del empleado
        public string Nombre { get; set; } = string.Empty; // Nombre del empleado
        public string Direccion { get; set; } = string.Empty; // Dirección del empleado
        public string Telefono { get; set; } = string.Empty; // Teléfono del empleado
        public DateTime FechaContratacion { get; set; } // Fecha de contratación
        public string Rol { get; set; } = string.Empty; // Nombre del rol (ej. Admin, Empleado)

            
    }
}