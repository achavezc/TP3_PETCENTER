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
    
    public partial class Ficha_Hospitalizacion_Insumo
    {
        public int codigo_ficha { get; set; }
        public int codigoInsumo { get; set; }
        public int cantidad_insumo { get; set; }
        public string estado_insumo { get; set; }
    
        public virtual Ficha_Hospitalizacion Ficha_Hospitalizacion { get; set; }
        public virtual Insumo Insumo { get; set; }
    }
}
