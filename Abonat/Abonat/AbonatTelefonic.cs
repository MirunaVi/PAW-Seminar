using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abonat
{
    public class AbonatTelefonic : Persoana, IComparable, ICloneable, IMedia
    {

        public long nrTelefon;
        public string tipAbonat;
        public double[] vectorMinuteVorbite;

        public AbonatTelefonic(long c, string n, string a, long tel, string tip, double[] vector) : base(c,n,a)
        {
            this.nrTelefon = tel;
            this.tipAbonat = tip;
            this.vectorMinuteVorbite = vector;
        }

        public long NrTelefon
        {
            get { return nrTelefon; }
            set { nrTelefon = value; }
        }

        public string TipAbonat
        {
            get { return tipAbonat; }
            set { if (value != null) tipAbonat = value; }
        }

        public double[] VectorMinuteVorbite
        {
            get { return vectorMinuteVorbite; }
            set { vectorMinuteVorbite = value; }
        }

        public object Clone()
        {
            return (AbonatTelefonic)((ICloneable)this).Clone();
        }

        object ICloneable()
        {
            return MemberwiseClone();
        }

        public int CompareTo(object obj)
        {
            AbonatTelefonic at = (AbonatTelefonic)obj;
            if (nrTelefon > at.nrTelefon)
            {
                return 1;
            }
            else if (nrTelefon < at.nrTelefon)
            {
                return -1;
            }
            else
            {
                return 0;
            }

        }

        public override string ToString()
        {
            string rezultat = "";
            rezultat = "Persoana cu numele " + nume + ", cu CNP-ul " + cnp + ", cu adresa " + adresa + ", cu numarul de telefon " + nrTelefon + ", abonatul este de tip " + tipAbonat + " si are un numarul de minute vorbite in functie de luni: ";
            for (int i = 0; i < vectorMinuteVorbite.Length; i++)
            {
                rezultat += vectorMinuteVorbite[i] + " ";
            }

            return rezultat;
        }

        public double CalculeazaMedie()
        {
            return (double)this;
        }

        public static explicit operator double(AbonatTelefonic at)
        {
            double suma = 0;
            for (int i = 0; i < at.vectorMinuteVorbite.Length; i++)
            {
                suma += at.vectorMinuteVorbite[i];
            }
            return suma / at.vectorMinuteVorbite.Length;
        }

        public static AbonatTelefonic operator+(AbonatTelefonic at, double m)
        {
            double[] aux = new double[at.vectorMinuteVorbite.Length + 1];
            for (int i = 0; i < aux.Length; i++)
            {
                aux[i] = at.vectorMinuteVorbite[i];
            }
            aux[at.vectorMinuteVorbite.Length] = m;
            at.vectorMinuteVorbite = aux;

            return at;
        }
    }
}
