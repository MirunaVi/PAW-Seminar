using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semPAW_2
{
    class Animal: ICloneable, IComparable
    {
        private int varsta;
        private string nume;
        private float greutate;

        public Animal(int v, string n, float g)
        {
            varsta = v;
            nume = n;
            greutate = g;
        }

        public int Varsta
        {
            get { return varsta; }
            set { varsta = value; }
        }

        public string Nume
        {
            get { return nume; }
            set { nume = value; }
        }

        public float Greutate
        {
            get { return greutate; }
            set { greutate = value; }
        }

        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }

        public Animal Clone()
        {
            return (Animal)((ICloneable)this).Clone();
        }

        public int CompareTo(object obj)
        {
            Animal nou = (Animal)obj;
            if (this.greutate > nou.greutate) return 1;
            else if (this.greutate < nou.greutate) return -1;
            else return string.Compare(this.nume, nou.nume);
        }

        public override string ToString()
        {
            return "Animalul " + nume + " are varsta " + varsta + " si greutatea " + greutate;
        }
    }
}
