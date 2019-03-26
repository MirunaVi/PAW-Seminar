using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semPAW_2
{
    class Zoo: ICloneable
    {
        private string denumire;
        private string adresa;
        private List<Animal> lista = new List<Animal>();

        public string Denumire
        {
            get { return denumire; }
            set { denumire = value; }
        }

        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; }
        }

        public List<Animal> Lista
        {
            get { return lista; }
            set { lista = value; }
        }

        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }

        public Zoo Clone()
        {
            Zoo nou = (Zoo)((ICloneable)this).Clone();
            List<Animal> copie = new List<Animal>();
            foreach (Animal a in lista)
                copie.Add(a.Clone());
            nou.lista = copie;
            return nou;
        }
    }
}
