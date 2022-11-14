using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_for_GoldGym.Models;

namespace WebAPI_for_GoldGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblThongTinTksController : ControllerBase
    {
        private readonly GoldGymDBContext _context;

        public TblThongTinTksController(GoldGymDBContext context)
        {
            _context = context;
        }

        // GET: api/TblThongTinTks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblThongTinTk>>> GetTblThongTinTks()
        {
            return await _context.TblThongTinTks.ToListAsync();
        }

        [HttpGet("taikhoan/{id}")]
        public async Task<ActionResult<TblThongTinTk>> GetTblThongTinTKTheoIDTaiKhoan(int id)
        {
            var tblThongTinTk = _context.TblThongTinTks.Where(x => x.IdTaiKhoan == id).FirstOrDefault();

            return tblThongTinTk;
        }

        // GET: api/TblThongTinTks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblThongTinTk>> GetTblThongTinTk(int id)
        {
            var tblThongTinTk = await _context.TblThongTinTks.FindAsync(id);

            if (tblThongTinTk == null)
            {
                return NotFound();
            }

            return tblThongTinTk;
        }

        // PUT: api/TblThongTinTks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutTblThongTinTk(TblThongTinTk tblThongTinTk)
        {
            /*if (id != tblThongTinTk.IdTaiKhoan)
            {
                return BadRequest();
            }*/

            _context.Entry(tblThongTinTk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblThongTinTkExists(tblThongTinTk.IdThongTinTk))
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

        // POST: api/TblThongTinTks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblThongTinTk>> PostTblThongTinTk(TblThongTinTk tblThongTinTk)
        {
            _context.TblThongTinTks.Add(tblThongTinTk);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblThongTinTk", new { id = tblThongTinTk.IdThongTinTk }, tblThongTinTk);
        }

        // DELETE: api/TblThongTinTks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblThongTinTk(int id)
        {
            var tblThongTinTk = await _context.TblThongTinTks.FindAsync(id);
            if (tblThongTinTk == null)
            {
                return NotFound();
            }

            _context.TblThongTinTks.Remove(tblThongTinTk);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblThongTinTkExists(int id)
        {
            return _context.TblThongTinTks.Any(e => e.IdThongTinTk == id);
        }
    }
}
