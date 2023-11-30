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
        [Display(Name = "Tarifa hora")]
        public int? TarifaHora { get; set; }
        [Display(Name = "Tarifa media hora")]
        public int? TarifaMediaHora { get; set; }
        [Display(Name = "En uso")]
        public bool EnUso { get; set; } = true;
        [Display(Name = "Total pagado")]
        public int? Monto_Pagado { get; set; }
    }
}
