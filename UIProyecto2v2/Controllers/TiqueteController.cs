using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using UIProyecto2v2.Models;
using UIProyecto2v2.Servicios;

namespace UIProyecto2v2.Controllers
{
    public class TiqueteController : Controller
    {
		private IServicioTiquete _iservicioTiquete;
        private IServicioParqueo _iservicioParqueo;

        public TiqueteController(IServicioTiquete iservicioTiquete, IServicioParqueo iservicioParqueo)
        {
            _iservicioParqueo = iservicioParqueo;
            _iservicioTiquete = iservicioTiquete;
		}

		// GET: Tiquete
		public async Task<IActionResult> Index(string searchString)
		{
			List<Tiquete> lalista;
            if (!String.IsNullOrEmpty(searchString))
            {
                lalista = await _iservicioTiquete.GetSearch(searchString);
                return View(lalista.ToList());
            }
            else
            {
                lalista = await _iservicioTiquete.Get();
                return View(lalista);
            }
            
		}

        // GET: Tiquete/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var tiquete = await _iservicioTiquete.BuscarTiqueteID(id);
            

            if (tiquete == null)
            {
                return NotFound("No se encontro");
            }

            return View(tiquete);
        }

        // GET: Tiquete/Create
        public IActionResult Create()
        {

            ViewBag.Parqueos = _iservicioParqueo.Get().Result;
            return View();
        }

        // POST: Tiquete/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParqueoID,TiqueteID,Ingreso,Salida,Placa,TarifaHora,TarifaMediaHora,EnUso")] Tiquete tiquete)
        {
            List<string> mensajes = new List<string>();
            ViewBag.Parqueos = _iservicioParqueo.Get().Result;
            try
            {
                string res = await _iservicioTiquete.Guardar(tiquete);

                if(res.Equals("OK"))
                {
                    return RedirectToAction(nameof(Index));

                }

                mensajes.Add(res);

                ViewBag.Mensajes = mensajes;

                return View(tiquete);
            }
            catch
            {
				return View(tiquete);
			}
			
		}

        // GET: Tiquete/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound("NO se especifico ningun id");
            }

            var tiquete = await _iservicioTiquete.BuscarTiqueteID((int)id);


            if (tiquete == null)
            {
                return NotFound("NO se encontro el tiquete pruebe de nuevo");
            }

            return View(tiquete);
        }



        // POST: Tiquete/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParqueoID,TiqueteID,Ingreso,Salida,Placa,TarifaHora,TarifaMediaHora,EnUso")] Tiquete tiquete)
        {
            if (tiquete.Salida < tiquete.Ingreso)
            {
                return BadRequest("La hora de entrada debe ser anterior a la hora de salida");
            }
            if (id != tiquete.TiqueteID)
            {
                return NotFound("No se especifico el id");
            }

            bool res = await _iservicioTiquete.Actualizar(id, tiquete);
            if( res)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(tiquete);
            }
   
        }

        // GET: Tiquete/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound("No se especifico el id");
            }

            var tiquete = await _iservicioTiquete.BuscarTiqueteID((int)id);


            if (tiquete == null)
            {
                return NotFound("No se encontro el tiquete");
            }

            return View(tiquete);
        }

        // POST: Tiquete/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var res = await _iservicioTiquete.Borrar(id);
            if (res.Equals("OK"))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return BadRequest(res);
            }
            
        }


        public async Task<IActionResult> CerrarTiquete(int id)
        {
            
            string resultado = await _iservicioTiquete.CerrarTiquete(id);

            if (resultado.Equals("OK"))
            {
                return RedirectToAction(nameof(Index));
                
            }
            else if (resultado.Equals("No se pudo encontrar el tiquete")) {
                return NotFound(resultado);
            }
            else
            {
                return BadRequest(resultado);
            }

            
           
        }
    }
}
