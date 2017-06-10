using Pet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.EF5
{
    public static class TipoConsumo
    {
        public static List<BETipoConsumo> ListaTipoConsumo()
        {
            List<BETipoConsumo> lista = new List<BETipoConsumo>();

            using (var db = new EFData.PETCENTEREntities1())
            {
                foreach (var item in db.TipoInsumoes.ToList())
                {
                    BETipoConsumo it = new BETipoConsumo();
                    it.Codigo = item.Codigo;
                    it.Descripcion = item.Descripcion;
                    it.EstadoRegistro = item.EstadoRegistro;
                    lista.Add(it);
                }

                return lista;
            }
        }
    }
}
