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
    public class GiangviensController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public GiangviensController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Giangviens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Giangvien>>> GetGiangvien()
        {
            var data = from s in _context.Giangvien
                       join cv in _context.Chucvu on s.MaCv equals cv.MaCv
                       join bm in _context.Bomontrungtam on s.MaBm equals bm.Mabm
                       select new
                       {
                           s.MaGv,
                           s.TenGv,
                           s.Tel,
                           s.Email,
                           cv.TenCv,
                           bm.TenBm
                       };
            return Ok(data);
        }

        // GET: api/Giangviens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Giangvien>> GetGiangvien(int id)
        {
            var data = from s in _context.Giangvien
                       join cv in _context.Chucvu on s.MaCv equals cv.MaCv
                       join bm in _context.Bomontrungtam on s.MaBm equals bm.Mabm
                       where s.MaGv == id
                       select new
                       {
                           s.MaCv,
                           s.MaGv,
                           s.TenGv,
                           s.Tel,
                           s.Email,
                           cv.TenCv,
                           bm.TenBm
                       };
            return Ok(data);
        }

        // PUT: api/Giangviens/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGiangvien(int id, Giangvien giangvien)
        {
            if (id != giangvien.MaGv)
            {
                return BadRequest();
            }

            _context.Entry(giangvien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiangvienExists(id))
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

        // POST: api/Giangviens
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Giangvien>> PostGiangvien(Giangvien giangvien)
        {
            _context.Giangvien.Add(giangvien);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGiangvien", new { id = giangvien.MaGv }, giangvien);
        }

        // DELETE: api/Giangviens/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Giangvien>> DeleteGiangvien(int id)
        {
            var giangvien = await _context.Giangvien.FindAsync(id);
            if (giangvien == null)
            {
                return NotFound();
            }

            _context.Giangvien.Remove(giangvien);
            await _context.SaveChangesAsync();

            return giangvien;
        }

        private bool GiangvienExists(int id)
        {
            return _context.Giangvien.Any(e => e.MaGv == id);
        }
    }
}
