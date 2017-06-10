using Pet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Service
{
    public static class TipoConsumo
    {
        public static List<BETipoConsumo> ListaTipoConsumo()
        {
            return Pet.Data.EF5.TipoConsumo.ListaTipoConsumo();
        }
    }
}
