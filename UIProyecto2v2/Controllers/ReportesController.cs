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
        public async Task<IActionResult> Index(string? searchString, string? sortOrder)
        {
            List<Parqueo> lalista;
            if (!String.IsNullOrEmpty(searchString))
            {
                lalista = await _iservicioParqueo.GetSearch(searchString);
                return View(lalista.ToList());
            }
            else
            {

                if (!String.IsNullOrEmpty(searchString) &&!sortOrder.Equals("Mas_Ventas"))
                {

                    lalista = await _iservicioReporte.GetParqueosMasVentas();


                }
                else
                {
                    lalista = await _iservicioParqueo.Get();
                }

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

                return View(data);

            }
            if (dia != null)
            {
                DateTime from = DateTime.Parse(dia);
                DateTime to = DateTime.Parse(dia).AddDays(1);
                List<Tiquete> data = await _iservicioReporte.GetTiquetesCerrados(Id, from.ToString(), to.ToString());

                return View(data);

            }
            if (range_dia != null && range_from != null && range_to != null)
            {
                DateTime from = DateTime.Parse(range_dia + "T" + range_from);
                DateTime to = DateTime.Parse(range_dia + "T" + range_to);
                List<Tiquete> data = await _iservicioReporte.GetTiquetesCerrados(Id, from.ToString(), to.ToString());

                return View(data);

            }

            return NotFound("No se encontro el Parqueo");

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



    }


}
