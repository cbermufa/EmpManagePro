namespace EmpManagePro.Models
{
    public class EmpleadoViewModel
    {
        public string EmpleadoID { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public DateTime FechaContratacion { get; set; }
        public string RoleId { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public int? PuestoID { get; set; }
        public string Puesto { get; set; } = string.Empty;
        public List<Turno> Turnos { get; set; } = new List<Turno>();

    }
}
