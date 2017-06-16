using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetCenter.Entidades
{
    public class Mascota
    {
        //public string id { get; set; }
        public int codigo_mascota { get; set; }
        public int codigo_cliente { get; set; }
        public string nombre_mascota { get; set; }
        public string genero { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string tamanho { get; set; }
        public string descripcion_raza { get; set; }
        public string descripcion_especie { get; set; }
        public string edad { get; set; }
        public int edadDias { get; set; }
        public int codigo_raza { get; set; }
    }
}