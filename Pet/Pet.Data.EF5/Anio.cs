using Pet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.EF5
{
    public static class Anio
    {
        public static List<BEAnio> ListaAnio()
        {
            List<BEAnio> lista = new List<BEAnio>();

            using (var db = new EFData.PETCENTEREntities())
            {
                foreach (var item in db.Anios.ToList())
                {
                    BEAnio it = new BEAnio();
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
