using Microsoft.EntityFrameworkCore.Infrastructure;
using UIProyecto2v2.Models;

namespace UIProyecto2v2.Servicios
{
	public interface IServicioEmpleado
	{
		public Task<List<Empleado>> Get();
		public Task<bool> Guardar(Empleado empleado);
		public Task<Empleado> BuscarEmpleado(int id);
		public Task<bool> Actualizar(int id, Empleado obj_parqueo);
        Task<List<Empleado>> GetSearch(string searchString);
        public Task<string> Borrar(int id);
    }
}
