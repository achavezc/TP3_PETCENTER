using Pet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Service
{
    public static class Mes
    {
        public static List<BEMes> ListaMes()
        {
            return Pet.Data.EF5.Mes.ListaMes();
        }
    }
}
