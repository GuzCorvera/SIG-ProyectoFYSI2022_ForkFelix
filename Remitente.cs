using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGVentas
{
    class Remitente
    {
        internal string correo;
        internal string contrasena;

        public Remitente(string correo, string contrasena)
        {
            this.correo = correo;
            this.contrasena = contrasena;
        }

        public Remitente()
        {
        }
    }
}
