using Microsoft.AspNetCore.Mvc; // Importo las herramientas MVC
using Microsoft.EntityFrameworkCore; // Importo Entity Framework Core para manejar la base de datos
using EmpManagePro.BaseDatos; // Importo el contexto de base de datos personalizado
using EmpManagePro.Models; // Importo los modelos necesarios
using System.Diagnostics;
using EmpManagePro.ViewModels;

namespace EmpManagePro.Controllers
{
    public class NominasController : Controller
    {
        private readonly EmpleadosDBContext _context; // Creo una instancia privada del contexto de base de datos

        // Constructor del controlador
        public NominasController(EmpleadosDBContext context)
        {
            _context = context; // Asigno la instancia del contexto de base de datos
        }

        // Acción para mostrar la vista unificada de gestión de nóminas
        public IActionResult GestionNominas()
        {
            // Simplemente retorno la vista "GestionNominas"
            return View();
        }

        // Acción para mostrar la vista de gestión de puestos
        public IActionResult GestionarPuestos()
        {
            var puestos = _context.Puesto.ToList(); // Obtengo la lista de puestos desde la base de datos
            ViewBag.Puestos = puestos; // Paso la lista a la vista usando ViewBag
            return View(new Puesto()); // Retorno la vista con un modelo vacío de Puesto para el formulario
        }

        // Este método maneja la creación de un nuevo puesto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePuesto(Puesto model)
        {
            // Verifico si el modelo es válido antes de continuar
            if (ModelState.IsValid)
            {
                // Agrego el nuevo puesto al contexto de la base de datos
                _context.Puesto.Add(model);

                // Guardo los cambios de manera asíncrona
                await _context.SaveChangesAsync();

                // Redirijo a la acción GestionarPuestos para que el usuario vea la lista actualizada
                return RedirectToAction(nameof(GestionarPuestos));
            }

            // Si el modelo no es válido, regreso a la vista de gestión con el modelo original para corregir errores
            return View("GestionarPuestos", model);
        }

        // Acción para mostrar la vista de edición de un puesto
        public async Task<IActionResult> EditPuesto(int? id)
        {
            // Verifico si se ha proporcionado un ID
            if (id == null)
            {
                // Si no, retorno un error 404
                return NotFound();
            }

            // Busco el puesto en la base de datos por su ID
            var puesto = await _context.Puesto.FindAsync(id);
            Debug.WriteLine($"ID recibido: {id}, PuestoID en el modelo: {puesto.PuestoID}");
            // Verifico si se encontró el puesto
            if (puesto == null)
            {
                // Si no, retorno un error 404
                return NotFound();
            }

            // Paso el puesto a la vista de edición
            return View(puesto);
        }

        // POST: Nominas/EditPuesto/#
        // Acción para manejar la solicitud de edición de un puesto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPuesto(int id, Puesto puesto)
        {
            //Console.WriteLine($"ID recibido: {id}, PuestoID en el modelo: {puesto.PuestoID}");
            Debug.WriteLine($"ID recibido: {id}, PuestoID en el modelo: {puesto.PuestoID}");

            // Verifico si el ID proporcionado coincide con el del modelo
            if (id != puesto.PuestoID)
            {
                return NotFound(); // Si no coinciden, regreso un 404
            }

            // Verifico si el modelo es válido
            if (ModelState.IsValid)
            {
                try
                {
                    // Actualizo el puesto en la base de datos
                    _context.Update(puesto);
                    // Guardo los cambios en la base de datos de manera asíncrona
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Verifico si el puesto todavía existe en la base de datos
                    if (!PuestoExists(puesto.PuestoID))
                    {
                        return NotFound(); // Si no existe, regreso un 404
                    }
                    else
                    {
                        throw; // Si ocurre un error de concurrencia, lo lanzo
                    }
                }
                // Redirijo de vuelta a la vista de gestión de puestos
                return RedirectToAction(nameof(GestionarPuestos));
            }

            // Si el modelo no es válido, regreso a la vista de edición con los errores
            return View(puesto);
        }

        // Acción para mostrar la vista de confirmación de eliminación de un puesto
        public async Task<IActionResult> DeletePuesto(int? id)
        {
            // Verifico si se ha proporcionado un ID
            if (id == null)
            {
                // Si no, retorno un error 404
                return NotFound();
            }

            // Busco el puesto en la base de datos por su ID
            var puesto = await _context.Puesto
                .FirstOrDefaultAsync(m => m.PuestoID == id);
            // Verifico si se encontró el puesto
            if (puesto == null)
            {
                // Si no, retorno un error 404
                return NotFound();
            }

            // Paso el puesto a la vista de confirmación de eliminación
            return View(puesto);
        }

