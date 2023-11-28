namespace API_Proyecto3.DTOs
{
    public class ParqueoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int MaxVehiculos { get; set; }
        public DateTime HoraApertura { get; set; }
        public DateTime HoraCierre { get; set; }
        public int TotalVendido { get; set; } = 0;
    }
}
