using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.EF5.OrdenIntervencion
{
    public class OrdenIntervencion
    {
        public static object ConsultarOI(Nullable<int> codigo, string medico, string paciente, Nullable<System.DateTime> fechaOperacion, Nullable<int> codigoEstado)
        {

            using (var db = new EFData.PETCENTEREntities())
            {
                var result = db.USP_CONSULTAROIV2(codigo,medico,paciente,fechaOperacion,codigoEstado).ToList();

                return result;

            }
        }
        public static object InsertarOI(Nullable<int> codigo, Nullable<int> codigoficha, Nullable<int> codigoDiagnosticoPresuntivo, Nullable<int> codigoDiagnosticoDefinitivo, Nullable<System.DateTime> fechaOperacion, Nullable<int> codigoEstado, string observaciones, string accion)
        {

            using (var db = new EFData.PETCENTEREntities())
            {
                ObjectParameter output = new ObjectParameter("CodigoOut", typeof(Int32));

                var result = db.USP_INSERTAROI(codigo, codigoficha, codigoDiagnosticoPresuntivo, codigoDiagnosticoDefinitivo, fechaOperacion, codigoEstado, observaciones, accion, output);
                return output.Value;


            }
        }
        public static object ObtenerOI(Nullable<int> codigo)
        {

            using (var db = new EFData.PETCENTEREntities())
            {
                var result = db.USP_OBTENEROIV2(codigo).ToList();

                return result;

            }
        }
    }
}
