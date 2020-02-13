using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReceptiZaKolace
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Classes.DataIO serializer = new Classes.DataIO();

        public static BindingList<Classes.Recept> Recepti { get; set; }

        public MainWindow()
        {
            Recepti = serializer.DeSerializeObject<BindingList<Classes.Recept>>("recepti.xml");
            if (Recepti == null)
            {
                Recepti = new BindingList<Classes.Recept>();
            }
            DataContext = this;

            InitializeComponent();
        }

        private void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {
            WindowDodajRecept dodaj = new WindowDodajRecept();
            dodaj.ShowDialog();
        } 

        private void buttonIzadji_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
        private void buttonPrikazi_Click(object sender, RoutedEventArgs e)
        {
            Classes.Recept novi = Recepti.ElementAt(dataGridRecepti.SelectedIndex);

            WindowPrikazi prikaz = new WindowPrikazi(novi);
            prikaz.ShowDialog();
        }

        private void buttonIzmijeni_Click(object sender, RoutedEventArgs e)
        {
            Classes.Recept novi = Recepti.ElementAt(dataGridRecepti.SelectedIndex);

            WindowIzmijeni izm = new WindowIzmijeni(novi);
            izm.ShowDialog();
        } 

        private void buttonObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (Recepti.Count > 0)
            {
                Recepti.RemoveAt(dataGridRecepti.SelectedIndex);
            }
        }

        private void save(object sender, CancelEventArgs e)
        {
            serializer.SerializeObject<BindingList<Classes.Recept>>(Recepti, "recepti.xml");
        }

    }
}
