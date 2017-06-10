using Pet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.EF5
{
    public static class Empleado
    {
        public static List<BEEmpleado> ListaEmpleado()
        {
            List<BEEmpleado> lista = new List<BEEmpleado>();

            using (var db = new EFData.PETCENTEREntities1())
            {
                foreach (var item in db.Empleadoes.ToList())
                {
                    BEEmpleado it = new BEEmpleado();
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
