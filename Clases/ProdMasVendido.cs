using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGVentas.Clases
{
    class ProdMasVendido
    {
        public string codigo { get; set; }
        public string codigoReporte { get; set; }
        public string nombreProducto { get; set; }
        public float cantidadProducto { get; set; }
        public ProdMasVendido(string cod, string codRep, string nombrePro, float cant)
        {
            codigo = cod;
            codigoReporte = codRep;
            nombreProducto = nombrePro;
            cantidadProducto = cant;
        }
        public ProdMasVendido( string nombrePro, float cant)
        {
            
            nombreProducto = nombrePro;
            cantidadProducto = cant;
        }

    }
    
}
