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
    
    public partial class sala
    {
        public sala()
        {
            this.Ficha_Hospitalizacion = new HashSet<Ficha_Hospitalizacion>();
            this.sala_cubiculo = new HashSet<sala_cubiculo>();
        }
    
        public int codigo_sala { get; set; }
        public string nombre_sala { get; set; }
        public string observacion_sala { get; set; }
        public int Codigo_Tipo_Sala { get; set; }
        public bool estado_sala { get; set; }
    
        public virtual ICollection<Ficha_Hospitalizacion> Ficha_Hospitalizacion { get; set; }
        public virtual tipo_sala tipo_sala { get; set; }
        public virtual ICollection<sala_cubiculo> sala_cubiculo { get; set; }
    }
}
