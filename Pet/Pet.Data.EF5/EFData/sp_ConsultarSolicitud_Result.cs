//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pet.Data.EF5.EFData
{
    using System;
    
    public partial class sp_ConsultarSolicitud_Result
    {
        public int numero_solicitud { get; set; }
        public Nullable<System.DateTime> fechaSolicitud { get; set; }
        public string tipoSolicitud { get; set; }
        public string estadoSolicitud { get; set; }
        public string comentarios { get; set; }
        public int codigo_cliente { get; set; }
        public string Mascota_Padre { get; set; }
        public string Mascota_Madre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string nombres { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public int codigo_persona { get; set; }
        public string descrDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public string emailCliente { get; set; }
        public Nullable<bool> autorizaUsoDatos { get; set; }
    }
}
