using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UIProyecto2v2.Models
{
	public class Parqueo
	{

		public int Id { get; set; }

        [Display(Name = "Tarifa hora")]
        [Range(100, 10000)]
        public int TarifaHora { get; set; }
        [Display(Name = "Tarifa media hora")]
        [Range(100, 10000)]
        public int TarifaMediaHora { get; set; }

        [StringLength(50, ErrorMessage = "No puede ser mayor a 50 caracteres.")]
        public string Nombre { get; set; }
        [Display(Name = "Max. Plazas")]
        [Range(0, 1000)]
        public int MaxVehiculos { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH\\:mm}")]
        [Display(Name = "Abre")]
        public DateTime HoraApertura { get; set; }
        [Display(Name = "Cierra")]
        [DisplayFormat(DataFormatString = "{0:HH\\:mm}")]
        public DateTime HoraCierre { get; set; }
		public List<int>? Empleados { get; set; } = new List<int>();
		public List<int>? Tiquetes { get; set; } = new List<int>();
        [Display(Name = "Total vendido")]
        public int? totalVendido { get; set; } = 0;
	}
}
