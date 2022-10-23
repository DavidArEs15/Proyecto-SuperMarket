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

namespace Eventos
{
    /// <summary>
    /// Lógica de interacción para AyudaW.xaml
    /// </summary>
    public partial class AyudaW : Window
    {
        private Window madre;
        private List<Ayuda> listadoAyudas;
        public AyudaW(Window ventana)
        {
            InitializeComponent();
            madre = ventana;
            listadoAyudas = LeerXML();
            DataContext = listadoAyudas;
            foreach (Ayuda item in listadoAyudas)
            {
                cbVentanas.Items.Add(item.NombreVentana);
            }
            
        }

        private List<Ayuda> LeerXML()
        {
            List<Ayuda> listadoAyudas = new List<Ayuda>();
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Datos/AyudaInfo.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevaAyuda = new Ayuda("", "");
                nuevaAyuda.NombreVentana = node.Attributes["NombreVentana"].Value;
                nuevaAyuda.Info = node.Attributes["Info"].Value;

                listadoAyudas.Add(nuevaAyuda);
            }
            return listadoAyudas;
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            
        }

        private void cbVentanas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string ventanaSeleccionada = (string)cbVentanas.SelectedItem;
            foreach (Ayuda item in listadoAyudas)
            {
                if (string.Equals(ventanaSeleccionada, item.NombreVentana))
                {
                    lblAyuda.Content = item.Info;
                }
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            madre.Effect = null;
        }
    }
}
