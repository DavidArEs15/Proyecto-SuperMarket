using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos
{
    class Perfil
    {
        public string User { set; get; }
        public string Nombre { set; get; }
        public string Apellidos { set; get; }
        public string Email { set; get; }
        public string Telefono { set; get; }
        public string Direccion { set; get; }
        public DateTime FechaNac { set; get; }

        public Perfil(string user, string nombre, string apellidos, string email, string
        telefono, string direccion, DateTime fechaNac)
        {
            User = user;
            Nombre = nombre;
            Apellidos = apellidos;
            Email = email;
            Telefono = telefono;
            Email = email;
            FechaNac = fechaNac;
        }

    }
}
