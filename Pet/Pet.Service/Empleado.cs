using Pet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Service
{
    public static class Empleado
    {
        public static List<BEEmpleado> ListaEmpleado()
        {
            return Pet.Data.EF5.Empleado.ListaEmpleado();
        }
    }
}
