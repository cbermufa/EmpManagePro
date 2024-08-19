using System.ComponentModel.DataAnnotations;

namespace EmpManagePro.Models
{
    // Este modelo representa una bonificación que un empleado puede recibir
    public class Bonificacion
    {
        // ID de la bonificación, es la clave primaria
        [Key]
        public int BonificacionID { get; set; }

        // Nombre de la bonificación, como "Medio año", "Por objetivos cumplidos", etc.
        [Required]
        [Display(Name = "Nombre de la Bonificación")]
        public string Nombre { get; set; } = string.Empty;

        // Monto de la bonificación
        [Required]
        [Display(Name = "Monto")]
        public decimal Monto { get; set; }

        // Relación muchos a muchos con Empleado a través de la tabla intermedia
        public ICollection<EmpleadoBonif> EmpleadoBonif { get; set; } = new List<EmpleadoBonif>();
    }
}
