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
    
    public partial class GPA_Registro_Resultados_KCP
    {
        public GPA_Registro_Resultados_KCP()
        {
            this.GPA_Detalle_Resultados_KCP = new HashSet<GPA_Detalle_Resultados_KCP>();
        }
    
        public int numero_registro_resultado_KCP { get; set; }
        public Nullable<int> numero_solicitud { get; set; }
        public Nullable<System.DateTime> fechaRegistroKCP { get; set; }
        public Nullable<short> numMascotas { get; set; }
        public Nullable<int> numRegistroKCPPadre { get; set; }
        public Nullable<int> numRegistroKCPMadre { get; set; }
    
        public virtual ICollection<GPA_Detalle_Resultados_KCP> GPA_Detalle_Resultados_KCP { get; set; }
        public virtual GPA_Solicitud GPA_Solicitud { get; set; }
    }
}
