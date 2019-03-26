using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semPAW_2
{
    class Pinguin: Animal
    {
        private bool areIgloo;

        public bool AreIgloo
        {
            get { return areIgloo; }
            set { areIgloo = value; }
        }

        public Pinguin(bool a, int v, string n, float g)
            : base(v, n, g)
        {
            areIgloo = a;
        }

        public override string ToString()
        {
            return base.ToString() + " si are igloo " + areIgloo;
        }
    }
}
