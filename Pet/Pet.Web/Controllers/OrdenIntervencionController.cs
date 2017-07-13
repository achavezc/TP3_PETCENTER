using Newtonsoft.Json;
using Pet.Service.Epicrisis;
using Pet.Service.OrdenIntervencion;
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
        public JsonResult listarOrden(Nullable<int> codigo, string medico, string paciente, Nullable<System.DateTime> fechaOperacion, Nullable<int> codigoEstado)
        {
            return Json(OrdenIntervencion.ConsultarOI(codigo, medico, paciente, fechaOperacion, codigoEstado), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult InsertarOI(Nullable<int> codigo, Nullable<int> codigoficha, Nullable<int> codigoDiagnosticoPresuntivo, Nullable<int> codigoDiagnosticoDefinitivo, Nullable<System.DateTime> fechaOperacion, Nullable<int> codigoEstado, string observaciones, string accion)
        {
            return Json(OrdenIntervencion.InsertarOI(codigo, codigoficha, codigoDiagnosticoPresuntivo, codigoDiagnosticoDefinitivo, fechaOperacion, codigoEstado, observaciones, accion), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ObtenerOI(Nullable<int> codigo)
        {
            return Json(OrdenIntervencion.ObtenerOI(codigo), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult listarOrdenIntervencion(Nullable<int> codigoIntervencion, Nullable<System.DateTime> fechaInicio, Nullable<System.DateTime> fechaFin, Nullable<int> codigo, string nombre, Nullable<int> codigoTipoBusqueda)
        {
            return Json(Epicrisis.ConsultarOrdenIntervencion(codigoIntervencion, fechaInicio, fechaFin, codigo, nombre,codigoTipoBusqueda), JsonRequestBehavior.AllowGet);
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
        [HttpGet]
        public JsonResult ListaDiagnostico()
        {
          
            return Json(Pet.Service.Diagnostico.ListaDiagnostico().ToList(), JsonRequestBehavior.AllowGet);
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