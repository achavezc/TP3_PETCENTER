using Pet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Service
{
    public static class Turno
    {
        public static List<BETurno> ListaTurno()
        {
            return Pet.Data.EF5.Turno.ListaTurno();
        }
    }
}
