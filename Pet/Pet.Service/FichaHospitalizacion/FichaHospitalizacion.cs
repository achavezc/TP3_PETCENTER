using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Service.FichaHospitalizacion
{
    public class FichaHospitalizacion
    {
        public static object ConsultarFicha(Nullable<System.DateTime> fechaInicio, Nullable<System.DateTime> fechaFin, Nullable<int> codigo, string nombreCliente, string nombrePaciente, Nullable<int> codigoEstado)
        {
            return Pet.Data.EF5.Ficha.FichaHospitalizacion.ConsultarFicha(fechaInicio,fechaFin,codigo,nombreCliente,nombrePaciente,codigoEstado);
        }
        public static object ValidarFicha(Nullable<int> codigoCita)
        {
            return Pet.Data.EF5.Ficha.FichaHospitalizacion.ValidarFicha(codigoCita);
        }
        public static object ConsultarTipoInsumo(string enfermedad, Nullable<int> codigoTipoInsumo, string nombreInsumo, Nullable<int> cantidad)
        {

            return Pet.Data.EF5.Ficha.FichaHospitalizacion.ConsultarTipoInsumo(enfermedad, codigoTipoInsumo, nombreInsumo, cantidad);
        }
        public static object ObtenerInsumo(Nullable<int> codigoFicha)
        {

            return Pet.Data.EF5.Ficha.FichaHospitalizacion.ObtenerInsumo(codigoFicha);
        }
        public static object ObtenerDetalleFicha(Nullable<int> codigoFicha)
        {
                return Pet.Data.EF5.Ficha.FichaHospitalizacion.ObtenerDetalleFicha(codigoFicha);
        }
        public static object InsertarFicha(Nullable<int> codigo, Nullable<int> codigoEmpleado, Nullable<int> codigoCita, string comentario, Nullable<int> codigoEmpleadoMedico, Nullable<int> codigoEmpleadoTecnico, Nullable<int> codigoSala, Nullable<int> codigoCubiculo, Nullable<int> codigoEstado, string accion)
        {
                return Pet.Data.EF5.Ficha.FichaHospitalizacion.InsertarFicha(codigo, codigoEmpleado, codigoCita, comentario, codigoEmpleadoMedico, codigoEmpleadoTecnico, codigoSala, codigoCubiculo, codigoEstado, accion);
        }
        public static object InsertarInsumo(Nullable<int> codigoFicha, Nullable<int> codigoInsumo, Nullable<int> cantidadInsumo, string estadoInsumo, string accion)
        {
            return Pet.Data.EF5.Ficha.FichaHospitalizacion.InsertarInsumo(codigoFicha, codigoInsumo, cantidadInsumo, estadoInsumo, accion);
        }
        public static object BuscarCita(Nullable<int> codigoCita)
        {

            return Pet.Data.EF5.Ficha.FichaHospitalizacion.BuscarCita(codigoCita);
        }
    }
}
