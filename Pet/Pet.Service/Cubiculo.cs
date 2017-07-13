using Pet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Service
{
    public static class Cubiculo
    {
        public static List<BECubiculo> ListaCubiculo()
        {
            return Pet.Data.EF5.Cubiculo.ListaCubiculo();
        }
    }
}
