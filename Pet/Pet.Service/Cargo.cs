using Pet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Service
{
    public static class Cargo
    {
        public static List<BECargo> ListaCargo()
        {
            return Pet.Data.EF5.Cargo.ListaCargo();
        }
    }
}
