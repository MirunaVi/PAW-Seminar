using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semPAW_1_clase
{
    class Student
    {
        private int cod;
        private string nume;

        public Student()
        {
            cod = 0;
            nume = "Gigel";
        }

        public Student(int c, string n)
        {
            cod = c;
            nume = n;
        }

        public Student(Student s)
        {
            cod = s.cod;
            nume = s.nume;
        }

        public int Cod
        {
            get { return cod; }
            set { cod = value; }
        }

        public string Nume
        {
            get { return nume; }
            set { nume = value; }
        }

        public void afisare()
        {
            Console.WriteLine("Studentul are codul {0} si numele {1}", this.cod, this.nume);
        }

        public override string ToString()
        {
            return "Studentul are codul " + this.cod + " si numele " + this.nume;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();
            Student s2 = new Student(123, "Ionel");
            Student s3 = new Student(s2);
            Student s4 = s2;
            s1.afisare();
            s2.afisare();
           
            s2.Nume = "Georgel";
            s3.afisare();
            s4.afisare();

            ArrayList lista = new ArrayList();
            lista.Add(s1);
            lista.Add(s2);
            lista.Add(s3);
            lista.Add(s4);

            foreach (Student s in lista)
                s.afisare();

            for (int i = 0; i < lista.Count; i++)
                ((Student)lista[i]).afisare();

            foreach (Student s in lista)
                Console.WriteLine(s.ToString());
        }
    }
}
