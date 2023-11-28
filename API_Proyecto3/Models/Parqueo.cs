﻿using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace API_Proyecto3.Models
{
    public class Parqueo
    {
        public int Id { get; set; }
        public int TarifaHora { get; set; }
        public int TarifaMediaHora { get; set; }
        [StringLength(50, ErrorMessage = "No puede ser mayor a 50 caracteres.")]
        public string Nombre { get; set; }
        public int MaxVehiculos { get; set; }
        public DateTime HoraApertura { get; set; }
        public DateTime HoraCierre { get; set; }
        public int TotalVendido { get; set; } = 0;

        public virtual ICollection<Tiquete> Tiquetes { get; set; } = new List<Tiquete>();
        public virtual ICollection<Empleado> Empleados { get; set; } =  new List<Empleado>();
    }
}
