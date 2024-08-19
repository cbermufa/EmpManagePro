namespace EmpManagePro.Models
{
    public class EmpleadoDeduc
    {
        public string EmpleadoID { get; set; } = string.Empty;
        public int DeduccionID { get; set; }

        public Empleado? Empleado { get; set; }
        public Deduccion? Deduccion { get; set; }
    }
}
