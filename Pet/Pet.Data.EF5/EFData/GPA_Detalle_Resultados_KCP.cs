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
    
    public partial class GPA_Detalle_Resultados_KCP
    {
        public int detalle_resultados_KCP { get; set; }
        public Nullable<int> numero_registro_resultado_KCP { get; set; }
        public string numRegistroKCP { get; set; }
        public string descResultado { get; set; }
    
        public virtual GPA_Registro_Resultados_KCP GPA_Registro_Resultados_KCP { get; set; }
    }
}