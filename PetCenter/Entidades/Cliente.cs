using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetCenter.Entidades
{
    public class Cliente
    {
        public string id { get; set; }
        public int codigo_cliente { get; set; }
        public int codigo_persona { get; set; }
        public string email_cliente { get; set; }
        public string autoriza_uso_datos { get; set; }

        public int codigo_tipo_documento { get; set; }

        public string descripcion_tipo_documento { get; set; }

        public string numero_documento { get; set; }

        public string nombres { get; set; }

        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }

    }
}