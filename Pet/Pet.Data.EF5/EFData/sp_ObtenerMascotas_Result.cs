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
    
    public partial class sp_ObtenerMascotas_Result
    {
        public int codigo_mascota { get; set; }
        public string nombreMascota { get; set; }
        public string codigo_genero { get; set; }
        public string genero { get; set; }
        public Nullable<System.DateTime> fechaNacimiento { get; set; }
        public string tamano { get; set; }
        public string descripcionEspecie { get; set; }
        public string nombreRaza { get; set; }
        public Nullable<int> EdadMeses { get; set; }
        public Nullable<int> EdadDias { get; set; }
    }
}
