using Microsoft.AspNetCore.Identity; // Importo ASP.NET Core Identity para manejar usuarios

namespace EmpManagePro.Models
{
    // Extiendo IdentityUser para crear mi propio usuario personalizado
    public class ApplicationUser : IdentityUser
    {
        // Agrego el campo EmpleadoID para relacionar usuarios con empleados
        public string? EmpleadoID { get; set; } = string.Empty;

        // Propiedad de navegación hacia Empleado
        public virtual Empleado? Empleado { get; set; }
    }
}
