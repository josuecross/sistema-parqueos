using Microsoft.EntityFrameworkCore.Infrastructure;
using UIProyecto2v2.Models;

namespace UIProyecto2v2.Servicios
{
	public interface IServicioParqueo
	{
		public Task<List<Parqueo>> Get();
		public Task<string> Guardar(Parqueo parqueo);
		public Task<Parqueo> BuscarParqueo(int id);
		public Task<bool> Actualizar(int id, Parqueo obj_parqueo);
        public Task<string> Borrar(int id);
        Task<List<Parqueo>> GetSearch(string searchString);
    }
}
