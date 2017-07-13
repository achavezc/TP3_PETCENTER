using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Entity
{
    public class BEEmpleado
    {
        public BEEmpleado()
        {
            this.Cargo = new Cargo();
        }
        public int Codigo { get; set; }
        public Cargo Cargo { get; set; }
        public string Descripcion { get; set; }
        public bool? EstadoRegistro { get; set; }
    }
    public  class Cargo
    {
        public Cargo()
        {
       
        }

        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public Nullable<bool> EstadoRegistro { get; set; }

       
    }
}
