using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ClientRauPlatnic : Client, IComparable, ICloneable, IMedia
    {

        public string tipClient;
        public double sumaPlata;
        public int[] vectorPlatiLunare;

        public string TipClient
        {
            get { return tipClient; }
            set { if (value == "PF" || value == "PJ") tipClient = value; }
        }

        public int[] VectorPlatiLunare
        {
            get { return vectorPlatiLunare; }
            set { if (value != null) vectorPlatiLunare = value; }
        }

        public double SumaPlata
        {
            get { return sumaPlata; }
            set { sumaPlata = value; }
        }

        public ClientRauPlatnic(int c, string n, string a, string tip, double s, int[] vector) : base(c, n, a)
        {
            tipClient = tip;
            sumaPlata = s;
            vectorPlatiLunare = new int[vector.Length];
            for (int i = 0; i < vector.Length; i++) 
            vectorPlatiLunare[i] = vector[i];
        }

        public object Clone()
        {
            return (ClientRauPlatnic)((ICloneable)this).Clone();
        }

        object ICloneable()
        {
            return MemberwiseClone();
        }

        public int CompareTo(object obj)
        {
            ClientRauPlatnic cl = (ClientRauPlatnic)obj;
            if (sumaPlata > cl.sumaPlata)
            {
                if (tipClient == "PF")
                {
                    return 1;
                }
                else return 0;
            }

            else if (sumaPlata < cl.sumaPlata)
            {
                if (tipClient == "PF")
                {
                    return -1;
                }
                else return 0;
            }

            else if (sumaPlata > cl.sumaPlata)
            {
                if (tipClient == "PJ")
                {
                    return 1;
                }
                else return 0;
            }

            else if (sumaPlata < cl.sumaPlata)
            {
                if (tipClient == "PJ")
                {
                    return -1;
                }
                else return 0;
            }

            else return 0;

        }

        public override string ToString()
        {
            
            string rezultat = "Banca are codul " + cod + ", numele acesteia este " + nume + " iar adresa la care se aflate este " + adresa + ", tipul clientului este " + tipClient + ", suma de plata este " + sumaPlata + ", iar platile pe luni sunt: ";
            for (int i = 0; i < vectorPlatiLunare.Length; i++)
            {
                rezultat += vectorPlatiLunare[i] + " ";
            }
            return rezultat;
        }

        public double CalculeazaValoareaMediaPlatita()
        {
            return (double)this;
        }

        public static explicit operator double(ClientRauPlatnic cl)
        {
            double s = 0;
            for (int i = 0; i < cl.vectorPlatiLunare.Length; i++)
            {
                s += cl.vectorPlatiLunare[i];
            }
            return s / cl.vectorPlatiLunare.Length;
        }

        public static ClientRauPlatnic operator+(ClientRauPlatnic cl)
        {
            int[] aux = new int[cl.vectorPlatiLunare.Length + 1];
            for (int i = 0; i < aux.Length; i++)
            {
                aux[i] = cl.vectorPlatiLunare[i];
            }
            cl.vectorPlatiLunare = aux;
            return cl;
        }


    }
}
