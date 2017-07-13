using Pet.Service.ProgramacionTurno;
using Pet.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace Pet.Web.Controllers
{
    public class SeguridadAgmaController : Controller
    {
        //
        // GET: /SeguridadCalculadorWeb/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Seguridad()
        {
            return View("Seguridad");
        }

        public ActionResult Login(string usuario, string password)
        {
            var resultado = ProgramacionTurno.Login(usuario, password);
            bool resultadoFinal = false;
            if (((System.Collections.Generic.List<Pet.Data.EF5.EFData.USP_LOGIN_Result>)resultado).Count > 0)
            {
                resultadoFinal = true;
                Session["nombreUsuario"] = usuario;
            }
            Session["usuario"] = "Logueado";
            return Json(new Result { Success = resultadoFinal }, JsonRequestBehavior.AllowGet);
        }
        public virtual ActionResult ObtenerMenus()
        {
            bool success = false;
            List<ResponseOpcionUI> menuDemo = new List<ResponseOpcionUI>();
            string nombreUsuario = "";
            string rolUsuario = "";
            if (Session["usuario"] != null)
            {
                success = true;
                nombreUsuario = Session["nombreUsuario"].ToString();
                rolUsuario = "Médico Cirujano";
                menuDemo.Add(new ResponseOpcionUI
                {
                    Clase = "Menu",
                    Codigo = "1",
                    Conceder = true,
                    NombreControl = "Programación de Turno",
                    Tipo = "Menu",
                    Url = "/ProgramacionTurno"
                });
                menuDemo.Add(new ResponseOpcionUI
                {
                    Clase = "Menu",
                    Codigo = "2",
                    Conceder = true,
                    NombreControl = "Epicrisis",
                    Tipo = "Menu",
                    Url = "/Epicrisis"
                });
                menuDemo.Add(new ResponseOpcionUI
                {
                    Clase = "Menu",
                    Codigo = "3",
                    Conceder = true,
                    NombreControl = "Ficha Hospitalizacion",
                    Tipo = "Menu",
                    Url = "/FichaHospitalizacion"
                });
                menuDemo.Add(new ResponseOpcionUI
                {
                    Clase = "Menu",
                    Codigo = "4",
                    Conceder = true,
                    NombreControl = "Riesgos Quirurgicos",
                    Tipo = "Menu",
                    Url = "/RiesgoQuirurgico"
                });
                menuDemo.Add(new ResponseOpcionUI
                {
                    Clase = "Menu",
                    Codigo = "5",
                    Conceder = true,
                    NombreControl = "Orden Intervención",
                    Tipo = "Menu",
                    Url = "/OrdenIntervencion"
                });
            }

            return Json(new MenuDTO { Success = success, MenuIzquierdo = menuDemo, NombreUsuario = nombreUsuario, RolUsuario = rolUsuario }, JsonRequestBehavior.AllowGet);

        }

        public virtual ActionResult CerrarSesion()
        {

            Session["usuario"] = null;

            Session.Abandon();
            Session.Clear();
            FormsAuthentication.SignOut();

            Response.Redirect("/");
            Response.End();

            return Json(new { success = true });
        }
    }
}