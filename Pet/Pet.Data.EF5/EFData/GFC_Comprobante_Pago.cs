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
    
    public partial class GFC_Comprobante_Pago
    {
        public int comprobante_pago { get; set; }
        public Nullable<int> codigo_cliente { get; set; }
        public Nullable<int> nroComprobante { get; set; }
        public string descripcionItem { get; set; }
        public Nullable<System.DateTime> fechaComprobante { get; set; }
        public Nullable<decimal> montoTotal { get; set; }
        public Nullable<decimal> igv { get; set; }
    
        public virtual GCP_Cliente GCP_Cliente { get; set; }
    }
}