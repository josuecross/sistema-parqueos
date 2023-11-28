using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UIProyecto2v2.Models
{
	public class Parqueo
	{

		public int Id { get; set; }


        public int TarifaHora { get; set; }
        public int TarifaMediaHora { get; set; }

        [StringLength(50, ErrorMessage = "No puede ser mayor a 50 caracteres.")]
        public string Nombre { get; set; }
		public int MaxVehiculos { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH\\:mm}")]
        public DateTime HoraApertura { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH\\:mm}")]
        public DateTime HoraCierre { get; set; }
		public List<int>? Empleados { get; set; } = new List<int>();
		public List<int>? Tiquetes { get; set; } = new List<int>();
		public int? totalVendido { get; set; } = 0;
	}
}
