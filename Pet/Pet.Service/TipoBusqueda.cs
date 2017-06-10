using Pet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Service
{
    public static class TipoBusqueda
    {
        public static List<BETipoBusqueda> ListaTipoBusqueda()
        {
            return Pet.Data.EF5.TipoBusqueda.ListaTipoBusqueda();
        }
    }
}
