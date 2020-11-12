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
    public class BomontrungtamsController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public BomontrungtamsController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Bomontrungtams
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Bomontrungtam>>> GetBomontrungtam()
        //{
        //    var data = from bm in _context.Bomontrungtam

        //               select new
        //               {
        //                    bm.Mabm,
        //                    bm.TenBm,
        //               };
        //    return Ok(data);
        //}

        public async Task<ActionResult<IEnumerable<Bomontrungtam>>> GetBomontrungtam()
        {
            return await _context.Bomontrungtam.ToListAsync();
        }

        // GET: api/Bomontrungtams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bomontrungtam>> GetBomontrungtam(int id)
        {
            var bomontrungtam = await _context.Bomontrungtam.FindAsync(id);

            if (bomontrungtam == null)
            {
                return NotFound();
            }

            return bomontrungtam;
        }

        // PUT: api/Bomontrungtams/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBomontrungtam(int id, Bomontrungtam bomontrungtam)
        {
            if (id != bomontrungtam.Mabm)
            {
                return BadRequest();
            }

            _context.Entry(bomontrungtam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BomontrungtamExists(id))
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

        // POST: api/Bomontrungtams
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Bomontrungtam>> PostBomontrungtam(Bomontrungtam bomontrungtam)
        {
            _context.Bomontrungtam.Add(bomontrungtam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBomontrungtam", new { id = bomontrungtam.Mabm }, bomontrungtam);
        }

        // DELETE: api/Bomontrungtams/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bomontrungtam>> DeleteBomontrungtam(int id)
        {
            var bomontrungtam = await _context.Bomontrungtam.FindAsync(id);
            if (bomontrungtam == null)
            {
                return NotFound();
            }

            _context.Bomontrungtam.Remove(bomontrungtam);
            await _context.SaveChangesAsync();

            return bomontrungtam;
        }

        private bool BomontrungtamExists(int id)
        {
            return _context.Bomontrungtam.Any(e => e.Mabm == id);
        }
    }
}
