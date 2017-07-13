using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Service.OrdenIntervencion
{
    public class OrdenIntervencion
    {
        public static object ConsultarOI(Nullable<int> codigo, string medico, string paciente, Nullable<System.DateTime> fechaOperacion, Nullable<int> codigoEstado)
        {
            return Pet.Data.EF5.OrdenIntervencion.OrdenIntervencion.ConsultarOI(codigo, medico, paciente, fechaOperacion, codigoEstado);
        }
        public static object InsertarOI(Nullable<int> codigo, Nullable<int> codigoficha, Nullable<int> codigoDiagnosticoPresuntivo, Nullable<int> codigoDiagnosticoDefinitivo, Nullable<System.DateTime> fechaOperacion, Nullable<int> codigoEstado, string observaciones, string accion)
        {
            return Pet.Data.EF5.OrdenIntervencion.OrdenIntervencion.InsertarOI(codigo,codigoficha,codigoDiagnosticoPresuntivo,codigoDiagnosticoDefinitivo,fechaOperacion,codigoEstado,observaciones,accion);
        }
        public static object ObtenerOI(Nullable<int> codigo)
        {
            return Pet.Data.EF5.OrdenIntervencion.OrdenIntervencion.ObtenerOI(codigo);
        }
    }
}
