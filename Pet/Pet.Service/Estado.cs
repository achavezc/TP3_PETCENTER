using Pet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Service
{
    public static class Estado
    {
        public static List<BEEstado> ListaEstado()
        {
            return Pet.Data.EF5.Estado.ListaEstado();
        }
    }
}
