using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGVentas.GestionUsuarios
{
    class TipoUsuario
    {
        public string codTipoUsuario { get; set; }
        public string nombreTipoUsuario { get; set; }

        public TipoUsuario(string codTipoUsuario, string nombreTipoUsuario)
        {
            this.codTipoUsuario = codTipoUsuario;
            this.nombreTipoUsuario = nombreTipoUsuario;
        }

        public TipoUsuario() { }
    }
}