        // Acción para confirmar la eliminación de un puesto
        [HttpPost, ActionName("DeletePuestoConfirmed")]
        [ValidateAntiForgeryToken] // Protejo el método contra ataques CSRF
        public async Task<IActionResult> DeletePuestoConfirmed(int id)
        {
            // Busco el puesto en la base de datos por su ID
            var puesto = await _context.Puesto.FindAsync(id);
            // Verifico si el puesto no es nulo
            if (puesto != null)
            {
                // Si existe, lo elimino de la base de datos
                _context.Puesto.Remove(puesto);
                // Guardo los cambios en la base de datos de manera asíncrona
                await _context.SaveChangesAsync();
            }
            // Redirijo al usuario de vuelta a la vista de gestión de puestos
            return RedirectToAction(nameof(GestionarPuestos));
        }

        // Método privado para verificar si un puesto existe en la base de datos
        private bool PuestoExists(int id)
        {
            // Verifico si existe un puesto con el ID proporcionado
            return _context.Puesto.Any(e => e.PuestoID == id);
        }

        // Acción para mostrar la vista de gestión de deducciones
        public async Task<IActionResult> GestionarDeducciones()
        {
            var deducciones = await _context.Deduccion.ToListAsync();
            return View(deducciones);
        }

        // Acción para crear una nueva deducción
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDeduccion(string Nombre, decimal Porcentaje)
        {
            var deduccion = new Deduccion { Nombre = Nombre, Porcentaje = Porcentaje };
            _context.Deduccion.Add(deduccion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(GestionarDeducciones));
        }

        // Acción para mostrar la vista de gestión de bonificaciones
        public async Task<IActionResult> GestionarBonificaciones()
        {
            var bonificaciones = await _context.Bonificacion.ToListAsync();

            Debug.WriteLine($"Bonificaciones: {bonificaciones}");
            return View(bonificaciones);
        }

        // Acción para crear una nueva bonificación
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBonificacion(string Nombre, decimal Monto)
        {
            var bonificacion = new Bonificacion { Nombre = Nombre, Monto = Monto };
            _context.Bonificacion.Add(bonificacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(GestionarBonificaciones));
        }

        // Acción para mostrar la vista de confirmación de eliminación de una deducción
        public async Task<IActionResult> DeleteDeduccion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deduccion = await _context.Deduccion
                .FirstOrDefaultAsync(m => m.DeduccionID == id);

            if (deduccion == null)
            {
                return NotFound();
            }

            return View(deduccion);
        }

        // Acción para confirmar la eliminación de una deducción
        [HttpPost, ActionName("DeleteDeduccion")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDeduccionConfirmed(int id)
        {
            var deduccion = await _context.Deduccion.FindAsync(id);

            if (deduccion != null)
            {
                _context.Deduccion.Remove(deduccion);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(GestionarDeducciones));
        }

        // Acción para mostrar la vista de confirmación de eliminación de una bonificación
        public async Task<IActionResult> DeleteBonificacion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bonificacion = await _context.Bonificacion
                .FirstOrDefaultAsync(m => m.BonificacionID == id);

            if (bonificacion == null)
            {
                return NotFound();
            }

            return View(bonificacion);
        }

