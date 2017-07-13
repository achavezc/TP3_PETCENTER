using Pet.Service.FichaHospitalizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pet.Web.Controllers
{
    public class FichaHospitalizacionController : Controller
    {
        //
        // GET: /FichaHospitalizacion/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult listarFicha(Nullable<System.DateTime> fechaInicio, Nullable<System.DateTime> fechaFin, Nullable<int> codigo, string nombreCliente, string nombrePaciente, Nullable<int> codigoEstado)
        {
            return Json(FichaHospitalizacion.ConsultarFicha(fechaInicio, fechaFin, codigo, nombreCliente, nombrePaciente, codigoEstado), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult BuscarInsumosDetalle(string enfermedad, Nullable<int> codigoTipoInsumo, string nombreInsumo, Nullable<int> cantidad)
        {
            return Json(FichaHospitalizacion.ConsultarTipoInsumo(enfermedad, codigoTipoInsumo, nombreInsumo, cantidad), JsonRequestBehavior.AllowGet);
        }
       
        [HttpPost]
        public JsonResult ObtenerDetalleFicha(Nullable<int> codigoFicha)
        {
            return Json(FichaHospitalizacion.ObtenerDetalleFicha(codigoFicha), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ObtenerInsumo(Nullable<int> codigoFicha)
        {
            return Json(FichaHospitalizacion.ObtenerInsumo(codigoFicha), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult InsertarFicha(Nullable<int> codigo, Nullable<int> codigoEmpleado, Nullable<int> codigoCita, string comentario, Nullable<int> codigoEmpleadoMedico, Nullable<int> codigoEmpleadoTecnico, Nullable<int> codigoSala, Nullable<int> codigoCubiculo, Nullable<int> codigoEstado, string accion)
        {
            return Json(FichaHospitalizacion.InsertarFicha(codigo, codigoEmpleado, codigoCita, comentario, codigoEmpleadoMedico, codigoEmpleadoTecnico, codigoSala, codigoCubiculo, codigoEstado, accion), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InsertarInsumo(Nullable<int> codigoFicha, Nullable<int> codigoInsumo, Nullable<int> cantidadInsumo, string estadoInsumo, string accion)
        {
            return Json(FichaHospitalizacion.InsertarInsumo(codigoFicha, codigoInsumo, cantidadInsumo, estadoInsumo, accion), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult BuscarCita(Nullable<int> codigoCita)
        {
            return Json(FichaHospitalizacion.BuscarCita(codigoCita), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ValidarFicha(Nullable<int> codigoCita)
        {
            return Json(FichaHospitalizacion.ValidarFicha(codigoCita), JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult ListaSala()
        {
            
            return Json(Pet.Service.Sala.ListaSala().ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ListaCubiculo()
        {
            
            return Json(Pet.Service.Cubiculo.ListaCubiculo().ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult BuscarInsumos()
        {
            return View("../Busqueda/BuscarInsumos");
        }

        public ActionResult Adicionar()
        {
            return View();
        }
        public ActionResult Lectura()
        {
            return View();
        }
        public ActionResult Editar()
        {
            return View();
        }
    }
}
