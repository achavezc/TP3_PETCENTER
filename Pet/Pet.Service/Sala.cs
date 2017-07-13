using Pet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Service
{
    public static class Sala
    {
        public static List<BESala> ListaSala()
        {
            return Pet.Data.EF5.Sala.ListaSala();
        }
    }
}
