namespace EmpManagePro.Models
{
    public class EmpleadoBonif
    {
        public string EmpleadoID { get; set; } = string.Empty;
        public int BonificacionID { get; set; }

        public Empleado? Empleado { get; set; }
        public Bonificacion? Bonificacion { get; set; }
    }
}
