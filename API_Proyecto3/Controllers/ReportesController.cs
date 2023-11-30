using API_Proyecto3.Data;
using API_Proyecto3.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Proyecto3.Controllers
{
    [Route("api/Reporte")]
    [ApiController]
    public class ReportesController : ControllerBase
    {


        private readonly API_Proyecto3Context _context;

        public ReportesController(API_Proyecto3Context context)
        {
            _context = context;
        }
        // GET: api/<ReportesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ReportesController>/5
        [HttpGet("Parqueo/{id}")]
        public ActionResult<IEnumerable<Tiquete>> Get(int id, string? From, string? To)
        {
            try
            {
                OperacionesEnReporte OReporte = new OperacionesEnReporte(_context);
                IEnumerable<Tiquete> tiquetes = OReporte.ObtenerTiquetesRangoTiempo(id, From, To);
                return Ok(tiquetes);
            }
            catch(Exception e )
            {
                return BadRequest(e.Message);
            }          
        }


        // GET api/<ReportesController>/5
        [HttpGet("Parqueo/")]
        public  ActionResult<IEnumerable<Parqueo>> GetMasVentas(string? From, string? To)
        {   
            try
            {
                OperacionesEnReporte OReporte = new OperacionesEnReporte(_context);
                IEnumerable<Parqueo> parqueos = OReporte.ObtenerParqueosMasVentas(From, To);

                
                return Ok(parqueos);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
