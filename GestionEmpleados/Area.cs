﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGVentas.GestionEmpleados
{
    class Area
    {
        public string codigoArea { get; set; }
        public string nombreArea { get; set; }
       
        public Area()
        {

        }
        public Area(string codigo, string area)
        {
            nombreArea = area;
            codigoArea = codigo;
        }
    }
}
