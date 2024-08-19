using System.ComponentModel.DataAnnotations;

namespace EmpManagePro.Models
{
    // Este modelo representa una deducción que se aplica al salario de un empleado
    public class Deduccion
    {
        // ID de la deducción, es la clave primaria
        public int DeduccionID { get; set; }

        // Nombre de la deducción, como "Seguridad Social", "Impuesto sobre la renta", etc.
        [Required]
        [Display(Name = "Nombre de la Deducción")]
        public string Nombre { get; set; } = string.Empty;

        // Porcentaje de la deducción que se aplicará al salario
        [Required]
        [Display(Name = "Porcentaje")]
        public decimal Porcentaje { get; set; }

        // Relación muchos a muchos con Empleado
        public ICollection<EmpleadoDeduc> EmpleadoDeducciones { get; set; } = new List<EmpleadoDeduc>();
    }
}
