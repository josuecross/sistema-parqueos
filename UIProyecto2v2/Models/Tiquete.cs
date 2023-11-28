using System.ComponentModel.DataAnnotations;

namespace UIProyecto2v2.Models
{
	public class Tiquete
	{
		public int TiqueteID { get; set; }
		public int ParqueoID { get; set; }
		public DateTime Ingreso { get; set; }
		public DateTime? Salida { get; set; }
        [StringLength(15, ErrorMessage = "No puede ser mayor a 15 caracteres.")]
        public string Placa { get; set; }
		public int? TarifaHora { get; set; }
		public int? TarifaMediaHora { get; set; }
		public bool EnUso { get; set; } = true;
        public int? Monto_Pagado { get; set; }
    }
}
