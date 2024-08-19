using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations; // Importo para usar anotaciones de datos
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpManagePro.Models
{
    public class Empleado
    {
        [Required(ErrorMessage = "El ID del Empleado es requerido.")]
        [Display(Name = "Identificador del Empleado")]
        [Key]
        public string EmpleadoID { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\\s]*$", ErrorMessage = "Por favor, ingrese solo letras, tildes, diéresis y la letra Ñ.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Dirección es requerida.")]
        public string Direccion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo Email es requerido.")]
        [Display(Name = "Correo electrónico")]
        [EmailAddress(ErrorMessage = "Debe proporcionar un correo electrónico válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Teléfono es requerido.")]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Fecha de Contratación es requerida.")]
        [Display(Name = "Fecha de Contratación")]
        [DataType(DataType.Date)]
        public DateTime FechaContratacion { get; set; }

        [Required(ErrorMessage = "El Rol es requerido.")]
        [Display(Name = "Rol")]
        public string? RoleId { get; set; }

        [NotMapped]
        [Required]
        [Display(Name = "Contraseña")]
        [StringLength(30, MinimumLength = 12, ErrorMessage = "La contraseña debe tener entre 12 y 30 caracteres.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@+!&$*-.])[A-Za-z\d@+!&$*-.]{12,30}$",
        ErrorMessage = "La contraseña debe tener al menos una letra minúscula, una letra mayúscula, un número y un carácter especial (@+!&$*-.).")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [NotMapped] 
        [Required]
        [Display(Name = "Confirmar contraseña")]
        [StringLength(30, MinimumLength = 12, ErrorMessage = "La contraseña debe tener entre 12 y 30 caracteres.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@+!&$*-.])[A-Za-z\d@+!&$*-.]{12,30}$",
        ErrorMessage = "La contraseña debe tener al menos una letra minúscula, una letra mayúscula, un número y un carácter especial (@+!&$*-.).")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        // Propiedad de navegación opcional para facilitar la relación con AspNetRoles
        public IdentityRole? Role { get; set; }

        // Esta propiedad de navegación crea la relación entre Empleado y ApplicationUser
        public virtual ApplicationUser? User { get; set; }

        // Propiedad de navegación para la relación con TurnoEmpleado
        public ICollection<TurnoEmpleado>? Turnos { get; set; }

        // ID del puesto asociado al empleado
        [Required]
        [Display(Name = "Puesto")]
        public int? PuestoID { get; set; }

        // Referencia al puesto, relación uno a muchos con la tabla Puesto
        public Puesto? Puesto { get; set; }

        // Relación muchos a muchos con Bonificacion a través de la tabla intermedia
        public ICollection<EmpleadoBonif> EmpleadoBonif { get; set; } = new List<EmpleadoBonif>();

        // Relación muchos a muchos con Deduccion a través de la tabla intermedia
        public ICollection<EmpleadoDeduc> EmpleadoDeduc { get; set; } = new List<EmpleadoDeduc>();

        


    }
}
