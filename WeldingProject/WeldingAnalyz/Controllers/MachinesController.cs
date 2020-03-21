using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeldingAnalyz.DAL.Models;
using WeldingAnalyz.Data.Context;

namespace WeldingAnalyz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachinesController : ControllerBase
    {
        private readonly WeldingContext _context;

        public MachinesController(WeldingContext context)
        {
            _context = context;
        }

        // GET: api/Machines
        [HttpGet]
        public async Task<JsonResult> GetMachines()
        {
            var machines = await _context.Machines
                .Include(x => x.MachineData)
                .Include(x => x.Task).ToListAsync();

            return new JsonResult(machines);
        }

        // GET: api/Machines/5
        [HttpGet("{id}")]
        public async Task<JsonResult> GetMachine(int id)
        {
            var machine = await _context.Machines
                .Include(x => x.Task)
                .Include(x => x.MachineData)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (machine == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(machine);
        }

        // PUT: api/Machines/5

        [HttpPut("{id}")]
        public async Task<JsonResult> PutMachine(int id, Machine machine)
        {
            if (id != machine.Id)
            {
                return new JsonResult(BadRequest());
            }

            _context.Entry(machine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineExists(id))
                    return new JsonResult(NotFound());

            }

            return new JsonResult(NoContent());
        }

        // POST: api/Machines

        [HttpPost]
        public async Task<ActionResult<Machine>> PostMachine(Machine machine)
        {
            _context.Machines.Add(machine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMachine", new { id = machine.Id }, machine);
        }

        // DELETE: api/Machines/5
        [HttpDelete("{id}")]
        public async Task<JsonResult> DeleteMachine(int id)
        {
            var machine = await _context.Machines.FindAsync(id);
            if (machine == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Machines.Remove(machine);
            await _context.SaveChangesAsync();

            return new JsonResult(machine);
        }

        private bool MachineExists(int id)
        {
            return _context.Machines.Any(e => e.Id == id);
        }
    }
}
