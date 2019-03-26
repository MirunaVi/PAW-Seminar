using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar6_1044
{
    class Credit
    {
        private int suma;
        private int perioada;
        private float dobanda;
        private float rata;

        public Credit()
        {

        }

        public int Suma
        {
            get { return suma; }
            set { suma = value; }
        }

        public int Perioada
        {
            get { return perioada; }
            set { perioada = value; }
        }

        public float Dobanda
        {
            get { return dobanda; }
            set { dobanda = value; }
        }

        public float Rata
        {
            get { return rata; }
            set { rata = value; }
        }

        public override string ToString()
        {
            return "Creditul in suma de " + suma + " pe perioada " + perioada + " cu dobanda " + dobanda + " are rata " + rata;
        }
    }
}
