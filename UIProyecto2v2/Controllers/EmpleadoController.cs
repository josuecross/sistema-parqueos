using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UIProyecto2v2.Models;
using UIProyecto2v2.Servicios;

namespace UIProyecto2v2.Controllers
{
    public class EmpleadoController : Controller
    {
		private IServicioEmpleado _iservicioEmpleado;
        private IServicioParqueo _iservicioParqueo;

        public EmpleadoController( IServicioEmpleado iservicioEmpleado, IServicioParqueo iservicioParqueo)
        {
            _iservicioParqueo = iservicioParqueo;
            _iservicioEmpleado = iservicioEmpleado;
		}

		// GET: Empleado
		public async Task<IActionResult> Index(string searchString)
		{
			List<Empleado> lalista;
            if (!String.IsNullOrEmpty(searchString))
            {
                lalista = await _iservicioEmpleado.GetSearch(searchString);
                return View(lalista.ToList());
            }
            else
            {
                lalista = await _iservicioEmpleado.Get();
                return View(lalista);
            }
		}

		// GET: Empleadoes/Details/5
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound("No se especifico el id");
            }

            var empleado = await _iservicioEmpleado.BuscarEmpleado((int)id);
             
            if (empleado == null)
            {
                return NotFound("No se encontro el empleado");
            }

            return View(empleado);
        }

        // GET: Empleadoes/Create
        public IActionResult Create()
        {
            ViewBag.Parqueos = _iservicioParqueo.Get().Result;
            return View();
        }

        // POST: Empleadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost] 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpleadoID,ParqueoID,Ingreso,Nombre,Apellidos,FechaNacimiento,NumCedula,Direccion,Email,Telefono,PersonaContacto")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                await _iservicioEmpleado.Guardar(empleado);

                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Parqueos = _iservicioParqueo.Get().Result;
            if (id == null)
            {
                return NotFound("No se especifico el id");
            }

            var empleado = await _iservicioEmpleado.BuscarEmpleado((int)id);


            if (empleado == null)
            {
                return NotFound("No se encontro el empleado");
            }

            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpleadoID,ParqueoID,Ingreso,Nombre,Apellidos,FechaNacimiento,NumCedula,Direccion,Email,Telefono,PersonaContacto")] Empleado empleado)
        {
            if (id != empleado.EmpleadoID)
            {
                return NotFound("No se especifico el id");
            }

            if (ModelState.IsValid)
            {
                bool res = await _iservicioEmpleado.Actualizar(id, empleado);
                if (res)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return BadRequest("Hubo un problema al intentar actualizar");
                }

            }
            return View(empleado);
        }


        // GET: Tiquete/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound("No se especifico el id");
            }

            var tiquete = await _iservicioEmpleado.BuscarEmpleado((int)id);


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
            var res = await _iservicioEmpleado.Borrar(id);
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
