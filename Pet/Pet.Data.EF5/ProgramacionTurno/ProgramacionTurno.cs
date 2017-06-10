using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.EF5.ProgramacionTurno
{
    public static class ProgramacionTurno
    {
        public static object ConsultarProgramacionTurno(Nullable<int> codigoSede, Nullable<int> codigoAnio, Nullable<int> codigoMes)
        {
           
            using (var db = new EFData.PETCENTEREntities1())
            {
                var result = db.USP_CONSULTAPROGRAMACION(codigoSede, codigoAnio, codigoMes).ToList();

                return result;

            }
        }
        public static object ObtenerProgramacionTurno(Nullable<int> codigo)
        {
            using (var db = new EFData.PETCENTEREntities1())
            {
                var result = db.USP_OBTENERPROGRAMACIONTURNO(codigo).ToList();

                return result;

            }
        }

        public static object ObtenerDetalleProgramacionTurno(Nullable<int> codigo)
        {
            using (var db = new EFData.PETCENTEREntities1())
            {
                var result = db.USP_OBTENERDETALLEPROGRAMACIONTURNO(codigo).ToList();

                return result;

            }
        }
        public static object InsertarProgramacionTurno(Nullable<int> codigo, Nullable<int> codigoSede, Nullable<int> codigoAnio, Nullable<int> codigoMes, Nullable<System.DateTime> fechaInicio, Nullable<System.DateTime> fechaFin, string accion)
        {
            using (var db = new EFData.PETCENTEREntities1())
            {
                ObjectParameter output = new ObjectParameter("CodigoOut", typeof(Int32));
                var result = db.USP_INSERTARPROGRAMACIONTURNO(codigo, codigoSede, codigoAnio, codigoMes, fechaInicio, fechaFin, accion, output);

                return output.Value;

            }
        }
        public static object InsertarDetalleProgramacionTurno(Nullable<int> codigo, Nullable<int> codigoTurno, Nullable<int> codigoCargo, Nullable<int> codigoEmpleado, Nullable<int> codigoProgramacionTurno, Nullable<bool> responsable, string accion)
        {
            using (var db = new EFData.PETCENTEREntities1())
            {
                ObjectParameter output = new ObjectParameter("CodigoOut", typeof(Int32));
                var result = db.USP_INSERTARDETALLEPROGRAMACIONTURNO(codigo, codigoTurno, codigoCargo, codigoEmpleado, codigoProgramacionTurno, responsable, accion, output);

                return output.Value;

            }
        }
        

    }
}
