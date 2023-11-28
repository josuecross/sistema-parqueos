using Newtonsoft.Json;
using System.Text;
using UIProyecto2v2.Models;

namespace UIProyecto2v2.Servicios
{
	public class ServicioParqueo : IServicioParqueo
	{
		private string _baseurl;
		public ServicioParqueo()
		{
			_baseurl = "http://localhost:5261";
		}
		public async Task<Parqueo> BuscarParqueo(int id)
		{
			Parqueo V_Parqueo = new Parqueo();
			var cliente = new HttpClient();
			cliente.BaseAddress = new Uri(_baseurl);
			var response = await cliente.GetAsync($"api/Parqueo/{id}?");
			//   var response = await cliente.DeleteAsync($"api/Parqueo/EliminarParqueo{Nombre}?");

			if (response.IsSuccessStatusCode)
			{
				var json_respuesta = await response.Content.ReadAsStringAsync();
				var resultado = JsonConvert.DeserializeObject<Parqueo>(json_respuesta);
				V_Parqueo = resultado;
			}
			return V_Parqueo;
		}

		public async Task<List<Parqueo>> Get()
		{
			List<Parqueo> lista = new List<Parqueo>();
			var cliente = new HttpClient();
			cliente.BaseAddress = new Uri(_baseurl);
			var response = await cliente.GetAsync("api/Parqueo");

			if (response.IsSuccessStatusCode)
			{
				var json_respuesta = await response.Content.ReadAsStringAsync();
				var resultado = JsonConvert.DeserializeObject<List<Parqueo>>(json_respuesta);
				lista = resultado;
			}
			return lista;
		}

		public async Task<string> Guardar(Parqueo obj_parqueo)
		{
            string Respuesta;
			var cliente = new HttpClient();
			cliente.BaseAddress = new Uri(_baseurl);

			var contenido = new StringContent(JsonConvert.SerializeObject(obj_parqueo), Encoding.UTF8, "application/json");
			var response = await cliente.PostAsync($"api/Parqueo", contenido);

			if (response.IsSuccessStatusCode)
			{
				return "OK";
			}
			else
			{
				Respuesta = await response.Content.ReadAsStringAsync();
				return Respuesta;
            }

			
		}

        public async Task<bool> Actualizar(int id, Parqueo obj_parqueo)
        {
            bool Respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(obj_parqueo), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"api/Parqueo/{id}?", contenido);

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }

            return Respuesta;
        }

        public async Task<string> Borrar(int id)
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.DeleteAsync($"api/Parqueo/{id}?");

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

        public async Task<List<Parqueo>> GetSearch(string searchString)
        {
            List<Parqueo> lista = new List<Parqueo>();
            string query;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            query = $"api/Parqueo/search/{searchString}?";


            var response = await cliente.GetAsync(query);

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
