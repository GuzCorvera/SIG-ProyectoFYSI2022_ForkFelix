using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGVentas.GestionMateriales;

namespace SGVentas.CotizacionRecibo
{
    class DetalleRecibo
    {
        public string codigo { get; set; }
        public string codigoRecibo { get; set; }
        //public string codigoSolicitud { get; set; }
        public GestionMateriales.Material material { get; set; }
        public float cantidad { get; set; }
        public string nombre { get; set; }
        public float subtotal { get; set; }
        public float precio { get; set; }

        public DetalleRecibo(string codigo, string codigoRecibo, Material material, float cantidad, string nombre, float subtotal, float precio)
        {
            this.codigo = codigo;
            this.codigoRecibo = codigoRecibo;
            this.material = material;
            this.cantidad = cantidad;
            this.nombre = nombre;
            this.subtotal = subtotal;
            this.precio = precio;
        }

        public DetalleRecibo()
        {
        }
    }
}
