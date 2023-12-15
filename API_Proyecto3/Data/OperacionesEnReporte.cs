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

            IEnumerable<Parqueo> parqueos = _context.Parqueo.AsNoTracking().ToList();
            List<Parqueo> updated = new List<Parqueo>();
            if (parqueos != null)
            {
                if (From != null && To != null)
                {

                    foreach(Parqueo p in parqueos)
                    {
                        List<Tiquete> tiquetes = (List<Tiquete>)ObtenerTiquetesRangoTiempo(p.Id, From, To);
                        int total = 0;
                        foreach(Tiquete t in tiquetes)
                        {
                           
                            total += (int)t.Monto_Pagado;
                            
                        }
                        p.TotalVendido = total;
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

            IEnumerable<Tiquete> tiquetes = _context.Tiquete.Where(tiquete => tiquete.ParqueoId == id && tiquete.Monto_Pagado != null).AsNoTracking();
            List<Tiquete> updates = new List<Tiquete>();


            if (tiquetes == null) { 
                throw new Exception("Error al solicitar tiquetes");
            }

            if (From != null && To != null)
            {
                DateTime datefrom = DateTime.Parse(From);
                DateTime dateTo = DateTime.Parse(To);

                

                foreach(Tiquete t in tiquetes)
                {
                    if(t.Ingreso >= datefrom && t.Ingreso <= dateTo)
                    {
                        updates.Add(t);

                    }
                }
                return updates;
                    
            }
            return tiquetes;


        }
        
    }
}
