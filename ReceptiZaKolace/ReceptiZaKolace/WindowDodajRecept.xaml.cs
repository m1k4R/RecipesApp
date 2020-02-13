using Microsoft.Win32;
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
    /// Interaction logic for DodajRecept.xaml
    /// </summary>
    public partial class WindowDodajRecept : Window
    {
        public WindowDodajRecept()
        {
            InitializeComponent();
            comboBoxVrsta.ItemsSource = Classes.Recept.vrste;
        }

        private void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (validate())
            {
                MainWindow.Recepti.Add(new Classes.Recept(textBoxNaziv.Text, textBoxOpis.Text, comboBoxVrsta.SelectedValue.ToString(), textBoxSastojci.Text, textBoxPriprema.Text, Int32.Parse(textBoxVrijeme.Text), image.Source.ToString()));
                this.Close();
            }
           /* else
            {
                MessageBox.Show("Polja nisu ispravno popunjena!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            } */
        }

        private void buttonIzadji_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonSlika_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (.jpg;.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (.png)|.png";

            if (dlg.ShowDialog() == true)
            {
                image.Source = new BitmapImage(new Uri(dlg.FileName));
            }
        }


        private bool validate()
        {
            bool result = true;

            if (textBoxNaziv.Text.Trim().Equals(""))
            {
                result = false;
                labelGreskaNaziv.Content = "Popunite polje!";
                textBoxNaziv.BorderBrush = Brushes.Red;
            }
            else
            {
                labelGreskaNaziv.Content = "";
                textBoxNaziv.BorderBrush = Brushes.Transparent;
            }

            if (textBoxOpis.Text.Trim().Equals(""))
            {
                result = false;
                labelGreskaOpis.Content = "Popunite polje!";
                textBoxOpis.BorderBrush = Brushes.Red;
            }
            else
            {
                labelGreskaOpis.Content = "";
                textBoxOpis.BorderBrush = Brushes.Transparent;
            }

            if (comboBoxVrsta.SelectedItem == null)
            {
                result = false;
                labelGreskaVrsta.Content = "Izaberite vrstu!";
                comboBoxVrsta.BorderBrush = Brushes.Red;
                comboBoxVrsta.BorderThickness = new Thickness(3);
            }
            else
            {
                labelGreskaVrsta.Content = "";
                comboBoxVrsta.BorderBrush = Brushes.Gray;
            }

            if (textBoxSastojci.Text.Trim().Equals(""))
            {
                result = false;
                labelGreskaSastojci.Content = "Popunite polje!";
                textBoxSastojci.BorderBrush = Brushes.Red;
            }
            else
            {
                labelGreskaSastojci.Content = "";
                textBoxSastojci.BorderBrush = Brushes.Transparent;
            }

            if(textBoxPriprema.Text.Trim().Equals(""))
            {
                result = false;
                labelGreskaPriprema.Content = "Popunite polje!";
                textBoxPriprema.BorderBrush = Brushes.Red;
            }
            else
            {
                labelGreskaPriprema.Content = "";
                textBoxPriprema.BorderBrush = Brushes.Transparent;
            }

            if (textBoxVrijeme.Text.Trim().Equals(""))
            {
                result = false;
                labelGreskaVrijeme.Content = "Popunite polje!";
                textBoxVrijeme.BorderBrush = Brushes.Red;
            }
            else
            {
                labelGreskaVrijeme.Content = "";
                textBoxVrijeme.BorderBrush = Brushes.Gray;
                textBoxVrijeme.BorderThickness = new Thickness();

                try
                {
                    Int32.Parse(textBoxVrijeme.Text.Trim());

                    if (Int32.Parse(textBoxVrijeme.Text.Trim()) == 0)
                    {
                        result = false;
                        textBoxVrijeme.BorderBrush = Brushes.Red;
                        textBoxVrijeme.BorderThickness = new Thickness(2);
                        MessageBox.Show("Vrijeme potrebno za pripremu ne moze biti 0 min!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (Int32.Parse(textBoxVrijeme.Text.Trim()) < 0)
                    {
                        result = false;
                        textBoxVrijeme.BorderBrush = Brushes.Red;
                        textBoxVrijeme.BorderThickness = new Thickness(2);
                        MessageBox.Show("Vrijeme potrebno za pripremu ne moze biti negativan broj minuta!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (Int32.Parse(textBoxVrijeme.Text.Trim()) > 360)
                    {
                        result = false;
                        textBoxVrijeme.BorderBrush = Brushes.Red;
                        textBoxVrijeme.BorderThickness = new Thickness(2);
                        MessageBox.Show("Vrijeme potrebno za pripremu ne moze biti vece od 360 min!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception exc)
                {
                    textBoxVrijeme.BorderBrush = Brushes.Red;
                    textBoxVrijeme.BorderThickness = new Thickness(2);
                    MessageBox.Show("Vrijeme potrebno za pripremu nije validno!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                    Console.WriteLine(exc.Message);
                    result = false;
                }
            }

            if (image.Source == null)
            {
                result = false;
                labelGreskaSlika.Content = "Dodajte sliku!";
                buttonSlika.BorderBrush = Brushes.Red;             
            }
            else
            {
                labelGreskaSlika.Content = "";
                buttonSlika.BorderBrush = Brushes.Gray;
            } 

            foreach (Classes.Recept r in MainWindow.Recepti)
            {
                if (textBoxNaziv.Text.Trim().ToUpper() == r.Naziv.Trim().ToUpper() & textBoxOpis.Text.Trim().ToUpper() == r.Opis.Trim().ToUpper())
                {
                    result = false;
                    textBoxNaziv.BorderBrush = Brushes.Red;
                    textBoxOpis.BorderBrush = Brushes.Red;
                    MessageBox.Show("Ovaj recept već postoji!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if(textBoxNaziv.Text.Trim().ToUpper() == r.Naziv.Trim().ToUpper() & textBoxSastojci.Text.Trim().ToUpper() == r.Sastojci.Trim().ToUpper() & textBoxPriprema.Text.Trim().ToUpper() == r.Priprema.Trim().ToUpper())
                {
                    result = false;
                    textBoxNaziv.BorderBrush = Brushes.Red;
                    textBoxSastojci.BorderBrush = Brushes.Red;
                    textBoxPriprema.BorderBrush = Brushes.Red;
                    MessageBox.Show("Ovaj recept već postoji!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }


            return result;
        }

        
    }
}
