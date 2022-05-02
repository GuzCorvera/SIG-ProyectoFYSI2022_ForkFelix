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
    /// Lógica de interacción para ConsultarReporteAntiguo.xaml
    /// </summary>
    public partial class ConsultarReporteAntiguo : Window
    {
        public string nombreEmpleado { get; set; }
        public string codReporte { get; set; }
        public DateTime fechaInicial { get; set; }
        public DateTime fechaFinal { get; set; }

        DataTable detalles = new DataTable(); 
        List<Clases.ProdMasVendido> dt = new List<Clases.ProdMasVendido>();
        
        public ConsultarReporteAntiguo(string nombre, string codigoRepo, DateTime fechaIni, DateTime fechaFini)
        {
            InitializeComponent();
            nombreEmpleado = nombre;
            codReporte = codigoRepo;
            fechaFinal = fechaFini;
            fechaInicial= fechaIni;
            lblFecha.Text = "Fecha: " + DateTime.Now.ToShortDateString();
            lblFechaInicial.Text = "Fecha Inicial: " + fechaInicial.ToShortDateString();
            lblFechaFinal.Text = "Fecha Final: " + fechaFinal.ToShortDateString();
            CargarTablaYaGenerado();
        }
        public ConsultarReporteAntiguo(string nombre, string codigoRepo, DateTime fechaIni, DateTime fechaFini, string nuevo)
        {
            InitializeComponent();
            nombreEmpleado = nombre;
            codReporte = codigoRepo;
            fechaFinal = fechaFini;
            fechaInicial = fechaIni;
            lblFecha.Text = "Fecha: " + DateTime.Now.ToShortDateString();
            lblFechaInicial.Text = "Fecha Inicial: " + fechaInicial.ToShortDateString();
            lblFechaFinal.Text = "Fecha Final: " + fechaFinal.ToShortDateString();
            CargarTablaNuevoReporte();

        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {

        }

        public void CargarTablaYaGenerado()
        {
            ControlBDG control = new ControlBDG();
            dt = control.ConsultarDetallesReportePMV(codReporte);
            dataReporte.ItemsSource = dt;

        }
        public void CargarTablaNuevoReporte()
        {
            ControlBD control = new ControlBD();
            ControlBDG controlBDG = new ControlBDG();
            string inicio = fechaInicial.Year.ToString() + fechaInicial.Month.ToString() + fechaInicial.Day.ToString();
            string final = fechaFinal.Year.ToString() + fechaFinal.Month.ToString() + fechaFinal.Day.ToString();
            
            dt= control.GenerarReporteProductosMVendidos(inicio, final);
            dataReporte.ItemsSource = dt;
            controlBDG.AgregarReportePMV(dt);

           /* ControlBDG control = new ControlBDG();
            detalles = control.ConsultarDetallesReportePMV(codReporte);
            dataReporte.ItemsSource = detalles.DefaultView;*/

        }
    }
}
