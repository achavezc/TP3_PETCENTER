using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetCenter.Entidades
{
    public class SolicitudAdopcion: Solicitud
    {
        public Cliente cliente { get; set; }

        public Mascota mascota { get; set; }

        public String domiciliolocal { get; set; }

        public int UsuarioCreacion { get; set; }

        public String numero_documento { get; set; }

        public DateTime fecha_inicial { get; set; }        

        public DateTime fecha_final { get; set; }
    }
}