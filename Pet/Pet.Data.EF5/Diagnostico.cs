using Pet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.EF5
{
    public static class Diagnostico
    {
        public static List<BEDiagnostico> ListaDiagnostico()
        {
            List<BEDiagnostico> lista = new List<BEDiagnostico>();

            using (var db = new EFData.PETCENTEREntities())
            {
                foreach (var item in db.Diagnosticoes.ToList())
                {
                    BEDiagnostico it = new BEDiagnostico();
                    it.Codigo = item.CodigoDiagnostico;
                    it.Descripcion = item.Descripcion;
                    if (item.tipo_diagnostico != null)
                    {
                        it.TipoDiagnostico = item.tipo_diagnostico.descripcion;
                    }
                    it.EstadoRegistro = item.EstadoRegistro;
                    lista.Add(it);
                }

                return lista;
            }
        }
    }
}
