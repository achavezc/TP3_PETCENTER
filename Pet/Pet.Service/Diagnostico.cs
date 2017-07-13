using Pet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Service
{
    public static class Diagnostico
    {
        public static List<BEDiagnostico> ListaDiagnostico()
        {
            return Pet.Data.EF5.Diagnostico.ListaDiagnostico();
        }
    }
}
