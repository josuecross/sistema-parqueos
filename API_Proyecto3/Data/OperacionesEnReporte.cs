using API_Proyecto3.Models;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace API_Proyecto3.Data
{
    public class OperacionesEnReporte
    {
        private readonly API_Proyecto3Context _context;
        public OperacionesEnReporte(API_Proyecto3Context context)
        {
            _context = context;
        }

        public IEnumerable<Parqueo> ObtenerParqueosMasVentas(string? From, string? To)
        {

            IEnumerable<Parqueo> parqueos = _context.Parqueo.AsNoTracking();
            List<Parqueo> updated = new List<Parqueo>();
            if (parqueos != null)
            {
                if (From != null && To != null)
                {
                    DateTime datefrom = DateTime.Parse(From);
                    DateTime dateTo = DateTime.Parse(To);

                    foreach(Parqueo p in parqueos)
                    {
                        p.TotalVendido = ObtenerTiquetesRangoTiempo(p.Id, datefrom.ToString(), dateTo.ToString()).Sum(t => (int)t.Monto_Pagado);
                        updated.Add(p);
                    }
                    parqueos = updated;
                }
                parqueos = parqueos.OrderByDescending(p => p.TotalVendido);
                return parqueos;
            }
            else
            {
                throw new Exception("Error al solicitar parqueos");
            }

            
        }

        public IEnumerable<Tiquete> ObtenerTiquetesRangoTiempo(int id, string? From, string? To)
        {
            IEnumerable<Tiquete> tiquetes = _context.Tiquete.Where(tiquete => tiquete.ParqueoId == id && tiquete.Monto_Pagado != null && !tiquete.EnUso).AsNoTracking().ToList();
            if (tiquetes != null)
            {
                if (From != null && To != null)
                {
                    DateTime datefrom = DateTime.Parse(From);
                    DateTime dateTo = DateTime.Parse(To);

                    tiquetes = tiquetes.Where(tiquete => tiquete.Ingreso >= datefrom && tiquete.Ingreso <= dateTo);
                }

                return tiquetes;
            }

            else
            {
                throw new Exception("Error al solicitar tiquetes");
            }
        }
        
    }
}
