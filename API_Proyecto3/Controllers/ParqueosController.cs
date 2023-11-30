using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Proyecto3.Data;
using API_Proyecto3.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace API_Proyecto3.Controllers
{
    [Route("api/Parqueo")]
    [ApiController]
    public class ParqueosController : ControllerBase
    {
        private readonly API_Proyecto3Context _context;

        public ParqueosController(API_Proyecto3Context context)
        {
            _context = context;
        }

        // GET: api/Parqueos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parqueo>>> GetParqueo()
        {
          if (_context.Parqueo == null)
          {
              return NotFound();
          }
            return await _context.Parqueo.ToListAsync();
        }

        [HttpGet("search/{searchString}")]
        public async Task<ActionResult<IEnumerable<Parqueo>>> GetParqueoSearch(string searchString)
        {

            var parqueos = from s in _context.Parqueo
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                parqueos = parqueos.Where(s => s.Nombre.ToUpper().Contains(searchString.ToUpper()));
            }

            return parqueos.ToList();
        }


        // GET: api/Parqueos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parqueo>> GetParqueo(int id)
        {
          if (_context.Parqueo == null)
          {
              return NotFound();
          }
            var parqueo = await _context.Parqueo.FindAsync(id);

            if (parqueo == null)
            {
                return NotFound();
            }

            return parqueo;
        }

        // PUT: api/Parqueos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParqueo(int id, Parqueo parqueo)
        {
            if (id != parqueo.Id)
            {
                return BadRequest();
            }

            try
            {
                OperacionesEnParqueo OParqueo = new OperacionesEnParqueo(_context);
                await OParqueo.PutParqueo(id, parqueo);
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParqueoExists(id))
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

        // POST: api/Parqueos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Parqueo>> PostParqueo(Parqueo parqueo)
        {
            if (_context.Parqueo == null)
            {
                return Problem("Entity set 'API_Proyecto3Context.Parqueo'  is null.");
            }
            _context.Parqueo.Add(parqueo);
            int res = await _context.SaveChangesAsync();
            if (res > 0)
            {
                return CreatedAtAction("GetParqueo", new { id = parqueo.Id }, parqueo);
            }
            else
            {
                return Problem("Error in database");
            }

        }

        // DELETE: api/Parqueos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParqueo(int id)
        {
            if (_context.Parqueo == null)
            {
                return NotFound();
            }
            var parqueo = await _context.Parqueo.FindAsync(id);
            if (parqueo == null)
            {
                return NotFound();
            }

            _context.Parqueo.Remove(parqueo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParqueoExists(int id)
        {
            return (_context.Parqueo?.Any(e => e.Id == id)).GetValueOrDefault();
        }


    }
}
