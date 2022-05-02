using System;
using System.Collections.Generic;
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
        public ConsultarReporteAntiguo(string nombre, string codigoRepo)
        {
            InitializeComponent();
            nombreEmpleado = nombre;
            codReporte = codigoRepo;
            
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
