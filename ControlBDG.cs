using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGVentas
{
    internal class ControlBDG
    {
        SQLiteConnection cn;
        
        public ControlBDG()
        {
            
            cn = new SQLiteConnection(@"data source=C:/SGFYSIEX/SGBD.db");   //CONEXION NORMAL

        }

    }
}
