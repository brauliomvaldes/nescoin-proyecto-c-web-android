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
    
    public partial class Tbl_Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Usuario()
        {
            this.Tbl_Log = new HashSet<Tbl_Log>();
            this.Tbl_movimiento = new HashSet<Tbl_movimiento>();
            this.Tbl_Usuario_Correo = new HashSet<Tbl_Usuario_Correo>();
            this.Tbl_Usuario_Profesion = new HashSet<Tbl_Usuario_Profesion>();
            this.Tbl_Usuario_Telefono = new HashSet<Tbl_Usuario_Telefono>();
            this.Tbl_Contacto = new HashSet<Tbl_Contacto>();
        }
    
        public decimal id_usuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }
        public Nullable<System.DateTime> fecha_actualizacion { get; set; }
        public string contraseña { get; set; }
        public decimal id_direccion { get; set; }
        public Nullable<decimal> id_tipo_cuenta { get; set; }
        public Nullable<bool> estado { get; set; }
        public string foto { get; set; }
        public string nick { get; set; }
    
        public virtual Tbl_Direccion Tbl_Direccion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Log> Tbl_Log { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_movimiento> Tbl_movimiento { get; set; }
        public virtual Tbl_Tipo_Cuenta Tbl_Tipo_Cuenta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Usuario_Correo> Tbl_Usuario_Correo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Usuario_Profesion> Tbl_Usuario_Profesion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Usuario_Telefono> Tbl_Usuario_Telefono { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Contacto> Tbl_Contacto { get; set; }
    }
}