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
    public class TblTaiKhoansController : ControllerBase
    {
        private readonly GoldGymDBContext _context;

        public TblTaiKhoansController(GoldGymDBContext context)
        {
            _context = context;
        }

        // GET: api/TblTaiKhoans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblTaiKhoan>>> GetTblTaiKhoans()
        {
            return await _context.TblTaiKhoans.ToListAsync();
        }

        // GET: api/TblTaiKhoans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblTaiKhoan>> GetTblTaiKhoan(int id)
        {
            var tblTaiKhoan = await _context.TblTaiKhoans.FindAsync(id);

            if (tblTaiKhoan == null)
            {
                return NotFound();
            }

            return tblTaiKhoan;
        }

        // PUT: api/TblTaiKhoans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblTaiKhoan(int id, TblTaiKhoan tblTaiKhoan)
        {
            if (id != tblTaiKhoan.IdTaiKhoan)
            {
                return BadRequest();
            }

            _context.Entry(tblTaiKhoan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblTaiKhoanExists(id))
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

        // POST: api/TblTaiKhoans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<datadangkitk>> PostDangKyTaiKhoan([FromBody]datadangkitk dataTaiKhoan)
        {
            var checkTenTaiKhoan = _context.TblTaiKhoans.Where(x => x.TenDangNhap == dataTaiKhoan.TenDangNhap);
            if (checkTenTaiKhoan.Count() > 0)
                return BadRequest(new { message = "This username is already taken" });

            else
            {
                TblTaiKhoan taiKhoan = new TblTaiKhoan();
                taiKhoan.TenDangNhap = dataTaiKhoan.TenDangNhap;
                taiKhoan.MatKhau = dataTaiKhoan.MatKhau;
                taiKhoan.Quyen = dataTaiKhoan.Quyen;
                taiKhoan.TrangThaiPremium = dataTaiKhoan.TrangThaiPremium;
                taiKhoan.ThoiGianDk = dataTaiKhoan.ThoiGianDk;
                _context.TblTaiKhoans.Add(taiKhoan);
                _context.SaveChanges();

                int id = taiKhoan.IdTaiKhoan;
                TblThongTinTk ttTaiKhoan = new TblThongTinTk();
                ttTaiKhoan.IdTaiKhoan = id;
                ttTaiKhoan.HoTen = dataTaiKhoan.HoTen;
                ttTaiKhoan.GioiTinh = dataTaiKhoan.GioiTinh;
                ttTaiKhoan.Tuoi = dataTaiKhoan.Tuoi;
                ttTaiKhoan.Sdt = dataTaiKhoan.Sdt;
                ttTaiKhoan.Email = dataTaiKhoan.Email;
                _context.TblThongTinTks.Add(ttTaiKhoan);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTblTaiKhoan", new { id = taiKhoan.IdTaiKhoan }, taiKhoan);
            }
        }
        [HttpPost("DangNhap")]
        public async Task<ActionResult<TaikhoanDangNhap>> PostDangNhapTaiKhoan([FromBody]TaikhoanDangNhap Tkdangnhap)
        {
            var checkTenTaiKhoan = _context.TblTaiKhoans.Where(x => x.TenDangNhap == Tkdangnhap.TenDangNhap && x.MatKhau == Tkdangnhap.MatKhau);
            if (checkTenTaiKhoan.Count() > 0)
            {
                return Ok(checkTenTaiKhoan.First().IdTaiKhoan);
            }
            else
            {
                return BadRequest(new { message = "username or password is not correct" });
            }
        }

        // DELETE: api/TblTaiKhoans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblTaiKhoan(int id)
        {
            var tblTaiKhoan = await _context.TblTaiKhoans.FindAsync(id);
            if (tblTaiKhoan == null)
            {
                return NotFound();
            }

            _context.TblTaiKhoans.Remove(tblTaiKhoan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblTaiKhoanExists(int id)
        {
            return _context.TblTaiKhoans.Any(e => e.IdTaiKhoan == id);
        }
    }
}
