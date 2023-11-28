using API_Proyecto3.Data;
using System.ComponentModel.DataAnnotations;

namespace API_Proyecto3.Models
{
    public class Tiquete
    {
        public int TiqueteId { get; set; }

        public DateTime Ingreso { get; set; }
        public DateTime? Salida { get; set; }
        [StringLength(15, ErrorMessage = "No puede ser mayor a 15 caracteres.")]
        public string Placa { get; set; }
        public int? TarifaHora { get; set; }
        public int? TarifaMediaHora { get; set; }
        public bool EnUso { get; set; }
        public int? Monto_Pagado { get; set; }

        public int ParqueoId { get; set; }
        public virtual Parqueo Parqueo { get; set; }
    }
}
