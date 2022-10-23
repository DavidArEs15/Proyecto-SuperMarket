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
using System.Xml;
using System.Xml.Linq;

namespace Eventos
{
    /// <summary>
    /// Lógica de interacción para Usuario.xaml
    /// </summary>
    public partial class Usuario : Window
    {
        private string perfil;
        private Window madre;
        string nombreUser, apellidoUser, emailUser, telefonoUser, direccionUser;
        private Perfil usuarioAct;
        private List<Perfil> listadoUsuarios;
        public Usuario(Window productos, string user)
        {
            InitializeComponent();
            perfil = user;
            madre = productos;
            listadoUsuarios = LeerXML();
            DataContext = listadoUsuarios;
            LbUsuarios.ItemsSource = listadoUsuarios;
            LbUsuarios.SelectedItem = sacarUser();
            lblUser.Content = usuarioAct.User;
            nombreUser = usuarioAct.Nombre;
            apellidoUser = usuarioAct.Apellidos;
            direccionUser = usuarioAct.Direccion;
            emailUser = usuarioAct.Email;
            telefonoUser = usuarioAct.Telefono;

        }

        private Perfil sacarUser()
        {
            usuarioAct = null;
         
            foreach (Perfil item in listadoUsuarios)
            {
                if (item.User.Equals(perfil))
                {
                    usuarioAct = item;
                }
            }

            return usuarioAct;

        }

        private void EscribirXML()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Usuarios.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            string strNewName = nombreUser;
            string strXPath = "/Usuarios/Usuario/Nombre[.='" + strNewName + "']";
            XmlElement ndName = (XmlElement)doc.SelectSingleNode(strXPath);
            if (ndName != null)
            {
                ndName.InnerText = Nombre.Text; 
            }

            strNewName = apellidoUser;
            strXPath = "/Usuarios/Usuario/Apellidos[.='" + strNewName + "']";
            XmlElement ndApellido = (XmlElement)doc.SelectSingleNode(strXPath);
            if (ndApellido != null)
            {
                ndApellido.InnerText = Apellidos.Text; 
            }

            strNewName = emailUser;
            strXPath = "/Usuarios/Usuario/Email[.='" + strNewName + "']";
            XmlElement ndEmail = (XmlElement)doc.SelectSingleNode(strXPath);
            if (ndEmail != null)
            {
                ndEmail.InnerText = Email.Text;
            }

            strNewName = direccionUser;
            strXPath = "/Usuarios/Usuario/Direccion[.='" + strNewName + "']";
            XmlElement ndDireccion = (XmlElement)doc.SelectSingleNode(strXPath);
            if (ndDireccion != null)
            {
                ndDireccion.InnerText = Direccion.Text;
            }

            strNewName = telefonoUser;
            strXPath = "/Usuarios/Usuario/Telefono[.='" + strNewName + "']";
            XmlElement ndTelefono = (XmlElement)doc.SelectSingleNode(strXPath);
            if (ndTelefono != null)
            {
                ndTelefono.InnerText = Telefono.Text;
            }

            doc.Save(path);
        }


        private List<Perfil> LeerXML()
        {
            List<Perfil> listadoUsuarios = new List<Perfil>();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Usuarios.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoUsuario = new Perfil("","", "", "", "", "", DateTime.Now);
                nuevoUsuario.User = node.SelectSingleNode("User").InnerText; ;
                nuevoUsuario.Nombre = node.SelectSingleNode("Nombre").InnerText;
                nuevoUsuario.Apellidos = node.SelectSingleNode("Apellidos").InnerText;
                nuevoUsuario.Telefono = node.SelectSingleNode("Telefono").InnerText;
                nuevoUsuario.Direccion = node.SelectSingleNode("Direccion").InnerText;
                nuevoUsuario.Email = node.SelectSingleNode("Email").InnerText;
                nuevoUsuario.FechaNac = Convert.ToDateTime(node.SelectSingleNode("FechaNac").InnerText);

                listadoUsuarios.Add(nuevoUsuario);
            }
            return listadoUsuarios;
        }

        private void btnlimpiar_Click(object sender, RoutedEventArgs e)
        {

            Nombre.Text = String.Empty;
            Apellidos.Text = String.Empty;
            Direccion.Text = String.Empty;
            Telefono.Text = String.Empty;
            Email.Text = String.Empty;

        }

        private void btConfirmar_Click(object sender, RoutedEventArgs e)
        {
            gdExito.Visibility = Visibility.Visible;
            EscribirXML();
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            madre.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            gdExito.Visibility = Visibility.Hidden;
        }

    }
}
