using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetCenter.Entidades
{
    public class Solicitud
    {
        public int id { get; set; }

        public int numero_solicitud { get; set; }

        public DateTime fecha_solicitud { get; set; }

        public string comentarios { get; set; }

        public string estado_solicitud { get; set; }

        public string tipo_solicitud { get; set; }
    }
}