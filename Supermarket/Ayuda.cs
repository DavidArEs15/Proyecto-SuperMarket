using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos
{
    class Ayuda
    {

        public string NombreVentana { set; get; }
        public string Info { set; get; }

        public Ayuda(string nombreVentana, string info)
        {
            NombreVentana = nombreVentana;
            Info = info;

        }

    }
}
