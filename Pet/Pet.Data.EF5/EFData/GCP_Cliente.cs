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
    
    public partial class GCP_Cliente
    {
        public GCP_Cliente()
        {
            this.Citas = new HashSet<Cita>();
            this.GAM_Informe_Medico = new HashSet<GAM_Informe_Medico>();
            this.GCP_Mascota = new HashSet<GCP_Mascota>();
            this.GFC_Comprobante_Pago = new HashSet<GFC_Comprobante_Pago>();
            this.GPA_Solicitud_Cruces = new HashSet<GPA_Solicitud_Cruces>();
            this.GPA_Solicitud_Cruces1 = new HashSet<GPA_Solicitud_Cruces>();
            this.GPA_Solicitud = new HashSet<GPA_Solicitud>();
            this.GCP_Mascota1 = new HashSet<GCP_Mascota>();
        }
    
        public int codigo_cliente { get; set; }
        public Nullable<int> codigo_persona { get; set; }
        public string emailCliente { get; set; }
        public Nullable<bool> autorizaUsoDatos { get; set; }
    
        public virtual ICollection<Cita> Citas { get; set; }
        public virtual ICollection<GAM_Informe_Medico> GAM_Informe_Medico { get; set; }
        public virtual GG_Persona GG_Persona { get; set; }
        public virtual ICollection<GCP_Mascota> GCP_Mascota { get; set; }
        public virtual ICollection<GFC_Comprobante_Pago> GFC_Comprobante_Pago { get; set; }
        public virtual ICollection<GPA_Solicitud_Cruces> GPA_Solicitud_Cruces { get; set; }
        public virtual ICollection<GPA_Solicitud_Cruces> GPA_Solicitud_Cruces1 { get; set; }
        public virtual ICollection<GPA_Solicitud> GPA_Solicitud { get; set; }
        public virtual ICollection<GCP_Mascota> GCP_Mascota1 { get; set; }
    }
}