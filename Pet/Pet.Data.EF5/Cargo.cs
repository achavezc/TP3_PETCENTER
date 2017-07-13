using Pet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.EF5
{
    public static class Cargo
    {
        public static List<BECargo> ListaCargo()
        {
            List<BECargo> lista = new List<BECargo>();

            using (var db = new EFData.PETCENTEREntities())
            {
                foreach (var item in db.Cargoes.ToList())
                {
                    BECargo it = new BECargo();
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
