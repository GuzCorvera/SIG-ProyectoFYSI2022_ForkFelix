using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGVentas.GestionMateriales;
using SGVentas.GestionUsuarios;

namespace SGVentas.CotizacionRecibo
{
    class SolicitudRecibo
    {
        public string codigo { get; set; }//yep
        //public string codigoReq { get; set; }
        //public string codigoCliente { get; set; }
        //public GestionUsuarios.Usuario solicitante { get; set; }
        public string fechaSolicitudRecibo { get; set; }//yep
        public string nombreCliente { get; set; }//yep
        public float totalRecibo { get; set; }//yep
        public List<DetalleRecibo> detalles { get; set; }
        //public string estado { get; set; }
        GestionUsuarios.Usuario autorizador { get; set; }

        public SolicitudRecibo()
        {
        }

        //public SolicitudRecibo(string codigo, Usuario solicitante, Usuario autorizador, string fechaSolicitud, List<DetalleRecibo> detalleSolicitud)
        public SolicitudRecibo(string codigo, string fechaSolicitudRecibo, string nombreCliente, float totalRecibo, List<DetalleRecibo> detalleSolicitudRecibo)
        {
            this.codigo = codigo;
            this.fechaSolicitudRecibo = fechaSolicitudRecibo;
            this.nombreCliente = nombreCliente;
            this.totalRecibo = totalRecibo;
            this.detalles = detalleSolicitudRecibo;
            this.autorizador = autorizador;
        }
        public void setListDetalles(List<DetalleRecibo> d)
        {
            this.detalles = d;
        }
    }
}
