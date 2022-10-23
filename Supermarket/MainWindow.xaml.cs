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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Eventos
{
    /// <summary>
    /// </summary>
    public partial class MainWindow : Window
    {
        String selectedLanguage = "Español";
        public MainWindow()
        {
            InitializeComponent();
            App.DefineIdioma("es-ES");
            Idioma.SelectedIndex = 0;
            imagIdioma.Source = imagEspana;

        }

        private BitmapImage imagEspana = new BitmapImage(new Uri("/imagenes/spain.png", UriKind.Relative));
        private BitmapImage imagIngles = new BitmapImage(new Uri("/imagenes/english.png", UriKind.Relative));
        private void MainWindow_Load(object sender, EventArgs e)
        {
            selectedLanguage = "Español";
            Idioma.Items.Insert(1, "English");
            Idioma.SelectedIndex = 0;
            lblIdioma.Content = "Español";
            imagIdioma.Source = imagEspana;

        }


        private BitmapImage imagOriginal = new BitmapImage(new Uri("/imagenes/personaComprando.png", UriKind.Relative));

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (!String.IsNullOrEmpty(txtUsuario.Text)
                && (ComprobarEntrada(txtUsuario.Text, usuario1,
                txtUsuario, imgCheckUsuario) || ComprobarEntrada(txtUsuario.Text, usuario2,
                txtUsuario, imgCheckUsuario) || ComprobarEntrada(txtUsuario.Text, usuario3,
                txtUsuario, imgCheckUsuario)))
                {
                    passContrasena.IsEnabled = true;
                    passContrasena.Focus();
                    txtUsuario.IsEnabled = true;
                }
            }
        }

        private void passContrasena_KeyUp(object sender, KeyEventArgs e)
        {
            if (ComprobarEntrada(passContrasena.Password, password,
            passContrasena, imgCheckContrasena))
                btnLogin.Focus();
        }

        private string usuario1 = "DA";
        private string usuario2 = "IV";
        private string usuario3 = "GSI";
        private string password = "Market";

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if ((ComprobarEntrada(txtUsuario.Text, usuario1,
            txtUsuario, imgCheckUsuario) || ComprobarEntrada(txtUsuario.Text, usuario2,
            txtUsuario, imgCheckUsuario) || ComprobarEntrada(txtUsuario.Text, usuario3,
            txtUsuario, imgCheckUsuario))
            &&
            ComprobarEntrada(passContrasena.Password, password,
            passContrasena, imgCheckContrasena))
            {

                string nombre_usuario = txtUsuario.Text;
                Productos productos = new Productos(nombre_usuario, Idioma.SelectedItem, this, txtUsuario.Text);

                productos.Show();
                this.Hide();

            }
        }
        private BitmapImage imagCheck = new BitmapImage(new Uri("/imagenes/tickbueno.png", UriKind.Relative));
        private BitmapImage imagCross = new BitmapImage(new Uri("/imagenes/redcrossbuena.png", UriKind.Relative));

        private Boolean ComprobarUsuario(string user)
        {
            Boolean valido = false;
            txtUsuario.BorderThickness = new Thickness(2);
            if (user.Equals(usuario1) || user.Equals(usuario2) || user.Equals(usuario3))
            {
                txtUsuario.BorderBrush = Brushes.Green;
                txtUsuario.Background = Brushes.LightGreen;
                imgCheckUsuario.Source = imagCheck;
                valido = true;
            }
            else
            {
                txtUsuario.BorderBrush = Brushes.Red;
                imgCheckUsuario.Source = imagCross;
                valido = false;
            }
            return valido;
        }

        private Boolean ComprobarPassword(string pass)
        {
            Boolean valido = false;
            passContrasena.BorderThickness = new Thickness(2);
            if (pass.Equals(password))
            {
                passContrasena.BorderBrush = Brushes.Green;
                passContrasena.Background = Brushes.LightGreen;
                imgCheckContrasena.Source = imagCheck;
                valido = true;
            }
            else
            {
                passContrasena.BorderBrush = Brushes.Red;
                imgCheckContrasena.Source = imagCross;
                valido = false;
            }
            return valido;
        }
        private Boolean ComprobarEntrada(string valorIntroducido, string valorValido,
Control componenteEntrada, Image imagenFeedBack)
        {
            Boolean valido = false;
            componenteEntrada.BorderThickness = new Thickness(2);
            if (valorIntroducido.Equals(valorValido))
            {
                componenteEntrada.BorderBrush = Brushes.Green;
                componenteEntrada.Background = Brushes.LightGreen;
                imagenFeedBack.Source = imagCheck;
                valido = true;
            }
            else
            {
                componenteEntrada.BorderBrush = Brushes.Red;
                imagenFeedBack.Source = imagCross;
                valido = false;
            }
            return valido;
        }

        private void Idioma_MouseEnter(object sender, MouseEventArgs e)
        {
            selectedLanguage = (string)Idioma.SelectedItem;
            lblIdioma.Content = selectedLanguage;
            if (lblIdioma.Content == "Español")
            {
                imagIdioma.Source = imagEspana;
            }
            else if (lblIdioma.Content == "English")
            {
                imagIdioma.Source = imagIngles;
            }
        }

        private void Idioma_Initialized(object sender, EventArgs e)
        {
            Idioma.Items.Add("Español");
            Idioma.Items.Add("English");
        }

        private void VentanaPrincipal_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            AyudaW ayudaW = new AyudaW(this);
            this.Effect = new BlurEffect();

            ayudaW.Show();
        }

        private void lblRecordarContrasena_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show((string)Resources["Para"], (string)Resources["Recordar contraseña"]);
        }
        
        private void Idioma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string idioma = "";
            string dic = "";
            int cbi = Idioma.SelectedIndex;
            switch (cbi)
            {
                case 0:
                    dic = "Español";
                    idioma = "es-ES";
                    break;
                case 1:
                    dic = "Inglés";
                    idioma = "en-UK";
                    break;
            }
            Resources.MergedDictionaries.Add(App.DefineIdioma(idioma));
            lblIdioma.Content = Resources["Idioma" + dic];
        }


        private void btnAumentar_Click(object sender, RoutedEventArgs e)
        {
            imagIdioma.Height = 30;
            imagIdioma.Width = 54;
            lblSelec_idioma.FontSize = 26;
            lblTituloLogin.FontSize = 30;
            lblUsuario.FontSize = 26;
            lblContrasena.FontSize = 26;
            lblRecordarContrasena.FontSize = 26;
            btnLogin.FontSize = 26;
            txtUsuario.FontSize = 26;
            passContrasena.FontSize = 26;
            Idioma.FontSize = 26;
            btnAumentar.Visibility = Visibility.Hidden;
            btnReducir.Visibility = Visibility.Visible;
        }

        private void btnReducir_Click(object sender, RoutedEventArgs e)
        {
            imagIdioma.Height = 21;
            imagIdioma.Width = 45;
            lblSelec_idioma.FontSize = 16;
            lblTituloLogin.FontSize = 20;
            lblUsuario.FontSize = 18;
            lblContrasena.FontSize = 18;
            lblRecordarContrasena.FontSize = 18;
            btnLogin.FontSize = 18;
            txtUsuario.FontSize = 16;
            passContrasena.FontSize = 16;
            Idioma.FontSize = 16;
            btnReducir.Visibility = Visibility.Hidden;
            btnAumentar.Visibility = Visibility.Visible;
        }
    }
}
