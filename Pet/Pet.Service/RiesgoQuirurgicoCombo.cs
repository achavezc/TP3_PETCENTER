using Pet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Service
{
    public static class RiesgoQuirurgicoCombo
    {
        public static List<BERiesgoQuirurgico> ListaRiesgoQuirurgico()
        {
            return Pet.Data.EF5.RiesgoQuirurgicoCombo.ListaRiesgoQuirurgico();
        }
    }
}
