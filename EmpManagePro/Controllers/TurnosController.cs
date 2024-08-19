using Microsoft.AspNetCore.Mvc; // Importo las herramientas de MVC
using Microsoft.EntityFrameworkCore; // Importo para trabajar con la base de datos
using Microsoft.AspNetCore.Authorization; // Importo para manejar la autorización
using EmpManagePro.BaseDatos; // Importo el contexto de base de datos
using EmpManagePro.Models; // Importo los modelos necesarios
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;


namespace EmpManagePro.Controllers
{
    [Authorize] 
    public class TurnosController : Controller
    {
        private readonly EmpleadosDBContext _context; // Instancia del contexto de base de datos
        private readonly UserManager<ApplicationUser> _userManager; // Creo una instancia para manejar usuarios en la aplicación

        // Inyección de dependencias del contexto de base de datos
        public TurnosController(EmpleadosDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context; // Guardo la instancia en una variable privada
            _userManager = userManager;
        }

        // GET: Turnos
        [Authorize] // Permitir que empleados y administradores accedan a la vista de turnos
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Empleado"))
            {
                // Obtener el ID del usuario autenticado
                var currentUserId = _userManager.GetUserId(User);

                // Obtener el EmpleadoID del usuario autenticado
                var empleadoId = await _context.Users
                    .Where(u => u.Id == currentUserId)
                    .Select(u => u.EmpleadoID)
                    .FirstOrDefaultAsync();

                if (empleadoId == null)
                {
                    return NotFound(); // Si no se encuentra el EmpleadoID, retornar un error 404
                }

                // Filtrar y mostrar solo los turnos asociados al empleado
                var turnosEmpleado = await _context.TurnoEmpleados
                    .Where(te => te.EmpleadoID == empleadoId)
                    .Include(te => te.Turno)
                    .Select(te => te.Turno)
                    .ToListAsync();

                return View("TurnosEmpleado", turnosEmpleado); // Vista solo informativa para empleados
            }

            // Si el usuario es admin, mostrar todos los turnos
            var todosLosTurnos = await _context.Turnos
                .Include(t => t.TurnoEmpleados) // Incluye la relación con TurnoEmpleados
                .ThenInclude(te => te.Empleado) // Incluye la relación con Empleado
                .ToListAsync();

            return View(todosLosTurnos); // Vista general para administradores
        }


