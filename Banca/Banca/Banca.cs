using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banca
{
    public abstract class Banca
    {

        public readonly int cod;
        public string denumire;
        public string adresa;

        public Banca(int c, string d, string a)
        {
            cod = c;
            denumire = d;
            adresa = a;
        }

        public int Cod
        {
            get { return cod; }
        }

        public string Denumire
        {
            get { return denumire; }
            set { if (value != null) denumire = value; }
        }

        public string Adresa
        {
            get { return adresa; }
            set { if (value != null) adresa = value; }
        }

    }
}
