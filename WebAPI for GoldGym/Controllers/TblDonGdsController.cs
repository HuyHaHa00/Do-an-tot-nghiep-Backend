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
    public class TblDonGdsController : ControllerBase
    {
        private readonly GoldGymDBContext _context;

        public TblDonGdsController(GoldGymDBContext context)
        {
            _context = context;
        }

        // GET: api/TblDonGds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblDonGd>>> GetTblDonGds()
        {
            return await _context.TblDonGds.ToListAsync();
        }

        // GET: api/TblDonGds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblDonGd>> GetTblDonGd(int id)
        {
            var tblDonGd = await _context.TblDonGds.FindAsync(id);

            if (tblDonGd == null)
            {
                return NotFound();
            }

            return tblDonGd;
        }

        // PUT: api/TblDonGds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutTblDonGd(TblDonGd tblDonGd)
        {
            /*if (id != tblDonGd.IdDonGd)
            {
                return BadRequest();
            }*/

            _context.Entry(tblDonGd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblDonGdExists(tblDonGd.IdDonGd))
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

        // POST: api/TblDonGds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblDonGd>> PostTblDonGd(TblDonGd tblDonGd)
        {
            _context.TblDonGds.Add(tblDonGd);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblDonGd", new { id = tblDonGd.IdDonGd }, tblDonGd);
        }

        // DELETE: api/TblDonGds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblDonGd(int id)
        {
            var tblDonGd = await _context.TblDonGds.FindAsync(id);
            if (tblDonGd == null)
            {
                return NotFound();
            }

            _context.TblDonGds.Remove(tblDonGd);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblDonGdExists(int id)
        {
            return _context.TblDonGds.Any(e => e.IdDonGd == id);
        }
    }
}
