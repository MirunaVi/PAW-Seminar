using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banca
{
    public class BancaComerciala : Banca, ICloneable, IComparable, IMedia
    {
        public double capitalSocial;
        public int nrAgentii;
        int[] vectorNrClientiNoiPeLuni;

        public double CapitalSocial
        {
            get { return capitalSocial; }
            set { if (value != null) capitalSocial = value; }
        }

        public int NrAgentii
        {
            get { return nrAgentii; }
            set { if (value != null) nrAgentii = value; }
        }

        public int[] VectorNrClientiNoiPeLuni
        {
            get { return vectorNrClientiNoiPeLuni; }
            set
            {
                vectorNrClientiNoiPeLuni = new int[value.Length];
                for (int i = 0; i < value.Length; i++)
                {
                    vectorNrClientiNoiPeLuni[i] = value[i];
                }
            }
        }

        public BancaComerciala(int c., string d, string a, double cs, int na, int[] vector) : base(c,d,a)
        {
            capitalSocial = cs;
            nrAgentii = na;
            vectorNrClientiNoiPeLuni = new int[vector.Length];
            for (int i = 0; i < vector.Length; i++)
            {
                vectorNrClientiNoiPeLuni[i] = vector[i];
            }
        }

        public object Clone()
        {
            return (BancaComerciala)((ICloneable)this).Clone();
        }

        public int CompareTo(object obj)
        {
            BancaComerciala bc = (BancaComerciala)obj;
            if (capitalSocial < bc.capitalSocial)
            {
                return -1;
            }
            else if (capitalSocial > bc.capitalSocial)
            {
                return 1;
            }
            else return 0;
        }

        public static BancaComerciala operator-(BancaComerciala bc)
        {
            int[] aux = new int[bc.vectorNrClientiNoiPeLuni.Length - 1];
            for (int i = 0; i < aux.Length; i++)
            {
                aux[i] = bc.vectorNrClientiNoiPeLuni[i];
            }
            bc.VectorNrClientiNoiPeLuni = aux;
            return bc;
        }

        public static explicit operator double(BancaComerciala bc)
        {
            double medie = 0;
            for (int i = 0; i < bc.vectorNrClientiNoiPeLuni.Length; i++)
            {
                medie += bc.vectorNrClientiNoiPeLuni[i];
            }

            return medie / bc.vectorNrClientiNoiPeLuni.Length;
        }

        public override string ToString()
        {
            string rezultat = null;
            rezultat = "Banca " + denumire + " cu codul " + cod + " este situata pe " + adresa + ". Aceasta are capitalul social in valoare de "
                + capitalSocial + " si " + nrAgentii + " nr agenti. In ultimele " + vectorNrClientiNoiPeLuni.Length + " luni au clienti noi: ";
            for (int i = 0; i < vectorNrClientiNoiPeLuni.Length; i++)
                rezultat += vectorNrClientiNoiPeLuni[i].ToString() + ' ';
            return rezultat;
        }

        public double CalculeazaNrMediuClient()
        {
            return (double)this;
        }
    }
}
