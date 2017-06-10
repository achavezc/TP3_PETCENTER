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
            Session["usuario"] = "Logueado";
            return Json(new Result { Success = true }, JsonRequestBehavior.AllowGet);

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
                nombreUsuario = "Juan Perez";
                rolUsuario = "Jefe Operaciones";
                menuDemo.Add(new ResponseOpcionUI
                {
                    Clase = "Menu",
                    Codigo = "1",
                    Conceder = true,
                    NombreControl = "Administrar Programación de Turno",
                    Tipo = "Menu",
                    Url = "/ProgramacionTurno"
                });
                menuDemo.Add(new ResponseOpcionUI
                {
                    Clase = "Menu",
                    Codigo = "2",
                    Conceder = true,
                    NombreControl = "Administrar Epicrisis",
                    Tipo = "Menu",
                    Url = "/Epicrisis"
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