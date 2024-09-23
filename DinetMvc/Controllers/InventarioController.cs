using DinetMvc.Models;
using DinetMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DinetMvc.Controllers
{
    public class InventarioController : Controller
    {
        private InventarioService inventarioService;

        public InventarioController()
        {
            inventarioService = new InventarioService();
        }


        public async Task<ActionResult> Index()
        {           
            return View();
        }

        public async Task<ActionResult> Lista()
        {
            return PartialView("_Lista", await inventarioService.ObtenerTodos());
        }

        public async Task<ActionResult> Fechas(string fechaInicio, string fechaFin, string tipoDocumento, string nroDocumento)
        {
            return PartialView("_Lista", await inventarioService.ObtenerPorFechas(fechaInicio, fechaFin, tipoDocumento, nroDocumento));
        }

        public ActionResult Formulario()
        {
            return PartialView("_FormularioInventario");
        }

        [HttpPost]
        public async Task<ActionResult> Crear(Inventario inventario)
        {
            inventario.FECHA_TRANSACCION = DateTime.Now.ToString("dd-MM-yyyy");

            try
            {
                await inventarioService.Crear(inventario);
            }
            catch (Exception)
            {

                throw;
            }

            return Json(new { success = true });
        }
    }
}