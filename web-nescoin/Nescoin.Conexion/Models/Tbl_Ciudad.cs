//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nescoin.Conexion.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Ciudad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Ciudad()
        {
            this.Tbl_Comuna = new HashSet<Tbl_Comuna>();
        }
    
        public decimal id_ciudad { get; set; }
        public string descripcion { get; set; }
        public Nullable<decimal> id_pais { get; set; }
        public bool estado { get; set; }
    
        public virtual Tbl_Pais Tbl_Pais { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Comuna> Tbl_Comuna { get; set; }
    }
}
