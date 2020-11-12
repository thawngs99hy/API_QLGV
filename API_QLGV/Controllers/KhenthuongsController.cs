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
    public class KhenthuongsController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public KhenthuongsController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Khenthuongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Giangvien>>> GetKhenThuong()
        {
            var data = from k in _context.Khenthuong
                       join gv in _context.Giangvien on k.MaGv equals gv.MaGv
                       select new
                       {
                           k.MaKt,
                           gv.TenGv,
                           k.Ten,
                           k.HinhThuc,
                       };
            return Ok(data);
        }

        // GET: api/Khenthuongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Khenthuong>> GetKhenthuong(int id)
        {
            var khenthuong = await _context.Khenthuong.FindAsync(id);

            if (khenthuong == null)
            {
                return NotFound();
            }

            return khenthuong;
        }

        // PUT: api/Khenthuongs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhenthuong(int id, Khenthuong khenthuong)
        {
            if (id != khenthuong.MaKt)
            {
                return BadRequest();
            }

            _context.Entry(khenthuong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhenthuongExists(id))
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

        // POST: api/Khenthuongs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Khenthuong>> PostKhenthuong(Khenthuong khenthuong)
        {
            _context.Khenthuong.Add(khenthuong);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKhenthuong", new { id = khenthuong.MaKt }, khenthuong);
        }

        // DELETE: api/Khenthuongs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Khenthuong>> DeleteKhenthuong(int id)
        {
            var khenthuong = await _context.Khenthuong.FindAsync(id);
            if (khenthuong == null)
            {
                return NotFound();
            }

            _context.Khenthuong.Remove(khenthuong);
            await _context.SaveChangesAsync();

            return khenthuong;
        }

        private bool KhenthuongExists(int id)
        {
            return _context.Khenthuong.Any(e => e.MaKt == id);
        }
    }
}
