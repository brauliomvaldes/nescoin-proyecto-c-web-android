using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nescoin.Cliente.Controllers
{
    public class RetornaUsuario_API
    {

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
    }
}