using System.Collections.Generic;

namespace EmpManagePro.Models
{
    public class NominasViewModel
    {
        // Lista de puestos que se mostrará en la vista
        public List<Puesto> Puestos { get; set; } = new List<Puesto>();

        // Otros campos para bonificaciones y deducciones se agregarán más adelante
    }
}
