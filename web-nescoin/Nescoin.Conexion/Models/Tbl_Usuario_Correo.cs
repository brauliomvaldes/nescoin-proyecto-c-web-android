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
    
    public partial class Tbl_Usuario_Correo
    {
        public decimal id_usuario { get; set; }
        public decimal id_correo { get; set; }
        public Nullable<bool> estado { get; set; }
        public Nullable<bool> principal { get; set; }
    
        public virtual Tbl_Correo Tbl_Correo { get; set; }
        public virtual Tbl_Usuario Tbl_Usuario { get; set; }
    }
}
