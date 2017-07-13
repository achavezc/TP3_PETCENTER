using Pet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.EF5
{
    public static class Cubiculo
    {
        public static List<BECubiculo> ListaCubiculo()
        {
            List<BECubiculo> lista = new List<BECubiculo>();

            using (var db = new EFData.PETCENTEREntities())
            {
                foreach (var item in db.cubiculoes.ToList())
                {
                    BECubiculo it = new BECubiculo();
                    it.Codigo = item.codigo_cubiculo;
                    it.Descripcion = item.nombre_cubiculo;
                    it.Ocupado = item.Ocupado;
                    lista.Add(it);
                }

                return lista;
            }
        }
    }
}
