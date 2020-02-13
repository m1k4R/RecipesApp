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

namespace ReceptiZaKolace
{
    /// <summary>
    /// Interaction logic for Prikazi.xaml
    /// </summary>
    public partial class WindowPrikazi : Window
    {
        public WindowPrikazi()
        {
            InitializeComponent();
        }

        public WindowPrikazi(Classes.Recept recept)
        {
            InitializeComponent();

            textBoxNaziv.Text = recept.Naziv;
            textBoxOpis.Text = recept.Opis;
            labelVrsta.Content = recept.Vrsta;
            labelSat.Content = Convert.ToString(recept.Vrijeme);
            textBoxSastojci.Text = recept.Sastojci;
            textBoxPriprema.Text= recept.Priprema;
            image.Source = new BitmapImage(new Uri(recept.Slika));          
        }

        private void buttonIzlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
