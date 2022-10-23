using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos
{
    public class Producto
    {
        public string Nombre { set; get; }
        public Double Coste { set; get; }
        public string Descripcion { set; get; }
        public Uri Imagen { set; get; }
        public Producto(string nombre, Double coste, string descripcion, Uri imagen)
        {
            Nombre = nombre;
            Coste = coste;
            Descripcion = descripcion;
            Imagen = imagen;
        }
    }
}
