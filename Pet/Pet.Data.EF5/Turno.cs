using Pet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.EF5
{
    public static class Turno
    {
        public static List<BETurno> ListaTurno()
        {
            List<BETurno> lista = new List<BETurno>();

            using (var db = new EFData.PETCENTEREntities())
            {
                foreach (var item in db.Turnoes.ToList())
                {
                    BETurno it = new BETurno();
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
