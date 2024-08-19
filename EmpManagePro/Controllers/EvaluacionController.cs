using EmpManagePro.BaseDatos;
using EmpManagePro.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmpManagePro.Controllers
{
    public class EvaluacionesController : Controller
    {
        private readonly EmpleadosDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public EvaluacionesController(EmpleadosDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Evaluaciones/MisEvaluaciones
        [Authorize(Roles = "Empleado")]
        public async Task<IActionResult> MisEvaluaciones()
        {
            // Obtener el ID del empleado autenticado
            var userId = _userManager.GetUserId(User);
            var empleadoId = await _context.Users
                .Where(u => u.Id == userId)
                .Select(u => u.EmpleadoID)
                .FirstOrDefaultAsync();

            if (empleadoId == null)
            {
                return NotFound(); // Si no se encuentra el EmpleadoID, retorno un error 404
            }

            // Obtener las evaluaciones del empleado autenticado
            var evaluaciones = await _context.EvaluacionesRendimiento
                .Where(e => e.EmpleadoID == empleadoId)
                .ToListAsync();

            return View(evaluaciones);
        }

        // GET: Evaluaciones
        public async Task<IActionResult> Index()
        {
            // Cargar todas las evaluaciones, incluyendo los datos del empleado
            var evaluaciones = await _context.EvaluacionesRendimiento
                .Include(e => e.Empleado) // Incluye el empleado asociado
                .ToListAsync();
            return View(evaluaciones); // Devuelve la lista a la vista de Index
        }

        // GET: Evaluaciones/Create
        public IActionResult Create()
        {
            // Llenar el ViewBag con la lista de empleados
            ViewBag.Empleados = new SelectList(_context.Empleados, "EmpleadoID", "Nombre");
            return View();
        }

        // POST: Evaluaciones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EvaluacionRendimiento evaluacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evaluacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirige al listado de evaluaciones después de guardar
            }

            // Si algo falla, vuelve a llenar el ViewBag y mostrar los datos actuales
            ViewBag.Empleados = new SelectList(_context.Empleados, "EmpleadoID", "Nombre", evaluacion.EmpleadoID);
            return View(evaluacion);
        }

        // GET: Evaluaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Busca la evaluación por ID e incluye el empleado asociado
            var evaluacion = await _context.EvaluacionesRendimiento
                .Include(e => e.Empleado)
                .FirstOrDefaultAsync(m => m.EvaluacionID == id);

            if (evaluacion == null)
            {
                return NotFound();
            }

            return View(evaluacion);
        }

        // GET: Evaluaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Busca la evaluación por ID
            var evaluacion = await _context.EvaluacionesRendimiento.FindAsync(id);

            if (evaluacion == null)
            {
                return NotFound();
            }

            // Llenar el ViewBag con los empleados
            ViewBag.Empleados = new SelectList(_context.Empleados, "EmpleadoID", "Nombre", evaluacion.EmpleadoID);
            return View(evaluacion);
        }

        // POST: Evaluaciones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EvaluacionRendimiento evaluacion)
        {
            if (id != evaluacion.EvaluacionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evaluacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvaluacionExists(evaluacion.EvaluacionID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            // Si hay un error, volver a cargar los empleados y regresar a la vista de edición
            ViewBag.Empleados = new SelectList(_context.Empleados, "EmpleadoID", "Nombre", evaluacion.EmpleadoID);
            return View(evaluacion);
        }

        // GET: Evaluaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Busca la evaluación por ID
            var evaluacion = await _context.EvaluacionesRendimiento
                .Include(e => e.Empleado)
                .FirstOrDefaultAsync(m => m.EvaluacionID == id);

            if (evaluacion == null)
            {
                return NotFound();
            }

            return View(evaluacion);
        }

        // POST: Evaluaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evaluacion = await _context.EvaluacionesRendimiento.FindAsync(id);
            _context.EvaluacionesRendimiento.Remove(evaluacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaluacionExists(int id)
        {
            return _context.EvaluacionesRendimiento.Any(e => e.EvaluacionID == id);
        }
    }
}
