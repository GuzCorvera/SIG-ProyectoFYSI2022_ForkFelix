using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGVentas.GestionMateriales;

namespace SGVentas.SolicitarInsumos
{
    class DetalleSolicitudInsumos
    {
        public string codigo { get; set; }
        public string codigoSolicitud { get; set; }
        public GestionMateriales.Material material { get; set; }
        public float cantidad { get; set; }

        public DetalleSolicitudInsumos(string codigo, string codigoSolicitud, Material material, float cantidad)
        {
            this.codigo = codigo;
            this.codigoSolicitud = codigoSolicitud;
            this.material = material;
            this.cantidad = cantidad;
        }

        public DetalleSolicitudInsumos()
        {
        }
    }
}
