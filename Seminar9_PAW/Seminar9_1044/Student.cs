using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar9_1044
{
    class Student
    {     
            private string nume;

            public string Nume
            {
                get { return nume; }
                set { nume = value; }
            }

            public Student(string n)
            {
                nume = n;
            }
    }
}
