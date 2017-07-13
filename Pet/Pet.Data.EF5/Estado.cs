using Pet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.EF5
{
    public static class Estado
    {
        public static List<BEEstado> ListaEstado()
        {
            List<BEEstado> lista = new List<BEEstado>();

            using (var db = new EFData.PETCENTEREntities())
            {
                foreach (var item in db.Estadoes.ToList())
                {
                    BEEstado it = new BEEstado();
                    it.Codigo = item.CodigoEstado;
                    it.Descripcion = item.DescripcionEstado;
                    it.TipoEstado = item.TipoEstado;
                    it.EstadoRegistro = item.EstadoRegistro;
                    lista.Add(it);
                }

                return lista;
            }
        }
    }
}
