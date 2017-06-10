using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pet.Web.Models.ViewModels
{
    public class MenuDTO : Result
    {
        public List<ResponseOpcionUI> MenuIzquierdo { get; set; }
        public string NombreUsuario { get; set; }
        public string RolUsuario { get; set; }
    }
}