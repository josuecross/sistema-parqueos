using UIProyecto2v2.Models;

namespace UIProyecto2v2.Servicios
{
    public interface IServicioReportes
    {
        public Task<List<Tiquete>> GetTiquetesCerrados(int id, string? From, string? To);
        public Task<List<Parqueo>> GetParqueosMasVentas(string? From, string? To);
    }
}
