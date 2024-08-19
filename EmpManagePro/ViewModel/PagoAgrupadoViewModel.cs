using EmpManagePro.Models;

namespace EmpManagePro.ViewModels
{
    public class PagoAgrupadoViewModel
    {
        public DateTime FechaPago { get; set; } // Fecha del pago
        public decimal TotalPagado { get; set; } // Total pagado en esa fecha
        public List<Pago> Pagos { get; set; } // Lista de pagos en esa fecha
    }
}
