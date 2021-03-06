//Las referencias comentadas están deprecadas y no se recomiendan usar
//using iTextSharp.text;
//using iTextSharp.text.pdf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace SGVentas
{
    class CreadorPDF
    {
        
        List<FlowDocument> paginas = new List<FlowDocument>();
        //Document document = new Document();
        // FlowDocument todo = new FlowDocument();
        // IEnumerable<FlowDocument> lista;
        public static FlowDocument prueba = new FlowDocument();

        public CreadorPDF(DataTable dataTable, string tipoReporte)
        {
            // CrearPDF(dataTable, tipoReporte);
        }

        public CreadorPDF()
        {
            
        }

        /*
        public void CrearPDF(DataTable dataTable, string tipoReporte)
        {  
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo Pdf |*.pdf";
            if (sfd.ShowDialog() == true)
            {


                FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                Document document = new Document();
                document.SetPageSize(iTextSharp.text.PageSize.LETTER);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();

                //Cabecera del reporte
                BaseFont baseFontHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font fontHead = new iTextSharp.text.Font(baseFontHead, 18, 1, BaseColor.BLACK);
                iTextSharp.text.Paragraph empresa = new iTextSharp.text.Paragraph();
                empresa.Alignment = Element.ALIGN_CENTER;
                empresa.Add(new Chunk("Fuego y Seguridad Industrial", fontHead));
                document.Add(empresa);

                //Datos generales del reporte
                BaseFont baseFontData = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font fontHeadData = new iTextSharp.text.Font(baseFontHead, 14, 1, BaseColor.BLACK);
                iTextSharp.text.Paragraph datos = new iTextSharp.text.Paragraph();
                datos.Alignment = Element.ALIGN_CENTER;
                datos.Add(new Chunk("\nReporte de " + tipoReporte, fontHeadData));
                datos.Add(new Chunk("\nFecha: " + DateTime.Now.ToShortDateString(), fontHeadData));
                document.Add(datos);
                document.Add(new Chunk("\n", fontHead));//inserta un salto de linea antes de imprimir tabla

                PdfPTable table = new PdfPTable(dataTable.Columns.Count);
                BaseFont baseFontColumns = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font fontColumns = new iTextSharp.text.Font(baseFontColumns, 10, 1, BaseColor.BLACK);
                //agregando la cabecera de la tabla
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    PdfPCell cell = new PdfPCell();

                    cell.AddElement(new Chunk(dataTable.Columns[i].ColumnName, fontColumns));
                    table.AddCell(cell);
                }
                //agregando la información de la tabla al documento

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {

                        table.AddCell(dataTable.Rows[i][j].ToString());
                    }

                }
                document.Add(table);
                document.Close();
                writer.Close();
                fs.Close();
            }
            // MessageBox.Show("Reporte creado en: " + direccion, "Resultado de la creacion del reporte", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        */

        // Crea una impresión de una solicitud de extracción.
        // AUTOR: Félix Eduardo Henríquez Cruz
        public void PrepararImpresionSolicitud(DataTable dataTable, string nombreSolicitante, string autorizador, string cliente, string empresaR, string codigoSolicitud, string numeroOrden, string fecha)
        {
            // Preparando impresión por medio de FlowDocument
            FlowDocument fd = new FlowDocument();

            Table tableEmpresa = new Table();
            fd.Blocks.Add(tableEmpresa);
            tableEmpresa.Background = System.Windows.Media.Brushes.White;
            tableEmpresa.Columns.Add(new TableColumn());
            tableEmpresa.RowGroups.Add(new TableRowGroup());
            tableEmpresa.RowGroups[0].Rows.Add(new TableRow());
            TableRow emp = tableEmpresa.RowGroups[0].Rows[0];
            // Agregando logo de la empresa
            BitmapImage bmp = new BitmapImage(new Uri("/Images/fysi.jpg", UriKind.Relative));
            System.Windows.Controls.Image logo = new System.Windows.Controls.Image { Source = bmp };
            logo.Width = 160;
            logo.Height = 98;
            emp.Cells.Add(new TableCell(new BlockUIContainer(logo)));
            // Agregando nombre de la empresa
            System.Windows.Documents.Paragraph p = new System.Windows.Documents.Paragraph(new Run("\nFuego y Seguridad Industrial\n"));
            p.Inlines.Add(new Run("Solicitud de Extracción"));
            p.FontSize = 20;
            emp.Cells.Add(new TableCell(p));

            // Construcción de tabla de cabecera
            Table tableCabecera = new Table();
            fd.Blocks.Add(tableCabecera);
            tableCabecera.Background = System.Windows.Media.Brushes.White;
            for (int i = 0; i < 2; i++)
            {
                tableCabecera.Columns.Add(new TableColumn());
            }
            // Información de orden
            tableCabecera.RowGroups.Add(new TableRowGroup());
            tableCabecera.RowGroups[0].Rows.Add(new TableRow());
            TableRow actual = tableCabecera.RowGroups[0].Rows[0];
            actual.FontSize = 14;
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("Fecha de ingreso: " + fecha))));
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("Orden #" + numeroOrden))));
            // Información de cliente y razón social
            tableCabecera.RowGroups[0].Rows.Add(new TableRow());
            actual = tableCabecera.RowGroups[0].Rows[1];
            actual.FontSize = 14;
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("Representante: " + cliente))));
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("Razón social: " + empresaR))));
            // Salto de línea
            p = new System.Windows.Documents.Paragraph(new Run("\n"));
            fd.Blocks.Add(p);

            // Tabla de detalles
            Table tableDetalles = new Table();
            fd.Blocks.Add(tableDetalles);
            tableDetalles.Background = System.Windows.Media.Brushes.White;
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                tableDetalles.Columns.Add(new TableColumn());
            }
            tableDetalles.RowGroups.Add(new TableRowGroup());
            // Creación de encabezado
            tableDetalles.RowGroups[0].Rows.Add(new TableRow());
            actual = tableDetalles.RowGroups[0].Rows[0];
            actual.FontSize = 12;
            actual.FontWeight = FontWeights.Bold;
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run(dataTable.Columns[i].ColumnName))));
            }
            // Agregando información
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                tableDetalles.RowGroups[0].Rows.Add(new TableRow());
                actual = tableDetalles.RowGroups[0].Rows[i+1];
                actual.FontSize = 12;
                actual.FontWeight = FontWeights.Regular;
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run(dataTable.Rows[i][j].ToString()))));
                }
            }
            // Salto de línea
            p = new System.Windows.Documents.Paragraph(new Run("\n"));
            fd.Blocks.Add(p);

            // Tabla de firmas
            Table tableFirmas = new Table();
            fd.Blocks.Add(tableFirmas);
            tableFirmas.Background = System.Windows.Media.Brushes.White;
            for (int i = 0; i < 2; i++)
            {
                tableFirmas.Columns.Add(new TableColumn());
            }
            tableFirmas.RowGroups.Add(new TableRowGroup());
            // Cabecera
            tableFirmas.RowGroups[0].Rows.Add(new TableRow());
            actual = tableFirmas.RowGroups[0].Rows[0];
            actual.FontSize = 14;
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("Firma de solicitante"))));
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("Firma de autorizador"))));
            // Nombre de empleados
            tableFirmas.RowGroups[0].Rows.Add(new TableRow());
            actual = tableFirmas.RowGroups[0].Rows[1];
            actual.FontSize = 14;
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run(nombreSolicitante))));
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run(autorizador))));
            // Espacio de firmas
            tableFirmas.RowGroups[0].Rows.Add(new TableRow());
            actual = tableFirmas.RowGroups[0].Rows[2];
            actual.FontSize = 20;
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("________________"))));
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("________________"))));
            // Impresión del documento
            MemoryStream s = new System.IO.MemoryStream();
            string copyString = XamlWriter.Save(fd);
            FlowDocument copy = XamlReader.Parse(copyString) as FlowDocument;
            // Carga de diálogo de impresión y ajuste del documento al tamaño de impresión.
            PrintDialog printDialog = new PrintDialog();
            IDocumentPaginatorSource idpSrc = copy;
            copy.PageHeight = printDialog.PrintableAreaHeight;
            copy.PageWidth = printDialog.PrintableAreaWidth;
            copy.PagePadding = new Thickness(50);
            copy.ColumnGap = 0;
            copy.ColumnWidth = printDialog.PrintableAreaWidth;
            copy.Name = "Solicitud" + codigoSolicitud;
            if (printDialog.ShowDialog() ?? false)
            {
                // Llamar a PrintDocument para la ventana de impresión
                printDialog.PrintDocument(idpSrc.DocumentPaginator, "Impresión de solicitud");
            }
        }



        // Crea una impresión de una solicitud elegida desde el historial del cliente.
        // AUTOR: Gabriel 
        public void ImpresionSolicitud(DataTable dataTable, string cliente, string empresaR, string codigoSolicitud, string fecha, int paginasRestantes)
        {
            // Preparando impresión por medio de FlowDocument

       FlowDocument todo = new FlowDocument();
        Table tableEmpresa = new Table();
           // todo.MinPageHeight = 982.7;
            todo.PageHeight = 982.7;
            
            todo.Blocks.Add(tableEmpresa);
            tableEmpresa.Background = System.Windows.Media.Brushes.White;
            tableEmpresa.Columns.Add(new TableColumn());
            tableEmpresa.RowGroups.Add(new TableRowGroup());
            tableEmpresa.RowGroups[0].Rows.Add(new TableRow());
            TableRow emp = tableEmpresa.RowGroups[0].Rows[0];
            // Agregando logo de la empresa
            BitmapImage bmp = new BitmapImage(new Uri("/Images/fysi.jpg", UriKind.Relative));
            System.Windows.Controls.Image logo = new System.Windows.Controls.Image { Source = bmp };
            logo.Width = 160;
            logo.Height = 98;
            emp.Cells.Add(new TableCell(new BlockUIContainer(logo)));
            // Agregando nombre de la empresa
            System.Windows.Documents.Paragraph p = new System.Windows.Documents.Paragraph(new Run("\nFuego y Seguridad Industrial\n"));
            p.Inlines.Add(new Run("Historial del Cliente"));
            p.FontSize = 20;
            emp.Cells.Add(new TableCell(p));

            // Construcción de tabla de cabecera
            Table tableCabecera = new Table();
            todo.Blocks.Add(tableCabecera);
            tableCabecera.Background = System.Windows.Media.Brushes.White;
            for (int i = 0; i < 2; i++)
            {
                tableCabecera.Columns.Add(new TableColumn());
            }
            // Información de orden
            tableCabecera.RowGroups.Add(new TableRowGroup());
            tableCabecera.RowGroups[0].Rows.Add(new TableRow());
            TableRow actual = tableCabecera.RowGroups[0].Rows[0];
            actual.FontSize = 14;
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("Fecha de impresion: " + fecha))));
         //   actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("Orden #" + numeroOrden))));
            // Información de cliente y razón social
            tableCabecera.RowGroups[0].Rows.Add(new TableRow());
            actual = tableCabecera.RowGroups[0].Rows[1];
            actual.FontSize = 14;
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("Representante: " + cliente))));
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("Razón social: " + empresaR))));
            // Salto de línea
            p = new System.Windows.Documents.Paragraph(new Run("\n"));
            todo.Blocks.Add(p);

            // Tabla de detalles
            Table tableDetalles = new Table();
            todo.Blocks.Add(tableDetalles);
            tableDetalles.Background = System.Windows.Media.Brushes.White;
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                tableDetalles.Columns.Add(new TableColumn());
            }           
            tableDetalles.RowGroups.Add(new TableRowGroup());
            // Creación de encabezado
            tableDetalles.RowGroups[0].Rows.Add(new TableRow());
            actual = tableDetalles.RowGroups[0].Rows[0];
            actual.FontSize = 12;
            actual.FontWeight = FontWeights.Bold;
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run(dataTable.Columns[i].ColumnName))));
            }
            // Agregando información
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                tableDetalles.RowGroups[0].Rows.Add(new TableRow());
                actual = tableDetalles.RowGroups[0].Rows[i + 1];
                actual.FontSize = 12;
                actual.FontWeight = FontWeights.Regular;
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run(dataTable.Rows[i][j].ToString()))));
                }
            }
            // Salto de línea
            p = new System.Windows.Documents.Paragraph(new Run("\n"));
            todo.Blocks.Add(p);

            Console.Write(paginasRestantes.ToString());
            paginas.Add(todo);
            if (paginasRestantes == 1)
            {
                prueba =MergedFlowDoc(paginas);
                OrdenarImpresion( prueba, "Impresion Historial");
                Console.Write("Entró");
            }
            Console.Write("Pasó");
         
        }
       
        
            public void OrdenarImpresion( FlowDocument doc, string tipo)
        {
          //  FlowDocument document=new FlowDocument();
           
            MemoryStream s = new System.IO.MemoryStream();
            //Document docu = new Document();
            //FlowDocument sourceDocument = (FlowDocument)XamlReader.Load(s);
            //List<Block> flowDocumentBlocks = new List<Block>(sourceDocument.Blocks);

            //flowDocumentBlocks.Add(document);
            //foreach (Block aBlock in flowDocumentBlocks)
           // {
             //   document.Blocks.Add(aBlock);
            //}

            string copyString = XamlWriter.Save(doc);
            FlowDocument copy = XamlReader.Parse(copyString) as FlowDocument;
            // Carga de diálogo de impresión y ajuste del documento al tamaño de impresión.
            PrintDialog printDialog = new PrintDialog();
            IDocumentPaginatorSource idpSrc = copy;
            copy.PageHeight = printDialog.PrintableAreaHeight;
            copy.PageWidth = printDialog.PrintableAreaWidth;
            copy.PagePadding = new Thickness(50);
            copy.ColumnGap = 0;
            copy.ColumnWidth = printDialog.PrintableAreaWidth;
            //copy.Name = "Solicitud" + codigoSolicitud;
            if (printDialog.ShowDialog() ?? false)
            {
                // Llamar a PrintDocument para la ventana de impresión
                printDialog.PrintDocument(idpSrc.DocumentPaginator, tipo);
            }

        }
    
        public static FlowDocument MergedFlowDoc(IEnumerable<FlowDocument> fDocs)
        {
            var fDoc = new FlowDocument();
            foreach (var doc in fDocs)
            {
                fDoc.Blocks.AddRange(doc.Blocks.ToList());
            }
            return fDoc;
        }

        //Impresion de Recibo
        // AUTOR: Gustavo Ernesto H. Corvera
        public void PrepararImpresionRecibo(DataTable dataTable, string fechaSolicitudRecibo, string codigo, string nombreCliente, float totalRecibo)
        {
            // Preparando impresión por medio de FlowDocument
            FlowDocument fd = new FlowDocument();

            Table tableEmpresa = new Table();
            fd.Blocks.Add(tableEmpresa);
            tableEmpresa.Background = System.Windows.Media.Brushes.White;
            tableEmpresa.Columns.Add(new TableColumn());
            tableEmpresa.RowGroups.Add(new TableRowGroup());
            tableEmpresa.RowGroups[0].Rows.Add(new TableRow());
            TableRow emp = tableEmpresa.RowGroups[0].Rows[0];

            // Agregando logo de la empresa
            BitmapImage bmp = new BitmapImage(new Uri("/Images/fysi.jpg", UriKind.Relative));
            System.Windows.Controls.Image logo = new System.Windows.Controls.Image { Source = bmp };
            logo.Width = 160;
            logo.Height = 98;
            emp.Cells.Add(new TableCell(new BlockUIContainer(logo)));

            // Agregando nombre de la empresa
            System.Windows.Documents.Paragraph p = new System.Windows.Documents.Paragraph(new Run("\nFuego y Seguridad Industrial\n"));
            p.Inlines.Add(new Run("Recibo"));
            p.FontSize = 20;
            emp.Cells.Add(new TableCell(p));

            // Construcción de tabla de cabecera
            Table tableCabecera = new Table();
            fd.Blocks.Add(tableCabecera);
            tableCabecera.Background = System.Windows.Media.Brushes.White;
            for (int i = 0; i < 3; i++)
            {
                tableCabecera.Columns.Add(new TableColumn());
            }

            // Información de orden
            tableCabecera.RowGroups.Add(new TableRowGroup());
            tableCabecera.RowGroups[0].Rows.Add(new TableRow());
            TableRow actual = tableCabecera.RowGroups[0].Rows[0];
            actual.FontSize = 14;
            actual.FontWeight = FontWeights.Bold;
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("Fecha: " + fechaSolicitudRecibo))));
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run(" "))));
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("No. " + codigo))));
            // Información de cliente
            tableCabecera.RowGroups[0].Rows.Add(new TableRow());
            actual = tableCabecera.RowGroups[0].Rows[1];
            actual.FontSize = 14;
            actual.FontWeight = FontWeights.Bold;
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("Cliente: " + nombreCliente))));
            // Salto de línea
            p = new System.Windows.Documents.Paragraph(new Run("\n"));
            fd.Blocks.Add(p);

            // Tabla de detalles
            Table tableDetalles = new Table();
            fd.Blocks.Add(tableDetalles);
            tableDetalles.Background = System.Windows.Media.Brushes.White;
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                tableDetalles.Columns.Add(new TableColumn());
            }
            //sección para modificar el tamaño de Longitud de las columnas
            GridLength anchoNombre = new GridLength(175);
            GridLength anchoPresentacion = new GridLength(200);
            GridLength anchoCantidad = new GridLength(100);
            GridLength anchoPrecio = new GridLength(100);
            GridLength anchoSubTotal = new GridLength(110);
            tableDetalles.Columns[0].Width = anchoNombre;
            tableDetalles.Columns[1].Width = anchoPresentacion;
            tableDetalles.Columns[2].Width = anchoCantidad;
            tableDetalles.Columns[3].Width = anchoPrecio;
            tableDetalles.Columns[4].Width = anchoSubTotal;

            tableDetalles.RowGroups.Add(new TableRowGroup());
            // Creación de encabezado
            tableDetalles.RowGroups[0].Rows.Add(new TableRow());
            actual = tableDetalles.RowGroups[0].Rows[0];
            actual.FontSize = 12;
            actual.FontWeight = FontWeights.Bold;
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run(dataTable.Columns[i].ColumnName))));
            }
            // Agregando información
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                tableDetalles.RowGroups[0].Rows.Add(new TableRow());
                actual = tableDetalles.RowGroups[0].Rows[i + 1];
                actual.FontSize = 12;
                actual.FontWeight = FontWeights.Regular;
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run(dataTable.Rows[i][j].ToString()))));
                }
            }
            // Salto de línea
            p = new System.Windows.Documents.Paragraph(new Run("\n"));
            fd.Blocks.Add(p);

            // Tabla del total
            Table tablaTotal = new Table();
            fd.Blocks.Add(tablaTotal);
            tablaTotal.Background = System.Windows.Media.Brushes.White;
            for (int i = 0; i < 5; i++)
            {
                tablaTotal.Columns.Add(new TableColumn());
            }
            tablaTotal.RowGroups.Add(new TableRowGroup());
            // Cabecera
            tablaTotal.RowGroups[0].Rows.Add(new TableRow());
            actual = tablaTotal.RowGroups[0].Rows[0];
            actual.FontSize = 14;
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("F.__________________Recibido. "))));
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run(" "))));
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run(" "))));
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("Total: "))));
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("" + totalRecibo))));
            
            tablaTotal.Columns[0].Width = anchoNombre;
            tablaTotal.Columns[1].Width = anchoPresentacion;
            tablaTotal.Columns[2].Width = anchoCantidad;
            tablaTotal.Columns[3].Width = anchoPrecio;
            tablaTotal.Columns[4].Width = anchoSubTotal;
            //agregando espacio en blanco:
            tablaTotal.RowGroups[0].Rows.Add(new TableRow());
            actual = tablaTotal.RowGroups[0].Rows[1];
            actual.FontSize = 14;
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("\n"))));
            


            // Impresión del documento
            MemoryStream s = new System.IO.MemoryStream();
            string copyString = XamlWriter.Save(fd);
            FlowDocument copy = XamlReader.Parse(copyString) as FlowDocument;
            // Carga de diálogo de impresión y ajuste del documento al tamaño de impresión.
            PrintDialog printDialog = new PrintDialog();
            IDocumentPaginatorSource idpSrc = copy;
            copy.PageHeight = printDialog.PrintableAreaHeight;
            copy.PageWidth = printDialog.PrintableAreaWidth;
            copy.PagePadding = new Thickness(50);
            copy.ColumnGap = 0;
            copy.ColumnWidth = printDialog.PrintableAreaWidth;
            //copy.Name = "Solicitud" + codigoSolicitud;
            if (printDialog.ShowDialog() ?? false)
            {
                // Llamar a PrintDocument para la ventana de impresión
                printDialog.PrintDocument(idpSrc.DocumentPaginator, "Impresión de Recibo/Factura");
            }
        }

        //Impresion de Cotización
        // AUTOR: Edwin Antonio Jiménez Palma
        public void PrepararImpresionCotizacion(DataTable dataTable, string fechaCotizacion, string codigo, string nombreCliente, float totalCotizacion)
        {
            // Preparando impresión por medio de FlowDocument
            FlowDocument fd = new FlowDocument();

            Table tableEmpresa = new Table();
            fd.Blocks.Add(tableEmpresa);
            tableEmpresa.Background = System.Windows.Media.Brushes.White;
            tableEmpresa.Columns.Add(new TableColumn());
            tableEmpresa.RowGroups.Add(new TableRowGroup());
            tableEmpresa.RowGroups[0].Rows.Add(new TableRow());
            TableRow emp = tableEmpresa.RowGroups[0].Rows[0];

            // Agregando logo de la empresa
            BitmapImage bmp = new BitmapImage(new Uri("/Images/fysi.jpg", UriKind.Relative));
            System.Windows.Controls.Image logo = new System.Windows.Controls.Image { Source = bmp };
            logo.Width = 160;
            logo.Height = 98;
            emp.Cells.Add(new TableCell(new BlockUIContainer(logo)));

            // Agregando nombre de la empresa
            System.Windows.Documents.Paragraph p = new System.Windows.Documents.Paragraph(new Run("\nFuego y Seguridad Industrial\n"));
            p.Inlines.Add(new Run("Cotización"));
            p.FontSize = 20;
            emp.Cells.Add(new TableCell(p));

            // Construcción de tabla de cabecera
            Table tableCabecera = new Table();
            fd.Blocks.Add(tableCabecera);
            tableCabecera.Background = System.Windows.Media.Brushes.White;
            for (int i = 0; i < 3; i++)
            {
                tableCabecera.Columns.Add(new TableColumn());
            }

            // Información de orden
            tableCabecera.RowGroups.Add(new TableRowGroup());
            tableCabecera.RowGroups[0].Rows.Add(new TableRow());
            TableRow actual = tableCabecera.RowGroups[0].Rows[0];
            actual.FontSize = 14;
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("Fecha: " + fechaCotizacion))));
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run(" "))));
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("No. " + codigo))));
            // Información de cliente
            tableCabecera.RowGroups[0].Rows.Add(new TableRow());
            actual = tableCabecera.RowGroups[0].Rows[1];
            actual.FontSize = 14;
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("Cliente: " + nombreCliente))));
            // Salto de línea
            p = new System.Windows.Documents.Paragraph(new Run("\n"));
            fd.Blocks.Add(p);

            // Tabla de detalles
            Table tableDetalles = new Table();
            fd.Blocks.Add(tableDetalles);
            tableDetalles.Background = System.Windows.Media.Brushes.White;
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                tableDetalles.Columns.Add(new TableColumn());
            }
            //sección para modificar el tamaño de Longitud de las columnas
            GridLength anchoCantidad = new GridLength(100);
            GridLength anchoConcepto = new GridLength(250);
            GridLength anchoPrecio = new GridLength(150);
            GridLength anchoSubTotal = new GridLength(150);
            tableDetalles.Columns[0].Width = anchoCantidad;
            tableDetalles.Columns[1].Width = anchoConcepto;
            tableDetalles.Columns[2].Width = anchoPrecio;
            tableDetalles.Columns[3].Width = anchoSubTotal;

            tableDetalles.RowGroups.Add(new TableRowGroup());
            // Creación de encabezado
            tableDetalles.RowGroups[0].Rows.Add(new TableRow());
            actual = tableDetalles.RowGroups[0].Rows[0];
            actual.FontSize = 12;
            actual.FontWeight = FontWeights.Bold;
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run(dataTable.Columns[i].ColumnName))));
            }
            // Agregando información
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                tableDetalles.RowGroups[0].Rows.Add(new TableRow());
                actual = tableDetalles.RowGroups[0].Rows[i + 1];
                actual.FontSize = 12;
                actual.FontWeight = FontWeights.Regular;
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run(dataTable.Rows[i][j].ToString()))));
                }
            }
            // Salto de línea
            p = new System.Windows.Documents.Paragraph(new Run("\n"));
            fd.Blocks.Add(p);

            // Tabla del total
            Table tablaTotal = new Table();
            fd.Blocks.Add(tablaTotal);
            tablaTotal.Background = System.Windows.Media.Brushes.White;
            for (int i = 0; i < 5; i++)
            {
                tablaTotal.Columns.Add(new TableColumn());
            }
            tablaTotal.RowGroups.Add(new TableRowGroup());
            // Cabecera
            tablaTotal.RowGroups[0].Rows.Add(new TableRow());
            actual = tablaTotal.RowGroups[0].Rows[0];
            actual.FontSize = 14;
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run(" "))));
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run(" "))));
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run(" "))));
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("Total: "))));
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("" + "$"+totalCotizacion))));
            //agregando espacio en blanco:
            tablaTotal.RowGroups[0].Rows.Add(new TableRow());
            actual = tablaTotal.RowGroups[0].Rows[1];
            actual.FontSize = 14;
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("\n"))));


            // Impresión del documento
            MemoryStream s = new System.IO.MemoryStream();
            string copyString = XamlWriter.Save(fd);
            FlowDocument copy = XamlReader.Parse(copyString) as FlowDocument;
            // Carga de diálogo de impresión y ajuste del documento al tamaño de impresión.
            PrintDialog printDialog = new PrintDialog();
            IDocumentPaginatorSource idpSrc = copy;
            copy.PageHeight = printDialog.PrintableAreaHeight;
            copy.PageWidth = printDialog.PrintableAreaWidth;
            copy.PagePadding = new Thickness(50);
            copy.ColumnGap = 0;
            copy.ColumnWidth = printDialog.PrintableAreaWidth;
            //copy.Name = "Solicitud" + codigoSolicitud;
            if (printDialog.ShowDialog() ?? false)
            {
                // Llamar a PrintDocument para la ventana de impresión
                printDialog.PrintDocument(idpSrc.DocumentPaginator, "Impresión de Cotización");
            }
        }
        // Crea una impresión de la bitacora de acciones del sistema gerencial.
        // AUTOR: Gabriel 
        public void ImprimirBitacora(DataTable dataTable, string administrador, string fecha, int paginasRestantes)
        {
            // Preparando impresión por medio de FlowDocument

            FlowDocument todo = new FlowDocument();
            Table tableEmpresa = new Table();
            // todo.MinPageHeight = 982.7;
            todo.PageHeight = 982.7;

            todo.Blocks.Add(tableEmpresa);
            tableEmpresa.Background = System.Windows.Media.Brushes.White;
            tableEmpresa.Columns.Add(new TableColumn());
            tableEmpresa.RowGroups.Add(new TableRowGroup());
            tableEmpresa.RowGroups[0].Rows.Add(new TableRow());
            TableRow emp = tableEmpresa.RowGroups[0].Rows[0];
            // Agregando logo de la empresa
            BitmapImage bmp = new BitmapImage(new Uri("/Images/fysi.jpg", UriKind.Relative));
            System.Windows.Controls.Image logo = new System.Windows.Controls.Image { Source = bmp };
            logo.Width = 160;
            logo.Height = 98;
            emp.Cells.Add(new TableCell(new BlockUIContainer(logo)));
            // Agregando nombre de la empresa
            System.Windows.Documents.Paragraph p = new System.Windows.Documents.Paragraph(new Run("\nFuego y Seguridad Industrial\n"));
            p.Inlines.Add(new Run("Bitacora del Sistema"));
            p.FontSize = 20;
            emp.Cells.Add(new TableCell(p));

            // Construcción de tabla de cabecera
            Table tableCabecera = new Table();
            todo.Blocks.Add(tableCabecera);
            tableCabecera.Background = System.Windows.Media.Brushes.White;
            for (int i = 0; i < 2; i++)
            {
                tableCabecera.Columns.Add(new TableColumn());
            }
            // Información de orden
            tableCabecera.RowGroups.Add(new TableRowGroup());
            tableCabecera.RowGroups[0].Rows.Add(new TableRow());
            TableRow actual = tableCabecera.RowGroups[0].Rows[0];
            actual.FontSize = 14;
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("Fecha de impresion: " + fecha))));
            //   actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("Orden #" + numeroOrden))));
            // Información de cliente y razón social
            tableCabecera.RowGroups[0].Rows.Add(new TableRow());
            actual = tableCabecera.RowGroups[0].Rows[1];
            actual.FontSize = 14;
            actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run("Impreso Por: " + administrador))));
            
 
            

            // Tabla de detalles
            Table tableDetalles = new Table();
            todo.Blocks.Add(tableDetalles);
            tableDetalles.Background = System.Windows.Media.Brushes.White;
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                tableDetalles.Columns.Add(new TableColumn());
            }
            tableDetalles.RowGroups.Add(new TableRowGroup());
            // Creación de encabezado
            tableDetalles.RowGroups[0].Rows.Add(new TableRow());
            actual = tableDetalles.RowGroups[0].Rows[0];
            actual.FontSize = 12;
            actual.FontWeight = FontWeights.Bold;
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run(dataTable.Columns[i].ColumnName))));
            }
            // Agregando información
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                tableDetalles.RowGroups[0].Rows.Add(new TableRow());
                actual = tableDetalles.RowGroups[0].Rows[i + 1];
                actual.FontSize = 12;
                actual.FontWeight = FontWeights.Regular;
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    actual.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run(dataTable.Rows[i][j].ToString()))));
                }
            }
            // Salto de línea
            p = new System.Windows.Documents.Paragraph(new Run("\n"));
            todo.Blocks.Add(p);

            Console.Write(paginasRestantes.ToString());
            paginas.Add(todo);
            if (paginasRestantes == 1)
            {
                prueba = MergedFlowDoc(paginas);
                OrdenarImpresion(prueba, "Impresion de Bitacora");
                
            }
           

        }


       

    }
}
