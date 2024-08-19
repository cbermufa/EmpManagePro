using System;
using System.ComponentModel.DataAnnotations;

namespace EmpManagePro.Models
{
    public class Pago
    {
        [Key]
        public int PagoID { get; set; } // ID único del pago

        [Required]
        public string EmpleadoID { get; set; } = string.Empty; // ID del empleado asociado
        public Empleado? Empleado { get; set; } // Relación con el empleado

        [Required]
        public decimal SalarioBase { get; set; } // Salario base del empleado

        public decimal TotalDeducciones { get; set; } // Suma de todas las deducciones
        public decimal TotalBonificaciones { get; set; } // Suma de todas las bonificaciones
        public decimal SalarioNeto { get; set; } // Salario final después de aplicar deducciones y bonificaciones

        [Required]
        public DateTime FechaPago { get; set; } // Fecha en que se realizó el pago
    }
}
