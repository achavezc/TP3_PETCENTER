using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.EF5.Epicrisis
{
    public static class Epicrisis
    {
        public static object ConsultarEpicrisis(Nullable<System.DateTime> fechaIngresoInicio, Nullable<System.DateTime> fechaIngresoFin, Nullable<int> codigo, string nombre, Nullable<int> codigoEstado)
        {
           
            using (var db = new EFData.PETCENTEREntities1())
            {
                var result = db.USP_CONSULTAEPICRISISV4(fechaIngresoInicio, fechaIngresoFin, codigo,nombre,codigoEstado).ToList();

                return result;

            }
        }
        public static object ConsultarOrdenIntevencion(Nullable<int> codigoIntervencion, Nullable<System.DateTime> fechaInicio, Nullable<System.DateTime> fechaFin, Nullable<int> codigo, string nombre)
        {

            using (var db = new EFData.PETCENTEREntities1())
            {
                var result = db.USP_CONSULTAORDENINTERVENCIONV4(codigoIntervencion, fechaInicio, fechaFin,codigo, nombre).ToList();

                return result;

            }
        }
        public static object ObtenerDetalleOrdenIntervencion(Nullable<int> codigoOrdenIntervencion)
        {
            using (var db = new EFData.PETCENTEREntities1())
            {
                var result = db.USP_OBTENERDETALLEORDENINTERVENCION(codigoOrdenIntervencion).ToList();
                return result;
            }
        }
        public static object ObtenerDetalleAnastesia(Nullable<int> codigoOrdenIntervencion)
        {
            using (var db = new EFData.PETCENTEREntities1())
            {
                var result = db.USP_OBTENERDETALLEANASTESIA(codigoOrdenIntervencion).ToList();
                return result;
            }
        }
        public static object ObtenerDetalleOperacion(Nullable<int> codigoOrdenIntervencion)
        {
            using (var db = new EFData.PETCENTEREntities1())
            {
                var result = db.USP_OBTENERDETALLEOPERACION(codigoOrdenIntervencion).ToList();
                return result;
            }
        }
        public static object ObtenerDetalleDiagnostico(Nullable<int> codigoOrdenIntervencion)
        {
            using (var db = new EFData.PETCENTEREntities1())
            {
                var result = db.USP_OBTENERDETALLEDIAGNOSTICO(codigoOrdenIntervencion).ToList();
                return result;
            }
        }
        public static object ObtenerDetalleProfesional(Nullable<int> codigoOrdenIntervencion)
        {
            using (var db = new EFData.PETCENTEREntities1())
            {
                var result = db.USP_OBTENERDETALLEPROFESIONAL(codigoOrdenIntervencion).ToList();
                return result;
            }
        }
        public static object ObtenerDetalleSignosVitales(Nullable<int> codigoOrdenIntervencion)
        {
            using (var db = new EFData.PETCENTEREntities1())
            {
                var result = db.USP_OBTENERDETALLESIGNOSVITALES(codigoOrdenIntervencion).ToList();
                return result;
            }
        }
        public static object ObtenerEpicrisis(Nullable<int> codigo)
        {
            using (var db = new EFData.PETCENTEREntities1())
            {
                var result = db.USP_OBTENEREPICRISIS(codigo).ToList();

                return result;

            }
        }

        public static object ObtenerDetalleEpicrisis(Nullable<int> codigo)
        {
            using (var db = new EFData.PETCENTEREntities1())
            {
                var result = db.USP_OBTENERDETALLEEPICRISIS(codigo).ToList();

                return result;

            }
        }
        public static object InsertarEpicrisis(Nullable<int> codigo, Nullable<int> codigoOrdenIntervencion, string areaHospitalaria, string servicio, string diasEstancia, Nullable<System.DateTime> fechaIngreso, Nullable<System.DateTime> fechaAlta, string veterinario, string tratamientoRecibido, string observaciones, Nullable<int> codigoEstado, string accion)
        {
            using (var db = new EFData.PETCENTEREntities1())
            {
                ObjectParameter output = new ObjectParameter("CodigoOut", typeof(Int32));
                var result = db.USP_INSERTAREPICRISIS(codigo, codigoOrdenIntervencion, areaHospitalaria, servicio, diasEstancia,fechaIngreso, fechaAlta,veterinario,tratamientoRecibido,observaciones,codigoEstado ,accion, output);

                return output.Value;

            }
        }
        public static object InsertarDetalleEpicrisis(Nullable<int> codigo, Nullable<int> codigoEpicrisis, Nullable<int> codigoTipoInsumo, string descripcion, string observaciones, string frecuencia, string dosis, string accion)
        {
            using (var db = new EFData.PETCENTEREntities1())
            {
                ObjectParameter output = new ObjectParameter("CodigoOut", typeof(Int32));
                var result = db.USP_INSERTARDETALLEEPICRISIS(codigo, codigoEpicrisis, codigoTipoInsumo, descripcion, observaciones, frecuencia, dosis, accion, output);

                return output.Value;

            }
        }
        

    }
}
