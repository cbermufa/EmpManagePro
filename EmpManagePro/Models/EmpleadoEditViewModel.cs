using System.ComponentModel.DataAnnotations;

namespace EmpManagePro.Models
{
    public class EmpleadoEditViewModel
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
        // ID del puesto asociado al empleado
        [Required]
        [Display(Name = "Puesto")]
        public int? PuestoID { get; set; }
        // Lista de IDs de bonificaciones que tiene el empleado
        public List<int> BonificacionesID { get; set; } = new List<int>();

        // Lista de bonificaciones relacionadas
        public ICollection<Bonificacion> Bonificaciones { get; set; } = new List<Bonificacion>();

        // Lista de IDs de deducciones que tiene el empleado
        public List<int> DeduccionesID { get; set; } = new List<int>();

        // Lista de deducciones relacionadas
        public ICollection<Deduccion> Deducciones { get; set; } = new List<Deduccion>();
    }
}
