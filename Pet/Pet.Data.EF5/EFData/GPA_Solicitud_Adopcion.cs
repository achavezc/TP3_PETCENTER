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
    
    public partial class GPA_Solicitud_Adopcion
    {
        public int solicitud_adopcion { get; set; }
        public Nullable<int> numero_solicitud { get; set; }
        public Nullable<bool> domicilioLocal { get; set; }
        public Nullable<int> codigo_mascota { get; set; }
    
        public virtual GCP_Mascota GCP_Mascota { get; set; }
        public virtual GPA_Solicitud GPA_Solicitud { get; set; }
    }
}
