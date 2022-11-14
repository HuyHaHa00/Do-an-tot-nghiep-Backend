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
    public class TblChiTietDstapsController : ControllerBase
    {
        private readonly GoldGymDBContext _context;

        public TblChiTietDstapsController(GoldGymDBContext context)
        {
            _context = context;
        }

        // GET: api/TblChiTietDstaps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblChiTietDstap>>> GetTblChiTietDstaps()
        {
            return await _context.TblChiTietDstaps.ToListAsync();
        }

        // GET: api/TblChiTietDstaps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChitietDstapvaBaiTap>> GetTblChiTietDstap(int id)
        {
            var chitietdanhsashtap = (from ctdt in _context.TblChiTietDstaps
                                      join bt in _context.TblBaiTaps on ctdt.IdBaiTap equals bt.IdBaiTap
                                      where ctdt.IdDstap == id
                                      select new ChitietDstapvaBaiTap
                                      {
                                          IdChiTietDstap = ctdt.IdChiTietDstap,
                                          IdDstap = ctdt.IdDstap,
                                          IdBaiTap = ctdt.IdBaiTap,
                                          SoLanTap = ctdt.SoLanTap,
                                          ThoiGianTap = ctdt.ThoiGianTap,
                                          BpCoThe = bt.BpCoThe,
                                          TbsuDung = bt.TbsuDung,
                                          Urlanh = bt.Urlanh,
                                          TenBaiTap = bt.TenBaiTap,
                                          NhomCo = bt.NhomCo,
                                      }).ToArray();
            if (chitietdanhsashtap.Length > 0)
                return Ok(chitietdanhsashtap);
            else
                return BadRequest();
        }

            // PUT: api/TblChiTietDstaps/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutTblChiTietDstap(TblChiTietDstap tblChiTietDstap)
        {
            /*if (id != tblChiTietDstap.IdChiTietDstap)
            {
                return BadRequest();
            }*/

            _context.Entry(tblChiTietDstap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblChiTietDstapExists(tblChiTietDstap.IdChiTietDstap))
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

        // POST: api/TblChiTietDstaps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblChiTietDstap>> PostTblChiTietDstap(TblChiTietDstap tblChiTietDstap)
        {
            _context.TblChiTietDstaps.Add(tblChiTietDstap);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblChiTietDstap", new { id = tblChiTietDstap.IdChiTietDstap }, tblChiTietDstap);
        }

        // DELETE: api/TblChiTietDstaps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblChiTietDstap(int id)
        {
            var tblChiTietDstap = await _context.TblChiTietDstaps.FindAsync(id);
            if (tblChiTietDstap == null)
            {
                return NotFound();
            }

            _context.TblChiTietDstaps.Remove(tblChiTietDstap);
            await _context.SaveChangesAsync();

            return Content("Delete OK!");
        }

        private bool TblChiTietDstapExists(int id)
        {
            return _context.TblChiTietDstaps.Any(e => e.IdChiTietDstap == id);
        }
    }
}
