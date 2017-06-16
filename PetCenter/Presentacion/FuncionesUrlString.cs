using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetCenter
{
    public class FuncionesUrlString
    {
        // GET api/<controller>
        public static string LibreriasJS()
        {
            return ""
            + "<script src='" + getPath() + "Presentacion/Adopcion/resources/js/jquery/jquery.min.js'/></script>"
            + "<script src='" + getPath() + "Presentacion/Adopcion/resources/js/jquery/jquery-ui-1.9.1.custom.min.js'/></script>"
            + "<script src='" + getPath() + "Presentacion/Adopcion/resources/js/jquery/jquery.blockUI.js'/></script>"
            + "<script src='" + getPath() + "Presentacion/Adopcion/resources/js/bootstrap/bootstrap.min.js'/></script>"
            + "<script src='" + getPath() + "Presentacion/Adopcion/resources/js/angularjs/angular.min.js'/></script>"
            + "<script src='" + getPath() + "Presentacion/Adopcion/resources/js/angularjs/angular-route.min.js'/></script>"
            + "<script src='" + getPath() + "Presentacion/Adopcion/resources/js/angularjs/angular-resource.min.js'/></script>"
            + "<script src='" + getPath() + "Presentacion/Adopcion/resources/js/angularjs/angular-animate.js'/></script>"
            + "<script src='" + getPath() + "Presentacion/Adopcion/resources/js/angularjs/angular-locale_es-pe.js'/></script>"
            + "<script src='" + getPath() + "Presentacion/Adopcion/resources/js/angularjs/ui-bootstrap-tpls.min.js'/></script>"
            + "<script src='" + getPath() + "Presentacion/Adopcion/resources/js/angularjs/ng-table.min.js'/></script>"
            + "<script src='" + getPath() + "Presentacion/Adopcion/resources/js/angularjs/moment.min.js'/></script>"
            + "<script src='" + getPath() + "Presentacion/Adopcion/resources/js/angularjs/bootstrap-datepicker.min.js'/></script>"
            + "<script src='" + getPath() + "Presentacion/Adopcion/resources/js/angularjs/bootstrap-datetimepicker.min.js'/></script>"
            + "<script src='" + getPath() + "Presentacion/Adopcion/resources/js/angularjs/satellizer.js'/></script>"
            + "<script src='" + getPath() + "Presentacion/Adopcion/resources/js/angularjs/angular-ui-notification.min.js'/></script>"            
            + "<script src='" + getPath() + "Presentacion/Adopcion/resources/js/FuncionesComunes.js'/></script>";

        }

        public static string LibreriasCSS()
        {
            return ""
              + "<link href='" + getPath() + "Presentacion/Adopcion/resources/css/jquery-ui-1.12.1.custom.min.css' rel='stylesheet' type='text/css' />"
              + "<link href='" + getPath() + "Presentacion/Adopcion/resources/css/bootstrap.min.css' rel='stylesheet' type='text/css' />"
              + "<link href='" + getPath() + "Presentacion/Adopcion/resources/css/style.css' rel='stylesheet' type='text/css' />"
              + "<link href='" + getPath() + "Presentacion/Adopcion/resources/css/datepicker.min.css' rel='stylesheet' type='text/css' />"
              + "<link href='" + getPath() + "Presentacion/Adopcion/resources/css/angular-csp.css' rel='stylesheet' type='text/css' />"
              + "<link href='" + getPath() + "Presentacion/Adopcion/resources/css/angular-ui-notification.min.css' rel='stylesheet' type='text/css' />";

        }

        static public string getPath()
        {

            return HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath + (HttpContext.Current.Request.ApplicationPath.EndsWith("/") ? "" : "/");
        }

        
    }
}