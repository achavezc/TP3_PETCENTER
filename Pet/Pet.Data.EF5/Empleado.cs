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

            using (var db = new EFData.PETCENTEREntities())
            {
                foreach (var item in db.GG_Empleado.ToList())
                {
                    BEEmpleado it = new BEEmpleado();
                    
                    it.Codigo = item.codigo_empleado;
                    it.Cargo.Codigo = item.Cargo.Codigo;
                    it.Descripcion = item.GG_Persona.nombres + ' '+ item.GG_Persona.apellidoPaterno + ' '+ item.GG_Persona.apellidoMaterno;//item.Descripcion;
                    it.EstadoRegistro = item.EstadoRegistro;
                    lista.Add(it);
                }

                return lista;
            }
        }
    }
}
