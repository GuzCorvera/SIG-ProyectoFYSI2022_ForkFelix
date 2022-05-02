using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SGVentas
{
    internal class ControlBDG
    {
        SQLiteConnection cn;

        public ControlBDG()
        {

            cn = new SQLiteConnection(@"data source=C:/SGFYSIEX/SGBD.db");   //CONEXION NORMAL

        }
        public String AgregarAccionABitacora(GestionUsuarios.AccionBitacora accion)
        {
            try
            {
                cn.Open();
                //  SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT C.CODCLIENTE, C.NOMBRECLIENTE, C.APELLIDOCLIENTE, C.EMPRESACLIENTE, T.NOMBRESERVICIO,T.CODSERVICIO from CLIENTE as C INNER JOIN TIPOSERVICIO AS T WHERE C.CODSERVICIO = T.CODSERVICIO", cn);
                SQLiteCommand comando = new SQLiteCommand("INSERT INTO BITACORA" +
                    " (COD_BITACORA, EMPLEADO_BITACORA, FECHA_BITACORA, NOMBRE_REPORTE_BITACORA) " +
                    "VALUES (@id,@empleado,@fecha,@accion)", cn);
                comando.Parameters.Add(new SQLiteParameter("@id", accion.codigo));
                comando.Parameters.Add(new SQLiteParameter("@empleado", accion.nombreEmpleado));
                comando.Parameters.Add(new SQLiteParameter("@fecha", accion.fechaActual));
                comando.Parameters.Add(new SQLiteParameter("@accion", accion.accion));

                comando.ExecuteNonQuery();
                cn.Close();
            }
            catch (SQLiteException ex)
            {
                cn.Close();
                return "Ha ocurrido el error: " + ex.Message.ToString() + "Al intentar agregar la accion";
            }
            cn.Close();
            return "1";
        }

        public DataTable ConsultarAcciones()
        {
            DataTable dataTable = new DataTable();

            try
            {
                cn.Open();
                Console.WriteLine(DateTime.Now.ToString());
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * from BITACORA", cn);
                adapter.Fill(dataTable);
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Ha ocurrido un error al cargar tabla de la Botacora " + ex.Message.ToString());
                Console.WriteLine();
                cn.Close();
            }
            cn.Close();
            Console.WriteLine(dataTable.Rows[0][1].ToString());

            return dataTable;
        }
        /// <summary>
        /// Termina metodos de bitacora, empieza metodos de Reporte de productos mas vendidos
        /// </summary>

        public String AgregarReporte(Clases.Reporte repo)
        {// Este metodo puede ser usado por todos, menos por el reporte de
            //por empresa
            try
            {
                cn.Open();

                SQLiteCommand comando = new SQLiteCommand("INSERT INTO REPORTE" +
                    " (COD_REPORTE, FECHA_REPORTE, EMPLEADO_REPORTE, TIPO_REPORTE, FECHA_INICIAL, FECHA_FINAL) " +
                    "VALUES (@id,@fecha,@emp,@tipo,@fechaIni,@fechaFini)", cn);
                comando.Parameters.Add(new SQLiteParameter("@id", repo.codigo));
                comando.Parameters.Add(new SQLiteParameter("@fecha", repo.fecha));
                comando.Parameters.Add(new SQLiteParameter("@emp", repo.nombreEmpleado));
                comando.Parameters.Add(new SQLiteParameter("@tipo", repo.tipoReporte));
                comando.Parameters.Add(new SQLiteParameter("@fechaIni", repo.fechaInicial));
                comando.Parameters.Add(new SQLiteParameter("@fechaFini", repo.fechaFinal));

                comando.ExecuteNonQuery();
                cn.Close();
            }
            catch (SQLiteException ex)
            {
                cn.Close();
                return "Ha ocurrido el error: " + ex.Message.ToString() + "Al intentar crear el Reporte";
            }
            cn.Close();
            return "1";
        }
        public DataTable ConsultarReportes(string tipoReporte)
        {// Este metodo puede ser usado por todos, menos por el reporte de
            //por empresa 
            //NOTA: Aun no lo he probado
            DataTable dataTable = new DataTable();
            string sentenciaSQL = "SELECT * from REPORTE WHERE TIPO_REPORTE='"+tipoReporte+"'";
            try
            {
                cn.Open();
                Console.WriteLine(DateTime.Now.ToString());
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sentenciaSQL, cn);
                adapter.Fill(dataTable);
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Ha ocurrido un error al cargar tabla de reportes de " + tipoReporte+" " + ex.Message.ToString());
                Console.WriteLine();
                cn.Close();
            }
            cn.Close();
            Console.WriteLine(dataTable.Rows[0][1].ToString());

            return dataTable;
        }

    }
}
