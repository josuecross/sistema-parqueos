using System.ComponentModel.DataAnnotations;

namespace API_Proyecto3.Models
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public DateTime Ingreso { get; set; }
        [StringLength(50, ErrorMessage = "No puede ser mayor a 50 caracteres.")]
        public string Nombre { get; set; }
        [StringLength(50, ErrorMessage = "No puede ser mayor a 50 caracteres.")]
        public string Apellidos { get; set; }
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

        public int ParqueoId { get; set; }
        public virtual Parqueo Parqueo { get; set; }
    }
}
