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


            return dataTable;
        }

    }
}
