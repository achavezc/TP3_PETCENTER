using Pet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.EF5
{
    public static class RiesgoQuirurgicoCombo
    {
        public static List<BERiesgoQuirurgico> ListaRiesgoQuirurgico()
        {
            List<BERiesgoQuirurgico> lista = new List<BERiesgoQuirurgico>();

            using (var db = new EFData.PETCENTEREntities())
            {
                foreach (var item in db.Riesgo_Quirurgico.ToList())
                {
                    BERiesgoQuirurgico it = new BERiesgoQuirurgico();
                    it.Codigo = item.CodigoRiesgoQuirurgico;
                    it.Descripcion = item.Descripcion;
                    lista.Add(it);
                }

                return lista;
            }
        }
    }
}
