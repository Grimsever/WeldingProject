using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeldingAnalyz.Data.Context;
using Task = WeldingAnalyz.DAL.Models.Task;

namespace WeldingAnalyz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly WeldingContext _context;

        public TaskController(WeldingContext context)
        {
            _context = context;
        }

        // GET: api/Task
        [HttpGet]
        public JsonResult GetTasks()
        {
            return new JsonResult(_context.Tasks.Include(x => x.Machine)
                .Include(x => x.TechnologicalMap)
                .Include(x => x.Worker).ToList());
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<JsonResult> GetTask(int id)
        {
            var task = await _context.Tasks.Include(x => x.Machine)
                .Include(x => x.TechnologicalMap)
                .Include(x => x.Worker)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (task == null)
            {
                return new JsonResult(BadRequest());
            }

            return new JsonResult(task);
        }

        // PUT: api/Task/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<JsonResult> PutTask(int id, Task task)
        {
            if (id != task.Id)
            {
                return new JsonResult(BadRequest());
            }

            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return new JsonResult(NotFound());
                }
            }

            return new JsonResult(NoContent());
        }

        // POST: api/Task
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Task>> PostTask(Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = task.Id }, task);
        }

        // DELETE: api/Task/5
        [HttpDelete("{id}")]
        public async Task<JsonResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return new JsonResult(task);

        }

        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}