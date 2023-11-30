using Newtonsoft.Json;
using System.Text;
using UIProyecto2v2.Models;

namespace UIProyecto2v2.Servicios
{
	public class ServicioEmpleado : IServicioEmpleado
	{
		private string _baseurl;
		public ServicioEmpleado()
		{
			_baseurl = "http://localhost:5261";
		}
		public async Task<Empleado> BuscarEmpleado(int id)
		{
			Empleado V_Empleado = new Empleado();
			var cliente = new HttpClient();
			cliente.BaseAddress = new Uri(_baseurl);
			var response = await cliente.GetAsync($"api/Empleado/{id}?");
			//   var response = await cliente.DeleteAsync($"api/Empleado/EliminarEmpleado{Nombre}?");

			if (response.IsSuccessStatusCode)
			{
				var json_respuesta = await response.Content.ReadAsStringAsync();
				var resultado = JsonConvert.DeserializeObject<Empleado>(json_respuesta);
				V_Empleado = resultado;
			}
			return V_Empleado;
		}

		public async Task<List<Empleado>> Get()
		{
			List<Empleado> lista = new List<Empleado>();
			var cliente = new HttpClient();
			cliente.BaseAddress = new Uri(_baseurl);
			var response = await cliente.GetAsync("api/Empleado");

			if (response.IsSuccessStatusCode)
			{
				var json_respuesta = await response.Content.ReadAsStringAsync();
				var resultado = JsonConvert.DeserializeObject<List<Empleado>>(json_respuesta);
				lista = resultado;
			}
			return lista;
		}

		public async Task<bool> Guardar(Empleado obj_empleado)
		{
			bool Respuesta = false;
			var cliente = new HttpClient();
			cliente.BaseAddress = new Uri(_baseurl);

			var contenido = new StringContent(JsonConvert.SerializeObject(obj_empleado), Encoding.UTF8, "application/json");
			var response = await cliente.PostAsync($"api/Empleado", contenido);

			if (response.IsSuccessStatusCode)
			{
				Respuesta = true;
			}

			return Respuesta;
		}

        public async Task<bool> Actualizar(int id, Empleado obj_empleado)
        {
            bool Respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(obj_empleado), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"api/Empleado/{id}?", contenido);

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }

            return Respuesta;
        }



        public async Task<List<Empleado>> GetSearch(string searchString)
        {
            List<Empleado> lista = new List<Empleado>();
            string query;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            query = $"api/Empleado/search/{searchString}?";


            var response = await cliente.GetAsync(query);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Empleado>>(json_respuesta);
                lista = resultado;
            }
            return lista;
        }

        public async Task<string> Borrar(int id)
        {

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);


            var response = await cliente.DeleteAsync($"api/Empleado/{id}?");

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




    }

}