        // GET: Turnos/Create
        // Acción para mostrar la vista de creación de un nuevo turno
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View(); // Devuelvo la vista de creación
        }

        // POST: Turnos/Create
        // Acción para manejar el envío del formulario de creación de un nuevo turno
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateTurno(TurnoViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Crear el turno basado en los datos proporcionados por el usuario
                var turno = new Turno
                {
                    TipoTurno = model.TipoTurno,
                    CantHoras = model.CantHoras, 
                    HoraEntrada = model.HoraEntrada,
                    HoraSalida = model.HoraSalida,
                    DiasSeleccionados = string.Join(",", model.DiasSeleccionados) // Almacenar los días seleccionados como un string
                };

                // Agrega este log para verificar los días seleccionados
                Console.WriteLine("Días Seleccionados: " + turno.DiasSeleccionados);

                _context.Add(turno);
                await _context.SaveChangesAsync(); // Guardar el turno en la base de datos

                return RedirectToAction(nameof(Index)); // Redirigir al listado de turnos
            }

            return View(model); // Si algo falla, regresar a la vista de creación con los datos originales
        }

        // GET: Turnos/Assign/5
        // Acción para mostrar la vista de asignación de empleados a un turno
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Assign(int? id)
        {
            if (id == null) // Verifico si el ID del turno fue proporcionado
            {
                return NotFound(); // Si no, retorno un error 404
            }

            var turno = await _context.Turnos.FindAsync(id); // Busco el turno en la base de datos
            if (turno == null)
            {
                return NotFound(); // Si no se encuentra el turno, retorno un error 404
            }

            // Convertir el modelo Turno a TurnoViewModel
            var turnoViewModel = new TurnoViewModel
            {
                TipoTurno = turno.TipoTurno,
                CantHoras = turno.CantHoras,
                HoraEntrada = turno.HoraEntrada,
                HoraSalida = turno.HoraSalida,
                DiasSeleccionados = turno.DiasSeleccionados.Split(',').ToList() // Convertir de string a lista
            };

            // Preparo una lista de empleados para el dropdown
            ViewBag.Empleados = new SelectList(_context.Empleados, "EmpleadoID", "Nombre");

            return View(turnoViewModel); // Paso el turno a la vista para asignar empleados
        }

        // POST: Turnos/Assign/5
        // Acción para manejar la asignación de empleados a un turno
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Assign(int id, string empleadoID)
        {
            var turno = await _context.Turnos.FindAsync(id); // Busco el turno en la base de datos
            if (turno == null)
            {
                return NotFound(); // Si no se encuentra el turno, retorno un error 404
            }

            var turnoEmpleado = new TurnoEmpleado
            {
                TurnoID = turno.TurnoID, // Asocio el turno seleccionado
                EmpleadoID = empleadoID // Asocio el empleado seleccionado
            };

            _context.TurnoEmpleados.Add(turnoEmpleado); // Agrego la asociación en la base de datos
            await _context.SaveChangesAsync(); // Guardo los cambios

            return RedirectToAction(nameof(Index)); // Redirijo a la lista de turnos
        }

        // GET: Turnos/Edit/5
        // Acción para mostrar la vista de edición de un turno
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) // Verifico si el ID del turno fue proporcionado
            {
                return NotFound(); // Si no, retorno un error 404
            }

            var turno = await _context.Turnos.FindAsync(id); // Busco el turno en la base de datos
            if (turno == null)
            {
                return NotFound(); // Si no se encuentra el turno, retorno un error 404
            }
            return View(turno); // Paso el turno a la vista de edición
        }

        // POST: Turnos/Edit/5
        // Acción para manejar la edición de un turno
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, Turno turno)
        {
            if (id != turno.TurnoID) // Verifico si el ID proporcionado coincide con el del turno
            {
                return NotFound(); // Si no, retorno un error 404
            }

            if (ModelState.IsValid) // Verifico si el modelo es válido
            {
                try
                {
                    _context.Update(turno); // Actualizo el turno en la base de datos
                    await _context.SaveChangesAsync(); // Guardo los cambios
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurnoExists(turno.TurnoID)) // Verifico si el turno existe
                    {
                        return NotFound(); // Si no, retorno un error 404
                    }
                    else
                    {
                        throw; // Si ocurre una excepción, la lanzo
                    }
                }
                return RedirectToAction(nameof(Index)); // Redirijo a la lista de turnos
            }
            return View(turno); // Si algo falla, devuelvo la vista de edición con los errores
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> VerEmpleadosAsignados(int id)
        {
            // Buscar el turno por su ID
            var turno = await _context.Turnos
                .Include(t => t.TurnoEmpleados)
                    .ThenInclude(te => te.Empleado)
                .FirstOrDefaultAsync(t => t.TurnoID == id);

            if (turno == null)
            {
                return NotFound();
            }

            // Pasar el TurnoID a la vista a través de ViewBag
            ViewBag.TurnoID = id;

            // Crear una lista de empleados asignados al turno
            var empleadosAsignados = turno.TurnoEmpleados.Select(te => te.Empleado).ToList();

            return View(empleadosAsignados);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EliminarEmpleadoDelTurno(string empleadoID, int turnoID)
        {
            var turnoEmpleado = await _context.TurnoEmpleados
                .FirstOrDefaultAsync(te => te.EmpleadoID == empleadoID && te.TurnoID == turnoID);

            if (turnoEmpleado != null)
            {
                _context.TurnoEmpleados.Remove(turnoEmpleado);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Empleado eliminado del turno exitosamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error: No se pudo encontrar el registro del empleado en el turno.";
            }

            return RedirectToAction("VerEmpleadosAsignados", new { id = turnoID });
        }


        // GET: Turnos/Delete/5
        // Acción para mostrar la vista de confirmación de eliminación de un turno
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) // Verifico si el ID del turno fue proporcionado
            {
                return NotFound(); // Si no, retorno un error 404
            }

            var turno = await _context.Turnos
                .FirstOrDefaultAsync(m => m.TurnoID == id); // Busco el turno en la base de datos
            if (turno == null)
            {
                return NotFound(); // Si no se encuentra el turno, retorno un error 404
            }

            return View(turno); // Paso el turno a la vista de eliminación
        }

        // POST: Turnos/Delete/5
        // Acción para manejar la eliminación de un turno
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turno = await _context.Turnos.FindAsync(id); // Busco el turno en la base de datos
            if (turno != null)
            {
                _context.Turnos.Remove(turno); // Elimino el turno de la base de datos
                await _context.SaveChangesAsync(); // Guardo los cambios
            }
            return RedirectToAction(nameof(Index)); // Redirijo a la lista de turnos
        }

        private bool TurnoExists(int id)
        {
            return _context.Turnos.Any(e => e.TurnoID == id); // Verifico si el turno existe
        }
    }
}
