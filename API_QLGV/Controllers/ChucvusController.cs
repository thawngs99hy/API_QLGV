using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_QLGV.Models;

namespace API_QLGV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucvusController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public ChucvusController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Chucvus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chucvu>>> GetChucvu()
        {
            return await _context.Chucvu.ToListAsync();
        }

        // GET: api/Chucvus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chucvu>> GetChucvu(int id)
        {
            var chucvu = await _context.Chucvu.FindAsync(id);

            if (chucvu == null)
            {
                return NotFound();
            }

            return chucvu;
        }

        // PUT: api/Chucvus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChucvu(int id, Chucvu chucvu)
        {
            if (id != chucvu.MaCv)
            {
                return BadRequest();
            }

            _context.Entry(chucvu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChucvuExists(id))
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

        // POST: api/Chucvus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Chucvu>> PostChucvu(Chucvu chucvu)
        {
            _context.Chucvu.Add(chucvu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChucvu", new { id = chucvu.MaCv }, chucvu);
        }

        // DELETE: api/Chucvus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Chucvu>> DeleteChucvu(int id)
        {
            var chucvu = await _context.Chucvu.FindAsync(id);
            if (chucvu == null)
            {
                return NotFound();
            }

            _context.Chucvu.Remove(chucvu);
            await _context.SaveChangesAsync();

            return chucvu;
        }

        private bool ChucvuExists(int id)
        {
            return _context.Chucvu.Any(e => e.MaCv == id);
        }
    }
}
