using System.ComponentModel.DataAnnotations;

namespace EmpManagePro.Models
{
    // Este modelo representa un puesto dentro de la empresa
    public class Puesto
    {
        // ID del puesto, es la clave primaria
        public int PuestoID { get; set; }

        // Nombre del puesto, como "Junior", "Senior", etc.
        [Required]
        [Display(Name = "Nombre del Puesto")]
        public string Nombre { get; set; } = string.Empty;

        // Salario asociado al puesto
        [Required]
        [Display(Name = "Salario")]
        public decimal Salario { get; set; }
    }
}
