using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW_Seminar3
{   
    class Student: ICloneable, IComparable
    {

        private string nume;
        private int varsta;
        private int[] note;

        public Student(string n, int v, int[] vn)
        {
            nume = n;
            varsta = v;
            note = new int[vn.Length];
            for(int i=0;i<vn.Length;i++)
            {
                note[i] = vn[i];
            }
        }

        public int[] Note
        {
            get { return note; }
            set
            {
                if (note != null)
                    note = value;
            }
        }

        public override string ToString()
        {
            string result = null;
            result += "Studentul " + nume + " are varsta " + varsta + " si notele: ";
            for (int i = 0; i < note.Length; i++)
            {
                result += note[i] + " ";
            }

            return result;
        }

        //Trebuie sa ramana in forma asta; nu putem pune tipul student si trebuie deci apelata cu cast
        public object Clone()
        {
            Student s = (Student)this.MemberwiseClone();
            int[] noteCopie = (int[])note.Clone();
            s.note = noteCopie;

            return s;
        }

        public int CompareTo(object obj)
        {
            Student s = (Student)obj;
            if (this.varsta < s.varsta)
                return -1;
            else if (this.varsta > s.varsta)
                return 1;
            else
                return string.Compare(this.nume, s.nume);
        }

        public static Student operator+(Student s, int n)
        {
            int[] noteNoi = new int[s.note.Length + 1];
            for (int i = 0; i < noteNoi.Length; i++)
                noteNoi[i] = s.note[i];
            noteNoi[noteNoi.Length - 1] = n;
            s.note = noteNoi;

            return s;
        }

        public static Student operator++(Student s)
        {
            s += 1;

            return s;
        }

        public static explicit operator float(Student s)
        {
            int suma = 0;
            for(int i=0;i<s.note.Length;i++)
            {
                suma += s.note[i];
            }

            return (float)suma / s.note.Length;
        }

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index <= this.note.Length)
                    return this.note[index];
                else
                    return -1;
            }


        }
    }
}
