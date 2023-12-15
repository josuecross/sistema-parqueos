using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Proyecto3.Data;
using API_Proyecto3.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;

namespace API_Proyecto3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiqueteController : ControllerBase
    {
        private readonly API_Proyecto3Context _context;

        public TiqueteController(API_Proyecto3Context context)
        {
            _context = context;
        }

        // GET: api/Tiquete
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tiquete>>> GetTiquete()
        {
          if (_context.Tiquete == null)
          {
              return NotFound();
          }
            return await _context.Tiquete.ToListAsync();
        }

        [HttpGet("search/{searchString}")]
        public async Task<ActionResult<IEnumerable<Tiquete>>> GetTiqueteSearch(string searchString)
        {

            var tiquetes = from s in _context.Tiquete
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                tiquetes = tiquetes.Where(s => s.Placa.ToUpper().Contains(searchString.ToUpper()));
            }

            return tiquetes.ToList();
        }

        // GET: api/Tiquete/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tiquete>> GetTiquete(int id)
        {
          if (_context.Tiquete == null)
          {
              return NotFound();
          }
            var tiquete = await _context.Tiquete.FindAsync(id);

            if (tiquete == null)
            {
                return NotFound();
            }

            return tiquete;
        }

        // PUT: api/Tiquete/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTiquete(int id, Tiquete tiquete)
        {
            if (id != tiquete.TiqueteId)
            {
                return BadRequest();
            }
            try
            {
                OperacionesEnTiquete OTiquete = new OperacionesEnTiquete(_context);
                await OTiquete.PutTiquete(id, tiquete);
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiqueteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception e)
            {
                
                return BadRequest(e.Message);
               
            }

            return NoContent();
        }

        // POST: api/Tiquete
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tiquete>> PostTiquete(Tiquete tiquete)
        {
            if (_context.Tiquete == null)
            {
                return Problem("Entity set 'API_Proyecto3Context.Tiquete'  is null.");
            }

            try
            {
                OperacionesEnTiquete OTiquete = new OperacionesEnTiquete(_context);
                await OTiquete.CrearTiquete(tiquete);
                return Ok();


            }
            catch (DbUpdateException e)
            {
                return BadRequest("Huvo un error al actualizar la base de datos, intente de nuevo");
               
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // DELETE: api/Tiquete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTiquete(int id)
        {
            if (_context.Tiquete == null)
            {
                return NotFound();
            }

            try
            {
                OperacionesEnTiquete OTiquete = new OperacionesEnTiquete(_context);
                await OTiquete.BorrarTiquete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        private bool TiqueteExists(int id)
        {
            return (_context.Tiquete?.Any(e => e.TiqueteId == id)).GetValueOrDefault();
        }
    }
}
