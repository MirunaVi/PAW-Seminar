using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar5_1044
{
    class Produs
    {
        private string denumire;
        private int pret;
        private int cantitate;

        public Produs(string d, int p, int c )
        {
            denumire = d;
            pret = p;
            cantitate = c;
        }

        public override string ToString()
        {
            return "Produsul " + denumire + " are pretul " + pret + " si cantitatea " + cantitate;
        }
    }
}
