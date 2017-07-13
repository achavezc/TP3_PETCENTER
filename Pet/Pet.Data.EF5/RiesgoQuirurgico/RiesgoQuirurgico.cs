using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.EF5.RiesgoQuirurgico
{
    public class RiesgoQuirurgico
    {
        public static object ConsultarRiesgoQuirurgico(Nullable<System.DateTime> fechaInicio, Nullable<System.DateTime> fechaFin, Nullable<int> codigo, string nombreCliente, string nombrePaciente, Nullable<int> codigoEstado)
        {

            using (var db = new EFData.PETCENTEREntities())
            {
                var result = db.USP_CONSULTARIESGOQUIRURGICO(fechaInicio, fechaFin, codigo, nombreCliente, nombrePaciente, codigoEstado).ToList();

                return result;

            }
        }

        public static object ValidarRiesgo(Nullable<int> codigoRiesgo)
        {

            using (var db = new EFData.PETCENTEREntities())
            {
                var result = db.USP_VALIDARRIESGO(codigoRiesgo).ToList();

                return result;

            }
        }

        public static object ConsultarFichaRiesgoQuirurgico(Nullable<System.DateTime> fechaInicio, Nullable<System.DateTime> fechaFin, Nullable<int> codigo, string nombreCliente, string nombrePaciente, Nullable<int> codigoEstado)
        {

            using (var db = new EFData.PETCENTEREntities())
            {
                var result = db.USP_BUSCARFICHARQV2(fechaInicio, fechaFin, codigo, nombreCliente, nombrePaciente, codigoEstado).ToList();

                return result;

            }
        }

        public static object InsertarRiesgoQuirurgico(Nullable<int> codigo, Nullable<int> codigoFicha, Nullable<int> codigoAnalisisPreliminar, string complicaciones, string consideraciones, string clasificacion, Nullable<int> codigoEmpleado, Nullable<int> codigoEstado, string accion)
        {

            using (var db = new EFData.PETCENTEREntities())
            {
                ObjectParameter output = new ObjectParameter("CodigoOut", typeof(Int32));
                var result = db.USP_INSERTARRIESGOQUIRURGICO(codigo, codigoFicha, codigoAnalisisPreliminar, complicaciones, consideraciones, clasificacion, codigoEmpleado, codigoEstado, accion, output);
                return output.Value;
                //return result;

            }
        }

        public static object InsertarDetalleRiesgoQuirurgico(Nullable<int> codigoInformeRiesgoQuirurgico, Nullable<int> codigoRiesgoQuirurgico, string detalleRiesgo, string consideraciones, string estadoRiesgo, string accion)
        {

            using (var db = new EFData.PETCENTEREntities())
            {
                ObjectParameter output = new ObjectParameter("CodigoOut", typeof(Int32));
                var result = db.USP_INSERTARDETALLERIESGOQUIRURGICO(codigoInformeRiesgoQuirurgico, codigoRiesgoQuirurgico, detalleRiesgo, consideraciones, estadoRiesgo, accion, output);
                return output.Value;
                //return result;

            }
        }


        public static object ObtenerRiesgoQuirurgico(Nullable<int> codigoRiesgoQuirurgico)
        {

            using (var db = new EFData.PETCENTEREntities())
            {
                var result = db.USP_OBTENERDETALLERIESGOQUIRURGICO(codigoRiesgoQuirurgico).ToList();

                return result;

            }
        }
        public static object ObtenerDetalleRiesgoQuirurgico(Nullable<int> codigoRiesgoQuirurgico)
        {

            using (var db = new EFData.PETCENTEREntities())
            {
                var result = db.USP_OBTENERDETALLERIESGOQUIRURGICODETALLE(codigoRiesgoQuirurgico).ToList();

                return result;

            }
        }
    }
}
