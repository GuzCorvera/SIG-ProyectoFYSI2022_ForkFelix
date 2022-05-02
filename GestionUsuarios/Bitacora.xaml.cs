using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SGVentas.GestionUsuarios
{
    /// <summary>
    /// Lógica de interacción para Bitacora.xaml
    /// </summary>
    public partial class AccionBitacora : Window
    {
        DataTable acciones= new DataTable();
        public AccionBitacora()
        {
            InitializeComponent();
            LlenarTabla();
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LlenarTabla()
        {
            ControlBDG control =  new ControlBDG();
            acciones = control.ConsultarAcciones();
            dataAcciones.ItemsSource = acciones.DefaultView;
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            GenerarImpresion();
            

        }

        private void btnExportar_Click(object sender, RoutedEventArgs e)
        {

        }


        private void GenerarImpresion()
        {
            string fecha= DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            // Adecuar cabeceras de tablas.
            DataTable aImprimir = new DataTable();
            aImprimir.Columns.Add("Código de Acción");
            aImprimir.Columns.Add("Empleado");
            aImprimir.Columns.Add("Acción Realizada");
            aImprimir.Columns.Add("Fecha");
            string[] descripcion = new string[4];
            for (int i = 0; i < acciones.Rows.Count; i++)
            {
                descripcion[0] = acciones.Rows[i][0].ToString();
                descripcion[1] = acciones.Rows[i][1].ToString();
                descripcion[2] = acciones.Rows[i][2].ToString();
                descripcion[3] = acciones.Rows[i][3].ToString();
                // Agregando detalle a la tabla de la impresión.
                aImprimir.Rows.Add(new Object[] { descripcion[0], descripcion[1], descripcion[2], descripcion[3] });
            }
            CreadorPDF impresion = new CreadorPDF();
            impresion.ImprimirBitacora(aImprimir, "admin", fecha, 1 );
            //MessageBox.Show("Se ha generado el archivo de la solicitud.", "Generación de solicitud", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
