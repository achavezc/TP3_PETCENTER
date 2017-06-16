using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pet.Entity;
using System.Data;
using log4net;
using Pet.Service.Epicrisis;


namespace Pet.Web.Controllers
{
    public class EpicrisisController : Controller
    {
        //
        // GET: /SolicitudMantenimiento/
        //Log4Net
        public log4net.ILog log;

        public EpicrisisController()
        {
            log = log4net.LogManager.GetLogger("LogEpicrisis");
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult listarEpicrisis(Nullable<System.DateTime> fechaIngresoInicio, Nullable<System.DateTime> fechaIngresoFin, Nullable<int> codigo, string nombre, Nullable<int> codigoEstado)
        {
            return Json(Epicrisis.ConsultarEpicrisis(fechaIngresoInicio, fechaIngresoFin, codigo, nombre, codigoEstado), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerEpicrisis(Nullable<int> codigo)
        {
            return Json(Epicrisis.ObtenerEpicrisis(codigo), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ObtenerDetalleEpicrisis(Nullable<int> codigo)
        {
            return Json(Epicrisis.ObtenerDetalleEpicrisis(codigo), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult IngresarEpicrisis(Nullable<int> codigo, Nullable<int> codigoOrdenIntervencion, string areaHospitalaria, string servicio, string diasEstancia, Nullable<System.DateTime> fechaIngreso, Nullable<System.DateTime> fechaAlta, string veterinario, string tratamientoRecibido, string observaciones, Nullable<int> codigoEstado, string accion)
        {
            return Json(Epicrisis.InsertarEpicrisis(codigo, codigoOrdenIntervencion, areaHospitalaria, servicio, diasEstancia, fechaIngreso, fechaAlta, veterinario, tratamientoRecibido, observaciones, codigoEstado, accion), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult IngresarDetalleEpicrisis(Nullable<int> codigo, Nullable<int> codigoEpicrisis, Nullable<int> codigoTipoInsumo, string descripcion, string observaciones, string frecuencia, string dosis, string accion)
        {
            return Json(Epicrisis.InsertarDetalleEpicrisis(codigo, codigoEpicrisis, codigoTipoInsumo, descripcion, observaciones, frecuencia, dosis, accion), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListaTipoBusqueda()
        {
            log.Info("Function: [ListaTipoBusqueda()]");
            return Json(Pet.Service.TipoBusqueda.ListaTipoBusqueda().ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ListaEstado()
        {
            log.Info("Function: [ListaEstado()]");
            return Json(Pet.Service.Estado.ListaEstado().ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ListaTipoConsumo()
        {
            log.Info("Function: [ListaTipoConsumo()]");
            return Json(Pet.Service.TipoConsumo.ListaTipoConsumo().ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListaEmpleado()
        {
            log.Info("Function: [ListaEmpleado()]");
            return Json(Pet.Service.Empleado.ListaEmpleado().ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Adicionar()
        {
            return View();
        }
        public ActionResult Lectura()
        {
            return View();
        }

    }
}
