namespace EmpManagePro.Models;
public class Turno
{
    public int TurnoID { get; set; }

    public string TipoTurno { get; set; } = string.Empty;
    public int CantHoras { get; set; }
    public TimeSpan HoraEntrada { get; set; }
    public TimeSpan HoraSalida { get; set; }
    public string DiasSeleccionados { get; set; } = string.Empty;

    // Propiedad de navegación para TurnoEmpleados
    public ICollection<TurnoEmpleado> TurnoEmpleados { get; set; }
}
