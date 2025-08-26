
using DeptApi.Data;
using DeptApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeptApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeptController : ControllerBase
    {
        private readonly DeptDbContext _context;

        public DeptController(DeptDbContext context)
        {
            _context = context;
        }

        // GET: api/Dept
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dept>>> GetDepts()
        {
            return await _context.Depts.Include(d => d.Manager).ToListAsync();
        }

        // GET: api/Dept/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dept>> GetDept(int id)
        {
            var dept = await _context.Depts.Include(d => d.Manager).FirstOrDefaultAsync(d => d.DeptId == id);

            if (dept == null)
            {
                return NotFound();
            }

            return dept;
        }

        // PUT: api/Dept/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutDept(int id, Dept dept)
        {
            if (id != dept.DeptId)
            {
                return BadRequest();
            }

            _context.Entry(dept).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeptExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Dept
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Dept>> PostDept(Dept dept)
        {
            _context.Depts.Add(dept);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDept", new { id = dept.DeptId }, dept);
        }

        // DELETE: api/Dept/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteDept(int id)
        {
            var dept = await _context.Depts.FindAsync(id);
            if (dept == null)
            {
                return NotFound();
            }

            _context.Depts.Remove(dept);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeptExists(int id)
        {
            return _context.Depts.Any(e => e.DeptId == id);
        }
    }
}
