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
    
    public partial class enfermedad_insumo
    {
        public int Codigo_Enfermedad { get; set; }
        public int CodigoInsumo { get; set; }
        public Nullable<bool> EstadoRegistro { get; set; }
    
        public virtual ENFERMEDAD ENFERMEDAD { get; set; }
        public virtual Insumo Insumo { get; set; }
    }
}
