using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UIProyecto2v2.Models;
using UIProyecto2v2.Servicios;

namespace UIProyecto2v2.Controllers
{
    public class ReportesController : Controller
    {


        private IServicioReportes _iservicioReporte;
        private IServicioParqueo _iservicioParqueo;
        public ReportesController(IServicioReportes iservicioReporte , IServicioParqueo iservicioParqueo)
        {
            _iservicioReporte = iservicioReporte;
            _iservicioParqueo = iservicioParqueo;
        }

        // GET: Parqueo
        public async Task<IActionResult> Index(string? searchString)
        {
            List<Parqueo> lalista;
            if (!String.IsNullOrEmpty(searchString))
            {
                lalista = await _iservicioParqueo.GetSearch(searchString);
                return View(lalista.ToList());
            }
            else
            {

                lalista = await _iservicioParqueo.Get();
                return View(lalista);
            }
        }

        // GET: Parqueo/Details/5
        public async Task<IActionResult> MostrarReporte(int Id, string? mes, string? dia, string? range_dia, string? range_from, string? range_to)
        {

            if (mes != null)
            {
                DateTime from = DateTime.Parse(mes);
                DateTime to = DateTime.Parse(mes).AddMonths(1);
                List<Tiquete> data = await _iservicioReporte.GetTiquetesCerrados(Id, from.ToString(), to.ToString());
                ViewBag.Time = from.ToString("MMMM yyyy");
                ViewBag.ID = Id;
                return View(data);

            }
            else if (dia != null)
            {
                DateTime from = DateTime.Parse(dia);
                DateTime to = DateTime.Parse(dia).AddDays(1);
                List<Tiquete> data = await _iservicioReporte.GetTiquetesCerrados(Id, from.ToString(), to.ToString());
                ViewBag.Time = from.ToString("dd MMMM yyyy");
                ViewBag.ID = Id;
                return View(data);

            }
            else if (range_dia != null && range_from != null && range_to != null)
            {
                DateTime from = DateTime.Parse(range_dia + "T" + range_from);
                DateTime to = DateTime.Parse(range_dia + "T" + range_to);
                List<Tiquete> data = await _iservicioReporte.GetTiquetesCerrados(Id, from.ToString(), to.ToString());
                ViewBag.Time = from.ToString() + " hasta " + to.ToString();
                ViewBag.ID = Id;
                return View(data);

            }
            else 
            {

                List<Tiquete> data = await _iservicioReporte.GetTiquetesCerrados(Id, null, null);
                ViewBag.Time = "Historial total de tiquetes";
                ViewBag.ID = Id;
                return View(data);

            }

        }



        public async Task<IActionResult> CrearReporte(int? id)
        {
            if (id == null)
            {
                return NotFound("No se especifico el id");
            }

            var Parqueo = await _iservicioParqueo.BuscarParqueo((int)id);


            if (Parqueo == null)
            {
                return NotFound("No se encontro el tiquete");
            }

            return View(Parqueo);
        }

        public async Task<IActionResult> ReporteMasVentasMes(string? mes)
        {
            List<Parqueo> lalista;
            if (!String.IsNullOrEmpty(mes))
            {
                DateTime From = DateTime.Parse(mes);
                DateTime To = DateTime.Parse(mes).AddMonths(1);
                ViewBag.Mes = mes;
                lalista = await _iservicioReporte.GetParqueosMasVentas(From.ToString(), To.ToString());
            }
            else
            {
                lalista = await _iservicioReporte.GetParqueosMasVentas(null,null);
            }
            
            return View(lalista);
        }

    }


}
