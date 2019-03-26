using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produs
{
    public abstract class Produs
    {
        readonly int cod;
        string denumire;
        int cantitate;

        public Produs(int c, string d, int ca)
        {
            cod = c;
            denumire = d;
            cantitate = ca;
        }

        public int Cod
        {
            get { return cod; }
        }

        public string Denumire
        {
            get { return denumire; }
            set { denumire = value; }
        }

        public int Cantitate
        {
            get { return cantitate; }
            set
            {
                if (value >= 0)
                {
                    cantitate = value;
                }
            }
        }
        }
}
