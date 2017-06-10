using Newtonsoft.Json;
using Pet.Service.Epicrisis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Web;
using System.Web.Mvc;

namespace Pet.Web.Controllers
{
    public class OrdenIntervencionController : Controller
    {
        //
        // GET: /Cliente/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BuscarOrdenIntervencion()
        {
            return View("../Busqueda/BuscarOrdenIntervencion");
        }
        [HttpPost]
        public JsonResult listarOrdenIntervencion(Nullable<int> codigoIntervencion, Nullable<System.DateTime> fechaInicio, Nullable<System.DateTime> fechaFin, Nullable<int> codigo, string nombre)
        {
            return Json(Epicrisis.ConsultarOrdenIntervencion(codigoIntervencion, fechaInicio, fechaFin, codigo, nombre), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ObtenerDetalleOrdenIntervencion(Nullable<int> codigoOrdenIntervencion)
        {
            return Json(Epicrisis.ObtenerDetalleOrdenIntervencion(codigoOrdenIntervencion), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ObtenerDetalleAnastesia(Nullable<int> codigoOrdenIntervencion)
        {
            return Json(Epicrisis.ObtenerDetalleAnastesia(codigoOrdenIntervencion), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ObtenerDetalleOperacion(Nullable<int> codigoOrdenIntervencion)
        {
            return Json(Epicrisis.ObtenerDetalleOperacion(codigoOrdenIntervencion), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ObtenerDetalleDiagnostico(Nullable<int> codigoOrdenIntervencion)
        {
            return Json(Epicrisis.ObtenerDetalleDiagnostico(codigoOrdenIntervencion), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ObtenerDetalleProfesional(Nullable<int> codigoOrdenIntervencion)
        {
            return Json(Epicrisis.ObtenerDetalleProfesional(codigoOrdenIntervencion), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ObtenerDetalleSignosVitales(Nullable<int> codigoOrdenIntervencion)
        {
            return Json(Epicrisis.ObtenerDetalleSignosVitales(codigoOrdenIntervencion), JsonRequestBehavior.AllowGet);
        }
 
    }
}