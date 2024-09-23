using DinetMvc.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;

namespace DinetMvc.Services
{
    public class InventarioService
    {
        public async Task<List<Inventario>> ObtenerTodos()
        {
            var rutaApi = "api/inventario";

            try
            {
                var response = await HttpService.Instance.GetAsync(rutaApi);

                return JsonConvert.DeserializeObject<List<Inventario>>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<InventarioResponse> Crear(Inventario inventario)
        {
            var rutaApi = "api/inventario";

            try
            {
                var response = await HttpService.Instance.PostAsync(rutaApi, new StringContent(JsonConvert.SerializeObject(inventario), 
                    System.Text.Encoding.UTF8, 
                    "application/json"));

                return JsonConvert.DeserializeObject<InventarioResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Inventario>> ObtenerPorFechas(string fechaInicio, string fechaFin, string tipoDocumento, string nroDocumento)
        {
            var rutaApi = $"api/inventario/fechas?fechaInicio={fechaInicio}&fechaFin={fechaFin}&tipoMovimiento={tipoDocumento}&nroDocumento={nroDocumento}";

            try
            {
                var response = await HttpService.Instance.GetAsync(rutaApi);

                return JsonConvert.DeserializeObject<List<Inventario>>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}