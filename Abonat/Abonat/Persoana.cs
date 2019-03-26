using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abonat
{
    public abstract class Persoana
    {
        public readonly long cnp;
        public string nume;
        public string adresa;

        public Persoana(long c, string n, string a)
        {
            this.cnp = c;
            this.nume = n;
            this.adresa = a;
        }

        public long Cnp
        {
            get { return cnp; }
        }

        public string Nume
        {
            get { return nume; }
            set { if (value != null) nume = value; }
        }

        public string Adresa
        {
            get { return nume; }
            set { if (value != null) adresa = value; }
        }
    }
}
