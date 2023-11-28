using Microsoft.EntityFrameworkCore.Infrastructure;
using UIProyecto2v2.Models;

namespace UIProyecto2v2.Servicios
{
	public interface IServicioTiquete
	{
		public Task<List<Tiquete>> Get();
		public Task<string> Guardar(Tiquete obj_tiquete);
		public Task<string> CerrarTiquete(int id);
		public Task<bool> Actualizar(int id, Tiquete obj_tiquete);
		public Task<Tiquete> BuscarTiqueteID(int id);
        public Task<Parqueo> GetParqueodelTiquete(int id);
		public Task<string> Borrar(int id);
        Task<List<Tiquete>> GetSearch(string searchString);
    }
}
