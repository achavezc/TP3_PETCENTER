using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects;

namespace Pet.Service.ProgramacionTurno
{
    public class ProgramacionTurno
    {
        public static object ConsultarProgramacionTurno(Nullable<int> codigoSede, Nullable<int> codigoAnio, Nullable<int> codigoMes)
        {
            return Pet.Data.EF5.ProgramacionTurno.ProgramacionTurno.ConsultarProgramacionTurno(codigoSede, codigoAnio, codigoMes);
        }
        public static object ObtenerProgramacionTurno(Nullable<int> codigo)
        {
            return Pet.Data.EF5.ProgramacionTurno.ProgramacionTurno.ObtenerProgramacionTurno(codigo);
        }
        public static object ObtenerDetalleProgramacionTurno(Nullable<int> codigo)
        {
            return Pet.Data.EF5.ProgramacionTurno.ProgramacionTurno.ObtenerDetalleProgramacionTurno(codigo);
        }

        public static object InsertarProgramacionTurno(Nullable<int> codigo, Nullable<int> codigoSede, Nullable<int> codigoAnio, Nullable<int> codigoMes, Nullable<System.DateTime> fechaInicio, Nullable<System.DateTime> fechaFin, string accion)
        {
            return Pet.Data.EF5.ProgramacionTurno.ProgramacionTurno.InsertarProgramacionTurno(codigo, codigoSede, codigoAnio, codigoMes, fechaInicio, fechaFin, accion);
        }
        public static object InsertarDetalleProgramacionTurno(Nullable<int> codigo, Nullable<int> codigoTurno, Nullable<int> codigoCargo, Nullable<int> codigoEmpleado, Nullable<int> codigoProgramacionTurno, Nullable<bool> responsable, string accion)
        {
            return Pet.Data.EF5.ProgramacionTurno.ProgramacionTurno.InsertarDetalleProgramacionTurno(codigo, codigoTurno, codigoCargo, codigoEmpleado, codigoProgramacionTurno, responsable, accion);
        }
      
    }
}
