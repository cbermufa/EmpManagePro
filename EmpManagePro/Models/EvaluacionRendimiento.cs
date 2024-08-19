using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpManagePro.Models
{
    public class EvaluacionRendimiento
    {
        [Key]
        public int EvaluacionID { get; set; } // ID único de la evaluación

        [Required(ErrorMessage = "El Empleado es requerido.")]
        public string EmpleadoID { get; set; } = string.Empty;// ID del empleado evaluado
        public Empleado? Empleado { get; set; } // Relación con el empleado

        [Required(ErrorMessage = "Los objetivos son requeridos.")]
        [Display(Name = "Objetivos")]
        public string Objetivos { get; set; } = string.Empty; // Objetivos establecidos para la evaluación

        [Required(ErrorMessage = "Debe de haber un dato de Seguimiento")]
        [Display(Name = "Seguimiento")]
        public string Seguimiento { get; set; } = string.Empty; // Seguimiento del progreso

        [Required(ErrorMessage = "Debe de haber un dato de Retroalimentación")]
        [Display(Name = "Retroalimentación")]
        public string Retroalimentacion { get; set; } = string.Empty; // Comentarios y retroalimentación

        [Required(ErrorMessage = "Se debe de agregar una fecha para la revisión de la evaluación")]
        [Display(Name = "Fecha de Reunión")]
        public DateTime FechaReunion { get; set; } // Fecha de la reunión de evaluación
    }
}
