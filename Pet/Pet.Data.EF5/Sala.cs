using Pet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.EF5
{
    public static class Sala
    {
        public static List<BESala> ListaSala()
        {
            List<BESala> lista = new List<BESala>();

            using (var db = new EFData.PETCENTEREntities())
            {
                foreach (var item in db.salas.ToList())
                {
                    BESala it = new BESala();
                    it.Codigo = item.codigo_sala;
                    it.Descripcion = item.nombre_sala;
                    lista.Add(it);
                }

                return lista;
            }
        }
    }
}
