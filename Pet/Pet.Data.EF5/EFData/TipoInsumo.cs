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
    
    public partial class TipoInsumo
    {
        public TipoInsumo()
        {
            this.EpicrisisDetalles = new HashSet<EpicrisisDetalle>();
            this.Insumoes = new HashSet<Insumo>();
        }
    
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public Nullable<bool> EstadoRegistro { get; set; }
    
        public virtual ICollection<EpicrisisDetalle> EpicrisisDetalles { get; set; }
        public virtual ICollection<Insumo> Insumoes { get; set; }
    }
}
