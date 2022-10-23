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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Eventos
{
    /// <summary>
    /// Lógica de interacción para VerProducto.xaml
    /// </summary>
    public partial class VerProducto : Window
    {
        private Window madre;
        public VerProducto(Window Wproductos, Producto productoElegido)
        {
            InitializeComponent();
            madre = Wproductos;
            lblNombre2.Content = productoElegido.Nombre;
            lblCoste2.Content = productoElegido.Coste;
            lblDescripcion2.Content = productoElegido.Descripcion;     
            
            BitmapImage imagenPro = new BitmapImage();
            imagenPro.BeginInit();
            imagenPro.UriSource = new Uri(productoElegido.Imagen.AbsoluteUri);
            imagenPro.EndInit();
            imagenProducto.Stretch = Stretch.Fill;
            imagenProducto.Source = imagenPro;
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            madre.Show();
            this.Hide();
        }

        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            AyudaW ayudaW = new AyudaW(this);
            this.Effect = new BlurEffect();

            ayudaW.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
