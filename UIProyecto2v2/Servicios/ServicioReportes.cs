using Humanizer;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using UIProyecto2v2.Models;

namespace UIProyecto2v2.Servicios
{
    public class ServicioReportes : IServicioReportes
    {

        private string _baseurl;
        public ServicioReportes()
        {
            _baseurl = "http://localhost:5261";
        }

        public async Task<List<Tiquete>> GetTiquetesCerrados(int id, string? From, string? To)
        {
            List<Tiquete> lista = new List<Tiquete>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            string query;

            if (From != null && To != null)
            {
                var queryParameters = new Dictionary<string, string>
                {
                    { "From", From },
                    { "To", To}
                };
                var dictFormUrlEncoded = new FormUrlEncodedContent(queryParameters);
                var queryString = await dictFormUrlEncoded.ReadAsStringAsync();


                query = $"api/Reporte/Parqueo/{id}?{queryString}";

            }
            else
            {
                query = $"api/Reporte/Parqueo/{id}?";
            }

            var response = await cliente.GetAsync(query);




            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Tiquete>>(json_respuesta);
                lista = resultado;
            }
            return lista;
        }
        public async Task<List<Parqueo>> GetParqueosMasVentas()
        {
            List<Parqueo> lista = new List<Parqueo>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            string query;

            var response = await cliente.GetAsync($"api/Reporte/Parqueo");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Parqueo>>(json_respuesta);
                lista = resultado;
            }

            return lista;
        }
    }
}
