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
    
    public partial class Insumo
    {
        public Insumo()
        {
            this.Ficha_Hospitalizacion_Insumo = new HashSet<Ficha_Hospitalizacion_Insumo>();
            this.InsumoRequeridoDetalles = new HashSet<InsumoRequeridoDetalle>();
        }
    
        public int CodigoInsumo { get; set; }
        public string DescripcionInsumo { get; set; }
        public int CodigoTipoInsumo { get; set; }
        public Nullable<int> StockActual { get; set; }
        public Nullable<bool> EstadoRegistro { get; set; }
    
        public virtual ICollection<Ficha_Hospitalizacion_Insumo> Ficha_Hospitalizacion_Insumo { get; set; }
        public virtual ICollection<InsumoRequeridoDetalle> InsumoRequeridoDetalles { get; set; }
    }
}
