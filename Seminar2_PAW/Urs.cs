using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semPAW_2
{
    class Urs: Animal
    {
        private bool hiberneaza;

        public bool Hiberneaza
        {
            get { return hiberneaza; }
            set { hiberneaza = value; }
        }

        public Urs(bool h, int v, string n, float g)
            : base(v, n, g)
        {
            hiberneaza = h;
        }

        public override string ToString()
        {
            return base.ToString() + " si hiberneaza " + hiberneaza;
        }
    }
}
