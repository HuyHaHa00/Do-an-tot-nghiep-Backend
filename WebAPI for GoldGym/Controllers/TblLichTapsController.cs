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
    public class TblLichTapsController : ControllerBase
    {
        private readonly GoldGymDBContext _context;

        public TblLichTapsController(GoldGymDBContext context)
        {
            _context = context;
        }

        // GET: api/TblLichTaps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblLichTap>>> GetTblLichTaps()
        {
            return await _context.TblLichTaps.ToListAsync();
        }

        // GET: api/TblLichTaps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblLichTap>> GetTblLichTap(int id)
        {
            var tblLichTap = await _context.TblLichTaps.FindAsync(id);

            if (tblLichTap == null)
            {
                return NotFound();
            }

            return tblLichTap;
        }

        [HttpGet("taikhoan/{id}")]
        public async Task<ActionResult<TblLichTap>> GetTblLichTapBangIDTaiKhoan(int id)
        {
            var tblLichTap = _context.TblLichTaps.Where(x => x.IdTaiKhoan == id);

            if (tblLichTap == null)
            {
                return NotFound();
            }

            return Ok(tblLichTap.ToList());
        }

        //GET: api/TblLichtaps/id
        [HttpGet("lichtap/{id}")]
        public async Task<ActionResult<TblDstap>> GetTblLichTapBangIDLichTap(int id)
        {
            var tblDstap = _context.TblLichTaps.Where(x => x.IdLichTap == id);

            if (tblDstap == null)
            {
                return NotFound();
            }
            return Ok(tblDstap.ToList());
        }


        // PUT: api/TblLichTaps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblLichTap(int id, TblLichTap tblLichTap)
        {
            if (id != tblLichTap.IdLichTap)
            {
                return BadRequest();
            }

            _context.Entry(tblLichTap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblLichTapExists(id))
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

        // POST: api/TblLichTaps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblLichTap>> PostTblLichTap([FromBody]TblLichTap tblLichTap)
        {
            _context.TblLichTaps.Add(tblLichTap);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblLichTap", new { id = tblLichTap.IdLichTap }, tblLichTap);
        }

        // DELETE: api/TblLichTaps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblLichTap(int id)
        {
            var tblLichTap = await _context.TblLichTaps.FindAsync(id);
            if (tblLichTap == null)
            {
                return NotFound();
            }

            _context.TblLichTaps.Remove(tblLichTap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblLichTapExists(int id)
        {
            return _context.TblLichTaps.Any(e => e.IdLichTap == id);
        }
    }
}
