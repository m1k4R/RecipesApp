using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Classes
{
    [Serializable]
    public class Recept
    {
        public static List<string> vrste = new List<string>() { "Kolač", "Torta", "Posni kolač", "Mafin", "Čajno pecivo" };

        private string naziv;
        private string opis;
        private string vrsta;
        private string sastojci;
        private string priprema;
        private int vrijeme;
        private string slika;

        
        public string Naziv
        {
            get
            {
                return naziv;
            }

            set
            {
                naziv = value;
            }
        }

        public string Vrsta
        {
            get
            {
                return vrsta;
            }

            set
            {
                vrsta = value;
            }
        }

        public string Sastojci
        {
            get
            {
                return sastojci;
            }

            set
            {
                sastojci = value;
            }
        }

        public string Priprema
        {
            get
            {
                return priprema;
            }

            set
            {
                priprema = value;
            }
        }

        public int Vrijeme
        {
            get
            {
                return vrijeme;
            }

            set
            {
                vrijeme = value;
            }
        }

        public string Slika
        {
            get
            {
                return slika;
            }

            set
            {
                slika = value;
            }
        }

        public string Opis
        {
            get
            {
                return opis;
            }

            set
            {
                opis = value;
            }
        }

        public Recept()
        {

        }

        public Recept(string naziv, string opis, string vrsta, string sastojci, string priprema, int vrijeme, string slika)
        {
            Naziv = naziv;
            Opis = opis;
            Vrsta = vrsta;
            Sastojci = sastojci;
            Priprema = priprema;
            Vrijeme = vrijeme;
            Slika = slika;
        }
    }
}
