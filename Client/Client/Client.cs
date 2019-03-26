using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public abstract class Client
    {
        public readonly int cod;
        public string nume;
        public string adresa;

        public Client(int c, string n, string a)
        {
            cod = c;
            nume = n;
            adresa = a;
        }

        public int Cod
        {
            get { return cod; }
        }

        public string Nume
        {
            get { return nume; }
            set { if (value != null) nume = value; }
        }

        public string Adresa
        {
            get { return adresa; }
            set { if (value != null) adresa = value; }
        }
    }
}
