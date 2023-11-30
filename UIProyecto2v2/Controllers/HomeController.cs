using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UIProyecto2v2.Models;
using UIProyecto2v2.Servicios;

namespace UIProyecto2v2.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private IServicioReportes _iservicioReportes;

        public HomeController(ILogger<HomeController> logger, IServicioReportes iservicioReportes)
		{
			_logger = logger;
            _iservicioReportes = iservicioReportes;
        }

		public async Task<IActionResult> Index()
		{
            List<Parqueo> lalista;
            lalista = await _iservicioReportes.GetParqueosMasVentas(null, null);
            return View(lalista);
		}

        // GET: Reportes/Parqueo/5
        public async Task<IActionResult> Details(int id, string? From, string? To)
        {
            List<Tiquete> lalista;
            lalista = await _iservicioReportes.GetTiquetesCerrados(id, From, To);

            return View(lalista);
        }


        public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}