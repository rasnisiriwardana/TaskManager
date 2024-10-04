using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models; // Ensure you are using the correct namespace

namespace TaskManager.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Ensure that you are using TaskManager.Models.Task for the Task entity
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Use TaskManager.Models.Task here
            var task = await _context.Tasks
                .FirstOrDefaultAsync(m => m.TaskId == id);  // Ensure TaskId exists in your Task model

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }
    }
}
