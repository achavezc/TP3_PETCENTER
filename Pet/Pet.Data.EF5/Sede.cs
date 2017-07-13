using Pet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.EF5
{
    public static class Sede
    {
        public static List<BESede> ListaSede()
        {
            List<BESede> lista = new List<BESede>();

            using (var db = new EFData.PETCENTEREntities())
            {
                foreach (var item in db.Sedes.ToList())
                {
                    BESede it = new BESede();
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
