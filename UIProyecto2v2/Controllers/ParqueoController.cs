using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UIProyecto2v2.Models;
using UIProyecto2v2.Servicios;

namespace UIProyecto2v2.Controllers
{
    public class ParqueoController : Controller
    {
        private IServicioParqueo _iservicioParqueo;

        public ParqueoController(IServicioParqueo iservicioParqueo)
        {
            _iservicioParqueo = iservicioParqueo;
        }

        // GET: Parqueo
        public async Task<IActionResult> Index(string searchString)
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
        public async Task<IActionResult> Details(int? id)
        {
            var parqueo = await _iservicioParqueo.BuscarParqueo((int)id);
            if (parqueo == null)
            {
                return NotFound("No se encontro el Parqueo");
            }

            return View(parqueo);
        }

        // GET: Parqueo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parqueo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,MaxVehiculos,HoraApertura,HoraCierre,totalVendido, TarifaHora, TarifaMediaHora")] Parqueo parqueo)
        {
            List<string> mensajes = new List<string>();

            if(parqueo.TarifaHora < parqueo.TarifaMediaHora)
            {
                mensajes.Add("Tarifa media hora debe ser menor a tarifa hora");
                ViewBag.Mensajes = mensajes;
                return View(parqueo);
            }
            string res = await _iservicioParqueo.Guardar(parqueo);
            if (res.Equals( "OK"))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(parqueo);
            }
            
        }

        // GET: Parqueo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound("No se especifico el id");
            }

            var parqueo = await _iservicioParqueo.BuscarParqueo((int)id);


            if (parqueo == null)
            {
                return NotFound("No se encontro el parqueo");
            }

            return View(parqueo);
        }

        // POST: Parqueo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,MaxVehiculos,HoraApertura,HoraCierre,totalVendido, TarifaHora, TarifaMediaHora")] Parqueo parqueo)
        {

            List<string> mensajes = new List<string>();
            if (id != parqueo.Id)
            {
                return NotFound("No se especifico el id");
            }


            if (parqueo.TarifaHora < parqueo.TarifaMediaHora)
            {

                mensajes.Add("Tarifa media Hora debe ser menor a tarifa hora");
                ViewBag.Mensajes = mensajes;
                return View(parqueo);
            }

            bool res = await _iservicioParqueo.Actualizar(id, parqueo);

            if (res)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(parqueo);
            }

        }

        // GET: Tiquete/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound("No se especifico el id");
            }

            var tiquete = await _iservicioParqueo.BuscarParqueo((int)id);


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
            var res = await _iservicioParqueo.Borrar(id);
            if (res.Equals("OK"))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return BadRequest(res);
            }

        }

    }
}
