using API_Proyecto3.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Proyecto3.Data
{
    public class OperacionesEnTiquete
    {
        private readonly API_Proyecto3Context _context;
        public OperacionesEnTiquete(API_Proyecto3Context context)
        {
            _context = context;
        }

        public async Task<bool> PutTiquete(int id, Tiquete tiquete)
        {
            _context.Entry(tiquete).State = EntityState.Modified;
            var parqueo = await _context.Parqueo.FindAsync(tiquete.ParqueoId);

            if (tiquete.Ingreso.Hour < parqueo.HoraApertura.Hour && tiquete.Ingreso.Hour > parqueo.HoraCierre.Hour)
            {
                throw new Exception("El ingreso no se esta haciendo en el horario debido");
            }

            if (tiquete.Ingreso != null && tiquete.Salida != null)
            {
                int total = 0;
                TimeSpan difference = DateTime.Now - tiquete.Ingreso;
                if (difference.TotalSeconds > 0)
                {
                    int tarifaHoras = (int)difference.Hours * (int)tiquete.TarifaHora;
                    int tarifaMediaHora = (int)((difference.TotalHours - difference.Hours) / 0.5) * (int)tiquete.TarifaHora;
                    tiquete.Monto_Pagado = tarifaHoras + tarifaMediaHora;
                }
                else
                {
                    throw new Exception("Hubo un error, la hora de salida debe ser posterior a la hora de entrada.");
                }
                

            }


            _context.Entry(tiquete).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                OperacionesEnParqueo OParqueo = new OperacionesEnParqueo(_context);
                OParqueo.ActualizarTotalVendido(tiquete.ParqueoId);
                return true;
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw e;
            }

        } 

        public async Task<bool> CrearTiquete(Tiquete tiquete)
        {
            var parqueo = await _context.Parqueo.FindAsync(tiquete.ParqueoId);
            ICollection<Tiquete> tiquetesAbiertosMismoID = await _context.Tiquete.Where(t => t.Placa == tiquete.Placa && tiquete.EnUso).ToListAsync();

            if (tiquetesAbiertosMismoID.Count > 0)
            {
                throw new Exception("Ya existe un tiquete con esta placa que se encuentra abierto");
            }

            if (parqueo != null)
            {
                tiquete.TarifaHora = parqueo.TarifaHora;
                tiquete.TarifaMediaHora = parqueo.TarifaMediaHora;
            }
            else
            {
                throw new Exception("El parqueo no fue encontrado");
            }

            if (tiquete.Ingreso.Hour < parqueo.HoraApertura.Hour || tiquete.Ingreso.Hour > parqueo.HoraCierre.Hour)
            {
                throw new Exception("El ingreso no se esta haciendo en el horario debido");
            }


            _context.Tiquete.Add(tiquete);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> BorrarTiquete(int id)
        {
            var tiquete = await _context.Tiquete.FindAsync(id);
            if (tiquete == null)
            {
                throw new Exception("No se encontro el tiquete que desea eliminar");
            }

            _context.Tiquete.Remove(tiquete);
            await _context.SaveChangesAsync();

            OperacionesEnParqueo OParqueo = new OperacionesEnParqueo(_context);
            OParqueo.ActualizarTotalVendido(tiquete.ParqueoId);

            return true;
        }


    }
}
