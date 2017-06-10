using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pet.Entity;
using System.Data;


using log4net;
using Pet.Service.ProgramacionTurno;
using System.Data.Objects;

namespace Pet.Web.Controllers
{
    public class ProgramacionTurnoController : Controller
    {
        public log4net.ILog log;

        public ProgramacionTurnoController()
        {
            log = log4net.LogManager.GetLogger("LogProgramacionTurno");
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult listarProgramacionTurno(Nullable<int> codigoSede, Nullable<int> codigoAnio, Nullable<int> codigoMes)
        {
            return Json(ProgramacionTurno.ConsultarProgramacionTurno(codigoSede, codigoAnio, codigoMes), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerProgramacionTurno(Nullable<int> codigo)
        {
            return Json(ProgramacionTurno.ObtenerProgramacionTurno(codigo), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ObtenerDetalleProgramacionTurno(Nullable<int> codigo)
        {
            return Json(ProgramacionTurno.ObtenerDetalleProgramacionTurno(codigo), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult IngresarProgramacionTurno(Nullable<int> codigo, Nullable<int> codigoSede, Nullable<int> codigoAnio, Nullable<int> codigoMes, Nullable<System.DateTime> fechaInicio, Nullable<System.DateTime> fechaFin, string accion)
        {
            return Json(ProgramacionTurno.InsertarProgramacionTurno(codigo, codigoSede, codigoAnio, codigoMes, fechaInicio, fechaFin, accion), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult IngresarDetalleProgramacionTurno(Nullable<int> codigo, Nullable<int> codigoTurno, Nullable<int> codigoCargo, Nullable<int> codigoEmpleado, Nullable<int> codigoProgramacionTurno, Nullable<bool> responsable, string accion)
        {
            return Json(ProgramacionTurno.InsertarDetalleProgramacionTurno(codigo, codigoTurno, codigoCargo, codigoEmpleado, codigoProgramacionTurno, responsable, accion), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListaSede()
        {
            log.Info("Function: [ListaSede()]");
            return Json(Pet.Service.Sede.ListaSede().ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ListaAnio()
        {
            log.Info("Function: [ListaAnio()]");
            return Json(Pet.Service.Anio.ListaAnio().ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ListaMes()
        {
            log.Info("Function: [ListaMes()]");
            return Json(Pet.Service.Mes.ListaMes().ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListaTurno()
        {
            log.Info("Function: [ListaTurno()]");
            return Json(Pet.Service.Turno.ListaTurno().ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ListaCargo()
        {
            log.Info("Function: [ListaCargo()]");
            return Json(Pet.Service.Cargo.ListaCargo().ToList(), JsonRequestBehavior.AllowGet);
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
