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
    
    public partial class OrdenIntervencionDetalleProfesional
    {
        public int Codigo { get; set; }
        public Nullable<int> CodigoOrdenIntervencion { get; set; }
        public Nullable<int> CodigoProfesional { get; set; }
        public Nullable<bool> EstadoRegistro { get; set; }
    
        public virtual OrdenIntervencion OrdenIntervencion { get; set; }
        public virtual Profesional Profesional { get; set; }
    }
}