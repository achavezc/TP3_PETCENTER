using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetCenter.Entidades
{
    public class SolicitudPedigri : Solicitud
    {
        public Cliente cliente { get; set; }

        public DateTime fechaRecepcionInf_KCP { get; set; }

        public DateTime fecha_inicial { get; set; }

        public bool domicilio_local { get; set; }

        public DateTime fecha_final { get; set; }

        public Mascota mascota_padre { get; set; }

        public Mascota mascota_madre { get; set; }

        public List<Mascota> camada_cachorros { get; set; }

        public Empleado usuario_creacion { get; set; }

        public Empleado usuario_modificacion { get; set; }
    }
}