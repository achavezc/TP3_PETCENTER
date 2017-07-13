using Pet.Service;
using Pet.Service.RiesgoQuirurgico;
//using Pet.Service.RiesgoQuirurgico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pet.Web.Controllers
{
    public class RiesgoQuirurgicoController : Controller
    {
        //
        // GET: /RiesgoQuirurgico/

        [HttpPost]
        public JsonResult listarRQ(Nullable<System.DateTime> fechaInicio, Nullable<System.DateTime> fechaFin, Nullable<int> codigo, string nombreCliente, string nombrePaciente, Nullable<int> codigoEstado)
        {
            return Json(RiesgoQuirurgico.ConsultarRiesgoQuirurgico(fechaInicio, fechaFin, codigo, nombreCliente, nombrePaciente, codigoEstado), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ValidarRiesgo(Nullable<int> codigoRiesgo)
        {
            return Json(RiesgoQuirurgico.ValidarRiesgo(codigoRiesgo), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult listarFichaRQ(Nullable<System.DateTime> fechaInicio, Nullable<System.DateTime> fechaFin, Nullable<int> codigo, string nombreCliente, string nombrePaciente, Nullable<int> codigoEstado)
        {
            return Json(RiesgoQuirurgico.ConsultarFichaRiesgoQuirurgico(fechaInicio, fechaFin, codigo, nombreCliente, nombrePaciente, codigoEstado), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InsertarRiesgoQuirurgico(Nullable<int> codigo, Nullable<int> codigoFicha, Nullable<int> codigoAnalisisPreliminar, string complicaciones, string consideraciones, string clasificacion, Nullable<int> codigoEmpleado, Nullable<int> codigoEstado, string accion)
        {
            return Json(RiesgoQuirurgico.InsertarRiesgoQuirurgico(codigo, codigoFicha, codigoAnalisisPreliminar, complicaciones, consideraciones, clasificacion, codigoEmpleado, codigoEstado, accion), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult InsertarDetalleRiesgoQuirurgico(Nullable<int> codigoInformeRiesgoQuirurgico, Nullable<int> codigoRiesgoQuirurgico, string detalleRiesgo, string consideraciones, string estadoRiesgo, string accion)
        {
            return Json(RiesgoQuirurgico.InsertarDetalleRiesgoQuirurgico(codigoInformeRiesgoQuirurgico, codigoRiesgoQuirurgico, detalleRiesgo, consideraciones, estadoRiesgo, accion), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ObtenerRiesgoQuirurgico(Nullable<int> codigoRiesgoQuirurgico)
        {
            return Json(RiesgoQuirurgico.ObtenerRiesgoQuirurgico(codigoRiesgoQuirurgico), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ObtenerDetalleRiesgoQuirurgico(Nullable<int> codigoRiesgoQuirurgico)
        {
            return Json(RiesgoQuirurgico.ObtenerDetalleRiesgoQuirurgico(codigoRiesgoQuirurgico), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListaRiesgoQuirurgico()
        {
            return Json(Pet.Service.RiesgoQuirurgicoCombo.ListaRiesgoQuirurgico().ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Adicionar()
        {
            return View();
        }
        public ActionResult Lectura()
        {
            return View();
        }
        public ActionResult BuscarFicha()
        {
            return View("../Busqueda/BuscarFicha");
        }
    }
}
