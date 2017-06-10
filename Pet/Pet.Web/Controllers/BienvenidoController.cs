using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pet.Web.Controllers
{
    public class BienvenidoController : Controller
    {
        //
        // GET: /Bienvenido/

        public ActionResult Index()
        {
            return View("bienvenido");
        }


    }
}
