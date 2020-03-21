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
    public class MachinesDataController : ControllerBase
    {
        private readonly WeldingContext _context;

        public MachinesDataController(WeldingContext context)
        {
            _context = context;
        }

        // GET: api/Data
        [HttpGet("/Dates")]
        public JsonResult GetDates()
        {
            return new JsonResult(_context.MachineDatas.Include(x => x.Machine)
                .Include(x => x.Amperages)
                .Include(x => x.Voltages).ToList());
        }

        // GET: api/Data/5
        [HttpGet("/GetData{id}")]
        public async Task<JsonResult> GetData(int id)
        {
            var data = await _context.MachineDatas.Include(x => x.Machine)
                .Include(x => x.Amperages)
                .Include(x => x.Voltages)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (data == null)
            {
                return new JsonResult(BadRequest());
            }

            return new JsonResult(data);
        }

        // PUT: api/Data/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("/Data{id}")]
        public async Task<JsonResult> PutData(int id, MachineData data)
        {
            if (id != data.Id)
            {
                return new JsonResult(BadRequest());
            }

            _context.Entry(data).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataExists(id))
                {
                    return new JsonResult(NotFound());
                }
            }

            return new JsonResult(NoContent());
        }

        // POST: api/Task
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("/Data")]
        public async Task<ActionResult<MachineData>> PostData(MachineData data)
        {
            _context.MachineDatas.Add(data);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetData", new { id = data.Id }, data);
        }

        // DELETE: api/Data/5
        [HttpDelete("/Data{id}")]
        public async Task<JsonResult> DeleteData(int id)
        {
            var data = await _context.MachineDatas.FindAsync(id);
            if (data == null)
            {
                return new JsonResult(NotFound());
            }

            _context.MachineDatas.Remove(data);
            await _context.SaveChangesAsync();

            return new JsonResult(data);

        }

        private bool DataExists(int id)
        {
            return _context.MachineDatas.Any(e => e.Id == id);
        }

    }
}