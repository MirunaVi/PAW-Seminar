using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produs
{
    public class ProdusAlimentar : Produs, ICloneable, IComparable, IMedia
    {
        string producator;
        string dataExpirare;
        float[] vectorPreturiPeLuni;

        public string Producator
        {
            get { return producator; }
            set { producator = value; }
        }

        public string DataExpirare
        {
            get { return dataExpirare; }
            set { dataExpirare = value; }
        }

        public float[] VectorPreturiPeLuni
        {
            get { return vectorPreturiPeLuni; }
            set {
                vectorPreturiPeLuni = new float[value.Length];
                    for (int i = 0; i < value.Length; i++)
                {
                    vectorPreturiPeLuni[i] = value[i];
                }
                    }
        }

        public ProdusAlimentar(int c, string d, int ca, string p, string data, float[] vector) : base(c,d,ca)
        {
            producator = p;
            dataExpirare = data;
            VectorPreturiPeLuni = new float[vector.Length];
            for (int i = 0; i < vector.Length; i++)
            {
                vectorPreturiPeLuni[i] = vector[i];
            }
        }

        public object Clone()
        {
            return (ProdusAlimentar)((ICloneable)this).Clone();
        }

        object ICloneable.Clone()
        {
            return MemberwiseClone();
        }

        public int CompareTo(object obj)
        {
            ProdusAlimentar pNou = (ProdusAlimentar)obj;
            if (producator.Equals(pNou.producator)) return 1;
            else return 0;
        }

        public static ProdusAlimentar operator+(ProdusAlimentar pa, float m)
        {
            ProdusAlimentar copie = (ProdusAlimentar)pa.Clone();
            if (copie.vectorPreturiPeLuni != null)
            {
                float[] vector = new float[copie.vectorPreturiPeLuni.Length + 1];
                copie.vectorPreturiPeLuni.CopyTo(vector, 0);
                vector[vector.Length + 1] = m;
                copie.vectorPreturiPeLuni = vector;
            }
            else
            {
                copie.vectorPreturiPeLuni = new float[1];
                copie.vectorPreturiPeLuni[0] = m;
            }

            return copie;
        }


        public static ProdusAlimentar operator-(ProdusAlimentar pa, float m)
        {
            ProdusAlimentar copie = (ProdusAlimentar)pa.Clone();
            if (copie.vectorPreturiPeLuni != null)
            {
                float[] vector = new float[copie.vectorPreturiPeLuni.Length - 1];
                copie.vectorPreturiPeLuni.CopyTo(vector, 0);
                vector[vector.Length - 1] = m;
                copie.vectorPreturiPeLuni = vector;
            } else
            {
                copie.vectorPreturiPeLuni = new float[1];
                copie.vectorPreturiPeLuni[0] = m;
            }

            return copie;
        }

        public override string ToString()
        {
            string rezultat = null;
            rezultat = "Produsul are codul " + Cod + ", denumirea este " + Denumire + ", cu o cantitate de " + Cantitate + ". Producatorul este " + Producator + ", expira la data de " + DataExpirare + " iar preturile pe luni ale acestuia sunt: ";
            for (int i = 0; i < VectorPreturiPeLuni.Length; i++)
            {
                rezultat += VectorPreturiPeLuni[i];
            }
            return rezultat;
        }

        public float CalculeazaPretMediu()
        {
            float mediu = 0;
            for (int i = 0; i <vectorPreturiPeLuni.Length; i++)
            {
                mediu += vectorPreturiPeLuni[i];
            }
            return mediu / vectorPreturiPeLuni.Length;
        }


    }
}
