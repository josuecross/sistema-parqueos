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
        public async Task<bool> ActualizarTotalVendido(int id)
        {
            Parqueo parqueo = await _context.Parqueo.FindAsync(id);
            int totalVendido = 0;

            if (parqueo != null)
            {
                _context.Entry(parqueo).Collection(x => x.Tiquetes).Load();
                foreach (Tiquete tiquete in parqueo.Tiquetes)
                {
                    if (tiquete.Monto_Pagado != null)
                    {
                        totalVendido += (int)tiquete.Monto_Pagado;
                    }
                }

                
                parqueo.TotalVendido = totalVendido;

                try
                {
                    bool res = await PutParqueo(parqueo.Id, parqueo);
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
                throw new Exception("El parqueo no existe");
            }

        }

        public async Task<bool> PutParqueo (int id, Parqueo parqueo) 
        {
            _context.Entry(parqueo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw e;
            }

        }
    }
}