        // Acción para confirmar la eliminación de una bonificación
        [HttpPost, ActionName("DeleteBonificacion")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBonificacionConfirmed(int id)
        {
            var bonificacion = await _context.Bonificacion.FindAsync(id);

            if (bonificacion != null)
            {
                _context.Bonificacion.Remove(bonificacion);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(GestionarBonificaciones));
        }

        // Acción para confirmar la eliminación de una deducción
        [HttpPost, ActionName("DeleteDeduccionConfirmed")]
        [ValidateAntiForgeryToken] // Protejo el método contra ataques CSRF
        public async Task<IActionResult> DeleteDeduccion(int id)
        {
            // Busco la deducción en la base de datos por su ID
            var deduccion = await _context.Deduccion.FindAsync(id);
            // Verifico si la deducción no es nula
            if (deduccion != null)
            {
                // Si existe, la elimino de la base de datos
                _context.Deduccion.Remove(deduccion);
                // Guardo los cambios en la base de datos de manera asíncrona
                await _context.SaveChangesAsync();
            }
            // Redirijo al usuario de vuelta a la vista de gestión de deducciones
            return RedirectToAction(nameof(GestionarDeducciones));
        }

        // Acción para confirmar la eliminación de una bonificación
        [HttpPost, ActionName("DeleteBonificacionConfirmed")]
        [ValidateAntiForgeryToken] // Protejo el método contra ataques CSRF
        public async Task<IActionResult> DeleteBonificacion(int id)
        {
            // Busco la bonificación en la base de datos por su ID
            var bonificacion = await _context.Bonificacion.FindAsync(id);
            // Verifico si la bonificación no es nula
            if (bonificacion != null)
            {
                // Si existe, la elimino de la base de datos
                _context.Bonificacion.Remove(bonificacion);
                // Guardo los cambios en la base de datos de manera asíncrona
                await _context.SaveChangesAsync();
            }
            // Redirijo al usuario de vuelta a la vista de gestión de bonificaciones
            return RedirectToAction(nameof(GestionarBonificaciones));
        }

        // GET: Nominas/EditDeduccion/5
        // Acción para mostrar la vista de edición de una deducción
        public async Task<IActionResult> EditDeduccion(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Si no se proporciona un ID, regreso un 404
            }

            // Busco la deducción en la base de datos por su ID
            var deduccion = await _context.Deduccion.FindAsync(id);
            if (deduccion == null)
            {
                return NotFound(); // Si no se encuentra la deducción, regreso un 404
            }

            return View(deduccion); // Retorno la vista de edición con el modelo de deducción
        }

        // POST: Nominas/EditDeduccion/5
        // Acción para manejar la solicitud de edición de una deducción
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDeduccion(int id, Deduccion deduccion)
        {
            // Verifico si el ID proporcionado coincide con el del modelo
            if (id != deduccion.DeduccionID)
            {
                return NotFound(); // Si no coinciden, regreso un 404
            }

            if (ModelState.IsValid) // Verifico si el modelo es válido
            {
                try
                {
                    _context.Update(deduccion); // Actualizo la deducción en la base de datos
                    await _context.SaveChangesAsync(); // Guardo los cambios en la base de datos de manera asíncrona
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeduccionExists(deduccion.DeduccionID)) // Verifico si la deducción todavía existe en la base de datos
                    {
                        return NotFound(); // Si no existe, regreso un 404
                    }
                    else
                    {
                        throw; // Si ocurre un error de concurrencia, lo lanzo
                    }
                }
                return RedirectToAction(nameof(GestionarDeducciones)); // Redirijo de vuelta a la vista de gestión de deducciones
            }

