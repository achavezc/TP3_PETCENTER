using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects;

namespace Pet.Service.Epicrisis
{
    public class Epicrisis
    {
        public static object ConsultarEpicrisis(Nullable<System.DateTime> fechaIngresoInicio, Nullable<System.DateTime> fechaIngresoFin, Nullable<int> codigo, string nombre, Nullable<int> codigoEstado)
        {
            return Pet.Data.EF5.Epicrisis.Epicrisis.ConsultarEpicrisis(fechaIngresoInicio, fechaIngresoFin, codigo, nombre, codigoEstado);
        }
        public static object ConsultarOrdenIntervencion(Nullable<int> codigoIntervencion, Nullable<System.DateTime> fechaInicio, Nullable<System.DateTime> fechaFin, Nullable<int> codigo, string nombre)
        {
            return Pet.Data.EF5.Epicrisis.Epicrisis.ConsultarOrdenIntevencion(codigoIntervencion, fechaInicio, fechaFin, codigo, nombre);
        }
        public static object ObtenerDetalleOrdenIntervencion(Nullable<int> codigoOrdenIntervencion)
        {
            return Pet.Data.EF5.Epicrisis.Epicrisis.ObtenerDetalleOrdenIntervencion(codigoOrdenIntervencion);
        }
        public static object ObtenerDetalleAnastesia(Nullable<int> codigoOrdenIntervencion)
        {
            return Pet.Data.EF5.Epicrisis.Epicrisis.ObtenerDetalleAnastesia(codigoOrdenIntervencion);
        }
        public static object ObtenerDetalleOperacion(Nullable<int> codigoOrdenIntervencion)
        {
            return Pet.Data.EF5.Epicrisis.Epicrisis.ObtenerDetalleOperacion(codigoOrdenIntervencion);
        }
        public static object ObtenerDetalleDiagnostico(Nullable<int> codigoOrdenIntervencion)
        {
            return Pet.Data.EF5.Epicrisis.Epicrisis.ObtenerDetalleDiagnostico(codigoOrdenIntervencion);
        }
        public static object ObtenerDetalleProfesional(Nullable<int> codigoOrdenIntervencion)
        {
            return Pet.Data.EF5.Epicrisis.Epicrisis.ObtenerDetalleProfesional(codigoOrdenIntervencion);
        }
        public static object ObtenerDetalleSignosVitales(Nullable<int> codigoOrdenIntervencion)
        {
            return Pet.Data.EF5.Epicrisis.Epicrisis.ObtenerDetalleSignosVitales(codigoOrdenIntervencion);
        }
       
        public static object ObtenerEpicrisis(Nullable<int> codigo)
        {
            return Pet.Data.EF5.Epicrisis.Epicrisis.ObtenerEpicrisis(codigo);
        }
        public static object ObtenerDetalleEpicrisis(Nullable<int> codigo)
        {
            return Pet.Data.EF5.Epicrisis.Epicrisis.ObtenerDetalleEpicrisis(codigo);
        }

        public static object InsertarEpicrisis(Nullable<int> codigo, Nullable<int> codigoOrdenIntervencion, string areaHospitalaria, string servicio, string diasEstancia, Nullable<System.DateTime> fechaIngreso, Nullable<System.DateTime> fechaAlta, string veterinario, string tratamientoRecibido, string observaciones, Nullable<int> codigoEstado, string accion)
        {
            return Pet.Data.EF5.Epicrisis.Epicrisis.InsertarEpicrisis(codigo, codigoOrdenIntervencion, areaHospitalaria, servicio, diasEstancia, fechaIngreso, fechaAlta, veterinario, tratamientoRecibido, observaciones, codigoEstado, accion);
        }
        public static object InsertarDetalleEpicrisis(Nullable<int> codigo, Nullable<int> codigoEpicrisis, Nullable<int> codigoTipoInsumo, string descripcion, string observaciones, string frecuencia, string dosis, string accion)
        {
            return Pet.Data.EF5.Epicrisis.Epicrisis.InsertarDetalleEpicrisis(codigo, codigoEpicrisis, codigoTipoInsumo, descripcion, observaciones, frecuencia, dosis, accion);
        }
      
    }
}
