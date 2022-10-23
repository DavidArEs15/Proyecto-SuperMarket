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
    /// Lógica de interacción para CestaCompra.xaml
    /// </summary>
    public partial class CestaCompra : Window
    {
        private Window madre;
        private List<Producto> listadoCesta = new List<Producto>();
        private Producto productoElegido;
        public CestaCompra(Window productos, List<Producto> listaCesta)
        {
            InitializeComponent();
            madre = productos;
            listadoCesta = listaCesta;
            DataContext = listadoCesta;
            lbCesta.ItemsSource = listadoCesta;
            lblCosteTotal.Content = calcularCoste();

        }

        private double calcularCoste()
        {
            double costeTotal = 0.0;
            foreach (Producto item in listadoCesta)
            {
                costeTotal += item.Coste;
            }
            costeTotal = (double)Decimal.Round((decimal)costeTotal, 2);
            if (costeTotal == 0.0)
            {
                btnPagar.IsEnabled = false;
            }
            else
            {
                btnPagar.IsEnabled = true;
            }
            return costeTotal;
        }

        private void btnPagar_Click(object sender, RoutedEventArgs e)
        {
            Pago pago = new Pago(this, listadoCesta);
            this.Effect = new BlurEffect();
            pago.Show();


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

        private void btnEliminarCesta_Click(object sender, RoutedEventArgs e)
        {
            productoElegido = (Producto)lbCesta.SelectedItem;
            listadoCesta.Remove(productoElegido);
            lbCesta.Items.Refresh();
            lblCosteTotal.Content = calcularCoste();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
