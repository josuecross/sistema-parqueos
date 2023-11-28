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

            IEnumerable<Tiquete> tiquetes = _context.Tiquete.Where(tiquete => tiquete.ParqueoId == id && tiquete.EnUso == false).ToList();
            if (tiquetes != null)
            {
                if (From != null && To != null)
                {
                    DateTime datefrom = DateTime.Parse(From);
                    DateTime dateTo = DateTime.Parse(To);

                    tiquetes = tiquetes.Where(tiquete => tiquete.Ingreso >= datefrom && tiquete.Salida <= dateTo);
                }

                return Ok(tiquetes);
            }

            else
            {
                return NotFound("No se encontro el parqueo indicado");
            }
          
        }


        // GET api/<ReportesController>/5
        [HttpGet("Parqueo/")]
        public ActionResult<IEnumerable<Tiquete>> GetMasVentas()
        {
            IEnumerable<Parqueo> laLista = new List<Parqueo>();

            var res = _context.Parqueo.ToListAsync();
            
            if(res != null)
            {
                laLista = res.Result;
                laLista = laLista.OrderByDescending(o => o.TotalVendido);
            }


            return Ok(laLista);
        }
    }
}
