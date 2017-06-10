using Pet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Service
{
    public static class Sede
    {
        public static List<BESede> ListaSede()
        {
            return Pet.Data.EF5.Sede.ListaSede();
        }
    }
}
