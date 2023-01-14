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
    public class TblChiTietLichTapsController : ControllerBase
    {
        private readonly GoldGymDBContext _context;

        public TblChiTietLichTapsController(GoldGymDBContext context)
        {
            _context = context;
        }

        // GET: api/TblChiTietLichTaps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblChiTietLichTap>>> GetTblChiTietLichTaps()
        {
            return await _context.TblChiTietLichTaps.ToListAsync();
        }

        // GET: api/TblChiTietLichTaps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblChiTietLichTap>> GetTblChiTietLichTap(int id)
        {
            var tblChiTietLichTap = await _context.TblChiTietLichTaps.FindAsync(id);

            if (tblChiTietLichTap == null)
            {
                return NotFound();
            }

            return tblChiTietLichTap;
        }

        [HttpGet("lichtap/{id}")]
        public async Task<ActionResult<CTLichTapVaDSTap>> GetTblChiTietLichTapBangIDLichTap(int id)
        {
            var chitietlichtapvadanhsachtap = (from ctlt in _context.TblChiTietLichTaps
                                               join dst in _context.TblDstaps on ctlt.IdDstap equals dst.IdDstap
                                               where ctlt.IdLichTap == id
                                               select new CTLichTapVaDSTap
                                               {
                                                   IdChiTietLichTap = ctlt.IdChiTietLichTap,
                                                   IdLichTap = ctlt.IdLichTap,
                                                   IdDstap = (int)ctlt.IdDstap,
                                                   BuoiTap = ctlt.BuoiTap,
                                                   TrangThaiBuoiTap = ctlt.TrangThaiBuoiTap,
                                                   TenDstap = dst.TenDstap,
                                                   MoTaDstap = dst.MoTaDstap,
                                                   LoaiDstap = dst.LoaiDstap,
                                               }).ToArray();
            if (chitietlichtapvadanhsachtap.Length > 0)
                return Ok(chitietlichtapvadanhsachtap);
            else
                return BadRequest();
        }


        // PUT: api/TblChiTietLichTaps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutTblChiTietLichTap(TblChiTietLichTap tblChiTietLichTap)
        {
            /*if (id != tblChiTietLichTap.IdChiTietLichTap)
            {
                return BadRequest();
            }*/

            _context.Entry(tblChiTietLichTap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblChiTietLichTapExists(tblChiTietLichTap.IdChiTietLichTap))
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

        // POST: api/TblChiTietLichTaps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("AddWithList")]
        public async Task<ActionResult<TblChiTietLichTap>> PostTblChiTietLichTapTheoIDTaiKhoan([FromBody] List<TblChiTietLichTap> tblctlt)
        {
            //_context.TblChiTietLichTaps.Add(tblChiTietLichTap);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTblChiTietLichTap", new { id = tblChiTietLichTap.IdChiTietLichTap }, tblChiTietLichTap);

            //xoa cac chi tiet lich tap cu truoc khi them lai.
            var idlichtap = tblctlt[0].IdLichTap;
            List<TblChiTietLichTap> CTLTtap = (from ct in _context.TblChiTietLichTaps
                                             where ct.IdLichTap == idlichtap
                                             select ct).ToList();

            if (CTLTtap.Count > 0)
            {
                foreach (TblChiTietLichTap ct in CTLTtap)
                {
                    _context.TblChiTietLichTaps.Remove(ct);
                }
                _context.SaveChanges();
            }
            
            foreach (TblChiTietLichTap ct in tblctlt)
            {
                _context.TblChiTietLichTaps.Add(ct);
            }
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<TblChiTietLichTap>> PostTblChiTietLichTap(TblChiTietLichTap tblChiTietLichTap)
        {
            _context.TblChiTietLichTaps.Add(tblChiTietLichTap);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblChiTietLichTap", new { id = tblChiTietLichTap.IdChiTietLichTap }, tblChiTietLichTap);
        }

        // DELETE: api/TblChiTietLichTaps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblChiTietLichTap(int id)
        {
            var tblChiTietLichTap = await _context.TblChiTietLichTaps.FindAsync(id);
            if (tblChiTietLichTap == null)
            {
                return NotFound();
            }

            _context.TblChiTietLichTaps.Remove(tblChiTietLichTap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblChiTietLichTapExists(int id)
        {
            return _context.TblChiTietLichTaps.Any(e => e.IdChiTietLichTap == id);
        }
    }
}
