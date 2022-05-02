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

namespace SGVentas.ProductosMasVendidos
{
    /// <summary>
    /// Lógica de interacción para ProductosMVendidos.xaml
    /// </summary>
    public partial class ProductosMVendidos : Window
    {
        public string nombreEmpleado { get; set; }
        public DataTable reportes = new DataTable();
        public string codigoRepo;
        public ProductosMVendidos(string nombreUsuario="user")
        {
            InitializeComponent();
            lblFecha.Text = DateTime.Now.ToShortDateString();
            nombreEmpleado=nombreUsuario;
            lblUsuario.Text = nombreEmpleado;
        }

       

        private void btnGenerar_Click(object sender, RoutedEventArgs e)
        {
            if(dateInicial.SelectedDate.HasValue== false)
            {
                MessageBox.Show("Debe seleccionar una Fecha inicial", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dateFinal.SelectedDate.HasValue == false)
                {
                    MessageBox.Show("Debe seleccionar una Fecha final", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (dateInicial.SelectedDate.Value > dateFinal.SelectedDate.Value)
                    {
                        MessageBox.Show("Debe seleccionar una Fecha inicial anterior a la fecha final", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {

                        Clases.Reporte reporte = new Clases.Reporte();
                        reporte.codigo = GenerarCodigoS();
                        codigoRepo = reporte.codigo;
                        reporte.nombreEmpleado = nombreEmpleado;
                        reporte.fecha = DateTime.Now;
                        reporte.tipoReporte = "PMV";
                        reporte.fechaInicial = dateInicial.SelectedDate.Value;
                        reporte.fechaFinal = dateFinal.SelectedDate.Value;
                        ControlBDG control = new ControlBDG();
                        control.AgregarReporte(reporte);
                        ConsultarReporteAntiguo consultar = new ConsultarReporteAntiguo(nombreEmpleado, reporte.codigo);
                        consultar.ShowDialog();
                    }
                }
            }
            
            
           
        }
        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void CargarTabla()
        {
            ControlBDG control = new ControlBDG();
            reportes = control.ConsultarReportes("PMV");
            dataReportes.ItemsSource = reportes.DefaultView;
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
        private void dgDetalles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            DataRowView repor = dataReportes.SelectedItem as DataRowView;
            if (repor != null && grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
            {
                ConsultarReporteAntiguo detail = new ConsultarReporteAntiguo(repor.Row.ItemArray[2].ToString(), repor.Row.ItemArray[0].ToString());
                detail.ShowDialog();

            }
            else
            {
                MessageBox.Show("Debe seleccionar un reporte primero", "Seleccione un reporte", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }
    }
}
