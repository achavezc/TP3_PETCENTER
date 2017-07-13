using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.EF5.Ficha
{
    public class FichaHospitalizacion
    {
        public static object ConsultarFicha(Nullable<System.DateTime> fechaInicio, Nullable<System.DateTime> fechaFin, Nullable<int> codigo, string nombreCliente, string nombrePaciente, Nullable<int> codigoEstado)
        {

            using (var db = new EFData.PETCENTEREntities())
            {
                var result = db.USP_CONSULTAFICHAV4(fechaInicio,fechaFin,codigo,nombreCliente,nombrePaciente,codigoEstado).ToList();

                return result;

            }
        }
        public static object ValidarFicha(Nullable<int> codigoCita)
        {

            using (var db = new EFData.PETCENTEREntities())
            {
                var result = db.USP_VALIDARFICHA(codigoCita).ToList();
                return result;
            }
        }
        public static object ConsultarTipoInsumo(string enfermedad, Nullable<int> codigoTipoInsumo, string nombreInsumo, Nullable<int> cantidad)
        {

            using (var db = new EFData.PETCENTEREntities())
            {
                var result = db.USP_BUSCARINSUMOS(enfermedad, codigoTipoInsumo, nombreInsumo, cantidad).ToList();

                return result;

            }
        }
        public static object ObtenerInsumo(Nullable<int> codigoFicha)
        {

            using (var db = new EFData.PETCENTEREntities())
            {
                var result = db.USP_OBTENERINSUMOS(codigoFicha).ToList();

                return result;

            }
        }
        public static object ObtenerDetalleFicha(Nullable<int> codigoFicha)
        {

            using (var db = new EFData.PETCENTEREntities())
            {
                var result = db.USP_OBTENERDETALLEFICHA(codigoFicha).ToList();

                return result;

            }
        }
        public static object InsertarFicha(Nullable<int> codigo, Nullable<int> codigoEmpleado, Nullable<int> codigoCita, string comentario, Nullable<int> codigoEmpleadoMedico, Nullable<int> codigoEmpleadoTecnico, Nullable<int> codigoSala, Nullable<int> codigoCubiculo, Nullable<int> codigoEstado, string accion)
        {
            using (var db = new EFData.PETCENTEREntities())
            {
                ObjectParameter output = new ObjectParameter("CodigoOut", typeof(Int32));
                var result = db.USP_INSERTARFICHA(codigo, codigoEmpleado, codigoCita, comentario, codigoEmpleadoMedico, codigoEmpleadoTecnico, codigoSala, codigoCubiculo, codigoEstado, accion, output);

                return output.Value;

            }
        }
        public static object InsertarInsumo(Nullable<int> codigoFicha, Nullable<int> codigoInsumo, Nullable<int> cantidadInsumo, string estadoInsumo, string accion)
        {
            using (var db = new EFData.PETCENTEREntities())
            {
                ObjectParameter output = new ObjectParameter("CodigoOut", typeof(Int32));
                var result = db.USP_INSERTARINSUMO(codigoFicha, codigoInsumo, cantidadInsumo, estadoInsumo, accion, output);

                return output.Value;

            }
        }
        public static object BuscarCita(Nullable<int> codigoCita)
        {

            using (var db = new EFData.PETCENTEREntities())
            {
                var result = db.USP_BUSCARCITA(codigoCita).ToList();

                return result;

            }
        }
    }
}
