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
    
    public partial class GCP_Mascota
    {
        public GCP_Mascota()
        {
            this.Citas = new HashSet<Cita>();
            this.GPA_Solicitud_Cruces = new HashSet<GPA_Solicitud_Cruces>();
            this.GPA_Solicitud_Cruces1 = new HashSet<GPA_Solicitud_Cruces>();
            this.GPA_Solicitud_Pedigri = new HashSet<GPA_Solicitud_Pedigri>();
            this.GPA_Solicitud_Pedigri1 = new HashSet<GPA_Solicitud_Pedigri>();
            this.GPA_Solicitud_Adopcion = new HashSet<GPA_Solicitud_Adopcion>();
        }
    
        public int codigo_mascota { get; set; }
        public Nullable<int> codigo_cliente { get; set; }
        public Nullable<int> codigo_especie { get; set; }
        public Nullable<int> codigo_raza { get; set; }
        public string nombreMascota { get; set; }
        public string genero { get; set; }
        public Nullable<System.DateTime> fechaNacimiento { get; set; }
        public string tamano { get; set; }
    
        public virtual ICollection<Cita> Citas { get; set; }
        public virtual GCP_Cliente GCP_Cliente { get; set; }
        public virtual GCP_Cliente GCP_Cliente1 { get; set; }
        public virtual GCP_Especie GCP_Especie { get; set; }
        public virtual GCP_Raza GCP_Raza { get; set; }
        public virtual ICollection<GPA_Solicitud_Cruces> GPA_Solicitud_Cruces { get; set; }
        public virtual ICollection<GPA_Solicitud_Cruces> GPA_Solicitud_Cruces1 { get; set; }
        public virtual ICollection<GPA_Solicitud_Pedigri> GPA_Solicitud_Pedigri { get; set; }
        public virtual ICollection<GPA_Solicitud_Pedigri> GPA_Solicitud_Pedigri1 { get; set; }
        public virtual ICollection<GPA_Solicitud_Adopcion> GPA_Solicitud_Adopcion { get; set; }
        public virtual GCP_Raza GCP_Raza1 { get; set; }
    }
}
