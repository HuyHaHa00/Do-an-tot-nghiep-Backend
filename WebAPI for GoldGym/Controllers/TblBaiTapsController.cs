using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebAPI_for_GoldGym.Models;

namespace WebAPI_for_GoldGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblBaiTapsController : ControllerBase
    {
        private readonly GoldGymDBContext _context;

        public TblBaiTapsController(GoldGymDBContext context)
        {
            _context = context;
        }

        // GET: api/TblBaiTaps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblBaiTap>>> GetTblBaiTaps()
        {
            return await _context.TblBaiTaps.ToListAsync();
        }


        // GET: api/TblBaiTaps/BpCoThe/"..."
        [HttpGet("BpCoThe/{bpcothe}")]
        public async Task<List<TblBaiTap>> GetBaiTapTheoBoPhan(string bpcothe)
        {
            List<TblBaiTap> list = new List<TblBaiTap>();
                list = _context.TblBaiTaps
                .Where(baitap => baitap.BpCoThe == bpcothe)
                .Select(baitap => new TblBaiTap
                {
                    BpCoThe = baitap.BpCoThe,
                    TbsuDung = baitap.TbsuDung,
                    Urlanh = baitap.Urlanh,
                    IdBaiTap = baitap.IdBaiTap,
                    TenBaiTap = baitap.TenBaiTap,
                    NhomCo = baitap.NhomCo,
                }).ToList();
            return list;
        }

        // GET: api/TblBaiTaps/TbsuDung/"..."
        [HttpGet("TbsuDung/{tbsudung}")]
        public async Task<List<TblBaiTap>> GetBaiTapTheoThietBi(string tbsudung)
        {
            List<TblBaiTap> list = new List<TblBaiTap>();
            list = _context.TblBaiTaps
            .Where(baitap => baitap.TbsuDung == tbsudung)
            .Select(baitap => new TblBaiTap
            {
                BpCoThe = baitap.BpCoThe,
                TbsuDung = baitap.TbsuDung,
                Urlanh = baitap.Urlanh,
                IdBaiTap = baitap.IdBaiTap,
                TenBaiTap = baitap.TenBaiTap,
                NhomCo = baitap.NhomCo,
            }).ToList();
            return list;
        }

        [HttpGet("NhomCo/{nhomco}")]
        public async Task<List<TblBaiTap>> GetBaiTapTheoNhomCo(string nhomco)
        {
            List<TblBaiTap> list = new List<TblBaiTap>();
            list = _context.TblBaiTaps
            .Where(baitap => baitap.NhomCo == nhomco)
            .Select(baitap => new TblBaiTap
            {
                BpCoThe = baitap.BpCoThe,
                TbsuDung = baitap.TbsuDung,
                Urlanh = baitap.Urlanh,
                IdBaiTap = baitap.IdBaiTap,
                TenBaiTap = baitap.TenBaiTap,
                NhomCo = baitap.NhomCo,
            }).ToList();
            return list;
        }


        // GET: api/TblBaiTaps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblBaiTap>> GetTblBaiTap(int id)
        {
            var tblBaiTap = await _context.TblBaiTaps.FindAsync(id);

            if (tblBaiTap == null)
            {
                return NotFound();
            }

            return tblBaiTap;
        }

        // PUT: api/TblBaiTaps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblBaiTap(int id, TblBaiTap tblBaiTap)
        {
            if (id != tblBaiTap.IdBaiTap)
            {
                return BadRequest();
            }

            _context.Entry(tblBaiTap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblBaiTapExists(id))
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

        // POST: api/TblBaiTaps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblBaiTap>> PostTblBaiTap(TblBaiTap tblBaiTap)
        {
            _context.TblBaiTaps.Add(tblBaiTap);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblBaiTap", new { id = tblBaiTap.IdBaiTap }, tblBaiTap);
        }

        /*ham post dung de cho du lieu bai tap tu api ve database--da xong
           public async Task<ActionResult<TblBaiTap>> PostTblBaiTap([FromBody] List<Exercise> exs)
        {
            int count = 0;
            foreach (Exercise ex in exs)
            {
                /* 
                public string BodyPart { get; set; }
                public string Equipment { get; set; }
                public string GifURL { get; set; }
                public string Id { get; set; }
                public string Name { get; set; }
                public string Target { get; set; }

                public string BpCoThe { get; set; } = null!;
                public string TbsuDung { get; set; } = null!;
                public string Urlanh { get; set; } = null!;
                public int IdBaiTap { get; set; }
                public string TenBaiTap { get; set; } = null!;
                public string NhomCo { get; set; } = null!;
                //////////////
                TblBaiTap baitap = new TblBaiTap();
                baitap.BpCoThe = ex.BodyPart;
                baitap.TbsuDung = ex.Equipment;
                baitap.Urlanh = ex.GifURL;
                baitap.TenBaiTap = ex.Name;
                baitap.NhomCo = ex.Target;
                count++;
                _context.TblBaiTaps.Add(baitap);
                await _context.SaveChangesAsync();
        }
                return Ok(count);
        //return CreatedAtAction("GetTblBaiTap", new { id = tblBaiTap.IdBaiTap }, tblBaiTap);
        }
        */

        // DELETE: api/TblBaiTaps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblBaiTap(int id)
        {
            var tblBaiTap = await _context.TblBaiTaps.FindAsync(id);
            if (tblBaiTap == null)
            {
                return NotFound();
            }

            _context.TblBaiTaps.Remove(tblBaiTap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblBaiTapExists(int id)
        {
            return _context.TblBaiTaps.Any(e => e.IdBaiTap == id);
        }
    }
}
