using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGVentas.GestionMateriales;
using SGVentas.GestionUsuarios;

namespace SGVentas.SolicitarInsumos
{
    class SolicitudInsumos
    {
        public string codigo { get; set; }
        public string codigoReq { get; set; }
        public string codigoCliente { get; set; }
        public Usuario solicitante { get; set; }
        public string fechaSolicitud { get; set; }
        public List<DetalleSolicitudInsumos> detalles { get; set; }
        public string estado { get; set; }
        public Usuario autorizador { get; set; }

        public SolicitudInsumos()
        {
        }

        public SolicitudInsumos(string codigo, Usuario solicitante, Usuario autorizador, string fechaSolicitud, List<DetalleSolicitudInsumos> detalleSolicitud)
        {
            this.codigo = codigo;
            this.solicitante = solicitante;
            this.fechaSolicitud = fechaSolicitud;
            this.detalles = detalleSolicitud;
            this.autorizador = autorizador;
        }
        public void setListDetalles(List<DetalleSolicitudInsumos> d)
        {
            this.detalles = d;
        }
        public SolicitudInsumos(string codigo, Usuario solicitante, Usuario autorizador, string fechaSolicitud, string codigoR)
        {
            this.codigo = codigo;
            this.solicitante = solicitante;
            this.fechaSolicitud = fechaSolicitud;
            this.autorizador = autorizador;
            this.codigoReq = codigoR;
        }
    }
}
