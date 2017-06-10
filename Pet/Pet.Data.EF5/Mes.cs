using Pet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.EF5
{
    public static class Mes
    {
        public static List<BEMes> ListaMes()
        {
            List<BEMes> lista = new List<BEMes>();

            using (var db = new EFData.PETCENTEREntities1())
            {
                foreach (var item in db.Mes.ToList())
                {
                    BEMes it = new BEMes();
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
