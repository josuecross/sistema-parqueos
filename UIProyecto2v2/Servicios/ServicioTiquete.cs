using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UIProyecto2v2.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace UIProyecto2v2.Servicios
{
	public class ServicioTiquete : IServicioTiquete
	{
		private string _baseurl;
		public ServicioTiquete()
		{
			_baseurl = "http://localhost:5261";
		}
		public async Task<Tiquete> BuscarTiqueteID(int id)
		{
			Tiquete V_Tiquete = new Tiquete();
			var cliente = new HttpClient();
			cliente.BaseAddress = new Uri(_baseurl);
			var response = await cliente.GetAsync($"api/Tiquete/{id}?");
			//   var response = await cliente.DeleteAsync($"api/Tiquete/EliminarTiquete{Nombre}?");

			if (response.IsSuccessStatusCode)
			{
				var json_respuesta = await response.Content.ReadAsStringAsync();
				var resultado = JsonConvert.DeserializeObject<Tiquete>(json_respuesta);
				V_Tiquete = resultado;
				return V_Tiquete;
			}
			else
			{
				return null;
			}
		}

		public async Task<Parqueo> GetParqueodelTiquete(int id)
		{
			ServicioParqueo servicio = new();

			Parqueo parqueo = await servicio.BuscarParqueo(id);

			return parqueo;

		}

		public async Task<List<Tiquete>> Get()
		{
			List<Tiquete> lista = new List<Tiquete>();
			var cliente = new HttpClient();
			cliente.BaseAddress = new Uri(_baseurl);
			var response = await cliente.GetAsync("api/Tiquete");

			if (response.IsSuccessStatusCode)
			{
				var json_respuesta = await response.Content.ReadAsStringAsync();
				var resultado = JsonConvert.DeserializeObject<List<Tiquete>>(json_respuesta);
				lista = resultado;
			}
			return lista;
		}

		public async Task<string> Guardar(Tiquete obj_tiquete)
		{
			bool Respuesta = false;
			var cliente = new HttpClient();
			cliente.BaseAddress = new Uri(_baseurl);

			var contenido = new StringContent(JsonConvert.SerializeObject(obj_tiquete), Encoding.UTF8, "application/json");
			var response = await cliente.PostAsync($"api/Tiquete", contenido);

			if (response.IsSuccessStatusCode)
			{
				return "OK";
			}

			return await response.Content.ReadAsStringAsync();
		}

		public async Task<string> Actualizar(int id, Tiquete obj_tiquete)
		{
			bool Respuesta = false;
			var cliente = new HttpClient();
			cliente.BaseAddress = new Uri(_baseurl);

			var contenido = new StringContent(JsonConvert.SerializeObject(obj_tiquete), Encoding.UTF8, "application/json");
			var response = await cliente.PutAsync($"api/Tiquete/{id}?", contenido);

			if (response.IsSuccessStatusCode)
			{
				return "OK";
			}

			return await response.Content.ReadAsStringAsync();
        }

		public async Task<string> CerrarTiquete(int id)
        {
            Tiquete V_Tiquete = new Tiquete();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Tiquete/{id}?");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Tiquete>(json_respuesta);
                V_Tiquete = resultado;
                V_Tiquete.EnUso = false;
				if (V_Tiquete.Salida == null)
				{
					V_Tiquete.Salida = DateTime.Now;
				}

				if (V_Tiquete.Salida < V_Tiquete.Ingreso)
				{
					return $"La hora de salida debe ser despues de la hora de entrada - ingreso: {V_Tiquete.Ingreso}, salida: Hora de la computadora";
				}
				//TimeSpan difference = DateTime.Now - V_Tiquete.Ingreso;
				//
				//int tarifaHoras = (int)difference.Hours * (int)V_Tiquete.TarifaHora;
                //int tarifaMediaHora = (int)(difference.TotalHours - difference.Hours / 0.5) * (int)V_Tiquete.TarifaHora;
				//
				//V_Tiquete.Monto_Pagado = tarifaHoras + tarifaMediaHora;


                string actualizado = await Actualizar(id, V_Tiquete);


                if (actualizado.Equals("OK")) {
					return "OK";
				}
				else
				{
					return "Hubo un problema, no se pudo actualizar";
				}


            }
            else
            {
				return "No se pudo encontrar el tiquete";
            }
        }

        public async Task<string> Borrar(int id)
        {
  
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);


            var response = await cliente.DeleteAsync($"api/Tiquete/{id}?");

            if (response.IsSuccessStatusCode)
            {
				return "OK";
            }
			else
			{
                string contenido = await response.Content.ReadAsStringAsync();
                return contenido;
			}

    
        }

        public async Task<List<Tiquete>> GetSearch(string searchString)
        {
            List<Tiquete> lista = new List<Tiquete>();
            string query;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            query = $"api/Tiquete/search/{searchString}?";

            
            var response = await cliente.GetAsync(query);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Tiquete>>(json_respuesta);
                lista = resultado;
            }
            return lista;
        }
    }
}
