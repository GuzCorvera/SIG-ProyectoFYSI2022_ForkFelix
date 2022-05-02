using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SGVentas.GestionUsuarios
{
    partial class AccionBitacora
    {
        public string codigo { get; set; }
        public string nombreEmpleado { get; set; }
        public string accion { get; set; }
        public DateTime fechaActual { get; set; }

        public AccionBitacora(string codigo, string nombreEmpledo, string accion, DateTime fecha  )
        {
            this.codigo = codigo;
            this.nombreEmpleado= nombreEmpledo;
            this.accion = accion;
            this.fechaActual= fecha;
        }
        //registra la accion en la BD solo se tiene que llamar la funcion y pasar los paramentros
        public void RegistrarAcccion(string nombreEmpledo, string accion, DateTime fecha)
        {
            string codigo = GenerarCodigoS();
            AccionBitacora accion1 = new AccionBitacora(codigo, nombreEmpledo, accion, fecha);
            ControlBDG control = new ControlBDG();
            string resulado=control.AgregarAccionABitacora(accion1);
            if (resulado != "1")
            {
                MessageBox.Show(resulado,"",MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        public string GenerarCodigoS()
        {
            DateTime fecha = DateTime.Now;
            string anio = fecha.Year.ToString();
            string mes = fecha.Month.ToString();
            string dia = fecha.Day.ToString();
            string hora = fecha.Hour.ToString();
            string min = fecha.Minute.ToString();
            string seg = fecha.Second.ToString();

            return dia + mes + anio + hora + min + seg;


        }



    }
}
