using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGVentas.GestionUsuarios
{
    class Usuario
    {
        internal string codigo { get; set; }
        internal string codigoEmpleado { get; set; }
        internal string correoElectronico { get; set; }
        internal string empleado { get; set; }
        internal TipoUsuario tipoUsuario { get; set; }
        internal string estado { get; set; }

        public string codigoE { get; set; }      
        public string nombre { get; set; }
        public Usuario()
        {
        }

        public Usuario(string codigoEmpleado, string empleado)
        {
            this.codigoE = codigoEmpleado;
            this.nombre = empleado;
        }
    }
}
