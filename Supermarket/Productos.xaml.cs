using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Xml;

namespace Eventos
{
    /// <summary>
    /// Lógica de interacción para Productos.xaml
    /// </summary>
    public partial class Productos : Window
    {
        private string perfil;
        private Window madre;
        private Producto productoElegido;
        private List<Producto> listadoProductos;
        private List<Producto> listadoCesta = new List<Producto>();
        public Productos(string nombre_usuario, object selectedItem, Window ventana_login, string user)
        {
            InitializeComponent();
            perfil = user;
            String idioma = "es-ES";
            if (selectedItem == null)
            {
                App.DefineIdioma("es-ES");
                idioma = "es-ES";
            }
            else if (selectedItem.Equals("Español"))
            {
                App.DefineIdioma("es-ES");
                idioma = "es-ES";
            }
            else if (selectedItem.Equals("English"))
            {
                App.DefineIdioma("en-UK");
                idioma = "en-UK";
            }
            Resources.MergedDictionaries.Add(App.DefineIdioma(idioma));
            madre = ventana_login;
            listadoProductos = LeerXML();
            DataContext = listadoProductos;
            lbProductos.ItemsSource = listadoProductos;
            lblnumProductos.Content = listadoCesta.Count;
        }

        private List<Producto> LeerXML()
        {
            List<Producto> listadoProductos = new List<Producto>();
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Datos/Productos.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoProducto = new Producto("", 0.0, "", null);
                nuevoProducto.Nombre = node.Attributes["Nombre"].Value;
                nuevoProducto.Coste = double.Parse(node.Attributes["Coste"].Value, CultureInfo.InvariantCulture);
                nuevoProducto.Descripcion = node.Attributes["Descripcion"].Value;
                nuevoProducto.Imagen = new Uri(node.Attributes["url"].Value, UriKind.Absolute);

                listadoProductos.Add(nuevoProducto);
            }
            return listadoProductos;
        }

        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            AyudaW ayudaW = new AyudaW(this);
            this.Effect = new BlurEffect();

            ayudaW.Show();
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

        private void btnProducto_Click(object sender, RoutedEventArgs e)
        {
            productoElegido = (Producto)lbProductos.SelectedItem;
            VerProducto verproductos = new VerProducto(this, productoElegido);

            verproductos.Show();
            this.Hide();
        }

        private void btnCesta_Click(object sender, RoutedEventArgs e)
        {
            CestaCompra cestaCompra = new CestaCompra(this, listadoCesta);

            cestaCompra.Show();
            this.Hide();
        }

        private void btnAnadirCesta_Click(object sender, RoutedEventArgs e)
        {
            productoElegido = (Producto)lbProductos.SelectedItem;
            listadoCesta.Add(productoElegido);
            imagenTick.Visibility = Visibility.Visible;
            lblnumProductos.Content = listadoCesta.Count;
        }

        private void lbProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnAnadirCesta.Visibility = Visibility.Visible;
            btnProducto.IsEnabled = true;
            imagenTick.Visibility = Visibility.Hidden;
            lblnumProductos.Content = listadoCesta.Count;
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            imagenTick.Visibility = Visibility.Hidden;
            lblnumProductos.Content = listadoCesta.Count;
        }

        private void btnPerfil_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario(this, perfil);

            usuario.Show();
            this.Hide();
        }

        bool hasBeenClicked = false;

        private void tbBuscar_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked = true;
            }
        }

        private void tbBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string desc, firstW, secondW, terW;
            bool continuar = true;
            lbProductos.ItemsSource = null;
            lbProductos.Items.Clear();
            foreach (Producto prod in listadoProductos)
            {
                continuar = true;
                desc = prod.Descripcion;
        
                char[] delimitadores = { ' ', ',', '.', ':', '\t', '\n' };
                char[] espacios = { ' ' };
                string[] strlist = desc.Split(delimitadores);
                string [] textoBuscador = tbBuscar.Text.Split(espacios);

                if (textoBuscador.Length == 1)
                {
                    for (int i = 0; i < strlist.Length && continuar == true; i++)
                    {
                        firstW = strlist[i];

                        if (firstW.Equals(textoBuscador[0], StringComparison.OrdinalIgnoreCase))
                        {
                            lbProductos.Items.Add(prod);
                            continuar = false;
                        }

                    }

                }

                if (textoBuscador.Length == 2)
                {
                    for (int i = 0; i < strlist.Length - 1 && continuar == true; i++)
                    {
                        firstW = strlist[i];
                        secondW = strlist[i + 1];

                        if (firstW.Equals(textoBuscador[0], StringComparison.OrdinalIgnoreCase))
                        {
                            if (secondW.Equals(textoBuscador[1], StringComparison.OrdinalIgnoreCase))
                            {
                                lbProductos.Items.Add(prod);
                                continuar = false;
                            }
                        }

                    }

                }
                if (textoBuscador.Length == 3)
                {
                    for (int i = 0; i < strlist.Length - 2 && continuar == true; i++)
                    {
                        firstW = strlist[i];
                        secondW = strlist[i + 1];
                        terW = strlist[i + 2];


                        if (firstW.Equals(textoBuscador[0], StringComparison.OrdinalIgnoreCase))
                        {
                            if (secondW.Equals(textoBuscador[1], StringComparison.OrdinalIgnoreCase))
                            {
                                if (terW.Equals(textoBuscador[2], StringComparison.OrdinalIgnoreCase))
                                {
                                    lbProductos.Items.Add(prod);
                                    continuar = false;
                                }
                            }
                        }


                    }

                }
            }
        }

        private void lblEtiquetaBuscar_MouseEnter(object sender, MouseEventArgs e)
        {
            lblEtiquetaBuscar.Visibility = Visibility.Hidden;
        }

        private void tbBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                lbHistorial.Items.Add(tbBuscar.Text);
            }
        }

        private void lbHistorial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbHistorial.SelectedItem == null)
            {
                return;
            } else {
                tbBuscar.Text = lbHistorial.SelectedItem.ToString();
            }
        }

        private void btnLimpiarHistorial_Click(object sender, RoutedEventArgs e)
        {
            lbHistorial.ItemsSource = null;
            lbHistorial.Items.Clear();
        }
    }
}