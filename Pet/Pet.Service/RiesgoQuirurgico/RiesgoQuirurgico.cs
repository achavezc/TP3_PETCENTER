using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Service.RiesgoQuirurgico
{
    public class RiesgoQuirurgico
    {
        public static object ConsultarRiesgoQuirurgico(Nullable<System.DateTime> fechaInicio, Nullable<System.DateTime> fechaFin, Nullable<int> codigo, string nombreCliente, string nombrePaciente, Nullable<int> codigoEstado)
        {
            return Pet.Data.EF5.RiesgoQuirurgico.RiesgoQuirurgico.ConsultarRiesgoQuirurgico(fechaInicio, fechaFin, codigo, nombreCliente, nombrePaciente, codigoEstado);
        }
        public static object ValidarRiesgo(Nullable<int> codigoRiesgo)
        {
            return Pet.Data.EF5.RiesgoQuirurgico.RiesgoQuirurgico.ValidarRiesgo(codigoRiesgo);
        }
        public static object ConsultarFichaRiesgoQuirurgico(Nullable<System.DateTime> fechaInicio, Nullable<System.DateTime> fechaFin, Nullable<int> codigo, string nombreCliente, string nombrePaciente, Nullable<int> codigoEstado)
        {
            return Pet.Data.EF5.RiesgoQuirurgico.RiesgoQuirurgico.ConsultarFichaRiesgoQuirurgico(fechaInicio, fechaFin, codigo, nombreCliente, nombrePaciente, codigoEstado);
        }
        public static object InsertarRiesgoQuirurgico(Nullable<int> codigo, Nullable<int> codigoFicha, Nullable<int> codigoAnalisisPreliminar, string complicaciones, string consideraciones, string clasificacion, Nullable<int> codigoEmpleado, Nullable<int> codigoEstado, string accion)
        {
            return Pet.Data.EF5.RiesgoQuirurgico.RiesgoQuirurgico.InsertarRiesgoQuirurgico(codigo,codigoFicha,codigoAnalisisPreliminar,complicaciones,consideraciones,clasificacion,codigoEmpleado,codigoEstado,accion);
        }
        public static object InsertarDetalleRiesgoQuirurgico(Nullable<int> codigoInformeRiesgoQuirurgico, Nullable<int> codigoRiesgoQuirurgico, string detalleRiesgo, string consideraciones, string estadoRiesgo, string accion)
        {
            return Pet.Data.EF5.RiesgoQuirurgico.RiesgoQuirurgico.InsertarDetalleRiesgoQuirurgico(codigoInformeRiesgoQuirurgico, codigoRiesgoQuirurgico, detalleRiesgo, consideraciones, estadoRiesgo, accion);
        }
        public static object ObtenerRiesgoQuirurgico(Nullable<int> codigoRiesgoQuirurgico)
        {
            return Pet.Data.EF5.RiesgoQuirurgico.RiesgoQuirurgico.ObtenerRiesgoQuirurgico(codigoRiesgoQuirurgico);
        }
        public static object ObtenerDetalleRiesgoQuirurgico(Nullable<int> codigoRiesgoQuirurgico)
        {
            return Pet.Data.EF5.RiesgoQuirurgico.RiesgoQuirurgico.ObtenerDetalleRiesgoQuirurgico(codigoRiesgoQuirurgico);
        }
    }
}
