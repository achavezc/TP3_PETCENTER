using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Entity
{
    public class BEDiagnostico
    {
       
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string TipoDiagnostico { get; set; }
        public bool? EstadoRegistro { get; set; }
       
    }
}
