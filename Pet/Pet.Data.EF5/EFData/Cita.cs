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
    using System.Collections.Generic;
    
    public partial class Cita
    {
        public Cita()
        {
            this.Ficha_Hospitalizacion = new HashSet<Ficha_Hospitalizacion>();
        }
    
        public int codigo_cita { get; set; }
        public Nullable<int> codigo_mascota { get; set; }
        public Nullable<int> codigo_cliente { get; set; }
        public Nullable<System.DateTime> fecha_cita { get; set; }
        public Nullable<int> CodigoDiagnostico { get; set; }
        public string atencion { get; set; }
        public string servicio { get; set; }
    
        public virtual GCP_Cliente GCP_Cliente { get; set; }
        public virtual Diagnostico Diagnostico { get; set; }
        public virtual GCP_Mascota GCP_Mascota { get; set; }
        public virtual ICollection<Ficha_Hospitalizacion> Ficha_Hospitalizacion { get; set; }
    }
}
