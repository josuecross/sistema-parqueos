using System.ComponentModel.DataAnnotations;

namespace UIProyecto2v2.Models
{
	public class Empleado
	{
		public int EmpleadoID { get; set; }
		public int ParqueoID { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Ingreso { get; set; }
        [StringLength(50, ErrorMessage = "No puede ser mayor a 50 caracteres.")]
        public string Nombre { get; set; }
        [StringLength(50, ErrorMessage = "No puede ser mayor a 50 caracteres.")]
        public string Apellidos { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? FechaNacimiento { get; set; }
        [StringLength(10, ErrorMessage = "No puede ser mayor a 10 caracteres.")]
        public string? NumCedula { get; set; }
        [StringLength(50, ErrorMessage = "No puede ser mayor a 50 caracteres.")]
        public string? Direccion { get; set; }
        [StringLength(50, ErrorMessage = "No puede ser mayor a 50 caracteres.")]
        public string? Email { get; set; }
        [StringLength(10, ErrorMessage = "No puede ser mayor a 15 caracteres.")]
        public string? Telefono { get; set; }
        [StringLength(50, ErrorMessage = "No puede ser mayor a 50 caracteres.")]
        public string? PersonaContacto { get; set; }


	}
}
