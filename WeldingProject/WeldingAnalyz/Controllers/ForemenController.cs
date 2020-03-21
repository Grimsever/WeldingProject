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
    public class ForemenController : ControllerBase
    {
        private readonly WeldingContext _context;

        public ForemenController(WeldingContext context)
        {
            _context = context;
        }

        // GET: api/Foremen
        [HttpGet]
        public JsonResult GetForemans()
        {
            return new JsonResult(_context.Foremans.Include(x => x.Workers).ToList());
        }

        // GET: api/Foremen/5
        [HttpGet("{id}")]
        public async Task<JsonResult> GetForeman(int id)
        {
            var foreman = await _context.Foremans.Include(x => x.Workers).FirstOrDefaultAsync(x => x.Id == id);

            if (foreman == null)
            {
                return new JsonResult(BadRequest());
            }

            return new JsonResult(foreman);
        }

        // PUT: api/Foremen/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<JsonResult> PutForeman(int id, Foreman foreman)
        {
            if (id != foreman.Id)
            {
                return new JsonResult(BadRequest());
            }

            _context.Entry(foreman).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForemanExists(id))
                {
                    return new JsonResult(NotFound());
                }
            }

            return new JsonResult(NoContent());
        }

        // POST: api/Foremen
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Foreman>> PostForeman(Foreman foreman)
        {
            _context.Foremans.Add(foreman);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetForeman", new { id = foreman.Id }, foreman);
        }

        // DELETE: api/Foremen/5
        [HttpDelete("{id}")]
        public async Task<JsonResult> DeleteForeman(int id)
        {
            var foreman = await _context.Foremans.FindAsync(id);
            if (foreman == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Foremans.Remove(foreman);
            await _context.SaveChangesAsync();

            return new JsonResult(foreman);

        }

        private bool ForemanExists(int id)
        {
            return _context.Foremans.Any(e => e.Id == id);
        }
    }
}
