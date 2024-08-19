using System.ComponentModel.DataAnnotations;


namespace EmpManagePro.Models;
public class TurnoViewModel
{
    [Required]
    [Display(Name = "Tipo de Turno")]
    public string TipoTurno { get; set; } = string.Empty; // Tipo de turno

    [Required]
    [Display(Name = "Cantidad de Horas")]
    public int CantHoras { get; set; } // Cantidad total de horas del turno

    [Required]
    [Display(Name = "Días de la Semana")]
    public List<string> DiasSeleccionados { get; set; } = new List<string>();// Lista de días seleccionados para el turno

    [Required]
    [Display(Name = "Hora de Entrada")]
    public TimeSpan HoraEntrada { get; set; } // Hora de entrada del turno

    [Required]
    [Display(Name = "Hora de Salida")]
    public TimeSpan HoraSalida { get; set; } // Hora de salida del turno
}
