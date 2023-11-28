using API_Proyecto3.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace API_Proyecto3.Data
{
    public class OperacionesEnParqueo
    {
        private readonly API_Proyecto3Context _context;

        public OperacionesEnParqueo(API_Proyecto3Context context)
        {
            _context = context;
        }
        public bool ActualizarTotalVendido(int id)
        {
            ICollection<Tiquete> tiquetes = _context.Tiquete.Where(t=>t.ParqueoId == id).ToList();
            int totalVendido = 0;

            if (tiquetes != null)
            {
               
                foreach (Tiquete tiquete in tiquetes)
                {
                    if (tiquete.Monto_Pagado != null)
                    {
                        totalVendido += (int)tiquete.Monto_Pagado;
                    }
                }
                Parqueo parqueo = _context.Parqueo.FindAsync(id).Result;
                parqueo.TotalVendido = totalVendido;

                try
                {
                    var res = PutParqueo(parqueo.Id, parqueo);
                    if (res)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (DbUpdateConcurrencyException e)
                {
                    throw e;
                }
                
            }
            else
            {
                return false;
            }

        }

        public bool PutParqueo (int id, Parqueo parqueo) 
        {
            _context.Entry(parqueo).State = EntityState.Modified;

            try
            {
                _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw e;
            }

        }
    }
}
