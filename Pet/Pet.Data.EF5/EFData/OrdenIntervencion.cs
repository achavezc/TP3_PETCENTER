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
    
    public partial class OrdenIntervencion
    {
        public OrdenIntervencion()
        {
            this.Epicrisis = new HashSet<Epicrisi>();
            this.OrdenIntervencionDetalleOperacions = new HashSet<OrdenIntervencionDetalleOperacion>();
            this.OrdenIntervencionDetalleAnastesias = new HashSet<OrdenIntervencionDetalleAnastesia>();
            this.OrdenIntervencionDetalleDiagnosticoes = new HashSet<OrdenIntervencionDetalleDiagnostico>();
            this.OrdenIntervencionDetalleSignosVitales = new HashSet<OrdenIntervencionDetalleSignosVitale>();
            this.OrdenIntervencionDetalleProfesionals = new HashSet<OrdenIntervencionDetalleProfesional>();
            this.OrdenIntervencionDetalleOperacions1 = new HashSet<OrdenIntervencionDetalleOperacion>();
        }
    
        public int Codigo { get; set; }
        public int codigo_ficha { get; set; }
        public Nullable<int> CodigoDiagnosticoPreventivo { get; set; }
        public Nullable<int> CodigoDiagnosticoPresuntivo { get; set; }
        public string Observaciones { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
        public Nullable<System.DateTime> FechaIntervencion { get; set; }
        public Nullable<int> CodigoEstado { get; set; }
        public Nullable<bool> EstadoRegistro { get; set; }
    
        public virtual Diagnostico Diagnostico { get; set; }
        public virtual Diagnostico Diagnostico1 { get; set; }
        public virtual ICollection<Epicrisi> Epicrisis { get; set; }
        public virtual Ficha_Hospitalizacion Ficha_Hospitalizacion { get; set; }
        public virtual ICollection<OrdenIntervencionDetalleOperacion> OrdenIntervencionDetalleOperacions { get; set; }
        public virtual ICollection<OrdenIntervencionDetalleAnastesia> OrdenIntervencionDetalleAnastesias { get; set; }
        public virtual ICollection<OrdenIntervencionDetalleDiagnostico> OrdenIntervencionDetalleDiagnosticoes { get; set; }
        public virtual ICollection<OrdenIntervencionDetalleSignosVitale> OrdenIntervencionDetalleSignosVitales { get; set; }
        public virtual ICollection<OrdenIntervencionDetalleProfesional> OrdenIntervencionDetalleProfesionals { get; set; }
        public virtual ICollection<OrdenIntervencionDetalleOperacion> OrdenIntervencionDetalleOperacions1 { get; set; }
    }
}
