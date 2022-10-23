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

namespace Eventos
{
    /// <summary>
    /// Lógica de interacción para Pago.xaml
    /// </summary>
    public partial class Pago : Window
    {
        private Window madre;
        private List<Producto> listadoCesta = new List<Producto>();
        public Pago(Window cesta, List<Producto> listaCesta)
        {
            InitializeComponent();
            madre = cesta;
            listadoCesta = listaCesta;
            DataContext = listadoCesta;
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
            if(costeTotal == 0.0)
            {
                btnConfirmarPago.IsEnabled = false;
            }
            else
            {
                //btnConfirmarPago.IsEnabled = true;
            }
            return costeTotal;
        }

        private void btAtras_Click(object sender, RoutedEventArgs e)
        {
            madre.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            madre.Effect = null;
        }

        bool hasBeenClicked1 = false;

        private void tbNombre_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked1)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked1 = true;
            }
        }

        bool hasBeenClicked2 = false;

        private void tbApellidos_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked2)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked2 = true;
            }
        }

        bool hasBeenClicked3 = false;

        private void tbExpiracion_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked3)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked3 = true;
            }
        }

        bool hasBeenClicked4 = false;

        private void tbCVV_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked4)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked4 = true;
            }
        }

        bool hasBeenClicked5 = false;

        private void tbDir_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked5)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked5 = true;
            }
        }

        bool hasBeenClicked6 = false;

        private void tbCiu_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked6)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked6 = true;
            }
        }

        bool hasBeenClicked7 = false;

        private void tbProv_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked7)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked7 = true;
            }
        }

        bool hasBeenClicked8 = false;

        private void tbCPostal_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked8)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked8 = true;
            }
        }

        bool hasBeenClicked9 = false;

        private void tbPais_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked9)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked9 = true;
            }
        }

        private void btnConfirmarPago_Click(object sender, RoutedEventArgs e)
        {
            gdPagoExitoso.Visibility = Visibility.Visible;
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            gdPagoExitoso.Visibility = Visibility.Hidden;
        }

        private void tbCVV_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbCVV.Text != "CVV" && tbCVV.Text != "")
            {
                btnConfirmarPago.IsEnabled = true;
            }
        }
    }
}
