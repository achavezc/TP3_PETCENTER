using Pet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Service
{
    public static class Anio
    {
        public static List<BEAnio> ListaAnio()
        {
            return Pet.Data.EF5.Anio.ListaAnio();
        }
    }
}
