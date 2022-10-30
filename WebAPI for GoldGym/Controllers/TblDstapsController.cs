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
    public class TblDstapsController : ControllerBase
    {
        private readonly GoldGymDBContext _context;

        public TblDstapsController(GoldGymDBContext context)
        {
            _context = context;
        }

        // GET: api/TblDstaps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblDstap>>> GetTblDstaps()
        {
            return await _context.TblDstaps.ToListAsync();
        }

        // GET: api/TblDstaps/taikhoan/{id}
        [HttpGet("taikhoan/{id}")]
        public async Task<ActionResult<TblDstap>> GetTblDstapBangIDTaiKhoan(int id)
        {
            var tblDstap = _context.TblDstaps.Where(x => x.IdTaiKhoan == id);

            if (tblDstap == null)
            {
                return NotFound();
            }

            return Ok(tblDstap.ToList());
        }

        // GET: api/TblDstaps/dstap/{id}
        //phuc vu muc dich lay thong tin danh sach tap sau khi chuyen den trang edit
        [HttpGet("dstap/{id}")]
        public async Task<ActionResult<TblDstap>> GetTblDstapBangIDdsTap(int id)
        {
            var tblDstap = _context.TblDstaps.Where(x => x.IdDstap == id);

            if (tblDstap == null)
            {
                return NotFound();
            }

            return Ok(tblDstap.ToList());
        }

        // PUT: api/TblDstaps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblDstap(int id, TblDstap tblDstap)
        {
            if (id != tblDstap.IdDstap)
            {
                return BadRequest();
            }

            _context.Entry(tblDstap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblDstapExists(id))
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

        // POST: api/TblDstaps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblDstap>> PostTblDstap([FromBody]TblDstap tblDstap)
        {
            _context.TblDstaps.Add(tblDstap);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblDstapBangIDTaiKhoan", new { id = tblDstap.IdDstap }, tblDstap);
        }

        // DELETE: api/TblDstaps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblDstap(int id)
        {
            var tblDstap = await _context.TblDstaps.FindAsync(id);
            if (tblDstap == null)
            {
                return NotFound();
            }

            List<TblChiTietDstap> CTDStap = (from ct in _context.TblChiTietDstaps
                           where ct.IdDstap == id
                           select ct).ToList();

            if(CTDStap.Count > 0)
            {
                foreach (TblChiTietDstap ct in CTDStap)
                {
                    _context.TblChiTietDstaps.Remove(ct);
                }
                _context.SaveChanges();
            }

            _context.TblDstaps.Remove(tblDstap);
            _context.SaveChanges();

            return NoContent();
        }

        private bool TblDstapExists(int id)
        {
            return _context.TblDstaps.Any(e => e.IdDstap == id);
        }
    }
}