            return View(deduccion); // Si el modelo no es válido, regreso a la vista de edición con los errores
        }

        // Método auxiliar para verificar si una deducción existe
        private bool DeduccionExists(int id)
        {
            return _context.Deduccion.Any(e => e.DeduccionID == id);
        }

        // GET: Nominas/EditBonificacion/5
        // Acción para mostrar la vista de edición de una bonificación
        public async Task<IActionResult> EditBonificacion(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Si no se proporciona un ID, regreso un 404
            }

            // Busco la bonificación en la base de datos por su ID
            var bonificacion = await _context.Bonificacion.FindAsync(id);
            if (bonificacion == null)
            {
                return NotFound(); // Si no se encuentra la bonificación, regreso un 404
            }

            return View(bonificacion); // Retorno la vista de edición con el modelo de bonificación
        }

        // POST: Nominas/EditBonificacion/5
        // Acción para manejar la solicitud de edición de una bonificación
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBonificacion(int id, Bonificacion bonificacion)
        {
            // Verifico si el ID proporcionado coincide con el del modelo
            if (id != bonificacion.BonificacionID)
            {
                return NotFound(); // Si no coinciden, regreso un 404
            }

            if (ModelState.IsValid) // Verifico si el modelo es válido
            {
                try
                {
                    _context.Update(bonificacion); // Actualizo la bonificación en la base de datos
                    await _context.SaveChangesAsync(); // Guardo los cambios en la base de datos de manera asíncrona
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BonificacionExists(bonificacion.BonificacionID)) // Verifico si la bonificación todavía existe en la base de datos
                    {
                        return NotFound(); // Si no existe, regreso un 404
                    }
                    else
                    {
                        throw; // Si ocurre un error de concurrencia, lo lanzo
                    }
                }
                return RedirectToAction(nameof(GestionarBonificaciones)); // Redirijo de vuelta a la vista de gestión de bonificaciones
            }

            return View(bonificacion); // Si el modelo no es válido, regreso a la vista de edición con los errores
        }

        // Método auxiliar para verificar si una bonificación existe
        private bool BonificacionExists(int id)
        {
            return _context.Bonificacion.Any(e => e.BonificacionID == id);
        }

        public async Task<IActionResult> RealizarPago()
        {
            // Obtener todos los empleados que tienen un puesto asignado
            var empleados = await _context.Empleados
                .Include(e => e.Puesto)
                .Where(e => e.Puesto != null)
                .ToListAsync();

            // Pasar la lista de empleados a la vista
            return View(empleados);
        }

        [HttpPost]
        public async Task<IActionResult> RealizarPago(string empleadoId)
        {
            var empleado = await _context.Empleados
                .Include(e => e.Puesto)
                .Include(e => e.EmpleadoBonif)
                    .ThenInclude(eb => eb.Bonificacion)
                .Include(e => e.EmpleadoDeduc)
                    .ThenInclude(ed => ed.Deduccion)
                .FirstOrDefaultAsync(e => e.EmpleadoID == empleadoId);

            if (empleado == null)
            {
                return NotFound(); // Si el empleado no existe, muestra un error
            }

            // Verificar si el empleado tiene un puesto
            if (empleado.Puesto == null)
            {
                return View("SinPuesto", empleado); // Si no tiene un puesto, mostrar la vista 'SinPuesto'
            }

            // Calcular las deducciones y bonificaciones
            var totalDeducciones = empleado.EmpleadoDeduc.Sum(d => d.Deduccion.Porcentaje / 100 * empleado.Puesto.Salario);
            var totalBonificaciones = empleado.EmpleadoBonif.Sum(b => b.Bonificacion.Monto);

            // Calcular el salario neto
            var salarioNeto = empleado.Puesto.Salario + totalBonificaciones - totalDeducciones;

            // Crear el registro de pago
            var pago = new Pago
            {
                EmpleadoID = empleado.EmpleadoID,
                SalarioBase = empleado.Puesto.Salario,
                TotalDeducciones = totalDeducciones,
                TotalBonificaciones = totalBonificaciones,
                SalarioNeto = salarioNeto,
                FechaPago = DateTime.Now
            };

            _context.Pagos.Add(pago); // Guardar el pago en la base de datos
            await _context.SaveChangesAsync(); // Guardar los cambios

            return RedirectToAction("HistoricoPagos", new { empleadoId = empleado.EmpleadoID }); // Redirigir al historial de pagos del empleado
        }


        public async Task<IActionResult> HistoricoPagos(string empleadoId)
        {
            var pagos = await _context.Pagos
                .Where(p => p.EmpleadoID == empleadoId)
                .OrderByDescending(p => p.FechaPago)
                .ToListAsync();

            return View(pagos); // Pasar la lista de pagos a la vista
        }

        public async Task<IActionResult> PagosTotales()
        {
            var pagosAgrupados = await _context.Pagos
                .GroupBy(p => p.FechaPago.Date)
                .Select(g => new PagoAgrupadoViewModel
                {
                    FechaPago = g.Key,
                    TotalPagado = g.Sum(p => p.SalarioNeto),
                    Pagos = g.ToList()
                })
                .ToListAsync();

            return View(pagosAgrupados); // Pasar la lista de pagos agrupados a la vista
        }

        public async Task<IActionResult> EmpleadosSinPuesto()
        {
            var empleadosSinPuesto = await _context.Empleados
                .Where(e => e.PuestoID == null)
                .ToListAsync();

            return View(empleadosSinPuesto); // Pasar la lista de empleados a la vista
        }

        public async Task<IActionResult> DetallesPorFecha(DateTime fechaPago)
        {
            // Obtener los pagos realizados en la fecha seleccionada
            var pagos = await _context.Pagos
                .Include(p => p.Empleado) // Incluimos la relación con el empleado para mostrar los detalles del empleado
                .Where(p => p.FechaPago.Date == fechaPago.Date) // Filtrar por la fecha de pago
                .ToListAsync();

            // Verificamos si se encontraron pagos
            if (pagos == null || !pagos.Any())
            {
                return NotFound(); // Si no se encuentran pagos, retornar un error 404
            }

            // Pasar la lista de pagos a la vista
            return View(pagos);
        }


    }



}
